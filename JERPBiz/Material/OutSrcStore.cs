using System;
using System.Data;
using System.Text;
using System.Collections.Generic;

namespace JERPBiz.Material
{
    public class OutSrcStore
    {
        private JERPData.Material.OutSrcStore accStore;
        public OutSrcStore()
        {
            this.accStore = new JERPData.Material.OutSrcStore();
        }
        public decimal GetStoreQty(int SupplierID, int PrdID)
        {
            decimal rut = 0;
            this.accStore.GetParmOutSrcStoreInventoryQty(SupplierID, PrdID, ref rut);
            return rut;
        }
        public decimal GetAvailableStoreQty(int SupplierID, int PrdID)
        {
            decimal rut = 0;
            this.accStore.GetParmOutSrcStoreAvailableInventoryQty(SupplierID,
                PrdID, ref rut);
            return rut;
        }
        public decimal GetPrdStoreQty(int PrdID)
        {
            decimal rut = 0;
            this.accStore.GetParmOutSrcStorePrdInventoryQty(PrdID, ref rut);
            return rut;
        }
        public decimal GetPrdAvailableManufQty(int PrdID)
        {
            decimal rut = 0;
            this.accStore.GetParmOutSrcStorePrdAvailableManufInventoryQty(PrdID, ref rut);
            return rut;
        }
    }
}
