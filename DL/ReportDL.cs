using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.DL
{
    internal class ReportDL
    {
        public static DataTable TakeAccountSummaryPerBranch()
        {
            string query1 =
     "SELECT " +
     "  b.BranchName,  " +
     "  COUNT(a.AccountID) AS TotalAccounts, " +
     "  SUM(a.Balance) AS TotalBalance, " +
     "  a.AccountType " +
     "FROM account a " +
     "JOIN Branch b ON a.BranchID = b.BranchID " +
     "GROUP BY a.BranchID, a.AccountType;";

            return DataBaseHelper.Instance.ExecuteQuery(query1);
        }

        public static DataTable TotalTransactionperbranch()
        {
            string query2 =
    "SELECT b.BranchName, DATE(t.TransactionDate) AS TransactionDate, COUNT(t.TransactionID) AS TotalTransactions, SUM(t.Amount) AS TotalAmount " +
    "FROM Transactions t " +
    "JOIN account sa ON t.SenderAccountID = sa.AccountID " +
    "JOIN branch b ON sa.BranchID = b.BranchID " +
    "WHERE DATE(t.TransactionDate) = CURDATE() " +
    "GROUP BY b.BranchID, DATE(t.TransactionDate);";


            return DataBaseHelper.Instance.ExecuteQuery(query2);
        }
        public static DataTable CustomerRecentTrnasaction()
        {
            string query = $"SELECT \r\n    t.TransactionID,\r\n    sa.AccountNumber AS SenderAccount,\r\n    ra.AccountNumber AS ReceiverAccount,\r\n    t.Amount,\r\n        t.TransactionDate,\r\n    t.Status\r\nFROM Transactions t\r\nJOIN Account sa ON t.SenderAccountID = sa.AccountID\r\nJOIN Account ra ON t.ReceiverAccountID = ra.AccountID\r\nORDER BY t.TransactionDate DESC\r\nLIMIT 1;";
;
            return DataBaseHelper.Instance.ExecuteQuery(query);
        }
        public static DataTable ChequeTrnasaction()
        {
            string query = $"SELECT cb.ChequeBookID, a.AccountNumber, cb.TotalLeaves, cb.UsedLeaves, cb.IsFullyUsed, cb.Status\r\nFROM ChequeBooks cb\r\nJOIN Account a ON cb.AccountID = a.AccountID;";
            ;
            return DataBaseHelper.Instance.ExecuteQuery(query);
        }
        public static DataTable Trnasactionhistory()
        {
            string query = $"SELECT t.TransactionID, sa.AccountNumber AS Sender, ra.AccountNumber AS Receiver,\r\n       t.Amount, t.TransactionType, t.TransactionDate, t.Status\r\nFROM Transactions t\r\nJOIN account sa ON t.SenderAccountID = sa.AccountID\r\nJOIN account ra ON t.ReceiverAccountID = ra.AccountID\r\nORDER BY t.TransactionDate DESC;";
            ;
            return DataBaseHelper.Instance.ExecuteQuery(query);
        } public static DataTable Accountbala()
        {
            string query = $"SELECT a.AccountID, a.AccountNumber, a.AccountType, a.Balance, a.Status, c.Name AS CustomerName, b.BranchName\r\nFROM Account a\r\nJOIN Customer c ON a.CustomerID = c.CustomerID\r\nJOIN Branch b ON a.BranchID = b.BranchID;";
            ;
            return DataBaseHelper.Instance.ExecuteQuery(query);
        }



    }
}
