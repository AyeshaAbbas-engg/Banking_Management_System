using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.BL
{
    public class AddChequeLeafBL
    {
        public int ChequeBookID { get; set; }
        public int LeafNumber { get; set; }
        public DateTime IssueDate { get; set; }
        public decimal Amount { get; set; }
        public string Status { get; set; } = "Issued";

    }
}
