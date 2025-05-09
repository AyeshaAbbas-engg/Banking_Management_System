using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.BL
{
    internal class SavingAccountBL:AccountBl
    {
        public decimal InterestRate { get; set; }
        public SavingAccountBL(string accountType, decimal balance,  int branchID,int CustomerID, decimal interestRate,string accountNumber)
            : base(accountType, balance,   branchID,CustomerID,accountNumber)
        {
            InterestRate = interestRate;
        }

        public override decimal GetInterestRate()
        {
            return InterestRate;
        }
    }
}
