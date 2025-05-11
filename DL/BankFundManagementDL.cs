using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.BL;

namespace WindowsFormsApp1.DL
{
    internal class BankFundManagementDL
    {
        public static decimal loadTotalFund()
        {
            string query = $"SELECT TotalAmount FRom bankfund limit 1";
            object Id = DataBaseHelper.Instance.ExecuteScalar(query);
            decimal result = Convert.ToDecimal(Id);
            return result;
        }
        public static bool AddTransaction(BankFundManagementBL b)
        {
            string query = $@"
            CALL AddBankFundTransaction(
                {b.amount},
                '{b.type}',
                '{b.source}',
                {b.performedBy},
                '{b.note}'
            );";

            int rows = DataBaseHelper.Instance.Update(query);
            return rows > 0;
        }
        public static DataTable loadHistory()
        {
            string query = "SELECT * FROM view_BankFundHistory;";
            DataTable dt = DataBaseHelper.GetData(query);
            return dt;

        }
    }
}
