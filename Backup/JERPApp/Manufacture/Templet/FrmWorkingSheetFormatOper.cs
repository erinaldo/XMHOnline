using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Manufacture.Templet
{
    public partial class FrmWorkingSheetFormatOper : Form
    {
        public FrmWorkingSheetFormatOper()
        {
            InitializeComponent();
            ToolTip tip = new ToolTip();
            tip.SetToolTip(this.btnAdd, "加明细");
            this.dgrdv.AutoGenerateColumns = false;
            this.accFormat = new JERPData.Manufacture.WorkingSheetFormat();
            this.accFieldTitle = new JERPData.Manufacture.WorkingSheetFieldTitle();
            this.FormatEntity = new JERPBiz.Manufacture.WorkingSheetFormatEntity();
            this.btnAdd.Click += new EventHandler(btnAdd_Click);
            this.btnSave.Click += new EventHandler(btnSave_Click);
            this.btnNew.Click += new EventHandler(btnNew_Click);
            this.btnDelete.Click += new EventHandler(btnDelete_Click);
            this.dgrdv.CellContentClick += new DataGridViewCellEventHandler(dgrdv_CellContentClick);
            this.dgrdv.RowValidated += new DataGridViewCellEventHandler(dgrdv_RowValidated);
        }

        JERPData.Manufacture.WorkingSheetFormat accFormat;
        JERPData.Manufacture.WorkingSheetFieldTitle accFieldTitle;
        JERPBiz.Manufacture.WorkingSheetFormatEntity FormatEntity;
        FrmWorkingSheetFieldTitle frmTitle;       
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
            this.txtWorkingSheetCodeCellName.Text = string.Empty;
            this.txtDateNoteCellName.Text = string.Empty;
            this.txtCompanyNameCellName.Text = string.Empty;
            this.txtPrdCodeCellName.Text = string.Empty;
            this.txtPrdNameCellName.Text = string.Empty;
            this.txtPrdSpecCellName.Text = string.Empty;
            this.txtModelCellName.Text = string.Empty;
            this.txtParmsCellName.Text = string.Empty;
            this.txtQuantityCellName.Text = string.Empty;
            this.txtManufImgCellName.Text = string.Empty;
            this.txtUnitNameCellName.Text = string.Empty;
            this.txtDateTargetCellName.Text = string.Empty;
            this.txtStoreTypeCellName.Text = string.Empty;
            this.txtMemoCellName.Text = string.Empty;
            this.txtMakerPsnCellName.Text = string.Empty;
            this.txtItemRowIndex.Text = string.Empty;
            this.txtItemRowCount.Text = string.Empty;
            this.LoadItem();
        }
        public void EditFormat(int FormatID)
        {
            this.FormatID = FormatID;
            this.FormatEntity.LoadData(FormatID);
            this.txtTmpSheetName.Text = this.FormatEntity.TmpSheetName;
            this.txtWorkingSheetCodeCellName.Text = this.FormatEntity.WorkingSheetCodeCellName;
            this.txtDateNoteCellName.Text = this.FormatEntity.DateNoteCellName; 
 
            this.txtCompanyNameCellName.Text = this.FormatEntity.CompanyNameCellName;        
         
            this.txtPrdCodeCellName.Text = this.FormatEntity.PrdCodeCellName;           
            this.txtPrdNameCellName.Text = this.FormatEntity.PrdNameCellName;
            this.txtPrdSpecCellName.Text = this.FormatEntity.PrdSpecCellName;
            this.txtModelCellName.Text = this.FormatEntity.ModelCellName;

            this.txtParmsCellName.Text = this.FormatEntity.ParmsCellName;
            this.txtManufImgCellName .Text = this.FormatEntity.ManufImgCellName ;

            this.txtQuantityCellName.Text = this.FormatEntity.QuantityCellName ;
            this.txtUnitNameCellName.Text = this.FormatEntity.UnitNameCellName ;
            this.txtDateTargetCellName.Text = this.FormatEntity.DateTargetCellName;
            this.txtStoreTypeCellName.Text = this.FormatEntity.StoreTypeCellName;

            this.txtMemoCellName.Text = this.FormatEntity.MemoCellName;
            this.txtMakerPsnCellName.Text = this.FormatEntity.MakerPsnCellName;
            this.txtItemRowIndex.Text = (this.FormatEntity.ItemRowIndex > 0) ? this.FormatEntity.ItemRowIndex.ToString() : string .Empty;
            this.txtItemRowCount.Text = (this.FormatEntity.ItemRowCount > 0) ? this.FormatEntity.ItemRowCount.ToString() : string.Empty;
       
            this.LoadItem();
        }
        private void LoadItem()
        {
            this.dtblFieldTitles = this.accFieldTitle.GetDataWorkingSheetFieldTitleByFormatID(this.FormatID).Tables[0];
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
            this.accFieldTitle.UpdateWorkingSheetFieldTitle(ref errormsg,
                drow["FieldTitleID"], drow["FieldTitle"], drow["ColumnName"], drow["SerialNoFlag"]);
         
        }

    
        void btnSave_Click(object sender, EventArgs e)
        {
            bool flag = false;
            string errormsg = string.Empty;

            if (this.FormatID == -1)
            {
                object objFormatID = DBNull.Value;
                flag = this.accFormat.InsertWorkingSheetFormat(ref errormsg, ref objFormatID,
                 this.txtTmpSheetName.Text,
                this.txtWorkingSheetCodeCellName.Text,
                this.txtDateNoteCellName .Text ,
                this.txtCompanyNameCellName.Text,
                this.txtPrdCodeCellName.Text,
                this.txtPrdNameCellName .Text,
                this.txtPrdSpecCellName .Text ,
                this.txtModelCellName .Text ,
                this.txtParmsCellName .Text ,
                this.txtManufImgCellName .Text ,
                this.txtQuantityCellName.Text,
                this.txtUnitNameCellName .Text ,
                this.txtDateTargetCellName .Text ,
                this.txtStoreTypeCellName .Text ,
                this.txtMemoCellName.Text,
                this.txtMakerPsnCellName.Text,
                this.txtItemRowIndex.Text,
                this.txtItemRowCount.Text);
                if (flag)
                {
                    this.FormatID = (int)objFormatID;
                }
            }
            else
            {
                flag = this.accFormat.UpdateWorkingSheetFormat(ref errormsg, this.FormatID,
                    this.txtTmpSheetName.Text,
                    this.txtWorkingSheetCodeCellName.Text,
                    this.txtDateNoteCellName.Text,
                    this.txtCompanyNameCellName.Text,
                    this.txtPrdCodeCellName.Text,
                    this.txtPrdNameCellName.Text,
                    this.txtPrdSpecCellName.Text,
                    this.txtModelCellName .Text ,
                    this.txtParmsCellName .Text ,
                    this.txtManufImgCellName .Text ,
                    this.txtQuantityCellName.Text,
                    this.txtUnitNameCellName.Text,
                    this.txtDateTargetCellName.Text,
                    this.txtStoreTypeCellName .Text , 
                    this.txtMemoCellName.Text,
                    this.txtMakerPsnCellName.Text,
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
                this.frmTitle = new FrmWorkingSheetFieldTitle();
                new FrmStyle(this.frmTitle).SetPopFrmStyle(this);
                this.frmTitle.AffterSave += new FrmWorkingSheetFieldTitle.AffterSaveDelegate(frmTitle_AffterSave);
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
                    this.frmTitle = new FrmWorkingSheetFieldTitle();
                    new FrmStyle(this.frmTitle).SetPopFrmStyle(this);
                    this.frmTitle.AffterSave += new FrmWorkingSheetFieldTitle.AffterSaveDelegate(frmTitle_AffterSave);
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
            flag = this.accFormat.DeleteWorkingSheetFormat(ref errormsg, this.FormatID);
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