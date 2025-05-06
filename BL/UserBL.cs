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

namespace WindowsFormsApp1.BL
{
    public class UserBL
    {
        
        public static User LogInSuccessful(string username,string password)
        {
            DataRow row = UserDL.GetUser(username,password);

            if (row == null)
                return null;

            //string storedHash = row["Password_Hash"].ToString();

            //if (BCrypt.Net.BCrypt.Verify(password, storedHash)) 
            //{
                int id = int.Parse(row["UserID"].ToString());
                string uname = row["UserName"].ToString();
                string email = row["Email"].ToString();
                //string pass = row["Password_Hash"].ToString();
                string pass = password;
                string role = row["Value_"].ToString();

                if (role == "Head")
                    return new Head(id, uname, email, pass);
                else if (role == "Manager")
                    return new Manager(id, uname, email, pass);
                else if (role == "Employee")
                    return new Employee(id, uname, email, pass);
                else if (role == "Customer")
                    return new Customer(id, uname, email, pass);
            //}

            return null;
        }
    }
}
