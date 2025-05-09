using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.BL
{
    internal class CurrentAccountBL: AccountBl
    {
        public decimal OverdraftLimit { get; set; }
        public CurrentAccountBL(string accountType, decimal balance,  int branchID,int CustomerID, decimal overdraftLimit,string accountNumber)
            : base(accountType, balance,   branchID, CustomerID, accountNumber)
        {
            OverdraftLimit = overdraftLimit;
        }
        public override decimal GetOverdraftLimit()
        {
            return OverdraftLimit;
        }
    }
    
}
