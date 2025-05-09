using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.BL
{
    internal class AccountBl
    {
        public int AccountID { get; set; }
        public string AccountType { get; set; }
        public decimal Balance { get; set; }
        public string Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public int BranchID { get; set; }
        public int CustomerID { get; set; }
        public string AccountNumber { get; set; }
        public AccountBl()
        { }
        public AccountBl(string accountType, decimal balance,   int branchID, int customerID, string accountNumber)
        {

            AccountType = accountType;
            Balance = balance;
            //Status = status;
            //CreatedDate = createdDate;
            BranchID = branchID;
            CustomerID = customerID;
            AccountNumber = accountNumber;
        }
        public AccountBl(int accountID, string accountType, decimal balance,   int branchID,int customerID,string accountNumber)
        {
            AccountID = accountID;
            AccountType = accountType;
            Balance = balance;
            //Status = status;
            //CreatedDate = createdDate;
            BranchID = branchID;
            CustomerID = customerID;
            AccountNumber = accountNumber;
        }

        public virtual decimal GetInterestRate()
        {
            return 0;
        }

        public virtual decimal GetOverdraftLimit()
        {
            return 0;
        }
    }
}
