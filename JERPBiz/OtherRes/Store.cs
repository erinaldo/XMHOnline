using System;
using System.Data;
using System.Text;
using System.Collections.Generic;

namespace JERPBiz.OtherRes
{
    public class Store
    {
        private JERPData.OtherRes.Store accStore;
        public Store()
        {
            this.accStore = new JERPData.OtherRes.Store();
        }
        public decimal GetStoreQty(int PrdID,int BranchStoreID)
        {
            decimal rut = 0;
            this.accStore.GetParmStoreInventoryQty(PrdID,BranchStoreID,ref rut);
            return rut;
        }
        public decimal GetPrdAvailableQty(int PrdID)
        {
            decimal rut = 0;
            this.accStore.GetParmStorePrdAvailableInventoryQty  (PrdID, ref rut);
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
