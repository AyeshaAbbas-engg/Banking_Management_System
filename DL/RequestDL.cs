using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.DL
{
    public class RequestDL
    {
        public static int CreateRequest(int customerID, int branchID, int accountID, int serviceType, DateTime requestDate)
        {
            string formattedDate = requestDate.ToString("yyyy-MM-dd HH:mm:ss"); 
            string query = $"INSERT INTO serviceRequests(CustomerID, BranchID, AccountID, ServiceType, RequestDate) " +
                           $"VALUES ({customerID}, {branchID}, {accountID}, {serviceType}, '{formattedDate}');";
            return DataBaseHelper.Instance.Update(query);
        }

    }
}
