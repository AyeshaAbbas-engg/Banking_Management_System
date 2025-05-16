using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.DL;
namespace WindowsFormsApp1.BL
{
    public class ChequeBL
    {
        public int RequestID { get; set; }
        public int AccountID { get; set; }
        public DateTime IssueDate { get; set; }
        public int TotalLeaves { get; set; }
        public int UsedLeaves { get; set; } = 0;
        public bool IsFullyUsed { get; set; } = false;
        public string Status { get; set; } = "Active";
        public static bool IsChequeBookAlreadyIssued(int requestId)
        {
            return ChequeDL.IsChequeBookAlreadyIssued(requestId);
        }
        public static bool DeleteServiceRequest(int requestId)
        {
            return ChequeDL.DeleteServiceRequest(requestId);
        }

    }

}
