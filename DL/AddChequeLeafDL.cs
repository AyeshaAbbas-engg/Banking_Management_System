using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.BL;
namespace WindowsFormsApp1.DL
{
    public class AddChequeLeafDL
    {
        public static bool AddChequeLeaf(AddChequeLeafBL leaf)
        {

            string insertQuery = $@"
        INSERT INTO ChequeLeaves (ChequeBookID, LeafNumber, IssueDate, Amount, Status)
        VALUES ({leaf.ChequeBookID}, {leaf.LeafNumber}, '{leaf.IssueDate:yyyy-MM-dd}', {leaf.Amount}, '{leaf.Status}')";

            int rowsInserted = DataBaseHelper.Instance.Update(insertQuery);

            if (rowsInserted > 0)
            {
               
                string updateQuery = $@"
            UPDATE ChequeBooks
            SET UsedLeaves = UsedLeaves + 1,
                IsFullyUsed = (UsedLeaves + 1 = TotalLeaves)
            WHERE ChequeBookID = {leaf.ChequeBookID}";

                DataBaseHelper.Instance.Update(updateQuery);
                return true;
            }

            return false;
        }
        public int GetAvailableLeavesCount(int chequeBookID)
        {
            string query = $"SELECT TotalLeaves - UsedLeaves FROM ChequeBooks WHERE ChequeBookID = {chequeBookID}";
            object result = DataBaseHelper.Instance.ExecuteScalar(query);

            return result != DBNull.Value ? Convert.ToInt32(result) : 0;
        }


    }
}
