using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.DL
{
    internal class UserDL
    {
        public static DataRow GetUser(string username,string password)
        {
            string query = $"SELECT u.UserID as UserID,u.UserName as UserName,u.Email as Email,u.Password_Hash as Password_Hash, r.Value_ as Value_ FROM users u JOIN lookup r ON u.RoleID = r.LookupID WHERE u.UserName = '{username}' AND u.Password_Hash='{password}'";

            DataTable dt = DataBaseHelper.Instance.ExecuteQuery(query);

            if (dt.Rows.Count > 0)
                return dt.Rows[0];

            return null;
        }
    }
}
