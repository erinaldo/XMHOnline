using System;
using System.Data;
using System.Text;
using System.Collections.Generic;

namespace JERPBiz.Material
{
    public class OEMStore
    {
        private JERPData.Material.OEMStore accStore;
        public OEMStore()
        {
            this.accStore = new JERPData.Material.OEMStore();
        }
        public decimal GetStoreQty(int CompanyID,int PrdID)
        {
            decimal rut = 0;
            this.accStore.GetParmOEMStoreInventoryQty(CompanyID ,PrdID ,ref rut);
            return rut;
        }
        public decimal GetAvailableQty(int CompanyID,int PrdID)
        {
            decimal rut = 0;
            this.accStore.GetParmOEMStoreAvailableStoreQty(CompanyID,PrdID, ref rut);
            return rut;
        }
       
    }
}
