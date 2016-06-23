using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Finance.Receivable.Templet
{
    public partial class FrmSaleReconciliationFormatOper : Form
    {
        public FrmSaleReconciliationFormatOper()
        {
            InitializeComponent();
            ToolTip tip = new ToolTip();
            tip.SetToolTip(this.btnAdd, "加明细");
            this.dgrdv.AutoGenerateColumns = false;
            this.accFormat = new JERPData.Product.SaleReconciliationFormat();
            this.accFieldTitle = new JERPData.Product.SaleReconciliationFieldTitle();
            this.FormatEntity = new JERPBiz.Product.SaleReconciliationFormatEntity();
            this.btnAdd.Click += new EventHandler(btnAdd_Click);
            this.btnSave.Click += new EventHandler(btnSave_Click);
            this.btnNew.Click += new EventHandler(btnNew_Click);
            this.btnDelete.Click += new EventHandler(btnDelete_Click);
            this.dgrdv.CellContentClick += new DataGridViewCellEventHandler(dgrdv_CellContentClick);
            this.dgrdv.RowValidated += new DataGridViewCellEventHandler(dgrdv_RowValidated);
        }



        JERPData.Product.SaleReconciliationFormat accFormat;
        JERPData.Product.SaleReconciliationFieldTitle accFieldTitle;
        JERPBiz.Product.SaleReconciliationFormatEntity FormatEntity;
        FrmSaleReconciliationFieldTitle frmTitle;
       
        private DataTable dtblFieldTitles;
    
        private int  formatID = -1;
        private int  FormatID
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
            this.txtReconciliationNameCellName.Text = string.Empty;
            this.txtReconciliationCodeCellName.Text = string.Empty;
            this.txtDateNoteCellName.Text = string.Empty;
            this.txtCompanyNameCellName.Text = string.Empty;
            this.txtFinanceAddressCellName.Text = string.Empty;
            this.txtLinkmanCellName.Text = string.Empty;
            this.txtTelphoneCellName.Text = string.Empty;
            this.txtFaxCellName.Text = string.Empty;
            this.txtMoneyTypeCellName.Text = string.Empty;
            this.txtSettleTypeCellName.Text = string.Empty;
            this.txtDateSettleCellName.Text = string.Empty;
            this.txtItemBeginRowIndex.Text = string.Empty;
            this.txtReconciliationNameCellName.Text = string.Empty;         
            this.txtTotalQtyCellName.Text = string.Empty;
            this.txtDeliverAMTCellName.Text = string.Empty;
            this.txtRepairAMTCellName.Text = string.Empty;
            this.txtReplaceExpressAMTCellName.Text = string.Empty;
            this.txtReturnAMTCellName.Text = string.Empty;
            this.txtFineAMTCellName.Text = string.Empty;
            this.txtTotalAMTCellName.Text = string.Empty;
            this.txtRecordBeginRowIndex.Text = string.Empty;
            this.txtRecordAMTColumnName.Text = string.Empty;
            this.txtRecordCodeColumnName.Text = string.Empty;
            this.txtRecordDateColumnName.Text = string.Empty;
            this.txtRecordPsnColumnName.Text = string.Empty;
            
            this.LoadItem();
        }
        public void EditFormat(int  FormatID)
        {
            this.FormatID = FormatID;
            this.FormatEntity.LoadData(FormatID);
            this.txtTmpSheetName.Text = this.FormatEntity.TelephoneCellName;
            this.txtReconciliationCodeCellName.Text = this.FormatEntity.ReconciliationCodeCellName ;
            this.txtReconciliationNameCellName.Text = this.FormatEntity.ReconciliationNameCellName;
            this.txtDateNoteCellName.Text = this.FormatEntity.DateNoteCellName ;
            this.txtCompanyNameCellName.Text = this.FormatEntity.CompanyNameCellName ;
            this.txtFinanceAddressCellName.Text = this.FormatEntity.FinanceAddressCellName ;
            this.txtLinkmanCellName.Text = this.FormatEntity.LinkmanCellName ;
            this.txtTelphoneCellName.Text = this.FormatEntity.TelephoneCellName ;
            this.txtFaxCellName.Text = this.FormatEntity.FaxCellName ;
            this.txtMoneyTypeCellName.Text = this.FormatEntity.MoneyTypeCellName;
            this.txtSettleTypeCellName.Text = this.FormatEntity.SettleTypeCellName ;
            this.txtDateSettleCellName.Text = this.FormatEntity.DateSettleCellName ;
            this.txtItemBeginRowIndex.Text =(this.FormatEntity .ItemBeginRowIndex >0)? this.FormatEntity.ItemBeginRowIndex .ToString ():string.Empty;
            this.txtTotalQtyCellName.Text = this.FormatEntity.TotalQtyCellName;
            this.txtDeliverAMTCellName.Text = this.FormatEntity.DeliverAMTCellName ;
            this.txtRepairAMTCellName.Text = this.FormatEntity.RepairAMTCellName ;
            this.txtReplaceExpressAMTCellName.Text = this.FormatEntity.ReplaceExpressAMTCellName ;
            this.txtReturnAMTCellName.Text = this.FormatEntity.ReturnAMTCellName ;
            this.txtFineAMTCellName.Text = this.FormatEntity.FineAMTCellName ;
            this.txtTotalAMTCellName.Text = this.FormatEntity.TotalAMTCellName ;
            this.txtRecordBeginRowIndex.Text =(this.FormatEntity.RecordBeginRowIndex>0)? this.FormatEntity.RecordBeginRowIndex .ToString ():string.Empty;
            this.txtRecordAMTColumnName.Text = this.FormatEntity.RecordAMTColumnName;
            this.txtRecordCodeColumnName.Text = this.FormatEntity.RecordCodeColumnName ;
            this.txtRecordDateColumnName.Text = this.FormatEntity.RecordDateColumnName ;
            this.txtRecordPsnColumnName.Text = this.FormatEntity.RecordPsnColumnName ;         
            this.LoadItem();
        }
        private void LoadItem()
        {
            this.dtblFieldTitles = this.accFieldTitle.GetDataSaleReconciliationFieldTitleByFormatID(this.FormatID).Tables[0];
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
            this.accFieldTitle.UpdateSaleReconciliationFieldTitle(ref errormsg,
                drow["FieldTitleID"], drow["FieldTitle"], drow["ColumnName"], drow["SerialNoFlag"]);
            this.accFieldTitle.UpdateSaleReconciliationFieldTitleForSort(ref errormsg , drow["FieldTitleID"], drow["SortNo"],
                drow["SortName"]);
        }

    
        void btnSave_Click(object sender, EventArgs e)
        {
            bool flag = false;
            string errormsg = string.Empty;
            object objRecordBeginRowIndex =DBNull .Value ;
            if (this.txtRecordBeginRowIndex.Text != string.Empty)
            {
                objRecordBeginRowIndex=this.txtRecordBeginRowIndex.Text;
            }
            if (this.FormatID == -1)
            {
                object objFormatID = DBNull.Value;
                flag = this.accFormat.InsertSaleReconciliationFormat(ref errormsg,
                    ref objFormatID,
                    this.txtTmpSheetName.Text,
                    this.txtReconciliationNameCellName.Text,
                    this.txtReconciliationCodeCellName.Text,
                    this.txtCompanyNameCellName.Text,
                    this.txtFinanceAddressCellName .Text,
                    this.txtLinkmanCellName .Text ,
                    this.txtTelphoneCellName .Text ,
                    this.txtFaxCellName .Text ,
                    this.txtMoneyTypeCellName.Text,
                    this.txtSettleTypeCellName.Text,
                    this.txtDateNoteCellName.Text,
                    this.txtDateSettleCellName.Text,
                    this.txtItemBeginRowIndex.Text,
                    this.txtTotalQtyCellName .Text ,
                    this.txtDeliverAMTCellName .Text ,
                    this.txtRepairAMTCellName .Text ,
                    this.txtReplaceExpressAMTCellName .Text ,
                    this.txtReturnAMTCellName .Text ,
                    this.txtFineAMTCellName .Text ,
                    this.txtTotalAMTCellName .Text ,
                    objRecordBeginRowIndex ,
                    this.txtRecordDateColumnName.Text ,
                    this.txtRecordCodeColumnName .Text ,
                    this.txtRecordPsnColumnName .Text ,
                    this.txtRecordAMTColumnName .Text );
                if (flag)
                {
                    this.FormatID = (int)objFormatID;
                }
            }
            else
            {
                flag = this.accFormat.UpdateSaleReconciliationFormat(ref errormsg,
                    this.FormatID ,
                    this.txtTmpSheetName.Text,
                    this.txtReconciliationNameCellName.Text,
                    this.txtReconciliationCodeCellName.Text,
                    this.txtCompanyNameCellName.Text,
                    this.txtFinanceAddressCellName.Text,
                    this.txtLinkmanCellName.Text,
                    this.txtTelphoneCellName.Text,
                    this.txtFaxCellName.Text,
                    this.txtMoneyTypeCellName.Text,
                    this.txtSettleTypeCellName.Text,
                    this.txtDateNoteCellName.Text,
                    this.txtDateSettleCellName.Text,
                    this.txtItemBeginRowIndex.Text,
                    this.txtTotalQtyCellName .Text ,
                    this.txtDeliverAMTCellName.Text,
                    this.txtRepairAMTCellName .Text ,
                    this.txtReplaceExpressAMTCellName .Text ,
                    this.txtReturnAMTCellName .Text ,
                    this.txtFineAMTCellName.Text ,
                    this.txtTotalAMTCellName .Text ,
                    objRecordBeginRowIndex,
                    this.txtRecordDateColumnName.Text,
                    this.txtRecordCodeColumnName.Text,
                    this.txtRecordPsnColumnName.Text,
                    this.txtRecordAMTColumnName.Text);
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
                this.frmTitle = new FrmSaleReconciliationFieldTitle();
                new FrmStyle(this.frmTitle).SetPopFrmStyle(this);
                this.frmTitle.AffterSave += new FrmSaleReconciliationFieldTitle.AffterSaveDelegate(frmTitle_AffterSave);
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
                    this.frmTitle = new FrmSaleReconciliationFieldTitle();
                    new FrmStyle(this.frmTitle).SetPopFrmStyle(this);
                    this.frmTitle.AffterSave += new FrmSaleReconciliationFieldTitle.AffterSaveDelegate(frmTitle_AffterSave);
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
            flag = this.accFormat.DeleteSaleReconciliationFormat(ref errormsg, this.FormatID);
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