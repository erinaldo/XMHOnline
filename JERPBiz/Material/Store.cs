using System;
using System.Data;
using System.Text;
using System.Collections.Generic;

namespace JERPBiz.Material
{
    public class Store
    {
        private JERPData.Material.Store accStore;
        public Store()
        {
            this.accStore = new JERPData.Material.Store();
        }
        public decimal GetStoreQty(int PrdID,int BranchStoreID)
        {
            decimal rut = 0;
            this.accStore.GetParmStoreInventoryQty(PrdID,BranchStoreID,ref rut);
            return rut;
        }
        public decimal GetPrdStoreQty(int PrdID)
        {
            decimal rut = 0;
            this.accStore.GetParmStorePrdInventoryQty (PrdID, ref rut);
            return rut;
        }
        public decimal GetPrdAvailableQty(int PrdID)
        {
            decimal rut = 0;
            this.accStore.GetParmStorePrdAvailableInventoryQty  (PrdID, ref rut);
            return rut;
        }
        public decimal GetPrdAvailableManufQty(int PrdID)
        {
            decimal rut = 0;
            this.accStore.GetParmStorePrdAvailableManufInventoryQty(PrdID, ref rut);
            return rut;
        }
        public decimal GetInventoryPrice(int PrdID,int BranchStoreID)
        {
            decimal rut = 0;
            this.accStore.GetParmStoreInventoryPrice (PrdID,BranchStoreID,ref rut);
            return rut;
        }
    }
}
