using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Store.Material
{
    public partial class CtrlOutSrcSupplyRequireOper : UserControl 
    {
        public CtrlOutSrcSupplyRequireOper()
        {
            InitializeComponent();
            this.dgrdv.AutoGenerateColumns = false; 
            this.accOrderItems = new JERPData.Manufacture.OutSrcOrderItems();
            this.OrderItemEntity = new JERPBiz.Manufacture.OutSrcOrderItemEntity();
            this.SupplyPlanEntity = new JERPBiz.Material.OutSrcSupplyPlanEntity();
            this.accSupplyPlans = new JERPData.Material.OutSrcSupplyPlans();
            this.accSupplyRequires = new JERPData.Material.OutSrcSupplyRequires(); 
            this.accManufBOM = new JERPData.Manufacture.BOM(); 
          
        }
        private JERPData.Manufacture .OutSrcOrderItems  accOrderItems;
        private JERPBiz.Manufacture.OutSrcOrderItemEntity OrderItemEntity;
        private JERPBiz.Material.OutSrcSupplyPlanEntity SupplyPlanEntity;
        private JERPData.Material.OutSrcSupplyRequires accSupplyRequires;
        private JERPData.Material.OutSrcSupplyPlans accSupplyPlans; 
        private JERPData.Manufacture.BOM accManufBOM; 
        private  DataTable  dtblBom;
        private long OutSrcOrderItemID = -1;
        private long OutSrcSupplyPlanID = -1;
        private decimal ManufQty = 0;
        public DataRow[] GetItems()
        {
            return this.dtblBom.Select();
        }
        
        public void New(long OutSrcOrderItemID,decimal ManufQty)
        {
            this.OutSrcSupplyPlanID = -1;
            this.OutSrcOrderItemID = OutSrcOrderItemID;
            this.ManufQty = ManufQty;
            this.OrderItemEntity.LoadData(OutSrcOrderItemID);         
            this.txtPONo.Text = this.OrderItemEntity.PONo;
            this.txtWorkingSheetCode.Text = this.OrderItemEntity.WorkingSheetCode;
            this.txtPrdCode.Text = this.OrderItemEntity.PrdCode;
            this.txtPrdName.Text = this.OrderItemEntity.PrdName;
            this.txtPrdSpec.Text = this.OrderItemEntity.PrdSpec;
            this.txtModel.Text = this.OrderItemEntity.Model;
            this.txtPrdStatus.Text = this.OrderItemEntity.PrdStatus; 
            this.txtManufQty.Text = string.Format ("{0:0.####}",ManufQty);
            this.lblUnitName.Text = this.OrderItemEntity.UnitName;
            this.dtblBom = this.accManufBOM.GetDataBOMForOutStore (this.OrderItemEntity.ManufScheduleID).Tables[0];
          
            this.dtblBom.Columns.Add("ItemID", typeof(long));
            this.dtblBom .Columns .Add ("RequireQty",typeof (decimal));
            foreach (DataRow drow in this.dtblBom.Rows)
            {
                int PrdID = (int)drow["PrdID"]; 
                if (drow["LossRate"] == DBNull.Value)
                {
                    drow["LossRate"] = 0;
                }
                drow["RequireQty"] =Math.Ceiling ( ManufQty * (decimal)drow["AssemblyQty"] * (1 + (decimal)drow["LossRate"]));
             }
            this.dgrdv.DataSource = this.dtblBom;
            
        }
        public void Edit(long OutSrcSupplyPlanID)
        {
            this.OutSrcSupplyPlanID = OutSrcSupplyPlanID;
            this.SupplyPlanEntity.LoadData(OutSrcSupplyPlanID);
            this.OutSrcOrderItemID = this.SupplyPlanEntity.OutSrcOrderItemID;
            this.txtPONo.Text = this.SupplyPlanEntity.PONo;
            this.txtWorkingSheetCode.Text = this.SupplyPlanEntity.WorkingSheetCode;
            this.txtPrdCode.Text = this.SupplyPlanEntity.PrdCode;
            this.txtPrdName.Text = this.SupplyPlanEntity.PrdName;
            this.txtPrdSpec.Text = this.SupplyPlanEntity.PrdSpec;
            this.txtModel.Text = this.SupplyPlanEntity.Model;
            this.txtPrdStatus.Text = this.SupplyPlanEntity.PrdStatus;
            this.txtManufQty.Text = string.Format("{0:0.####}", this.SupplyPlanEntity.Quantity);
            this.lblUnitName.Text = this.SupplyPlanEntity.UnitName;

            this.dtblBom  = this.accSupplyRequires.GetDataOutSrcSupplyRequiresByOutSrcSupplyPlanID(OutSrcSupplyPlanID).Tables[0];
            this.dgrdv.DataSource = this.dtblBom ;
        }
        public void Save(long NoteID)
        {
            if (this.OutSrcSupplyPlanID > -1) return;//如果是编辑就不要搞的啦
            //先给老子保存出头            
            object objOutSrcSupplyPlanID = DBNull.Value;
            bool flag = false;
            string errormsg = string.Empty;
            int CompanyID = this.OrderItemEntity.CompanyID;
            long ManufScheduleID = this.OrderItemEntity.ManufScheduleID;
            flag = this.accSupplyPlans.InsertOutSrcSupplyPlans(ref errormsg,
                ref objOutSrcSupplyPlanID,
                NoteID,
                this.OutSrcOrderItemID,
                this.ManufQty);
            if (!flag)
            {
                MessageBox.Show(errormsg);
                return;

            }
            this.OutSrcSupplyPlanID = (long)objOutSrcSupplyPlanID;
            //开整需求明细
            foreach (DataRow drow in this.dtblBom.Rows)
            {
                this.accSupplyRequires.InsertOutSrcSupplyRequires(ref errormsg,
                   this.OutSrcSupplyPlanID ,
                    drow["PrdID"],
                    drow["AssemblyQty"],
                    drow["LossRate"],
                    drow["RequireQty"]);
            }
            

        }
  

    }
}