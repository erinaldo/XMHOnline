using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Manufacture.Templet
{
    public partial class FrmManufScheduleFormatOper : Form
    {
        public FrmManufScheduleFormatOper()
        {
            InitializeComponent(); 
            this.accFormat = new JERPData.Manufacture.ManufScheduleFormat();
            this.accFieldTitle = new JERPData.Manufacture.WorkingSheetFieldTitle();
            this.FormatEntity = new JERPBiz.Manufacture.ManufScheduleFormatEntity();
            
            this.btnSave.Click += new EventHandler(btnSave_Click);
            this.btnNew.Click += new EventHandler(btnNew_Click);
            this.btnDelete.Click += new EventHandler(btnDelete_Click); 
        }


        JERPData.Manufacture.ManufScheduleFormat accFormat;
        JERPData.Manufacture.WorkingSheetFieldTitle accFieldTitle;
        JERPBiz.Manufacture.ManufScheduleFormatEntity FormatEntity;
      
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
            this.txtCompanyCodeCellName.Text = string.Empty;
            this.txtPrdCodeCellName.Text = string.Empty;
            this.txtPrdNameCellName.Text = string.Empty;
            this.txtPrdSpecCellName.Text = string.Empty;
            this.txtModelCellName.Text = string.Empty;
            this.txtPrdStatusCellName.Text = string.Empty;
            this.txtQuantityCellName.Text = string.Empty; 
            this.txtUnitNameCellName.Text = string.Empty;
            this.txtPrdDateTargetCellName.Text = string.Empty;
            this.txtMemoCellName.Text = string.Empty;
            this.txtDateTargetCellName.Text = string.Empty;
            this.txtLastPrdStatusCellName.Text = string.Empty; 
        }
        public void EditFormat(int FormatID)
        {
            this.FormatID = FormatID;
            this.FormatEntity.LoadData(FormatID);
            this.txtTmpSheetName.Text = this.FormatEntity.TmpSheetName;
            this.txtWorkingSheetCodeCellName.Text = this.FormatEntity.WorkingSheetCodeCellName;
             this.txtCompanyCodeCellName.Text = this.FormatEntity.CompanyCodeCellName ;        
         
            this.txtPrdCodeCellName.Text = this.FormatEntity.PrdCodeCellName;           
            this.txtPrdNameCellName.Text = this.FormatEntity.PrdNameCellName;
            this.txtPrdSpecCellName.Text = this.FormatEntity.PrdSpecCellName;
            this.txtModelCellName.Text = this.FormatEntity.ModelCellName;
            this.txtPrdStatusCellName.Text = this.FormatEntity.PrdStatusCellName ;
            this.txtMemoCellName.Text = this.FormatEntity.MemoCellName ;

            this.txtQuantityCellName.Text = this.FormatEntity.QuantityCellName ;
            this.txtUnitNameCellName.Text = this.FormatEntity.UnitNameCellName ;
            this.txtPrdDateTargetCellName.Text = this.FormatEntity.PrdDateTargetCellName ;

           
            this.txtDateTargetCellName.Text = this.FormatEntity.DateTargetCellName  ;
           
            this.txtLastPrdStatusCellName.Text = this.FormatEntity.LastPrdStatusCellName   ;

            this.txtNextPrdStatusCellName.Text = this.FormatEntity.NextPrdStatusCellName ;
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
                flag = this.accFormat.InsertManufScheduleFormat(ref errormsg,
                ref objFormatID,
                this.txtTmpSheetName.Text,
                this.txtWorkingSheetCodeCellName.Text,
                this.txtCompanyCodeCellName .Text , 
                this.txtPrdCodeCellName.Text,
                this.txtPrdNameCellName .Text,
                this.txtPrdSpecCellName .Text ,
                this.txtModelCellName .Text ,
                this.txtPrdStatusCellName.Text,
                this.txtQuantityCellName.Text,
                this.txtUnitNameCellName.Text,
                this.txtPrdDateTargetCellName.Text,
                this.txtDateTargetCellName.Text, 
                this.txtMemoCellName.Text,
                this.txtLastPrdStatusCellName.Text,
                this.txtNextPrdStatusCellName .Text);
                if (flag)
                {
                    this.FormatID = (int)objFormatID;
                }
            }
            else
            {
                flag = this.accFormat.UpdateManufScheduleFormat(ref errormsg, this.FormatID,
                   this.txtTmpSheetName.Text,
                this.txtWorkingSheetCodeCellName.Text,
                this.txtCompanyCodeCellName.Text, 
                this.txtPrdCodeCellName.Text,
                this.txtPrdNameCellName.Text,
                this.txtPrdSpecCellName.Text,
                this.txtModelCellName .Text ,
                this.txtPrdStatusCellName.Text,
                this.txtQuantityCellName.Text,
                this.txtUnitNameCellName.Text,
                this.txtPrdDateTargetCellName.Text,
                this.txtDateTargetCellName.Text, 
                this.txtMemoCellName.Text,
                this.txtLastPrdStatusCellName.Text,
                this.txtNextPrdStatusCellName.Text);
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
            flag = this.accFormat.DeleteManufScheduleFormat(ref errormsg, this.FormatID);
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