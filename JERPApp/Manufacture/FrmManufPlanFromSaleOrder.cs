using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JERPApp.Manufacture
{
    public partial class FrmManufPlanFromSaleOrder : Form
    {
        public FrmManufPlanFromSaleOrder()
        {
            InitializeComponent();
            this.dgrdvPackingPlan.AutoGenerateColumns = false;
            this.accSaleOrderItems = new JERPData.Product.SaleOrderItems();
            this.accBuyPlan = new JERPData.Product.BuyPlans();
            this.accManufPlans = new JERPData.Manufacture.ManufPlans ();
            this.accPackinngPlans = new JERPData.Packing.PackingPlans();
            this.ItemEntity = new JERPBiz.Product.SaleOrderItemEntity();
            this.accBuyOrderItems = new JERPData.Product.BuyOrderItems();
            this.Store = new JERPBiz.Product.Store();
            this.accStoreReserve = new JERPData.Product.StoreReserve();
            this.accRoadReserve = new JERPData.Product.RoadStoreReserve();
            this.accPackingType = new JERPData.Product.PackingType();
            this.btnSave.Click += new EventHandler(btnSave_Click);
            this.btnCancel.Click += new EventHandler(btnCancel_Click);
            this.dgrdvPackingPlan.DataError += new DataGridViewDataErrorEventHandler(dgrdvPackingPlan_DataError);
            this.ColumnPackingTypeID.ValueMember = "PackingTypeID";
            this.ColumnPackingTypeID.DisplayMember = "PackingTypeName";

            this.dtblPackingPlans = new DataTable();
            this.dtblPackingPlans.Columns.Add("PackingTypeID", typeof(int));
            this.dtblPackingPlans.Columns.Add("Quantity", typeof(decimal));
            this.dtblPackingPlans.Columns.Add("DateTarget", typeof(DateTime));
            this.dtblPackingPlans.Columns.Add("Memo", typeof(string));
            this.dtblPackingPlans.Columns["Quantity"].AllowDBNull = false;
            this.dgrdvPackingPlan.DataSource = this.dtblPackingPlans;
        }

        private JERPData.Product.SaleOrderItems accSaleOrderItems;
        private JERPData.Product.BuyOrderItems accBuyOrderItems;
        private JERPData.Product.BuyPlans accBuyPlan;
        private JERPData.Manufacture.ManufPlans accManufPlans;
        private JERPData.Packing .PackingPlans accPackinngPlans;
        private JERPBiz.Product.SaleOrderItemEntity ItemEntity;
        private JERPBiz.Product.Store Store;
        private JERPData.Product.StoreReserve accStoreReserve;
        private JERPData.Product.RoadStoreReserve accRoadReserve;
        private JERPData.Product.PackingType accPackingType;

        private DataTable dtblPackingPlans,dtblPackingType;
        private long SaleOrderItemID = -1;
        private int PrdID = -1;
        private decimal NonHandleQty;
        
        private void LoadPackingPlan()
        {
            if (this.dtblPackingPlans != null) this.dtblPackingPlans.Clear();

            this.dtblPackingType = this.accPackingType.GetDataPackingTypeByPrdID(this.PrdID).Tables[0];
            this.ColumnPackingTypeID.DataSource = this.dtblPackingType;
        }
        public void HandleOper(long SaleOrderItemID)
        {
            this.SaleOrderItemID = SaleOrderItemID;
            this.ItemEntity.LoadData(SaleOrderItemID);
            this.PrdID =this.ItemEntity .PrdID ;
            this.txtCompanyCode.Text = this.ItemEntity.CompanyCode ;
            this.txtHandlePsn.Text = this.ItemEntity.SalePsn;
            this.txtPONo.Text = this.ItemEntity.PONo;
            this.txtPrdCode.Text = this.ItemEntity.PrdCode;
            this.txtPrdName.Text = this.ItemEntity.PrdName;
            this.txtPrdSpec.Text = this.ItemEntity.PrdSpec;
            this.txtModel.Text = this.ItemEntity.Model;
            this.rchMemo.Text = this.ItemEntity.Memo; 
            this.NonHandleQty = this.ItemEntity.NonHandleQty;
            this.txtNonHandleQty.Text = string.Format("{0:0.####}", NonHandleQty);
            if (this.ItemEntity.DateTarget == DateTime.MinValue)
            {
                this.dtpDateTarget.Value = DateTime.Now.AddDays(3);
            }
            else
            {
                this.dtpDateTarget.Value = this.ItemEntity.DateTarget;
            }
            decimal StoreQty = this.Store.GetPrdAvailableQty(this.PrdID);
            this.txtStoreQty.Text = string.Format("{0:0.####}", StoreQty );
            decimal RoadQty = 0;
            this.accBuyOrderItems.GetParmBuyOrderItemsPrdAvailableQty(PrdID, ref RoadQty);
            this.txtRoadQty.Text = string.Format("{0:0.####}", RoadQty);
            decimal RequireQty = (this.NonHandleQty > StoreQty+RoadQty ) ? (this.NonHandleQty - StoreQty-RoadQty) : 0;
            this.txtRequireQty.Text = string.Format("{0:0.####}", RequireQty);
            this.txtAppendQty.Enabled = (RequireQty >=0);
            this.rchMemo.Text = this.ItemEntity.Memo;

           
            this.LoadPackingPlan();
           
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
        private decimal GetReserveQty(decimal RequireQty, decimal AvailableQty)
        {
            return ((RequireQty >= AvailableQty) ? (AvailableQty) : RequireQty);
        }
        private decimal GetManufQty(decimal RequireQty, decimal ReserveQty)
        {
            return ((RequireQty >= ReserveQty) ? (RequireQty - ReserveQty) : 0);
        }
       
        private void SaveBomHandle(int PrdID, decimal ManufQty)
        {
            decimal AvailableQty, ReserveQty;
            string errormsg = string.Empty;
            AvailableQty = this.Store.GetPrdAvailableQty(PrdID);
            ReserveQty = this.GetReserveQty(ManufQty, AvailableQty);
            if (ReserveQty > 0)
            {
                this.accStoreReserve.SaveStoreReserveForAppReserve(ref errormsg, PrdID , ReserveQty);
            }
            ManufQty = this.GetManufQty(ManufQty, ReserveQty);         
            if (ManufQty == 0) return;
             decimal AppendQty;
            if (!decimal.TryParse(this.txtAppendQty.Text, out AppendQty))
            {
                AppendQty = 0;
            }
            if (this.radManufFlag .Checked )
            {
               
                //生产计划
                bool PrdStoreFlag = true;
                this.accManufPlans.InsertManufPlans     (ref errormsg, 
                    DateTime .Now .Date ,
                    this.SaleOrderItemID ,
                    this.ItemEntity .CompanyID ,
                   PrdID ,
                   ManufQty+AppendQty,
                   PrdStoreFlag,
                   false,
                   this.dtpDateTarget .Value,
                   this.rchMemo .Text  ,
                   true,
                   JERPBiz .Frame .UserBiz .PsnID
                   );
            }
            if (this.radBuyFlag .Checked )
            {
                //采购计划
                this.accBuyPlan.SaveBuyPlans(ref errormsg,this.ItemEntity .PrdID  ,
                    ManufQty+AppendQty   );
              
            }    
        
        }

        void dgrdvPackingPlan_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            this.dgrdvPackingPlan[e.ColumnIndex, e.RowIndex].Value = DBNull.Value;
        }

      
      
        void btnCancel_Click(object sender, EventArgs e)
        {
            string errormsg = string.Empty;
            bool flag = false;
            //先整订单处理
            DialogResult rul = MessageBox.Show("您将订单下单处理,不作任何计划,适用于备库生产的类型！", "操作确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rul == DialogResult.No) return;
            flag = this.accSaleOrderItems.UpdateSaleOrderItemsForAppHandleQty(ref errormsg,
                this.SaleOrderItemID,
                this.NonHandleQty);
            if (this.affterSave != null) this.affterSave();
            MessageBox.Show("成功进行当前订单处理！");
            this.Close();
        }

        void btnSave_Click(object sender, EventArgs e)
        {
            string errormsg = string.Empty;
            bool flag = false;
            //先整订单处理
            DialogResult rul = MessageBox.Show("您将订单下单处理，一经确认不能变更！", "操作确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rul == DialogResult.No) return;
            flag = this.accSaleOrderItems.UpdateSaleOrderItemsForAppHandleQty(ref errormsg,
                this.SaleOrderItemID,
                this.NonHandleQty);
            decimal AvailableQty = this.Store.GetPrdAvailableQty(this.PrdID);
            decimal ReserveQty = this.GetReserveQty(this.NonHandleQty, AvailableQty);
            if(ReserveQty >0)
            {
                this.accStoreReserve.SaveStoreReserveForAppReserve(ref errormsg, this.PrdID, ReserveQty); 
            }
            decimal ManufQty=this.GetManufQty (this.NonHandleQty ,ReserveQty );
            if (ManufQty > 0)
            {
                this.accBuyOrderItems.GetParmBuyOrderItemsPrdAvailableQty(this.PrdID, ref AvailableQty);
                ReserveQty = this.GetReserveQty(ManufQty, AvailableQty);
                if (ReserveQty > 0)
                {
                    this.accRoadReserve.SaveRoadStoreReserveForAppReserve(ref errormsg, this.PrdID, ReserveQty);
                }
            }
            ManufQty = this.GetManufQty(ManufQty, ReserveQty);
            if (ManufQty > 0)
            {
                this.SaveBomHandle(this.PrdID, ManufQty);
            }
            object objPackingTypeID = DBNull.Value;
            foreach (DataRow drow in this.dtblPackingPlans.Rows)
            {
                if (drow.RowState == DataRowState.Deleted) continue;
                this.accPackinngPlans.InsertPackingPlans(
                    ref errormsg,
                    ref objPackingTypeID ,
                   DateTime.Now.Date,
                   this.SaleOrderItemID ,
                   this.ItemEntity .CompanyID ,
                       this.PrdID, 
                       drow["PackingTypeID"],
                       drow["Quantity"],
                       drow["DateTarget"],
                       this.rchMemo.Text, 
                       JERPBiz.Frame.UserBiz.PsnID
                       );

            }
            if (this.affterSave != null) this.affterSave();
            MessageBox.Show("成功进行当前订单生产下单！");
            this.Close();
        }

     


     
    }
}