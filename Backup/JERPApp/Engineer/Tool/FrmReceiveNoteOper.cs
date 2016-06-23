using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Engineer.Tool
{
    public partial class FrmReceiveNoteOper : Form
    {
        public FrmReceiveNoteOper()
        {
            InitializeComponent();
            this.accNotes = new JERPData.Tool .BuyReceiveNotes();
            this.accItems = new JERPData.Tool.BuyReceiveItems();
            this.accOrderNotes = new JERPData.Tool.BuyOrderNotes();
            this.accOrderItems = new JERPData.Tool.BuyOrderItems();
            this.printhelper = new JERPBiz.Tool.BuyReceiveNotePrintHelper();
            this.OrderNoteEntity = new JERPBiz.Tool.BuyOrderNoteEntity();
            this.MoneyTypeParm = new JERPBiz.Finance.MoneyTypeParm(); 
            this.dgrdvItem.AutoGenerateColumns = false;
            this.dgrdvItem.CellMouseClick += new DataGridViewCellMouseEventHandler(dgrdvItem_CellMouseClick);
            this.dgrdvItem.DataBindingComplete += new DataGridViewBindingCompleteEventHandler(dgrdvItem_DataBindingComplete);
            this.dgrdvItem.CellValueChanged += new DataGridViewCellEventHandler(dgrdvItem_CellValueChanged);      
            this.btnSave .Click +=new EventHandler(btnSave_Click);
        }
        private JERPBiz.Tool.BuyReceiveNotePrintHelper printhelper;
        private JERPData.Tool.BuyReceiveNotes accNotes;
        private JERPData.Tool.BuyReceiveItems accItems;
        private JERPData.Tool.BuyOrderItems accOrderItems;
        private JERPData.Tool.BuyOrderNotes accOrderNotes;
        private JERPBiz.Tool.BuyOrderNoteEntity OrderNoteEntity;
        private JERPBiz.Finance.MoneyTypeParm MoneyTypeParm; 
        private DataTable dtblItems;
        private long BuyOrderNoteID = -1;
        public void NewNote(long BuyOrderNoteID)
        {
            this.BuyOrderNoteID = BuyOrderNoteID;
            this.txtNoteCode.Text = string.Empty;
            this.rchMemo.Text = string.Empty;
            this.OrderNoteEntity.LoadData(BuyOrderNoteID);
            this.txtCompanyAbbName.Text = this.OrderNoteEntity.CompanyAbbName;
            this.txtPONo.Text = this.OrderNoteEntity.NoteCode;
            
            this.dtblItems = this.accOrderItems.GetDataBuyOrderItemsForReceive(BuyOrderNoteID).Tables[0];
            this.dtblItems.Columns.Add("ReceiveQty", typeof(decimal));
            this.dtblItems.Columns.Add("PriceQty", typeof(decimal));
            foreach (DataRow drow in this.dtblItems.Rows)
            {
                drow["ReceiveQty"] = drow["NonFinishedQty"];
                if (drow["UnitName"].ToString() == drow["PriceUnitName"].ToString())
                {
                    drow["PriceQty"] = drow["ReceiveQty"];
                }
            }
            this.dgrdvItem.DataSource = this.dtblItems;

        }
    
        public delegate void AffterSaveDelegate();
        private AffterSaveDelegate affterSave;
        public event AffterSaveDelegate AffterSave
        {
            add
            {
                affterSave += value;
            }
            remove
            {
                affterSave -= value;
            }
        }

        void dgrdvItem_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow grow in this.dgrdvItem.Rows)
            {
                if (grow.Cells[this.ColumnUnitName.Name].Value.ToString() == grow.Cells[this.ColumnPriceUnitName.Name].Value.ToString())
                {
                    grow.Cells[this.ColumnPriceQty.Name].ReadOnly = true;
                }
                grow.ErrorText = string.Empty;
                if (grow.Cells[this.ColumnReceiveQty.Name].Value != DBNull.Value)
                {
                    
                    if (grow.Cells[this.ColumnPriceQty.Name].Value == DBNull.Value)
                    {
                        grow.ErrorText = "未设计价数量";
                        continue;
                    }
                }
            }
        }
        void dgrdvItem_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if (this.dgrdvItem.Columns[icol].DataPropertyName == "ReceiveQty")
            {
                if (e.Button == MouseButtons.Left)
                {
                    if (this.dgrdvItem[icol, irow].Value == DBNull.Value)
                    {
                        this.dgrdvItem[icol, irow].Value = this.dgrdvItem[this.ColumnNonFinishedQty .Name, irow].Value;
                    }
                }
                if (e.Button == MouseButtons.Right)
                {
                    this.dgrdvItem[icol, irow].Value = DBNull.Value;

                }
            }
        }
        void dgrdvItem_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if (this.dgrdvItem.Columns[icol].DataPropertyName == "ReceiveQty")
            {
                object objReceiveQty = this.dgrdvItem[icol, irow].Value;
                if ((this.dgrdvItem[this.ColumnPriceQty.Name, irow].ReadOnly)
                    || (objReceiveQty == DBNull.Value) || ((decimal)objReceiveQty == 0))
                {
                    this.dgrdvItem[this.ColumnPriceQty.Name, irow].Value = objReceiveQty;
                }
            }
            if (this.dgrdvItem.Columns[icol].DataPropertyName == "PriceQty")
            {
                object objPriceQty = this.dgrdvItem[icol, irow].Value;
                object objReceiveQty = this.dgrdvItem[this.ColumnReceiveQty.Name, irow].Value;
                if ((objPriceQty != DBNull.Value) && ((decimal)objPriceQty > 0))
                {
                    if ((objReceiveQty == DBNull.Value) || ((decimal)objReceiveQty == 0))
                    {
                        this.dgrdvItem[icol, irow].Value = objReceiveQty;
                    }
                }
            }
        }
        private  bool ValidateData()
        {
            if (this.txtNoteCode.Text == string.Empty)
            {
                MessageBox.Show("对不起,送货单号不能为空!");
                return false;
            }
            if (this.dtblItems.Select("ReceiveQty is not  null and PriceQty is not null").Length == 0)
            {
                MessageBox.Show("对不起,没有任何明细项");
                return false ;
            }           
            if (this.dtblItems.Select("(ReceiveQty is not null and PriceQty is  null)").Length > 0)
            {
                MessageBox.Show("存在未设计价数量明细");
                return false;
            }
            if (this.dtblItems.Select("(ReceiveQty is  null and PriceQty is  not null)").Length > 0)
            {
                MessageBox.Show("存在未设数量明细");
                return false;
            }
            return true;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateData() == false) return;
            DialogResult rul = MessageBox.Show("将进行保存入账一经确认不能变更！", "审核确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rul == DialogResult.No) return;
            bool flag = false;
            string errormsg = string.Empty;
            long NoteID = -1;
            object objNoteID = DBNull.Value;
            decimal TotalAMT = 0;
            int CompanyID = this.OrderNoteEntity.CompanyID;
            int MoneyTypeID = this.OrderNoteEntity.MoneyTypeID;
            int SettleTypeID = this.OrderNoteEntity.SettleTypeID;
            int PriceTypeID = this.OrderNoteEntity.PriceTypeID;
            int InvoiceTypeID = this.OrderNoteEntity.InvoiceTypeID;
            decimal ExchangeRate = this.MoneyTypeParm.GetExchangeRate(MoneyTypeID);
          
            foreach (DataRow drow in this.dtblItems.Select("Price is not null"))
            {
                TotalAMT += (decimal)drow["PriceQty"] * (decimal)drow["Price"];
            }   
            flag = this.accNotes.InsertBuyReceiveNotes (
               ref errormsg,
               ref objNoteID ,
               this.txtNoteCode.Text,
               this.tpkDateNote .Value .Date ,
               this.BuyOrderNoteID ,
               CompanyID ,
               MoneyTypeID ,
               SettleTypeID ,
               PriceTypeID,
               InvoiceTypeID ,
               this.ctrlQCPsnID .PsnID ,
               TotalAMT ,
               JERPBiz.Frame.UserBiz.PsnID,
               this.rchMemo.Text);
            if (!flag)
            {
                MessageBox.Show(errormsg,"操作提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            NoteID = (long)objNoteID;
         
            //明细
            object objItemID=DBNull .Value ;
            decimal Quantity, Price, PriceQty;
            foreach (DataRow drow in this.dtblItems.Rows)
            {
                if (drow["ReceiveQty"] == DBNull.Value) continue;    
                if (drow["PriceQty"]==DBNull .Value) continue;                   
                Quantity = (decimal)drow["ReceiveQty"];
                Price = (decimal)drow["Price"];
                PriceQty = (decimal)drow["PriceQty"];             
                this.accItems.InsertBuyReceiveItems(ref errormsg, ref objItemID,
                    NoteID,
                    drow["ItemID"],
                    Quantity ,
                    PriceQty);
                //增加完成数
                this.accOrderItems.UpdateBuyOrderItemsForAppFinishedQty(ref errormsg, drow["ItemID"], Quantity );
                
                
            }
            this.accOrderNotes.UpdateBuyOrderNotesForDeliverAMT(
               ref errormsg,
               this.BuyOrderNoteID);
            rul = MessageBox.Show("成功进行采购收货,需要输出打印吗?", "打印确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rul == DialogResult.Yes)
            {
                this.printhelper.ExportToExcel(NoteID);
                this.accNotes.UpdateBuyReceiveNotesForPrint(ref errormsg, NoteID, JERPBiz.Frame.UserBiz.PsnID);
            }
            if (this.affterSave != null) this.affterSave();
            this.Close(); 
        }

   
      
    }
}