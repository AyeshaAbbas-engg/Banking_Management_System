using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.DL
{
    internal class LoanPaymentDL
    {
        public static DataTable LoadLoan(int customerID)
        {
            string query = $@"
            SELECT AccountID, CONCAT('A/C# ', AccountNumber, ' (', AccountType, ')') AS DisplayName
            FROM account
            WHERE CustomerID = {customerID
            } ";
            DataTable dt = DataBaseHelper.Instance.ExecuteQuery(query);
            return dt;
        }
        public static DataTable loadInstallments(int loanID)
        {
            string query=$@"SELECT InstallmentID,DueDate,Amount,Status FROM loaninstallments             WHERE LoanID = {loanID}";
            DataTable dt = DataBaseHelper.Instance.ExecuteQuery(query);
            return dt;
        }
        public static string PayInstallment(int installmentID, int accountID, int performedBy, int receivedBy)
        {
            // installment
            string query = $"SELECT LoanID, Amount, DueDate, Status FROM loaninstallments WHERE InstallmentID = {installmentID}";
            DataTable dt = DataBaseHelper.Instance.ExecuteQuery(query);

            if (dt.Rows.Count == 0)
                return "Installment not found.";

            DataRow row = dt.Rows[0];
            int loanID = Convert.ToInt32(row["LoanID"]);
            decimal amount = Convert.ToDecimal(row["Amount"]);
            DateTime dueDate = Convert.ToDateTime(row["DueDate"]);
            string status = row["Status"].ToString();

            // 2. Check if already paid
            if (status == "Paid")
                return "This installment is already paid.";

            // 3. Check due date range
            int daysDifference = (dueDate - DateTime.Now).Days;
            if (daysDifference > 30)
                return "Installment cannot be paid. Due date is more than 30 days ahead.";

            // 4. Check account balance
            string balanceQuery = $"SELECT Balance FROM account WHERE AccountID = {accountID}";
            object result = DataBaseHelper.Instance.ExecuteScalar(balanceQuery);
            decimal balance = result != null ? Convert.ToDecimal(result) : 0;

            if (balance < amount)
                return "Insufficient balance.";

            // 5. Run all updates in single combined query
            string updateQuery = $@"
        INSERT INTO loanpayment (LoanID, AccountID, PaidAmount, PerformedBy, ReceivedBy) 
        VALUES ({loanID}, {accountID}, {amount}, {performedBy}, {receivedBy});
        
        UPDATE loaninstallments SET Status = 'Paid' WHERE InstallmentID = {installmentID};
        
        UPDATE account SET Balance = Balance - {amount} WHERE AccountID = {accountID};
        Update bankfund SET TotalAmount = TotalAmount + {amount} where FundID=2;


    ";

            int rowsAffected = DataBaseHelper.Instance.Update(updateQuery);

            return rowsAffected > 0 ? "Installment paid successfully." : "Failed to pay installment.";
        }

    }
}
