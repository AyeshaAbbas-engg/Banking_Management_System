using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp1.DL
{
    public class TransactionDL
    {
        public static bool ExecuteTransfer(int fromAcc, int toAcc, decimal amount, string remarks)
        {
            using (MySqlConnection con = DataBaseHelper.Instance.getConnection())
            {
                con.Open();
                MySqlTransaction transaction = con.BeginTransaction();

                try
                {
                    if (fromAcc == toAcc)
                        throw new Exception("Cannot transfer to the same account.");

                    // Check both accounts exist and belong to same branch
                    string checkQuery = $@"
                    SELECT a1.Balance, a1.BranchID AS Branch1, a2.BranchID AS Branch2 
                    FROM Accounts a1, Accounts a2 
                    WHERE a1.AccountID = {fromAcc} AND a2.AccountID = {toAcc}";

                    MySqlCommand checkCmd = new MySqlCommand(checkQuery, con, transaction);
                    using (MySqlDataReader reader = checkCmd.ExecuteReader())
                    {

                        if (!reader.Read())
                            throw new Exception("One or both accounts do not exist.");

                        decimal balance = reader.GetDecimal("Balance");
                        int branch1 = reader.GetInt32("Branch1");
                        int branch2 = reader.GetInt32("Branch2");

                        if (branch1 != branch2)
                            throw new Exception("Accounts are not in the same branch.");

                        if (balance < amount)
                            throw new Exception("Insufficient balance.");

                        reader.Close();
                    }
                    // Deduct from sender
                    string debitQuery = $"UPDATE Accounts SET Balance = Balance - {amount} WHERE AccountID = {fromAcc}";
                    MySqlCommand debitCmd = new MySqlCommand(debitQuery, con, transaction);
                    debitCmd.ExecuteNonQuery();

                    // Credit to receiver
                    string creditQuery = $"UPDATE Accounts SET Balance = Balance + {amount} WHERE AccountID = {toAcc}";
                    MySqlCommand creditCmd = new MySqlCommand(creditQuery, con, transaction);
                    creditCmd.ExecuteNonQuery();

                    // Record successful transaction
                    string insertTxn = $@"
                    INSERT INTO Transactions (FromAccountID, ToAccountID, Amount, Remarks, Status)
                    VALUES ({fromAcc}, {toAcc}, {amount}, '{remarks}', 'Success')";
                    MySqlCommand txnCmd = new MySqlCommand(insertTxn, con, transaction);
                    txnCmd.ExecuteNonQuery();

                    transaction.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    try
                    {
                        // Record failed transaction
                        string failTxn = $@"
                        INSERT INTO Transactions (FromAccountID, ToAccountID, Amount, Remarks, Status)
                        VALUES ({fromAcc}, {toAcc}, {amount}, '[FAILED] {ex.Message}', 'Failed')";
                        MySqlCommand failCmd = new MySqlCommand(failTxn, con, transaction);
                        failCmd.ExecuteNonQuery();

                        transaction.Rollback();
                    }
                    catch { }

                    return false;
                }
            }

        }
    }
}
