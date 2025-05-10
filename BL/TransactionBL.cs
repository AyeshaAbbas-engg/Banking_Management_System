using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.DL;
namespace WindowsFormsApp1.BL
{

    public class TransactionBL
    {
      
        public int TransactionID { get; set; }
        public int SenderAccountID { get; set; }
        public int ReceiverAccountID { get; set; }
        public int FromBranchID { get; set; }
        public int ToBranchID { get; set; }
        public decimal Amount { get; set; }
        public string TransactionType { get; set; }
        public DateTime TransactionDate { get; set; }
        public string Status { get; set; }

        public TransactionBL() { }

        public TransactionBL(int senderId, int receiverId, int fromBranchId, int toBranchId, decimal amount)
        {
            SenderAccountID = senderId;
            ReceiverAccountID = receiverId;
            FromBranchID = fromBranchId;
            ToBranchID = toBranchId;
            Amount = amount;
            TransactionType = fromBranchId == toBranchId ? "WithBranch" : "BranchToBranch";
            TransactionDate = DateTime.Now;
            Status = "Completed";
        }

     
        public static bool PerformTransaction(int senderId, int receiverId, int fromBranchId, int toBranchId, decimal amount)
        {
            if (senderId == receiverId)
                throw new Exception("Sender and receiver cannot be the same.");
            if (amount <= 0)
                throw new Exception("Amount must be greater than zero.");

            return TransactionDL.InsertTransaction(senderId, receiverId, fromBranchId, toBranchId, amount);
        }
    }

}

