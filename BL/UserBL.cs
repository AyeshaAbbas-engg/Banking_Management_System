using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Crypto.Generators;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using WindowsFormsApp1.Domain;
using WindowsFormsApp1.DL;
using System.Data;
using System.Windows.Forms;
using WindowsFormsApp1.Interfaces;
namespace WindowsFormsApp1.BL
{
    public class UserBL : IUserAuthServices
    {

        public  User LogInSuccessful(string username, string password)
        {
            DataRow row = UserDL.GetUser(username, password);

            if (row == null)
                return null;

           
            int id = int.Parse(row["UserID"].ToString());
            string uname = row["UserName"].ToString();
            string email = row["Email"].ToString();
            string pass = password;
            string role = row["Value_"].ToString();
           
            if (role == "Head")
                return new Head(id);
            else if (role == "Manager")
                return new Manager(id);

            else if (role == "Employee")
                return new EmployeeBL(id);
            else if (role == "Customer")
                return new CustomerBL(id);
            return null;
        }
    

            
        
    }
}
