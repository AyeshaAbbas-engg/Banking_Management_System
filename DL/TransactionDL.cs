using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp1.DL
{
    public class TransactionDL
    {
        public static  bool HasExceededOverdraftLimit(int accountId, decimal withdrawalAmount)
        {
            string query = $@"
        SELECT 
            a.OverdraftLimit,
            IFNULL(SUM(l.Amount), 0) AS TotalToday
        FROM Account a
        LEFT JOIN AuditTransactionLog l ON a.AccountID = l.AccountID 
            AND DATE(l.timeoftransaction) = CURDATE()
        WHERE a.AccountID = {accountId}
          AND a.AccountType = 'Current'
        GROUP BY a.OverdraftLimit";

            using (var connection = DataBaseHelper.Instance.getConnection())
            {
                using (var command = new MySqlCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            decimal overdraftLimit = reader.GetDecimal("OverdraftLimit");
                            decimal totalToday = reader.GetDecimal("TotalToday");

                            return (totalToday + withdrawalAmount) > overdraftLimit;
                        }
                    }
                }
            }

            // If no data found, assume it's not a current account or doesn't exist
            return false;
        }

        public static bool InsertTransaction(int senderId, int receiverId, int fromBranchId, int toBranchId, decimal amount)
        {
            using (var con = DataBaseHelper.Instance.getConnection())
            using (var trans = con.BeginTransaction())
            {
                try
                {
                    if (senderId == receiverId)
                        throw new Exception("Sender and receiver cannot be the same.");
                    if (amount <= 0)
                        throw new Exception("Amount must be greater than zero.");

                    // 1. Validate receiver exists and is active
                    string checkReceiver = $"SELECT COUNT(*) FROM account WHERE AccountID = {receiverId} AND Status = 'Active'";
                    var receiverCmd = new MySqlCommand(checkReceiver, con, trans);
                    int receiverCount = Convert.ToInt32(receiverCmd.ExecuteScalar());
                    if (receiverCount == 0)
                        throw new Exception("Receiver account does not exist or is not active.");

                    // 2. Get sender info
                    string senderQuery = $"SELECT AccountType, Balance FROM account WHERE AccountID = {senderId}";
                    var senderCmd = new MySqlCommand(senderQuery, con, trans);
                    string senderType = "";
                    decimal senderBalance = 0;

                    using (var reader = senderCmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            senderType = reader["AccountType"].ToString();
                            senderBalance = Convert.ToDecimal(reader["Balance"]);
                        }
                        else
                        {
                            throw new Exception("Sender account not found.");
                        }
                    }

                    // 3. Get receiver account type
                    string receiverType = "";
                    string receiverQuery = $"SELECT AccountType FROM account WHERE AccountID = {receiverId}";
                    var receiverTypeCmd = new MySqlCommand(receiverQuery, con, trans);
                    receiverType = receiverTypeCmd.ExecuteScalar()?.ToString();
                    if (string.IsNullOrEmpty(receiverType))
                        throw new Exception("Receiver account type not found.");

                    // 4. Determine fees
                    decimal fee = 0;
                    if (fromBranchId != toBranchId)
                    {
                        fee = 100; // branch to branch
                    }

                    if ((senderType == "Saving" && receiverType == "Current") || (senderType == "Current" && receiverType == "Saving"))
                    {
                        fee += 250;
                    }

                    decimal totalDebit = amount + fee;

                    // 5. Check balance
                    if (senderBalance < totalDebit)
                        throw new Exception("Insufficient balance including transaction fees.");

                    // 6. Update sender balance
                    string deduct = $"UPDATE account SET Balance = Balance - {totalDebit} WHERE AccountID = {senderId}";
                    new MySqlCommand(deduct, con, trans).ExecuteNonQuery();

                    // 7. Update receiver balance
                    string add = $"UPDATE account SET Balance = Balance + {amount} WHERE AccountID = {receiverId}";
                    new MySqlCommand(add, con, trans).ExecuteNonQuery();

                    // 8. Insert into transactions
                    string type = fromBranchId == toBranchId ? "WithBranch" : "BranchToBranch";
                    string insert = $@"
                        INSERT INTO transactions 
                        (SenderAccountID, ReceiverAccountID, FromBranchID, ToBranchID, Amount, Fee,Status)
                        VALUES ({senderId}, {receiverId}, {fromBranchId}, {toBranchId}, {amount}, {fee},'Completed')";
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
        public static bool IsReceiverValid(int receiverId)
        {
            string q = receiverId.ToString();
            using (var con = DataBaseHelper.Instance.getConnection())
            {
                string query = $"SELECT COUNT(*) FROM account WHERE AccountNumber = '{q}' AND Status = 'Active'";
                var cmd = new MySqlCommand(query, con);
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0;
            }
        }
    }
}
