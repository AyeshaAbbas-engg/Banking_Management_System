using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Domain
{
    public class Customer : User
    {
        public Customer( string username, string email, string passwordHash,string phone)
            : base(username, email, passwordHash, phone) { }
        public override string GetRole()
        {
            return "Customer";
        }
    }
   
}
