using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.SqlServer.Server;
using WindowsFormsApp1.Domain;
namespace WindowsFormsApp1.BL
{
    internal class EmployeeBL : User
    {
        public int branch { get; set; }
        public int userID { get; set; }
        public string status { get; set; }
        public EmployeeBL( string username, string email, string passwordHash, string phone, int branch)
            : base( username, email, passwordHash,phone)
        {
           this.branch = branch;
        }
        public EmployeeBL(string username, string email, string passwordHash, string phone, int branch,int id)
            : base(username, email, passwordHash, phone)
        {
            this.branch = branch;
            userID = id;
        }
        public EmployeeBL(string username, string email, string passwordHash, string phone, int branch, int id,string status)
           : base(username, email, passwordHash, phone)
        {
            this.branch = branch;
            userID = id;
            this.status = status;
        }
        public EmployeeBL(int id)
        {
            UserID = id;
            
        }
        public override string GetRole()
        {
            return "Employee";
        }
    }
}
