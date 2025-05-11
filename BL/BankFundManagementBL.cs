using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.DL;

namespace WindowsFormsApp1.BL
{
    internal class BankFundManagementBL
    {
        public string type {  get; set; }
        public decimal amount { get; set; }
        public string source { get; set; }
        public int performedBy { get; set; }
        public string note { get; set; }
        public BankFundManagementBL()
        {

        }
        public BankFundManagementBL(string type, decimal amount,string source,  int performedBy, string note)
        {
            this.type = type;
            this.amount = amount;
            this.source = source;
            this.performedBy = performedBy;
            this.note = note;
        }
        public static decimal LoadTotalFund()
        {
            return DL.BankFundManagementDL.loadTotalFund();
        }
        public static bool fundTransaction(BankFundManagementBL b)
        {
            return BankFundManagementDL.AddTransaction(b);
        }
        
    }
}
