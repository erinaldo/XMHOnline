using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Store.Material
{
    public partial class FrmOutSrcSupplyNoteOper : Form
    {
        public FrmOutSrcSupplyNoteOper()
        {
            InitializeComponent(); 
            this.dgrdvOrder.AutoGenerateColumns = false;
            this.accOrderItems = new JERPData.Manufacture.OutSrcOrderItems();
            this.accNotes = new JERPData.Material.OutSrcSupplyNotes();
            this.NoteEntity = new JERPBiz.Material.OutSrcSupplyNoteEntity();
            this.accSupplyPlans = new JERPData.Material.OutSrcSupplyPlans();
            this.printhelper = new JERPBiz.Material.OutSrcSupplyNotePrintHelper();
            this.tabMain.Padding = new Point(0);
            foreach (DataGridViewColumn col in this.dgrdvOrder.Columns)
            {
                col.ReadOnly = true;
            }
            this.ColumnManufQty.ReadOnly = false;
            this.btnAdd .Click +=new EventHandler(btnAdd_Click);
            this.btnCancel .Click +=new EventHandler(btnCancel_Click);
            this.btnSave .Click +=new EventHandler(btnSave_Click);
            this.btnExport.Click += new EventHandler(btnExport_Click);
            this.dgrdvOrder .CellMouseClick +=new DataGridViewCellMouseEventHandler(dgrdvOrder_CellMouseClick);
            this.dgrdvOrder .DataBindingComplete +=new DataGridViewBindingCompleteEventHandler(dgrdvOrder_DataBindingComplete);
            this.btnDelete.Click += new EventHandler(btnDelete_Click);
        }

        private JERPData.Manufacture .OutSrcOrderItems  accOrderItems;
        private JERPData.Material.OutSrcSupplyNotes accNotes;
        private JERPBiz.Material.OutSrcSupplyNoteEntity NoteEntity;
        private JERPData.Material.OutSrcSupplyPlans accSupplyPlans;        
        private JERPBiz.Material.OutSrcSupplyNotePrintHelper printhelper;
        private int CompanyID = -1;
        private long noteid = -1;
        private long NoteID
        {
            get
            {
                return this.noteid;
            }
            set
            {
                this.noteid = value;
                this.btnDelete.Enabled = (value > -1);
            }
        }
        private DataTable  dtblOrderItems;  
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
          
     

        void dgrdvOrder_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow grow in this.dgrdvOrder.Rows)
            {
                grow.ErrorText = string.Empty;
                object objManufQty = grow.Cells[this.ColumnManufQty.Name].Value;
                if (objManufQty == DBNull.Value) continue;
                decimal BOMNonFinishedQty =(decimal)grow.Cells[this.ColumnBOMNonFinishedQty.Name].Value;
                if ((decimal)objManufQty > BOMNonFinishedQty)
                {
                    grow.ErrorText = "算料数不能大于未算料数";
                }
            }
        }
        void dgrdvOrder_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
             
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if((irow==-1)||(icol==-1))return;
            if(this.dgrdvOrder .Columns [icol].Name ==this.ColumnManufQty .Name )
            {
                if (this.ColumnManufQty.ReadOnly == false)
                {
                    if (e.Button == MouseButtons.Left)
                    {
                        this.dgrdvOrder[icol, irow].Value = this.dgrdvOrder[this.ColumnBOMNonFinishedQty.Name, irow].Value;
                    }
                    else
                    {
                        this.dgrdvOrder[icol, irow].Value = DBNull.Value;
                    }
                }
            }
        }
        public void New(int CompanyID,string CompanyAbbName)
        {
            this.NoteID = -1;
            this.CompanyID = CompanyID;
            this.txtNoteCode.Text = string.Empty;
            this.txtCompanyAbbName.Text = CompanyAbbName;
            this.ctrlSupplierAddress.LoadData(CompanyID);
            this.SetComputeControl(true);
            this.LoadItems();
        }
        public void Edit(long NoteID)
        {
            this.NoteID = NoteID;
            this.NoteEntity.LoadData(NoteID);
            this.txtNoteCode.Text = this.NoteEntity.NoteCode;
            this.CompanyID = this.NoteEntity.CompanyID;
            this.txtCompanyAbbName.Text = CompanyName;
            this.dtpDateNote.Value = this.NoteEntity.DateNote;
            this.ctrlSupplierAddress.LoadData(this.NoteEntity.CompanyID);
            this.SetComputeControl(false);
            this.LoadItems();
        }
        private void LoadItems()
        {
            DataTable dtblTmp = this.accSupplyPlans.GetDataOutSrcSupplyPlansByNoteID(NoteID).Tables[0];
            this.dtblOrderItems = this.accOrderItems.GetDataOutSrcOrderItemsForSupplyBOM(CompanyID,this.NoteID).Tables[0];
            this.dtblOrderItems.Columns.Add("ManufQty", typeof(decimal));
            while (this.tabMain.TabCount > 1)
            {
                this.tabMain.TabPages.RemoveAt(1);
            }
            DataRow[] drowItems;
            CtrlOutSrcSupplyRequireOper ctrlRequire; 
            TabPage page;
            foreach (DataRow drowTmp in dtblTmp.Rows)
            {
                drowItems = this.dtblOrderItems.Select("ItemID=" + drowTmp["OutSrcOrderItemID"].ToString());
                if (drowItems.Length > 0)
                {
                    drowItems[0]["ManufQty"] = drowTmp["Quantity"];
                    drowItems[0]["BOMNonFinishedQty"] = (decimal)drowTmp["Quantity"] + (decimal)drowItems[0]["BOMNonFinishedQty"];
                }
                ctrlRequire = new CtrlOutSrcSupplyRequireOper();
                ctrlRequire.Edit((long)drowTmp["OutSrcSupplyPlanID"]);
                ctrlRequire.Dock = DockStyle.Fill;
                page = new TabPage();
                page.Text = drowTmp["PONo"].ToString() + "[" + string.Format("{0:0.####}", drowTmp["Quantity"]) + "]";
                page.Controls.Add(ctrlRequire);
                this.tabMain.TabPages.Add(page);
            }
            this.dgrdvOrder.DataSource = this.dtblOrderItems;           
            this.ctrlOutSrcSupplyItemOper.CompanyID = CompanyID;
            this.ctrlOutSrcSupplyItemOper.ClearItems();
            this.ctrlOutSrcSupplyItemOper.Edit(this.NoteID);

           
            
        }
        void SetComputeControl(bool flag)
        {
            this.btnAdd.Enabled = flag;
            this.ColumnManufQty.ReadOnly = !flag;


        }
        void btnCancel_Click(object sender, EventArgs e)
        {
            //重置
            string errormsg=string.Empty ;
            this.accNotes.UpdateOutSrcSupplyNotesForReset(ref errormsg, this.NoteID);
          
            this.OutSrcOrderHandle();
            //
            this.SetComputeControl(true);
            this.ctrlOutSrcSupplyItemOper.ClearItems();
            while (this.tabMain.TabCount > 1)
            {
                this.tabMain.TabPages.RemoveAt(1);
            }
           
        }

        void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult rul = MessageBox.Show("即将进行发料单删除，一经删除不能恢复！", "删除确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rul == DialogResult.No) return;
            bool flag = false;
            string errormsg = string.Empty;
            flag = this.accNotes.DeleteOutSrcSupplyNotes(ref errormsg,
                this.NoteID);
            if (flag)
            {
                this.OutSrcOrderHandle();
                MessageBox.Show("成功删除当前发料单");
            }
            else
            {
                MessageBox.Show(errormsg);
            }
            if (this.affterSave != null) this.affterSave();
            this.Close();
        }


        bool ValidateData()
        { 
            if (this.dtblOrderItems.Select("ManufQty is not null", "", DataViewRowState.CurrentRows).Length == 0)
            {
                MessageBox.Show("未设置任何加工数量");
                return false;
            }
            if (this.dtblOrderItems.Select("ManufQty >BOMNonFinishedQty", "", DataViewRowState.CurrentRows).Length>0)
            {

                MessageBox.Show("加工数不能大于未加工数");
                return false;
            }
            return true;
        }
      
        void btnAdd_Click(object sender, EventArgs e)
        {
            if (this.ValidateData() == false) return;          
            this.SetComputeControl(false);
            while (this.tabMain.TabCount >1)
            {
                this.tabMain.TabPages.RemoveAt(1);
            }
            FrmMsg.Show("正在计算物料.....");
            CtrlOutSrcSupplyRequireOper ctrlRequire;
            TabPage page;
            foreach (DataRow drow in this.dtblOrderItems.Rows)
            {
                Application.DoEvents();
                if (drow["ManufQty"] == DBNull.Value) continue;
                ctrlRequire = new CtrlOutSrcSupplyRequireOper();
                ctrlRequire.New((long)drow["ItemID"], (decimal)drow["ManufQty"]);
                ctrlRequire.Dock = DockStyle.Fill;
                page = new TabPage();               
                page.Text = drow["PONo"].ToString() + "[" + string.Format("{0:0.####}", drow["ManufQty"])+"]";
                page.Controls.Add(ctrlRequire);
                this.tabMain.TabPages.Add(page);
                this.ctrlOutSrcSupplyItemOper.AppendItems(ctrlRequire.GetItems(),true);
            }
            FrmMsg.Hide(); 
        }


        void btnExport_Click(object sender, EventArgs e)
        {
            this.ctrlOutSrcSupplyItemOper.Export();
        }
        private void OutSrcOrderHandle()
        {
            string errormsg = string.Empty;
            foreach (DataRow drowOrder in this.dtblOrderItems.Rows)
            {
                if (drowOrder["ManufQty"] == DBNull.Value) continue;
                this.accOrderItems.UpdateOutSrcOrderItemsForBOMFinishedQty(ref errormsg,
                    drowOrder["ItemID"]);
            }

        }
        void btnSave_Click(object sender, EventArgs e)
        {
            if (this.ValidateData() == false)return; 
            DialogResult rul = MessageBox.Show("将进行发料单保存！", "保存确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rul == DialogResult.No) return;
            string errormsg = string.Empty;
            bool flag = false;
            if (this.NoteID == -1)
            {
                object objNoteID = DBNull.Value;
                object objNoteCode = DBNull.Value;
                flag = this.accNotes.InsertOutSrcSupplyNotes(ref errormsg,
                    ref objNoteID,
                    ref objNoteCode,
                    this.dtpDateNote.Value.Date,
                    this.CompanyID,
                    this.ctrlSupplierAddress.SupplierAddress,
                    JERPBiz.Frame.UserBiz.PsnID,
                    this.rchMemo.Text);
                if (flag)
                {
                    this.NoteID = (long)objNoteID;
                    this.txtNoteCode.Text = objNoteCode.ToString();
                }
              
                    
            }
            else
            {
                flag=this.accNotes.UpdateOutSrcSupplyNotes (ref errormsg ,
                    this.NoteID ,
                    this.ctrlSupplierAddress .SupplierAddress ,
                       JERPBiz.Frame.UserBiz.PsnID,
                    this.rchMemo.Text);
            }
            if (!flag)
            {
                MessageBox.Show(errormsg);
                return;
            }
            //保存总数
            this.ctrlOutSrcSupplyItemOper.Save(this.NoteID);
            //保存用量需求
            CtrlOutSrcSupplyRequireOper ctrlRequire; 
            for (int j = 1; j < this.tabMain.TabCount; j++)
            {
                ctrlRequire = (CtrlOutSrcSupplyRequireOper)this.tabMain.TabPages[j].Controls[0];
                ctrlRequire.Save(this.NoteID);
            }
            //弄的是完成
            this.OutSrcOrderHandle();

            MessageBox.Show("成功保存当前发料单");
            if (this.affterSave != null) this.affterSave();
         
        }
 

    }
}