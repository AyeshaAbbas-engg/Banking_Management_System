using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.DL;

namespace WindowsFormsApp1.BL
{
    internal class ATMBL
    {
        public string AccountNumber { get; set; }
        public string Pin { get; set; }
        public ATMBL(string account , string pin) {
            AccountNumber = account;
            Pin = pin;
        }
        public bool DoWithdral(string account, string pin,decimal amount)
        {
            if (ATMDL.CreditNumberExists(account, pin))
            {
                int balance = ATMDL.AccountBalance(account, pin);
                if (balance < amount)
                    throw new Exception("Insufficiant Balance");
                if (ATMDL.Accounttype(account, pin) == "Saving" && balance - amount < 500)
                    throw new Exception("Minimum balance of 500 should be maintained for saving Account");
                if (ATMDL.Statustype(account, pin) != "Active")
                    throw new Exception("Account is not active");
                if (ATMDL.Accounttype(account, pin) == "Current" && ATMDL.Overdraft(account, pin) < amount)
                    throw new Exception("Overdraft limit exceeded");
                if (TransactionDL.HasExceededOverdraftLimit(int.Parse(account), amount)) 
                    throw new Exception("Overdraft limit for One day has been Exceeded");
                else
                    ATMDL.UpdateBalance(account, pin, amount);
            }
            else
                throw new Exception("WithDrawl has been cancelled"); return false;
        }
    }

}
