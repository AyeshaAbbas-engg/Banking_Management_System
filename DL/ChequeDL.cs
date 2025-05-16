using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using WindowsFormsApp1.BL;
namespace WindowsFormsApp1.DL
{
    public class ChequeDL
    {
        public static bool AddChequeBook(ChequeBL cb)
        {
            string query = $@"
            INSERT INTO ChequeBooks 
            (RequestID, AccountID, IssueDate, TotalLeaves, UsedLeaves, IsFullyUsed, Status)
            VALUES 
            ({cb.RequestID}, {cb.AccountID}, '{cb.IssueDate:yyyy-MM-dd}', {cb.TotalLeaves}, 
             {cb.UsedLeaves}, {Convert.ToInt32(cb.IsFullyUsed)}, '{cb.Status}')";

            int rows = DataBaseHelper.Instance.Update(query);
            return rows > 0;
        }
        public static void Block(int id)
        {
            string query = $"UPDATE ChequeBooks SET Status = 'Block' WHERE ChequeBookID = '{id}' ";
            DataBaseHelper.Instance.Update(query);

        }
        public static bool IsChequeBookAlreadyIssued(int requestId)
        {
            string query = $"SELECT COUNT(*) FROM ChequeBooks WHERE RequestID = {requestId}";
            object result = DataBaseHelper.Instance.ExecuteScalar(query);
            return Convert.ToInt32(result) > 0;
        }
        public static bool DeleteServiceRequest(int requestId)
        {
            string query = $"DELETE FROM ServiceRequests WHERE RequestID = {requestId}";
            return DataBaseHelper.Instance.Update(query) > 0;
        }
      
    }
}
