using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Domain
{
    public class Customer : User
    {
        public Customer(int id, string username, string email, string passwordHash)
            : base(id, username, email, passwordHash) { }
        public override string GetRole()
        {
            return "Customer";
        }
    }
   
}
