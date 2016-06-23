using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Sale.Report
{
    public partial class FrmBoxItemSearch : Form
    {
        public FrmBoxItemSearch()
        {
            InitializeComponent();
            this.accBoxItem = new JERPData.Packing.BoxItems();
            this.BoxItemEntity = new JERPBiz.Packing.BoxItemEntity();
            this.SaleEntity = new JERPBiz.Product.SaleDeliverNoteEntity();
            this.RepairEntity = new JERPBiz.Product.RepairDeliverNoteEntity();
            this.SetPermit();
        }
        private JERPData.Packing.BoxItems accBoxItem;
        private JERPBiz.Packing.BoxItemEntity BoxItemEntity;
        private JERPBiz.Product.SaleDeliverNoteEntity SaleEntity;
        private JERPBiz.Product.RepairDeliverNoteEntity RepairEntity;
        private JERPApp.Manufacture.Report.Bill.FrmWorkingSheet frmWorkingSheet;
        private JERPApp.Store.Product.Report.Bill.FrmSaleDeliverNote frmSaleDeliverNote; 

        //权限码
        private bool enableBrowse = false;//浏览
        private void SetPermit()
        {
            this.enableBrowse = JERPBiz.Frame.PermitHelper.EnableFunction(459);
            if (this.enableBrowse)
            {
               this.txtBarcode .KeyDown +=new KeyEventHandler(txtBarcode_KeyDown);
               this.lnkWorkingSheetCode.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkWorkingSheetCode_LinkClicked);
               this.lnkNoteCode.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkNoteCode_LinkClicked);
            }
        }

        private long SaleDeliverNoteID = -1;
        void  txtBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            bool ExistFlag = false;
            this.accBoxItem.GetParmBoxItemsExistFlag(this.txtBarcode.Text, ref ExistFlag);
            if (ExistFlag == false)
            {
                MessageBox.Show("不存在此产品条码");
            }
            this.BoxItemEntity.LoadData(this.txtBarcode .Text );
            this.txtWorkingSheetCode.Text = this.BoxItemEntity.WorkingSheetCode;
            this.txtChipsetCode.Text = this.BoxItemEntity.ChipsetCode;
            this.txtPrdCode.Text = this.BoxItemEntity.PrdCode;
            this.txtModel.Text = this.BoxItemEntity.Model;
            this.txtPrdName.Text = this.BoxItemEntity.PrdName;
            this.txtPrdSpec.Text = this.BoxItemEntity.PrdSpec;
          
            
            this.txtCompanyAbbName.Text = string.Empty;
            this.txtDeliverAddress.Text = string.Empty;
            this.SaleDeliverNoteID = -1; 
            this.accBoxItem.GetParmBoxItemsSaleDeliverNoteID(this.txtBarcode .Text , ref this.SaleDeliverNoteID);
            if (this.SaleDeliverNoteID > -1)
            {
               
                this.SaleEntity.LoadData(this.SaleDeliverNoteID);
                this.txtNoteCode.Text = this.SaleEntity.NoteCode;
                this.txtDateNote.Text = this.SaleEntity.DateNote.ToShortDateString();
                this.txtCompanyAbbName.Text = this.SaleEntity.CompanyAbbName;
                this.txtDeliverAddress.Text = this.SaleEntity.DeliverAddress;
               
            }
          
        }

        void lnkNoteCode_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (this.SaleDeliverNoteID > -1)
            {
                if (frmSaleDeliverNote == null)
                {
                    frmSaleDeliverNote = new JERPApp.Store.Product.Report.Bill.FrmSaleDeliverNote();
                    new FrmStyle(frmSaleDeliverNote).SetPopFrmStyle(this);                   
                }
                frmSaleDeliverNote.DetailNote(this.SaleDeliverNoteID);
                frmSaleDeliverNote.ShowDialog();
            }
           
        }

        void lnkWorkingSheetCode_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (frmWorkingSheet == null)
            {
                frmWorkingSheet = new JERPApp.Manufacture.Report.Bill.FrmWorkingSheet();
                new FrmStyle(frmWorkingSheet).SetPopFrmStyle(this);
            }
            frmWorkingSheet.WorkingSheet (this.BoxItemEntity.WorkingSheetID);
            frmWorkingSheet.ShowDialog();
        }
    }
}