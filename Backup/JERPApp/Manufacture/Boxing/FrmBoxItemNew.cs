using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using JCommon;
namespace JERPApp.Manufacture.Boxing
{
    public partial class FrmBoxItemNew : Form
    {
        public FrmBoxItemNew()
        {
            InitializeComponent();
            this.accWorkingSheets = new JERPData.Manufacture .WorkingSheets();
            this.accBoxeItems = new JERPData.Packing .BoxItems(); 
            this.WorkingSheetEntity = new JERPBiz.Manufacture.WorkingSheetEntity(); 
            this.BoxItemPrinter = new JERPBiz.Packing.BoxItemPrinterHelper();
            this.btnCreate.Click += new EventHandler(btnCreate_Click); 
        }

        private JERPData.Manufacture  .WorkingSheets accWorkingSheets;
        private JERPData.Packing.BoxItems accBoxeItems; 
        private JERPBiz.Manufacture.WorkingSheetEntity WorkingSheetEntity;
        private JERPBiz.Packing.BoxItemPrinterHelper BoxItemPrinter; 
        private long WorkingSheetID = -1;
        public void BarcodeOper(long WorkingSheetID)
        {
            this.WorkingSheetID = WorkingSheetID;
            this.WorkingSheetEntity.LoadData(WorkingSheetID);
            this.txtWorkingSheetCode.Text = this.WorkingSheetEntity.WorkingSheetCode; 
            this.txtPrdCode.Text = this.WorkingSheetEntity.PrdCode;
            this.txtPrdName.Text = this.WorkingSheetEntity.PrdName;
            this.txtPrdSpec.Text = this.WorkingSheetEntity.PrdSpec; 
            this.lblUnitName.Text = this.WorkingSheetEntity.UnitName;
            this.txtBarcodeNonFinishedQty.Text = string.Format("{0:0}", this.WorkingSheetEntity.BarcodeNonFinishedQty);
            this.txtQuantity.Text = this.txtBarcodeNonFinishedQty.Text; 
            this.dtpDateNote.Value = DateTime.Now.Date;
           
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
        private bool ValidateData()
        { 
            int i;
            if (!int.TryParse(this.txtQuantity.Text, out i))
            {

                MessageBox.Show("数量格式出错");
                return false;
            }
            return true;
        }
        void btnCreate_Click(object sender, EventArgs e)
        {
            if (this.ValidateData() == false) return ;
            DialogResult rul = MessageBox.Show("即将生成产品标签，一经生成不能变更", "操作确认", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (rul == DialogResult.Cancel) return;
            object objBoxCode = DBNull.Value;
            string errormsg = string.Empty;
            bool flag = false;
            int Quantity = int.Parse(this.txtQuantity.Text); 
            for (int i = 0; i < Quantity; i++)
            { 
                flag = this.accBoxeItems.InsertBoxItems (ref errormsg, 
                    this.WorkingSheetID ,
                    this.WorkingSheetEntity .PrdID ,
                    this.dtpDateNote .Value .Date );
            }
            this.accWorkingSheets.UpdateWorkingSheetsForAppendBarcodeFinishedQty(ref errormsg,
                  this.WorkingSheetID,
                  Quantity
                  );
            rul = MessageBox.Show("成功生成产品标签，需要立即打印不，请检查条码纸是否够数","操作确认", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (rul == DialogResult.Yes)
            {
                DataRow[] drowBoxItems = this.accBoxeItems.GetDataBoxItemsNonPrint().Tables[0].Select();
                this.BoxItemPrinter.Export(drowBoxItems); 
            }
            if (this.affterSave != null) this.affterSave();
            this.Close();
        }
    }
}