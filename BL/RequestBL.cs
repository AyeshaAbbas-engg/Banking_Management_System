using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.DL;

namespace WindowsFormsApp1.BL
{
    public class RequestBL
    {
        public int RequestID { get; set; } // Optional if auto-generated
        public int CustomerID { get; set; }
        public int BranchID { get; set; }
        public int AccountID { get; set; }
        public string ServiceTypeID { get; set; }
        public DateTime RequestDate { get; set; }
        public decimal Amount { get; set; }


        public static int CreateRequest(int customerID, int branchID, int accountID, int serviceTypeID, DateTime requestDate)
        {

            return RequestDL.CreateRequest(customerID, branchID, accountID, serviceTypeID, requestDate);
        
        }
        public static int CreateloanRequest(int customerID, int branchID, int accountID, decimal amount)
        {
            return RequestDL.CreateLoanRequest(customerID, branchID, accountID, amount);
        }
        public static int GetBranchID(int accountID)
        {
            return RequestDL.branchid(accountID);
        }
        public static int GetCustomerID(int accountID)
        {
            return RequestDL.GetCustomerID(accountID);
        }
        public static bool IssueLoan(int requestID)
        {
            return RequestDL.issueloan(requestID);
        }

    }
}

