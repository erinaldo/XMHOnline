using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Finance.Receivable.Templet
{
    public partial class FrmExpressReconciliationFormatOper : Form
    {
        public FrmExpressReconciliationFormatOper()
        {
            InitializeComponent();
            ToolTip tip = new ToolTip();
            tip.SetToolTip(this.btnAdd, "加明细");
            this.dgrdv.AutoGenerateColumns = false;
            this.accFormat = new JERPData.Product.ExpressReconciliationFormat();
            this.accFieldTitle = new JERPData.Product.ExpressReconciliationFieldTitle();
            this.btnAdd.Click += new EventHandler(btnAdd_Click);
            this.btnSave.Click += new EventHandler(btnSave_Click);
            this.btnNew.Click += new EventHandler(btnNew_Click);
            this.btnDelete.Click += new EventHandler(btnDelete_Click);
            this.dgrdv.CellContentClick += new DataGridViewCellEventHandler(dgrdv_CellContentClick);
            this.dgrdv.RowValidated += new DataGridViewCellEventHandler(dgrdv_RowValidated);
        }



        JERPData.Product.ExpressReconciliationFormat accFormat;
        JERPData.Product.ExpressReconciliationFieldTitle accFieldTitle;
        FrmExpressReconciliationFieldTitle frmTitle;
       
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
            this.txtReconciliationNameCellName.Text = string.Empty;
            this.txtReconciliationCodeCellName.Text = string.Empty;
            this.txtDateNoteCellName.Text = string.Empty;
            this.txtCompanyNameCellName.Text = string.Empty;
        
            this.txtMoneyTypeCellName.Text = string.Empty;
            this.txtItemBeginRowIndex.Text = string.Empty;
            this.txtReconciliationNameCellName.Text = string.Empty;
            this.txtTmpSheetName.Text = string.Empty;
        
            this.txtTotalAMTCellName.Text = string.Empty;
            this.txtMakerPsnCellName.Text = string.Empty;

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
            DataTable dtbl = this.accFormat.GetDataExpressReconciliationFormatByFormatID(FormatID).Tables[0];
            this.txtReconciliationNameCellName.Text = string.Empty;
            this.txtReconciliationCodeCellName.Text = string.Empty;
            this.txtDateNoteCellName.Text = string.Empty;
            this.txtCompanyNameCellName.Text = string.Empty;
          
            this.txtMoneyTypeCellName.Text = string.Empty;
            this.txtItemBeginRowIndex.Text = string.Empty;
            this.txtTmpSheetName.Text = string.Empty;
            this.txtTotalAMTCellName.Text = string.Empty;
            this.txtMakerPsnCellName.Text = string.Empty;
            this.txtRecordBeginRowIndex.Text = string.Empty;
            this.txtRecordAMTColumnName.Text = string.Empty;
            this.txtRecordCodeColumnName.Text = string.Empty;
            this.txtRecordDateColumnName.Text = string.Empty;
            this.txtRecordPsnColumnName.Text = string.Empty;
            if (dtbl.Rows.Count > 0)
            {
                DataRow drow = dtbl.Rows[0];
                this.txtTmpSheetName.Text = drow["TmpSheetName"].ToString();
                this.txtReconciliationNameCellName.Text = drow["ReconciliationNameCellName"].ToString();
                this.txtReconciliationCodeCellName.Text = drow["ReconciliationCodeCellName"].ToString();
                this.txtCompanyNameCellName.Text = drow["CompanyNameCellName"].ToString();
                this.txtMoneyTypeCellName.Text = drow["MoneyTypeCellName"].ToString();
                this.txtDateNoteCellName.Text = drow["DateNoteCellName"].ToString();
                this.txtItemBeginRowIndex.Text = drow["ItemBeginRowIndex"].ToString();              
                this.txtTotalAMTCellName.Text = drow["TotalAMTCellName"].ToString();
                this.txtMakerPsnCellName.Text = drow["MakerPsnCellName"].ToString();
                this.txtRecordBeginRowIndex.Text = drow["RecordBeginRowIndex"].ToString();
                this.txtRecordDateColumnName.Text = drow["RecordDateColumnName"].ToString();
                this.txtRecordCodeColumnName.Text = drow["RecordCodeColumnName"].ToString();
                this.txtRecordPsnColumnName.Text = drow["RecordPsnColumnName"].ToString();
                this.txtRecordAMTColumnName.Text = drow["RecordAMTColumnName"].ToString();
            }
            this.LoadItem();
        }
        private void LoadItem()
        {
            this.dtblFieldTitles = this.accFieldTitle.GetDataExpressReconciliationFieldTitleByFormatID(this.FormatID).Tables[0];
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
            this.accFieldTitle.UpdateExpressReconciliationFieldTitle(ref errormsg,
                drow["FieldTitleID"], drow["FieldTitle"], drow["ColumnName"], drow["SerialNoFlag"]);
            this.accFieldTitle.UpdateExpressReconciliationFieldTitleForSort(ref errormsg , drow["FieldTitleID"], drow["SortNo"],
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
                flag = this.accFormat.InsertExpressReconciliationFormat(ref errormsg,
                    ref objFormatID,
                    this.txtTmpSheetName.Text,
                    this.txtReconciliationNameCellName.Text,
                    this.txtReconciliationCodeCellName.Text,
                    this.txtCompanyNameCellName.Text,
                    this.txtMoneyTypeCellName.Text,
                    this.txtDateNoteCellName.Text,
                    this.txtItemBeginRowIndex.Text,
                    this.txtTotalAMTCellName .Text ,
                    this.txtMakerPsnCellName .Text ,
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
                flag = this.accFormat.UpdateExpressReconciliationFormat(ref errormsg,
                    this.FormatID ,
                    this.txtTmpSheetName.Text,
                     this.txtReconciliationNameCellName.Text,
                    this.txtReconciliationCodeCellName.Text,
                    this.txtCompanyNameCellName.Text,
                    this.txtMoneyTypeCellName.Text,
                    this.txtDateNoteCellName.Text,
                    this.txtItemBeginRowIndex.Text,
                    this.txtTotalAMTCellName.Text,
                    this.txtMakerPsnCellName.Text,
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
                this.frmTitle = new FrmExpressReconciliationFieldTitle();
                new FrmStyle(this.frmTitle).SetPopFrmStyle(this);
                this.frmTitle.AffterSave += new FrmExpressReconciliationFieldTitle.AffterSaveDelegate(frmTitle_AffterSave);
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
                    this.frmTitle = new FrmExpressReconciliationFieldTitle();
                    new FrmStyle(this.frmTitle).SetPopFrmStyle(this);
                    this.frmTitle.AffterSave += new FrmExpressReconciliationFieldTitle.AffterSaveDelegate(frmTitle_AffterSave);
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
            flag = this.accFormat.DeleteExpressReconciliationFormat(ref errormsg, this.FormatID);
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