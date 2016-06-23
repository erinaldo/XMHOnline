using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Store.Material.Report.Bill
{
    public partial class FrmOutSrcSupplyNote : FrmBizBill 
    {
        public FrmOutSrcSupplyNote()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.NoteEntity = new JERPBiz.Material.OutSrcSupplyNoteEntity();
            this.accItems = new JERPData.Material.OutSrcSupplyItems();
            this.PrinterHelper = new JERPBiz.Material.OutSrcSupplyNotePrintHelper();
            this.accSupplyPlans = new JERPData.Material.OutSrcSupplyPlans();
            this.btnExplore .Click  +=new EventHandler(btnExplore_Click);
        }
        private JERPBiz.Material.OutSrcSupplyNoteEntity NoteEntity;
        private JERPData.Material.OutSrcSupplyItems accItems;
        private JERPData.Material.OutSrcSupplyPlans accSupplyPlans;
        private JERPBiz.Material.OutSrcSupplyNotePrintHelper PrinterHelper;
        private DataTable dtblItems,dtblSupplyPlans;
        private long NoteID = -1;
        public override void DetailNote(long NoteID)
        {
            this.NoteID = NoteID;
            this.NoteEntity.LoadData(NoteID);
            this.txtCompanyAbbName.Text = this.NoteEntity.CompanyAbbName;          
            this.txtDateNote.Text = this.NoteEntity.DateNote.ToShortDateString();
            this.txtNoteCode.Text = this.NoteEntity.NoteCode;
            this.txtSupplierAddress.Text = this.NoteEntity.SupplierAddress;
            this.rchMemo.Text = this.NoteEntity.Memo;
            this.txtMakerPsn.Text = this.NoteEntity.MakerPsn;
            this.CreateColumn();
            this.dtblItems = this.accItems.GetDataOutSrcSupplyItemsForExport (NoteID).Tables[0];
            this.dgrdv.DataSource = this.dtblItems;
        }
        private void CreateColumn()
        {
            this.dtblSupplyPlans = this.accSupplyPlans.GetDataOutSrcSupplyPlansByNoteID(NoteID).Tables[0];
            while (this.dgrdv.ColumnCount > 4)
            {
                this.dgrdv.Columns.RemoveAt(4);
            }
            DataGridViewTextBoxColumn  txt;
            foreach (DataRow drow in this.dtblSupplyPlans.Rows)
            {
                txt = new DataGridViewTextBoxColumn ();
                txt.Width =80;
                txt.DataPropertyName = drow["OutSrcSupplyPlanID"].ToString();
                txt.HeaderText =drow["PONo"].ToString ()+"\n"+ drow["PrdCode"].ToString() +"["+ string.Format("{0:0.####}", drow["Quantity"])+"]";
                this.dgrdv.Columns.Add(txt);
            }
            txt = new DataGridViewTextBoxColumn();
            txt.Width = 66;
            txt.DataPropertyName = "RequireQty";
            txt.HeaderText = "总需求";
            this.dgrdv.Columns.Add(txt);

            txt = new DataGridViewTextBoxColumn();
            txt.Width = 80;
            txt.DataPropertyName = "LastInventoryQty";
            txt.HeaderText = "上单结存";
            this.dgrdv.Columns.Add(txt);

            txt = new DataGridViewTextBoxColumn();
            txt.Width = 54;
            txt.DataPropertyName = "MinPackingQty";
            txt.HeaderText = "最小包装";
            this.dgrdv.Columns.Add(txt);

           

            txt = new DataGridViewTextBoxColumn();
            txt.Width = 66;
            txt.DataPropertyName = "Quantity";
            txt.HeaderText = "实发数";
            this.dgrdv.Columns.Add(txt);

            txt = new DataGridViewTextBoxColumn();
            txt.Width = 80;
            txt.DataPropertyName = "CurrentInventoryQty";
            txt.HeaderText = "本单结存";
            this.dgrdv.Columns.Add(txt);
        }
        void btnExplore_Click(object sender, EventArgs e)
        {
            FrmMsg.Show("正在生成打印文档，请稍候......");
            this.PrinterHelper.ExportToExcel(this.NoteID);
            FrmMsg.Hide();
          
        
           
        }
    }
}