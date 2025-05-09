using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using WindowsFormsApp1.BL;

namespace WindowsFormsApp1.DL
{
    internal class EmployeeDL
    {
        public static void AddEmployeetouser(EmployeeBL e)
        {
         string insertUserQuery = $"INSERT INTO Users (UserName, Email, Password_Hash, RoleID) VALUES ('{e.UserName}', '{e.Email}', '{e.PasswordHash}', {3});";
          DataBaseHelper.Instance.Update(insertUserQuery);
        }
        public static int latestID()
        {
            string getUserIdQuery = "SELECT LAST_INSERT_ID();";
            DataTable userIdTable = DataBaseHelper.GetData(getUserIdQuery);
            int latestUserId = Convert.ToInt32(userIdTable.Rows[0][0]);
            return latestUserId;

        }
        public static void AddEmployee(EmployeeBL e)
        {
            string insertEmployeeQuery = $"INSERT INTO Employee (Name, Email, Phone, RoleID, BranchID, UserID) VALUES ('{e.UserName}', '{e.Email}', '{e.phone}', {3}, {e.branch}, {latestID()});";
            DataBaseHelper.Instance.Update(insertEmployeeQuery);

        }
        public static void UpdateEmployee(EmployeeBL e)
        {
            string updateEmployeeQuery = $"UPDATE Employee SET Name = '{e.UserName}', Email = '{e.Email}',RoleID ={3}, Phone = '{e.phone}', BranchID = {e.branch} , Status ='{e.status}' WHERE UserID = {e.userID};";
            DataBaseHelper.Instance.Update(updateEmployeeQuery);
        }
        public static void SoftDelete(int id)
        {
            string softDeleteQuery = $"UPDATE Employee SET Status = 'Delete' WHERE EmployeeID = {id};";
            DataBaseHelper.Instance.Update(softDeleteQuery);

        }
        public static void SoftDeleteManager(int id)
        {
            string softDeleteQuery = $"UPDATE Employee SET ManagerID = Null WHERE BranchID = {id};";
            DataBaseHelper.Instance.Update(softDeleteQuery);

        }
        public static int getBranchID(string bid)
        {
            string query = $"SELECT BranchID FROM Branch WHERE BranchName = '{bid}';";
            DataTable userIdTable = DataBaseHelper.GetData(query);
            int latestUserId = Convert.ToInt32(userIdTable.Rows[0][0]);
            return latestUserId;

        }
        public static void AssignManager(int managerId,string BranchID)
        {

            string assignManagerQuery = $"UPDATE Employee SET ManagerID = {managerId} WHERE BranchID = {getBranchID(BranchID)};";
            DataBaseHelper.Instance.Update(assignManagerQuery);
        }
    }
}
