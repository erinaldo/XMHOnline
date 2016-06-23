using System;
using System.Collections.Generic;
using System.Text;

namespace JERPBiz.Finance
{
    public class MoneyTypeParm
    {
        public MoneyTypeParm()
        {
            this.accMoneyType = new JERPData.Finance.MoneyType();
        }
        private JERPData.Finance.MoneyType accMoneyType;
        public  int GetMainMoneyTypeID()
        {
            int rut = 0;
            this.accMoneyType.GetParmMoneyTypeMainMoneyTypeID(ref rut);
            return rut;
        }
        public string GetMainMoneyTypeName()
        {
            string rut = string.Empty;
            this.accMoneyType.GetParmMoneyTypeMainMoneyTypeName(ref rut);
            return rut;
        }
        public decimal  GetExchangeRate(int MoneyTypeID)
        {
            decimal rut = 0;
            this.accMoneyType.GetParmMoneyTypeExchangeRate(MoneyTypeID, ref rut);
            return rut;
        }
    }
}
