using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.DL;
namespace WindowsFormsApp1.BL
{
    public class CreditCardBL
    {
        public int RequestID { get; set; }
        public int CustomerID { get; set; }
        public decimal CreditLimit { get; set; }
        public string Status { get; set; } = "Active";  // Default status is Active

        public bool IssueCreditCard()
        {
            // Generate the card number (You can use the method from the previous example for random generation)
            string cardNumber = CreditCardGenerator.GenerateCardNumber();
            DateTime issueDate = DateTime.Now;
            DateTime expiryDate = issueDate.AddYears(3);  // Expiry in 3 years

            // Insert into the database using the Data Layer
            return CreditCardDL.AddCreditCard(RequestID, CustomerID, cardNumber, issueDate, expiryDate, CreditLimit, Status);
        }
    }
}
