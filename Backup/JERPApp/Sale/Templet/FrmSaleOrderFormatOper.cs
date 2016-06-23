using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Sale.Templet
{
    public partial class FrmSaleOrderFormatOper : Form
    {
        public FrmSaleOrderFormatOper()
        {
            InitializeComponent();
            ToolTip tip = new ToolTip();
            tip.SetToolTip(this.btnAdd, "加明细");
            this.dgrdv.AutoGenerateColumns = false;
            this.accFormat = new JERPData.Product.SaleOrderFormat();
            this.accFieldTitle = new JERPData.Product.SaleOrderFieldTitle();
            this.FormatEntity = new JERPBiz.Product.SaleOrderFormatEntity();
            this.btnAdd.Click += new EventHandler(btnAdd_Click);
            this.btnSave.Click += new EventHandler(btnSave_Click);
            this.btnNew.Click += new EventHandler(btnNew_Click);
            this.btnDelete.Click += new EventHandler(btnDelete_Click);
            this.dgrdv.CellContentClick += new DataGridViewCellEventHandler(dgrdv_CellContentClick);
            this.dgrdv.RowValidated += new DataGridViewCellEventHandler(dgrdv_RowValidated);
        }

        JERPData.Product.SaleOrderFormat accFormat;
        JERPData.Product.SaleOrderFieldTitle accFieldTitle;
        JERPBiz.Product.SaleOrderFormatEntity FormatEntity;
        FrmSaleOrderFieldTitle frmTitle;
       
        private DataTable dtblFieldTitles;
    
        private int formatID = -1;
        private int FormatID
        {
            get
            {
                return formatID;
            }
            set
            {
                this.formatID = value;
                this.btnAdd.Enabled = (value > -1);
                this.btnDelete.Enabled = (value > -1);
            }
        }
        public void NewFormat()
        {
            this.FormatID = -1;
            this.txtTmpSheetName.Text = string.Empty;
            this.txtNoteCodeCellName.Text = string.Empty;
            this.txtPONoCellName.Text = string.Empty;
            this.txtDateNoteCellName.Text = string.Empty;
            this.txtFaxCellName.Text = string.Empty;
            this.txtTelephoneCellName.Text = string.Empty;
            this.txtEmailCellName.Text = string.Empty;
            this.txtCompanyNameCellName.Text = string.Empty;
            this.txtLegalPersonCellName.Text = string.Empty;
            this.txtLinkmanCellName.Text = string.Empty;
            this.txtDeliverAddressCellName.Text = string.Empty;
            this.txtFinanceAddressCellName.Text = string.Empty;
            this.txtDeliverTypeCellName.Text = string.Empty;
            this.txtExpressRequireCellName.Text = string.Empty;
            this.txtMoneyTypeCellName.Text = string.Empty;
            this.txtSettleTypeCellName.Text = string.Empty;
            this.txtPriceTypeCellName.Text = string.Empty;
            this.txtSalePsnCellName.Text = string.Empty;
            this.txtMakerPsnCellName.Text = string.Empty;
            this.txtTotalAMTCellName.Text = this.FormatEntity.TotalAMTCellName;
            this.txtMemoCellName.Text = string.Empty;
            this.txtItemRowIndex.Text = string.Empty;
            this.txtItemRowCount.Text = string.Empty;
            this.LoadItem();
        }
        public void EditFormat(int FormatID)
        {
            this.FormatID = FormatID;
            this.FormatEntity.LoadData(FormatID);
            this.txtTmpSheetName.Text = this.FormatEntity.TmpSheetName;
            this.txtNoteCodeCellName.Text = this.FormatEntity.NoteCodeCellName;
            this.txtPONoCellName.Text = this.FormatEntity.PONoCellName ;
            this.txtCompanyNameCellName.Text = this.FormatEntity.CompanyNameCellName;
            this.txtLegalPersonCellName.Text = this.FormatEntity.LegalPersonCellName;
            this.txtLinkmanCellName.Text = this.FormatEntity.LinkmanCellName;
            this.txtDateNoteCellName.Text = this.FormatEntity.DateNoteCellName;
            this.txtFaxCellName.Text = this.FormatEntity.FaxCellName;
            this.txtTelephoneCellName.Text = this.FormatEntity.TelephoneCellName ; 
            this.txtMoneyTypeCellName.Text = this.FormatEntity.MoneyTypeCellName;
            this.txtSettleTypeCellName.Text = this.FormatEntity.SettleTypeCellName;
            this.txtPriceTypeCellName.Text = this.FormatEntity.PriceTypeCellName;
            this.txtInvoiceTypeCellName.Text = this.FormatEntity.InvoiceTypeCellName;
            this.txtDeliverAddressCellName.Text = this.FormatEntity.DeliverAddressCellName;           
            this.txtFinanceAddressCellName.Text = this.FormatEntity.FinanceAddressCellName;
            this.txtDeliverTypeCellName.Text = this.FormatEntity.DeliverTypeCellName;
            this.txtExpressRequireCellName.Text = this.FormatEntity.ExpressRequireCellName;
            this.txtSalePsnCellName.Text = this.FormatEntity.SalePsnCellName;
            this.txtMakerPsnCellName.Text = this.FormatEntity.MakerPsnCellName;
            this.txtMemoCellName.Text = this.FormatEntity.MemoCellName;
            this.txtTotalAMTCellName.Text = this.FormatEntity.TotalAMTCellName ;
            this.txtItemRowIndex.Text = (this.FormatEntity.ItemRowIndex > 0) ? this.FormatEntity.ItemRowIndex.ToString() : string .Empty;
            this.txtItemRowCount.Text = (this.FormatEntity.ItemRowCount > 0) ? this.FormatEntity.ItemRowCount.ToString() : string.Empty;
       
            this.LoadItem();
        }
        private void LoadItem()
        {
            this.dtblFieldTitles = this.accFieldTitle.GetDataSaleOrderFieldTitleByFormatID(this.FormatID).Tables[0];
            this.dgrdv.DataSource = this.dtblFieldTitles;
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

        void dgrdv_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            DataRow drow = null;
            try
            {
                drow=this.dtblFieldTitles.DefaultView[irow].Row;
            }
            catch 
            { 
                return; 
            }
            if (drow == null) return;
            string errormsg=string.Empty ;
            this.accFieldTitle.UpdateSaleOrderFieldTitle(ref errormsg,
                drow["FieldTitleID"], drow["FieldTitle"], drow["ColumnName"], drow["SerialNoFlag"]);
         
        }

    
        void btnSave_Click(object sender, EventArgs e)
        {
            bool flag = false;
            string errormsg = string.Empty;

            if (this.FormatID == -1)
            {
                object objFormatID = DBNull.Value;
                flag = this.accFormat.InsertSaleOrderFormat(ref errormsg, ref objFormatID,
                this.txtTmpSheetName.Text,
                this.txtNoteCodeCellName .Text ,
                this.txtPONoCellName.Text,
                this.txtDateNoteCellName.Text,
                this.txtCompanyNameCellName.Text,
                this.txtLegalPersonCellName .Text,
                this.txtLinkmanCellName .Text ,
                this.txtTelephoneCellName.Text,
                this.txtFaxCellName.Text,
                this.txtDeliverAddressCellName.Text,
                this.txtFinanceAddressCellName.Text,
                this.txtDeliverTypeCellName .Text,
                this.txtExpressRequireCellName .Text ,
                this.txtMoneyTypeCellName.Text,
                this.txtSettleTypeCellName.Text,
                this.txtPriceTypeCellName.Text,
                this.txtInvoiceTypeCellName .Text ,
                this.txtMakerPsnCellName.Text,
                this.txtSalePsnCellName.Text,
                this.txtTotalAMTCellName.Text,
                this.txtMemoCellName.Text,
                this.txtItemRowIndex.Text,
                this.txtItemRowCount.Text);
                if (flag)
                {
                    this.FormatID = (int)objFormatID;
                }
            }
            else
            {
                flag = this.accFormat.UpdateSaleOrderFormat(ref errormsg,
                    this.FormatID,
                    this.txtTmpSheetName.Text,
                    this.txtNoteCodeCellName .Text ,
                    this.txtPONoCellName.Text,
                    this.txtDateNoteCellName.Text,
                    this.txtCompanyNameCellName.Text,
                    this.txtLegalPersonCellName.Text,
                    this.txtLinkmanCellName .Text ,
                    this.txtTelephoneCellName.Text,
                    this.txtFaxCellName.Text,
                    this.txtDeliverAddressCellName.Text,
                    this.txtFinanceAddressCellName.Text,
                    this.txtDeliverTypeCellName .Text,
                    this.txtExpressRequireCellName .Text ,
                    this.txtMoneyTypeCellName.Text,
                    this.txtSettleTypeCellName.Text,
                    this.txtPriceTypeCellName.Text,
                    this.txtInvoiceTypeCellName .Text ,
                    this.txtMakerPsnCellName.Text,
                    this.txtSalePsnCellName.Text,
                    this.txtTotalAMTCellName.Text,
                    this.txtMemoCellName.Text,
                    this.txtItemRowIndex.Text,
                    this.txtItemRowCount.Text);
            }
            if (!flag)
            {
                MessageBox.Show(errormsg);
                return;
            }
            else
            {
                MessageBox.Show("成功保存当前系统记录"); 
                if (this.affterSave != null) this.affterSave();
                
            }

           
        }
        void btnNew_Click(object sender, EventArgs e)
        {
            this.NewFormat();
        }
        void btnAdd_Click(object sender, EventArgs e)
        {
            if (this.frmTitle == null)
            {
                this.frmTitle = new FrmSaleOrderFieldTitle();
                new FrmStyle(this.frmTitle).SetPopFrmStyle(this);
                this.frmTitle.AffterSave += new FrmSaleOrderFieldTitle.AffterSaveDelegate(frmTitle_AffterSave);
            }
            this.frmTitle.NewFieldTitle(this.FormatID);
            this.frmTitle.ShowDialog();
        }

        void dgrdv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            int irow = e.RowIndex;
            int icol = e.ColumnIndex;
            if ((irow == -1) || (icol == -1)) return;
            if (this.dgrdv.Columns[icol].Name == this.ColumnBtnEdit.Name)
            {
                long FieldTitleID = (long)this.dtblFieldTitles.DefaultView[irow]["FieldTitleID"];
                if (this.frmTitle == null)
                {
                    this.frmTitle = new FrmSaleOrderFieldTitle();
                    new FrmStyle(this.frmTitle).SetPopFrmStyle(this);
                    this.frmTitle.AffterSave += new FrmSaleOrderFieldTitle.AffterSaveDelegate(frmTitle_AffterSave);
                }
                this.frmTitle.EditFieldTitle(FieldTitleID);
                this.frmTitle.ShowDialog();
            }
        }

        void frmTitle_AffterSave()
        {
            this.LoadItem();
        }
        void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult rul = MessageBox.Show("您的删除将不能恢复，请确认！", "删除确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rul == DialogResult.No) return;
            bool flag = false;
            string errormsg = string.Empty;
            flag = this.accFormat.DeleteSaleOrderFormat(ref errormsg, this.FormatID);
            if (flag)
            {
                MessageBox.Show("成功删除当前格式！");
            }
            else
            {
                MessageBox.Show(errormsg);
            }
            if (this.affterSave != null) this.affterSave();
            this.NewFormat();
        }

    

    }
}