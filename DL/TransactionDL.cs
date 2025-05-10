using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp1.DL
{
    public class TransactionDL
    {
        public static bool InsertTransaction(int senderId, int receiverId, int fromBranchId, int toBranchId, decimal amount)
        {
            using (var con = DataBaseHelper.Instance.getConnection())
            using (var trans = con.BeginTransaction())
            {
                try
                {
                    // 1. Check sender balance
                    string checkBal = $"SELECT Balance FROM account WHERE AccountID = {senderId}";
                    var checkCmd = new MySqlCommand(checkBal, con, trans);
                    decimal senderBalance = Convert.ToDecimal(checkCmd.ExecuteScalar());

                    if (senderBalance < amount)
                        throw new Exception("Insufficient balance.");

                    // 2. Deduct from sender
                    string deduct = $"UPDATE account SET Balance = Balance - {amount} WHERE AccountID = {senderId}";
                    new MySqlCommand(deduct, con, trans).ExecuteNonQuery();

                    // 3. Add to receiver
                    string add = $"UPDATE account SET Balance = Balance + {amount} WHERE AccountID = {receiverId}";
                    new MySqlCommand(add, con, trans).ExecuteNonQuery();

                    // 4. Insert transaction
                    string type = fromBranchId == toBranchId ? "WithBranch" : "BranchToBranch";
                    string insert = $@"
                    INSERT INTO transactions 
                    (SenderAccountID, ReceiverAccountID, FromBranchID, ToBranchID, Amount, TransactionType, TransactionDate, Status)
                    VALUES ({senderId}, {receiverId}, {fromBranchId}, {toBranchId}, {amount}, '{type}', NOW(), 'Completed')";
                    new MySqlCommand(insert, con, trans).ExecuteNonQuery();

                    trans.Commit();
                    return true;
                }
                catch
                {
                    trans.Rollback();
                    throw;
                }
            }
        }

        public static DataTable GetAllTransactions()
        {
            string query = "SELECT * FROM Transactions ORDER BY TransactionDate DESC";
            return DataBaseHelper.GetData(query);
        }
    }
}
