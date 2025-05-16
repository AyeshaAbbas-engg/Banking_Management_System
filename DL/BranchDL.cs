using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.BL;

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
        public static int UpdateBranch(BranchBL branch)
        {
            string query = $"UPDATE Branch SET " +
                           $"BranchName = '{branch.BranchName}', " +
                           $"Contact = '{branch.Contact}', " +
                           $"Address = '{branch.Address.Replace("'", "''")}', " +
                           $"Status = '{branch.Status}' " +
                           $"WHERE BranchID = {branch.BranchID};";

            return DataBaseHelper.Instance.Update(query);
        }

        public static int UpdateBranch(int id, string name, string contact, string address, string status)
        {
            string query = $"UPDATE Branch SET " +
                           $"BranchName = '{name}', Contact = '{contact}', Address = '{address.Replace("'", "''")}', " +
                           $"Status = '{status}' " +
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
            string query = "SELECT * FROM Branch where Status not like 'Deleted';";
            return DataBaseHelper.Instance.ExecuteQuery(query);
        }

       
        public static DataTable getBranchById(int id)
        {
            string query = $"SELECT * FROM Branch WHERE BranchID = {id}";
            return DataBaseHelper.Instance.ExecuteQuery(query);
        }
        
            public static bool AddBranch(BranchBL branch)
            {
                string query = $"INSERT INTO branch (BranchName, Contact, Address, Status, BankCode) " +
                               $"VALUES ('{branch.BranchName}', '{branch.Contact}', '{branch.Address}', '{branch.Status}', {branch.BankCode})";
            return DataBaseHelper.Instance.Update(query) > 0;
        }
        public static int SoftDeleteBranch(int branchID)
        {
           
            string query = $"UPDATE branch SET Status = 'Deleted' WHERE BranchID = {branchID}";
            return DataBaseHelper.Instance.Update(query);
        }


    }
}
