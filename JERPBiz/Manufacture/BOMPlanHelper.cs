using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
namespace JERPBiz.Manufacture
{
    public class BOMPlanHelper
    {
        public BOMPlanHelper()
        {
            //算料保存之东东
            this.bizStore = new JERPBiz.Material.Store();
            this.accStoreReserve = new JERPData.Material.StoreReserve();
            this.accBuyPlan = new JERPData.Material.BuyPlans();
            this.accRoadReserve = new JERPData.Material.RoadStoreReserve();
            this.accManufPlans = new JERPData.Manufacture.ManufPlans();
            this.accBuyOrderItems = new JERPData.Material.BuyOrderItems();
            this.accOutSrcStore = new JERPData.Material.OutSrcStore();
            this.accOutSrcStoreReserve = new JERPData.Material.OutSrcStoreReserve();
            this.accOEMOrderItems = new JERPData.Material.OEMOrderItems();
            this.bizOEMStore = new JERPBiz.Material.OEMStore();
            this.accOEMPlan = new JERPData.Material.OEMPlans();
            this.accOEMRoadReserve = new JERPData.Material.OEMRoadStoreReserve();
            this.accOEMStoreReserve = new JERPData.Material.OEMStoreReserve();
        }
        //算料保存之东东
        private JERPData.Material.BuyOrderItems accBuyOrderItems;
        //产品库存及预留
        private JERPBiz.Material.Store bizStore;
        private JERPData.Material.StoreReserve accStoreReserve;
        private JERPData.Material.RoadStoreReserve accRoadReserve;
        private JERPData.Material.BuyPlans accBuyPlan;


        private JERPData.Material.OEMOrderItems accOEMOrderItems;
        private JERPBiz.Material.OEMStore bizOEMStore;
        private JERPData.Material.OEMStoreReserve accOEMStoreReserve;
        private JERPData.Material.OEMRoadStoreReserve accOEMRoadReserve;
        private JERPData.Material.OEMPlans accOEMPlan;

        private JERPData.Material.OutSrcStore accOutSrcStore;
        private JERPData.Material.OutSrcStoreReserve accOutSrcStoreReserve;
        private JERPData.Manufacture.ManufPlans   accManufPlans;
       
        public  decimal GetStoreAvailableQty(int PrdID)
        {
            return this.bizStore.GetPrdAvailableQty(PrdID);
        }

        public  decimal GetOutSrcAvailabelQty(int OutSrcCompanyID,int PrdID)
        {
            decimal rut = 0;
            this.accOutSrcStore.GetParmOutSrcStoreAvailableInventoryQty(OutSrcCompanyID , PrdID, ref rut);
            return rut;
        }

        public  decimal GetRoadAvailableQty(int PrdID)
        {
            decimal rut = 0;
            this.accBuyOrderItems.GetParmBuyOrderItemsPrdAvailableQty(PrdID,
                ref rut);
            return rut;
        }
        public  decimal GetOEMStoreAvailableQty(int CustomerID, int PrdID)
        {
            return this.bizOEMStore.GetAvailableQty(CustomerID, PrdID);
        }
        public  decimal GetOEMRoadAvailableQty(int CustomerID, int PrdID)
        {
            decimal rut = 0;
            this.accOEMOrderItems.GetParmOEMOrderItemsPrdAvailableQty(CustomerID, PrdID,
                ref rut);
            return rut;
        }

        public  decimal GetReserveQty(decimal RequireQty, decimal AvailableQty)
        {
            return ((RequireQty >= AvailableQty) ? (AvailableQty) : RequireQty);
        }
        public  decimal GetPlanQty(decimal RequireQty, decimal ReserveQty)
        {
            return ((RequireQty >= ReserveQty) ? (RequireQty - ReserveQty) : 0);
        }
        public  void BOMOutSrcHandle(int OutSrcCompanyID,int PrdID, ref decimal RequireQty)
        {
            string errormsg = string.Empty;
            if (OutSrcCompanyID == -1) return;
            //如果此工序是委外，这里做一个委外库处理及预留
            decimal AvailableQty = this.GetOutSrcAvailabelQty(OutSrcCompanyID,PrdID);
            decimal ReserveQty = this.GetReserveQty(RequireQty, AvailableQty);
            if (ReserveQty > 0)
            {
                this.accOutSrcStoreReserve.SaveOutSrcStoreReserveForAppReserve(ref errormsg,
                    OutSrcCompanyID,
                    PrdID,
                    ReserveQty);
            }
            RequireQty = this.GetPlanQty(RequireQty, ReserveQty);

        }
        public  void BOMHandle(int CustomerID, int PrdID, decimal RequireQty, int SourceTypeID)
        {
            string errormsg = string.Empty;
            //自产和采购
            decimal AvailableQty = this.GetStoreAvailableQty(PrdID); 
            decimal ReserveQty = this.GetReserveQty(RequireQty, AvailableQty);
            //预留进去了
            if (ReserveQty > 0)
            { 
                this.accStoreReserve.SaveStoreReserveForAppReserve(ref errormsg, PrdID, ReserveQty);
                 
            }
            RequireQty = this.GetPlanQty(RequireQty, ReserveQty);

            if (RequireQty <= 0) return;
            AvailableQty = this.GetRoadAvailableQty(PrdID); 
            ReserveQty = this.GetReserveQty(RequireQty, AvailableQty);
            if (ReserveQty > 0)
            {
                this.accRoadReserve.SaveRoadStoreReserveForAppReserve(ref errormsg,
                    PrdID,
                    ReserveQty);
               
            }
            decimal PlanQty = this.GetPlanQty(RequireQty, ReserveQty);
            if (PlanQty <= 0) return;
            if (SourceTypeID == 1)
            {
                //下一级的生产计划
                this.accManufPlans.InsertManufPlans  (ref errormsg, 
                    DateTime .Now.Date,
                    DBNull .Value ,
                    CustomerID,
                    PrdID,
                    PlanQty,
                    false,
                    true, 
                    DBNull.Value,
                    "计算生产",
                    false,
                    JERPBiz.Frame.UserBiz.PsnID);
            }
            if (SourceTypeID == 2)
            {
                //采购计划
                this.accBuyPlan.SaveBuyPlans(
                    ref errormsg,
                    PrdID,
                    PlanQty);
            }
          
        }
        public  void BOMOEMHandle(int CustomerID, int PrdID, decimal RequireQty)
        {
            string errormsg = string.Empty;
            //自产和采购
            decimal AvailableQty = this.GetOEMStoreAvailableQty(CustomerID, PrdID);
            decimal ReserveQty = this.GetReserveQty(RequireQty, AvailableQty);
            //预留进去了
            if (ReserveQty > 0)
            {
                this.accOEMStoreReserve.SaveOEMStoreReserveAppReserve(ref errormsg, CustomerID, PrdID, ReserveQty);
            }
            RequireQty = this.GetPlanQty(RequireQty, ReserveQty);
            if (RequireQty <= 0) return;
            AvailableQty = this.GetOEMRoadAvailableQty(CustomerID, PrdID);
            ReserveQty = this.GetReserveQty(RequireQty, AvailableQty);
            if (ReserveQty > 0)
            {
                this.accOEMRoadReserve.SaveOEMRoadStoreReserveAppReserve(ref errormsg,
                    CustomerID,
                    PrdID,
                    ReserveQty);
            }
            decimal PlanQty = this.GetPlanQty(RequireQty, ReserveQty);
            if (PlanQty <= 0) return;
            //客供计划
            this.accOEMPlan.SaveOEMPlans(
                ref errormsg,
                CustomerID,
                PrdID,
                PlanQty);
        }
    }
}
