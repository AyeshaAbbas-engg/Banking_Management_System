using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.DL
{
    public class BranchDL
    {
        public static int CreateBranch(string name, string contact, string address, string status, int bankCode)
        {
            string query = $"INSERT INTO Branch (BranchName, Contact, Address, Status, BankCode) " +
                           $"VALUES ('{name}', '{contact}', '{address.Replace("'", "''")}', '{status}', {bankCode});";
            return DataBaseHelper.Instance.Update(query);
        }

        public static int UpdateBranch(int id, string name, string contact, string address, string status, int bankCode)
        {
            string query = $"UPDATE Branch SET " +
                           $"BranchName = '{name}', Contact = '{contact}', Address = '{address.Replace("'", "''")}', " +
                           $"Status = '{status}', BankCode = {bankCode} " +
                           $"WHERE BranchID = {id};";
            return DataBaseHelper.Instance.Update(query);
        }

        public static int DeleteBranch(int id)
        {
            string query = $"DELETE FROM Branch WHERE BranchID = {id};";
            return DataBaseHelper.Instance.Update(query);
        }

        public static DataTable GetAllBranches()
        {
            string query = "SELECT * FROM Branch;";
            return DataBaseHelper.Instance.ExecuteQuery(query);
        }

       
        public static DataTable getBranchById(int id)
        {
            string query = $"SELECT * FROM Branch WHERE BranchID = {id}";
            return DataBaseHelper.Instance.ExecuteQuery(query);
        }

    }
}
