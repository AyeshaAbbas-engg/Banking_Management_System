using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Domain
{
    public  class Head:User
    {
        //public Head(int id, string username, string email, string passwordHash)
        //: base(id, username, email, passwordHash) { }

        public override string GetRole()
        {
            return "Head";
        }
    }
}
