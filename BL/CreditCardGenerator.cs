using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.BL
{
    public class CreditCardGenerator
    {
        public static string GenerateCardNumber()
        {
            Random random = new Random();
            StringBuilder cardNumber = new StringBuilder();

            // Generate the first 15 digits randomly
            for (int i = 0; i < 15; i++)
            {
                cardNumber.Append(random.Next(0, 10)); // Append a random digit (0-9)
            }

            // Calculate the checksum (last digit) using the Luhn Algorithm
            int checksum = CalculateLuhnChecksum(cardNumber.ToString());
            cardNumber.Append(checksum);

            return cardNumber.ToString();
        }

        // Luhn Algorithm to calculate the checksum
        private static int CalculateLuhnChecksum(string number)
        {
            int sum = 0;
            bool isOdd = false;

            // Traverse the digits from right to left
            for (int i = number.Length - 1; i >= 0; i--)
            {
                int digit = int.Parse(number[i].ToString());

                if (isOdd)
                {
                    digit *= 2;
                    if (digit > 9) digit -= 9; // If result > 9, subtract 9
                }

                sum += digit;
                isOdd = !isOdd;
            }

            // Calculate the last digit (checksum)
            return (10 - (sum % 10)) % 10;
        }
    }
}
