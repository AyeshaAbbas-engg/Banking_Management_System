using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.BL;

namespace WindowsFormsApp1.DL
{
    internal class ATMDL
    {
        public static bool CreditNumberExists(string accountNumber,string pin)
        {
            string query = $"SELECT COUNT(*) FROM CreditCards WHERE CardNumber = '{accountNumber}' and pin ='{pin}'";
            object result = DataBaseHelper.Instance.ExecuteScalar(query);
            int count = Convert.ToInt32(result);
            return count > 0;
        }
        public static int AccountBalance(string accountNumber, string pin)
        {
            string query = $"SELECT Balance FROM Account join CreditCards on CreditCards.AccountID = Account.AccountID WHERE CardNumber = '{accountNumber}' and pin ='{pin}'";
            object result = DataBaseHelper.Instance.ExecuteScalar(query);
            int count = Convert.ToInt32(result);
            return count;
            
        }
        public static string Accounttype(string accountNumber, string pin)
        {
            string query = $"SELECT AccountType FROM Account join CreditCards on CreditCards.AccountID = Account.AccountID WHERE CardNumber = '{accountNumber}' and pin ='{pin}'";
            object result = DataBaseHelper.Instance.ExecuteScalar(query);
            string count = result.ToString();
            return count;

        }public static string Statustype(string accountNumber, string pin)
        {
            string query = $"SELECT Status FROM Account join CreditCards on CreditCards.AccountID = Account.AccountID WHERE CardNumber = '{accountNumber}' and pin ='{pin}'";
            object result = DataBaseHelper.Instance.ExecuteScalar(query);
            string count = result.ToString();
            return count;

        }public static decimal Overdraft(string accountNumber, string pin)
        {
            string query = $"SELECT Status FROM Account join CreditCards on CreditCards.AccountID = Account.AccountID WHERE CardNumber = '{accountNumber}' and pin ='{pin}'";
            object result = DataBaseHelper.Instance.ExecuteScalar(query);
            decimal count = Convert.ToDecimal(result);
            return count;

        }
        public static bool UpdateBalance(string accountNumber, string pin,decimal amount)
        {
            string updateEmployeeQuery = $"UPDATE Account SET Balance = Balance - {amount} join CreditCards on CreditCards.AccountID = Account.AccountID WHERE CardNumber = '{accountNumber}' and pin ='{pin}'";
            DataBaseHelper.Instance.Update(updateEmployeeQuery);
            return true;
        }
    }
}
