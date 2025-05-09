using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.DL
{
    public class CreditCardDL
    {
        public static bool AddCreditCard(int requestID, int customerID, string cardNumber, DateTime issueDate, DateTime expiryDate, decimal creditLimit, string status)
        {
            string query = "INSERT INTO CreditCards (RequestID, CustomerID, IssueDate, CardNumber, ExpiryDate, CreditLimit, Status) " +
                           "VALUES (" + requestID + ", " + customerID + ", '" + issueDate.ToString("yyyy-MM-dd") + "', '" + cardNumber + "', '" + expiryDate.ToString("yyyy-MM-dd") + "', " + creditLimit + ", '" + status + "')";
            return DataBaseHelper.Instance.Update(query) > 0;
        }
      }
    }
