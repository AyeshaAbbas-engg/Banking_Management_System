using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.DL
{
    public class RequestDL
    {
        public static int CreateRequest(int customerID, int branchID, int accountID, int serviceType, DateTime requestDate)
        {
            string formattedDate = requestDate.ToString("yyyy-MM-dd HH:mm:ss"); 
            string query = $"INSERT INTO serviceRequests(CustomerID, BranchID, AccountID, ServiceType, RequestDate) " +
                           $"VALUES ({customerID}, {branchID}, {accountID}, {serviceType}, '{formattedDate}');";
            return DataBaseHelper.Instance.Update(query);
        }
        public static int CreateLoanRequest(int customerID, int branchID, int accountID, decimal amount)
        {

            string query = $"INSERT INTO laonrequest(CustomerID, BranchID, AccountID,   Amount) " +
                           $"VALUES ({customerID}, {branchID}, {accountID},  {amount});";
            return DataBaseHelper.Instance.Update(query);
        }
        public static int branchid(int accountID)
        {
            string query = $"SELECT BranchID FROM account WHERE AccountID = {accountID};";
            object Id = DataBaseHelper.Instance.ExecuteScalar(query);
            int result = Convert.ToInt32(Id);
            return result;
        }
        public static int GetCustomerID(int accountID)
        {
            string query = $"SELECT CustomerID FROM account WHERE AccountID = {accountID};";
            object Id = DataBaseHelper.Instance.ExecuteScalar(query);
            int result = Convert.ToInt32(Id);
            return result;
        }
        public static bool issueloan(int requestID)
        {
            string query = $"UPDATE laonrequest SET Status = 'Approved' WHERE LoanRequestID = {requestID};";

            int result = DataBaseHelper.Instance.Update(query);
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool loanApprove(int requestID, int accountID, decimal loanAmount, int performedBy)
        {
            string query = "CALL ApproveLoanRequest(" + requestID + ", " + accountID + ", " + loanAmount.ToString("0.00") + ", " + performedBy + ")";
            int result = DataBaseHelper.Instance.Update(query);

            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool LoanAvailable(decimal amount)
        {
            decimal fund = BankFundManagementDL.loadTotalFund();

            if (amount < fund)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static int loadAccount(int requestID)
        {
            string query = $"SELECT AccountID from laonrequest WHERE LoanRequestID={requestID}";
            object Id = DataBaseHelper.Instance.ExecuteScalar(query);
            int result = Convert.ToInt32(Id);
            return result;
        }
    }
}
