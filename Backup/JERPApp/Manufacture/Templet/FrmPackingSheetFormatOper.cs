using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Manufacture.Templet
{
    public partial class FrmPackingSheetFormatOper : Form
    {
        public FrmPackingSheetFormatOper()
        {
            InitializeComponent();
            ToolTip tip = new ToolTip(); 
            this.accFormat = new JERPData.Packing.WorkingSheetFormat();
            this.FormatEntity = new JERPBiz.Packing.WorkingSheetFormatEntity(); 
            this.btnSave.Click += new EventHandler(btnSave_Click);
            this.btnNew.Click += new EventHandler(btnNew_Click);
            this.btnDelete.Click += new EventHandler(btnDelete_Click); 
        }

        JERPData.Packing .WorkingSheetFormat accFormat;
        JERPBiz.Packing.WorkingSheetFormatEntity FormatEntity;  
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
            this.txtWorkingSheetCodeCellName.Text = string.Empty;
            this.txtDateNoteCellName.Text = string.Empty;
            this.txtCompanyNameCellName.Text = string.Empty;
            this.txtPrdCodeCellName.Text = string.Empty;
            this.txtPrdNameCellName.Text = string.Empty;
            this.txtPrdSpecCellName.Text = string.Empty;
            this.txtModelCellName.Text = string.Empty; 
            this.txtQuantityCellName.Text = string.Empty; 
            this.txtUnitNameCellName.Text = string.Empty;
            this.txtDateTargetCellName.Text = string.Empty;
            this.txtPackingTypeCellName.Text = string.Empty;
            this.txtMemoCellName.Text = string.Empty;
            this.txtMakerPsnCellName.Text = string.Empty; 
           
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

           

            this.txtQuantityCellName.Text = this.FormatEntity.QuantityCellName ;
            this.txtUnitNameCellName.Text = this.FormatEntity.UnitNameCellName ;
            this.txtDateTargetCellName.Text = this.FormatEntity.DateTargetCellName;
            this.txtPackingTypeCellName.Text = this.FormatEntity.PackingTypeCellName ;

            this.txtMemoCellName.Text = this.FormatEntity.MemoCellName;
            this.txtMakerPsnCellName.Text = this.FormatEntity.MakerPsnCellName;
       
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
                flag = this.accFormat.InsertWorkingSheetFormat(ref errormsg, ref objFormatID,
                 this.txtTmpSheetName.Text,
                this.txtWorkingSheetCodeCellName.Text,
                this.txtDateNoteCellName .Text ,
                this.txtCompanyNameCellName.Text,
                this.txtPrdCodeCellName.Text,
                this.txtPrdNameCellName .Text,
                this.txtPrdSpecCellName .Text ,
                this.txtModelCellName .Text ,
                this.txtQuantityCellName.Text,
                this.txtUnitNameCellName .Text ,
                this.txtDateTargetCellName .Text ,
                this.txtPackingTypeCellName .Text ,
                this.txtMemoCellName.Text,
                this.txtMakerPsnCellName.Text );
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
                    this.txtQuantityCellName.Text,
                    this.txtUnitNameCellName.Text,
                    this.txtDateTargetCellName.Text,
                    this.txtPackingTypeCellName .Text , 
                    this.txtMemoCellName.Text,
                    this.txtMakerPsnCellName.Text );
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