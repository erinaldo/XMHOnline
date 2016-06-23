using System;
using System.Collections.Generic;
using System.Text;

namespace JERPBiz.Finance
{
    public class AccountType
    {
        
        public const  int iCash = 1;
        public const string Cash = "现金";
        public const int iBank = 2;
        public const string Bank = "银行存款";
        public const int iReceivable = 3;
        public const string Receivable = "应收账款";
        public const int iExpressReceivable = 4;
        public const string ExpressReceivable = "代收货款";
        public const int iPayable = 5;
        public const string Payable = "应付账款";
        public const int iExpressPayable = 6;
        public const string ExpressPayable = "应付运费";
        public const int iExpense = 7;
        public const string Expense = "费用";
        public const int iRevenue = 8;
        public const string Revenue = "收入";
    }
}
