using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.BL;

namespace WindowsFormsApp1.DL
{
    internal class CustomerDL
    {
        public static void AddCustomertouser(CustomerBL c)
        {
            string insertUserQuery = $"INSERT INTO Users (UserName, Email, Password_Hash, RoleID) VALUES ('{c.UserName}', '{c.Email}', '{c.PasswordHash}', {4});";
            
            DataBaseHelper.Instance.Update(insertUserQuery);
        }
        public static int latestID()
        {
            string getUserIdQuery = "SELECT LAST_INSERT_ID();";
            DataTable userIdTable = DataBaseHelper.GetData(getUserIdQuery);
            int latestUserId = Convert.ToInt32(userIdTable.Rows[0][0]);
            return latestUserId;

        }


        public static void AddCustomer(CustomerBL c)
        {
            string insertCustomerQuery = $"INSERT INTO customer (Name,Email,CNIC,Phone,Address,DateOfBirth,UserID) VALUES ('{c.UserName}', '{c.Email}', '{c.CNIC}', '{c.phone}', '{c.Address}', '{c.DateOfBirth.ToString("yyyy-MM-dd")}', {latestID()});";
            DataBaseHelper.Instance.Update(insertCustomerQuery);

        }
        public static void UpdateCustomer(CustomerBL c)
        {
            string updateCustomerQuery = $"UPDATE Customer SET Name = '{c.UserName}', Email = '{c.Email}', CNIC = '{c.CNIC}', Phone = '{c.phone}', Address = '{c.Address}', DateOfBirth = '{c.DateOfBirth.ToString("yyyy-MM-dd")}'  WHERE UserID = {c.UserID};";
            DataBaseHelper.Instance.Update(updateCustomerQuery);
        }
        public static void SoftDelete(int id)
        {
            string softDeleteQuery = $"UPDATE Customer SET Status = 'Inactive' WHERE CustomerID = {id};";
            DataBaseHelper.Instance.Update(softDeleteQuery);

        }
    }
}
