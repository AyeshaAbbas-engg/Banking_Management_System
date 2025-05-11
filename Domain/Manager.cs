using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Domain
{
    public class Manager : User
    {
        public Manager(int id)
        : base(id) { }

        public override string GetRole()
        {
            return "Manager";
        }
    }
}
