using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Sale
{
    public partial class FrmSaleDeliverPlanBatch : Form
    {
        public FrmSaleDeliverPlanBatch()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;
            this.ctrlCheckAll.SeachGridView = this.dgrdv;
            this.ctrlGFind.SeachGridView = this.dgrdv;
            this.accPlanItems = new JERPData.Product.SaleDeliverPlanItems();
            this.accPlanNotes = new JERPData.Product.SaleDeliverPlanNotes();
            this.accOrderItems = new JERPData.Product.SaleOrderItems();
            this.accOrderNotes = new JERPData.Product.SaleOrderNotes();
            this.ctrlGFind.BeforeFilter += this.LoadData;
            for (int j = 1; j < this.dgrdv.ColumnCount; j++)
            {
                this.dgrdv.Columns[j].ReadOnly = true;
            }
            this.btnSave.Click += new EventHandler(btnSave_Click);
        }

        private JERPData.Product.SaleDeliverPlanNotes accPlanNotes;
        private JERPData.Product.SaleDeliverPlanItems accPlanItems;
        private JERPData.Product.SaleOrderItems accOrderItems;
        private JERPData.Product.SaleOrderNotes accOrderNotes;
        private DataTable dtblNotes;
        public void LoadData()
        {
            this.dtblNotes = this.accOrderNotes.GetDataSaleOrderNotesForDeliverApply(JERPBiz.Frame.UserBiz.PsnID).Tables[0];
            this.dtblNotes.Columns.Add("CheckedFlag", typeof(bool));
            this.dgrdv.DataSource = this.dtblNotes;
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
        private void SaveNote(DataRow drowNote)
        {
            long NoteID = -1;
            long SaleOrderNoteID = (long)drowNote["NoteID"];
            this.accPlanNotes.GetParmSaleDeliverPlanNotesNoteIDBySaleOrderNoteID(SaleOrderNoteID,
               ref NoteID );
            string errormsg=string.Empty ;
            bool flag = false;
            if (NoteID == -1)
            {
                object objNoteID = DBNull.Value;
                flag=this.accPlanNotes.InsertSaleDeliverPlanNotes(ref errormsg,
                    ref objNoteID,
                    DateTime.Now.Date,
                    SaleOrderNoteID,
                    drowNote["CompanyID"],
                    drowNote["DeliverAddressID"],
                    drowNote["FinanceAddressID"],
                    drowNote["DeliverTypeID"],
                    drowNote["ExpressRequire"],
                    drowNote["MoneyTypeID"],
                    drowNote["SettleTypeID"],
                    drowNote["PriceTypeID"],
                    drowNote["InvoiceTypeID"],
                    drowNote["MakerPsnID"],
                    drowNote["Memo"]);
                if (flag)
                {
                    NoteID = (long)objNoteID;
                }
            }
            if (NoteID == -1) return;
            DataTable dtblItems = this.accOrderItems.GetDataSaleOrderItemsForDeliverApply(SaleOrderNoteID,NoteID ).Tables[0];
            foreach (DataRow drowOrderItem in dtblItems.Rows)
            {
                this.accPlanItems.SaveSaleDeliverPlanItems(
                    ref errormsg,
                    NoteID,
                    drowOrderItem["ItemID"],
                    drowOrderItem["PrdID"],
                    drowOrderItem["NonDeliverPlanQty"],
                    drowOrderItem["Price"],
                    drowOrderItem["CustomerRef"],
                    drowOrderItem["OptionalPrdInfor"],
                    drowOrderItem["Memo"]);
                this.accOrderItems.UpdateSaleOrderItemsForDeliverPlanQty (ref errormsg,
                    drowOrderItem["ItemID"]);
            }
        }
        void btnSave_Click(object sender, EventArgs e)
        {
            DialogResult rul = MessageBox.Show("将对选择项进行出货申请,请确认!", "操作确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rul == DialogResult.No) return;
            foreach (DataRow drowNote in this.dtblNotes.Rows)
            {
                if (drowNote["CheckedFlag"] == DBNull.Value) continue;
                if ((bool)drowNote["CheckedFlag"] == false) continue;
                this.SaveNote(drowNote);
            }
            this.ctrlCheckAll.CheckedFlag = false;
            MessageBox.Show("成功进行出货申请"); 
            if (this.affterSave != null) this.affterSave();
            this.Close();
           
        }
    }
}