using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Finance.Receivable.Templet
{
    public partial class FrmSaleReceiptFormatOper : Form
    {
        public FrmSaleReceiptFormatOper()
        {
            InitializeComponent();
            this.accFormat = new JERPData.Product.SaleReceiptFormat();
            this.FormatEntity = new JERPBiz.Product.SaleReceiptFormatEntity();
            this.btnSave.Click += new EventHandler(btnSave_Click);
            this.btnNew.Click += new EventHandler(btnNew_Click);
            this.btnDelete.Click += new EventHandler(btnDelete_Click);
           
        }


        JERPData.Product.SaleReceiptFormat accFormat;
        private JERPBiz.Product.SaleReceiptFormatEntity FormatEntity;      
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
                this.btnDelete.Enabled = (value > -1);
            }
        }
        public void NewFormat()
        {
            this.FormatID = -1;
            this.txtTmpSheetName.Text = string.Empty;
            this.txtNoteCodeCellName.Text = string.Empty;
            this.txtDateNoteCellName.Text = string.Empty;
            this.txtCompanyNameCellName.Text = string.Empty; 
            this.txtReconciliationCodeCellName.Text = string.Empty;
            this.txtMoneyTypeCellName.Text = string.Empty;
            this.txtTotalAMTCellName.Text = string.Empty;
            this.txtAdvanceAMTCellName.Text = string.Empty;
            this.txtAmountCellName.Text = string.Empty;
            this.txtExpressCompanyNameCellName.Text = string.Empty;
            this.txtMakerPsnCellName.Text = string.Empty;
        }
        public void EditFormat(int  FormatID)
        {
            this.FormatID = FormatID;
            this.FormatEntity.LoadData(FormatID);
            this.txtTmpSheetName.Text = FormatEntity.TmpSheetName;
            this.txtNoteCodeCellName.Text = FormatEntity.NoteCodeCellName;
            this.txtDateNoteCellName.Text = FormatEntity.DateNoteCellName;
            this.txtCompanyNameCellName.Text = FormatEntity.CompanyNameCellName; 
            this.txtReconciliationCodeCellName.Text = FormatEntity.ReconciliationCodeCellName;
            this.txtMoneyTypeCellName.Text = FormatEntity.MoneyTypeCellName;
            this.txtTotalAMTCellName.Text = FormatEntity.TotalAMTCellName;
            this.txtAdvanceAMTCellName.Text = FormatEntity.AdvanceAMTCellName;
            this.txtAmountCellName.Text = FormatEntity.AmountCellName;
            this.txtExpressCompanyNameCellName.Text = FormatEntity.ExpressCompanyNameCellName;
            this.txtMakerPsnCellName.Text = FormatEntity.MakerPsnCellName;
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

     
        void btnSave_Click(object sender, EventArgs e)
        {
            bool flag = false;
            string errormsg = string.Empty;         
            if (this.FormatID == -1)
            {
                object objFormatID = DBNull.Value;
                flag = this.accFormat.InsertSaleReceiptFormat(ref errormsg,
                    ref objFormatID,
                    this.txtTmpSheetName.Text,
                    this.txtNoteCodeCellName.Text,
                    this.txtDateNoteCellName.Text,
                    this.txtCompanyNameCellName.Text,  
                    this.txtReconciliationCodeCellName.Text,
                    this.txtMoneyTypeCellName.Text,
                    this.txtTotalAMTCellName.Text,
                    this.txtAdvanceAMTCellName.Text,
                    this.txtAmountCellName.Text,
                    this.txtExpressCompanyNameCellName.Text,
                    this.txtMakerPsnCellName.Text);

                if (flag)
                {
                    this.FormatID = (int)objFormatID;
                }
            }
            else
            {
                flag = this.accFormat.UpdateSaleReceiptFormat(ref errormsg,                  
                    this.FormatID,
                   this.txtTmpSheetName.Text,
                    this.txtNoteCodeCellName.Text,
                    this.txtDateNoteCellName.Text,
                    this.txtCompanyNameCellName.Text,  
                    this.txtReconciliationCodeCellName.Text,
                    this.txtMoneyTypeCellName.Text,
                    this.txtTotalAMTCellName.Text,
                    this.txtAdvanceAMTCellName.Text,
                    this.txtAmountCellName.Text,
                    this.txtExpressCompanyNameCellName.Text,
                    this.txtMakerPsnCellName.Text);

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
    
        void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult rul = MessageBox.Show("您的删除将不能恢复，请确认！", "删除确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rul == DialogResult.No) return;
            bool flag = false;
            string errormsg = string.Empty;
            flag = this.accFormat.DeleteSaleReceiptFormat(ref errormsg, this.FormatID);
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