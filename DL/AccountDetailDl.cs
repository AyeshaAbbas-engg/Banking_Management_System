using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.BL;

namespace WindowsFormsApp1.DL
{
    internal class AccountDetailDl
    {
        public static bool AddAccount(AccountBl account)
        {
            decimal interestRate = 0;
            decimal overdraftLimit = 0;

            if (account is SavingAccountBL s)
            {
                interestRate = s.InterestRate;
            }
            else if (account is CurrentAccountBL c)
            {
                overdraftLimit = c.OverdraftLimit;
            }
            string insertQuery = $"INSERT INTO account (AccountNumber,AccountType, Balance, InterestRate, OverdraftLimit, BranchID,CustomerID) VALUES ('{account.AccountNumber}','{account.AccountType}', {account.Balance},  {interestRate}, {overdraftLimit}, {account.BranchID},{account.CustomerID});";
            
            return DataBaseHelper.Instance.Update(insertQuery) > 0;

        }
        public static class AccountHelper
    {
    public static string GenerateUniqueAccountNumber()
    {
        Random random = new Random();
        string accountNumber;

        while (true)
        {
            accountNumber = random.Next(100000000, 1000000000).ToString(); // 9-digit number

            if (!AccountNumberExists(accountNumber))
                break;
        }

        return accountNumber;
    }

    private static bool AccountNumberExists(string accountNumber)
    {
        string query = $"SELECT COUNT(*) FROM account WHERE AccountNumber = '{accountNumber}'";
        object result = DataBaseHelper.Instance.ExecuteScalar(query);
        int count = Convert.ToInt32(result);
        return count > 0;
    }
}
        public static int SearchCustomer(string customerName,string email,string cnic)
        {
            string query = $"SELECT CustomerID from customer where Name='{customerName}'and Email='{email}'and CNIC='{cnic}'";
            object Id = DataBaseHelper.Instance.ExecuteScalar(query);
            int result = Convert.ToInt32(Id);
            return result;
        }
        public static string AccountType(string accountNumber)
        {
            string query = $"SELECT AccountType from account where AccountNumber='{accountNumber}'";
            object Id = DataBaseHelper.Instance.ExecuteScalar(query);
            string result = Id.ToString();
            return result;
        }
        public static decimal OverDraft(string accountNumber)
        {
            string query = $"SELECT OverdraftLimit from account where AccountNumber='{accountNumber}'";
            object Id = DataBaseHelper.Instance.ExecuteScalar(query);
            decimal result = Convert.ToDecimal(Id);
            return result;
        }
        public static decimal Interest(string accountNumber)
        {
            string query = $"SELECT InterestRate from account where AccountNumber='{accountNumber}'";
            object Id = DataBaseHelper.Instance.ExecuteScalar(query);
            decimal result = Convert.ToDecimal(Id);
            return result;
        }
        public static bool UpdateAccount(string accountNumber, decimal limit)
        {
            string query = $"UPDATE account SET OverdraftLimit = {limit} WHERE AccountNumber = '{accountNumber}'";
            return DataBaseHelper.Instance.Update(query) > 0;
        }
        public static bool UpdateSavingAccount(string accountNumber, decimal interest)
        {
            string query = $"UPDATE account SET InterestRate = {interest} WHERE AccountNumber = '{accountNumber}'";
            return DataBaseHelper.Instance.Update(query) > 0;
        }
        public static bool DeleteAccout(string accountNumber)
        {
            string query = $"Update account SET Status='Deleted' Where AccountNumber='{accountNumber}'";
            return DataBaseHelper.Instance.Update(query) > 0;
        }
    }
}
