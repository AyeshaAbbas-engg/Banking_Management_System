using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Domain
{
    public class Branch
    {
        public int BranchID { get; set; }
        public string BranchName { get; set; }
        public string Contact { get; set; }
        public string Address { get; set; }
        public string Status { get; set; } = "Active";
        public int BankCode { get; set; }
    
    }
}
