using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Store.Material
{
    public partial class CtrlOutSrcSupplyRequireConfirm: UserControl 
    {
        public CtrlOutSrcSupplyRequireConfirm()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false;  
            this.PlanEntity = new JERPBiz.Material.OutSrcSupplyPlanEntity();
            this.accSupplyRequires = new JERPData.Material.OutSrcSupplyRequires(); 
          
        } 
        private JERPBiz.Material .OutSrcSupplyPlanEntity  PlanEntity;
        private JERPData.Material.OutSrcSupplyRequires accSupplyRequires;
        private DataTable dtblRequires;
        
        public void ConfirmOper(long OutSrcSupplyPlanID)
        { 
            this.PlanEntity.LoadData(OutSrcSupplyPlanID);         
            this.txtPONo.Text = this.PlanEntity.PONo;
            this.txtWorkingSheetCode.Text = this.PlanEntity.WorkingSheetCode;
            this.txtPrdCode.Text = this.PlanEntity.PrdCode;
            this.txtPrdName.Text = this.PlanEntity.PrdName;
            this.txtPrdSpec.Text = this.PlanEntity.PrdSpec;
            this.txtModel.Text = this.PlanEntity.Model;
            this.txtPrdStatus.Text = this.PlanEntity.PrdStatus; 
            this.txtManufQty.Text = string.Format ("{0:0.####}",this.PlanEntity .Quantity );
            this.lblUnitName.Text = this.PlanEntity.UnitName;

            this.dtblRequires = this.accSupplyRequires.GetDataOutSrcSupplyRequiresByOutSrcSupplyPlanID(OutSrcSupplyPlanID).Tables[0];
            this.dgrdv.DataSource = this.dtblRequires;
        }
      
   

    }
}