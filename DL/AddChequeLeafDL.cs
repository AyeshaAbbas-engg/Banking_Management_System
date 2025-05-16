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
        public static int GetAvailableLeavesCount(int chequeBookID)
        {
            string totalLeavesQuery = $"SELECT TotalLeaves FROM ChequeBooks WHERE ChequeBookID = {chequeBookID}";
            string usedLeavesQuery = $"SELECT COUNT(*) FROM ChequeLeaves WHERE ChequeBookID = {chequeBookID}";

            object totalObj = DataBaseHelper.Instance.ExecuteScalar(totalLeavesQuery);
            object usedObj = DataBaseHelper.Instance.ExecuteScalar(usedLeavesQuery);

            int totalLeaves = totalObj != null ? Convert.ToInt32(totalObj) : 0;
            int usedLeaves = usedObj != null ? Convert.ToInt32(usedObj) : 0;

            return totalLeaves - usedLeaves;
        }

        public static void MarkChequeBookAsUsed(int chequeBookID)
        {
            string query = $"UPDATE ChequeBooks SET IsFullyUsed = 1, Status = 'Used' WHERE ChequeBookID = {chequeBookID}";
            DataBaseHelper.Instance.Update(query);

        }


    }
}
