using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.DL
{
    public class CreditCardDL
    {
       
        public static bool AddCreditCard(int requestID, int customerID, string cardNumber, DateTime issueDate, DateTime expiryDate, decimal creditLimit, string status, string pin)
        {
            string query = "INSERT INTO CreditCards (RequestID, CustomerID, IssueDate, CardNumber, ExpiryDate, CreditLimit, Status,pin) " +
                           "VALUES (" + requestID + ", " + customerID + ", '" + issueDate.ToString("yyyy-MM-dd") + "', '" + cardNumber + "', '" + expiryDate.ToString("yyyy-MM-dd") + "', " + creditLimit + "', " + status + ", '" + pin + "')";
            return DataBaseHelper.Instance.Update(query) > 0;
        }
        public static bool ValidateCardPin(string cardNumber, string oldPin, int id)
        {
            string query = $"SELECT COUNT(*) FROM CreditCards WHERE CardNumber = '{cardNumber}' AND pin = '{oldPin}' and AND AccountID IN (SELECT AccountID FROM Account WHERE UserID = {id}";
            object result = DataBaseHelper.Instance.ExecuteScalar(query);
            int count = Convert.ToInt32(result);
            return count == 1;
        }

        public static bool UpdateCardPin(string cardNumber, string newPin,int id)
        {
            string query = $"UPDATE CreditCards SET pin = '{newPin}' WHERE CardNumber = '{cardNumber}' AND AccountID IN (SELECT AccountID FROM Account WHERE UserID = {id}";
            int rowsAffected = DataBaseHelper.Instance.Update(query);
            return rowsAffected > 0;
        }public static void Block(int id)
        {
            string query = $"UPDATE CreditCards SET Status = 'Block' WHERE CardID = '{id}' ";
            DataBaseHelper.Instance.Update(query);
            
        }
    }
    }
