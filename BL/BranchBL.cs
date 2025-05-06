using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using WindowsFormsApp1.DL;

namespace WindowsFormsApp1.BL
{

    public  class BranchBL
    {
        //public int BranchID { get; set; }
        //public string BranchName { get; set; }
        //public string Contact { get; set; }
        //public string Address { get; set; }
        //public string Status { get; set; }
        //public int BankCode { get; set; }
        //public BranchBL(int branchID, string branchName, string contact, string address, string status, int bankCode)
        //{
        //    BranchID = branchID;
        //    BranchName = branchName;
        //    Contact = contact;
        //    Address = address;
        //    Status = status;
        //    BankCode = bankCode;
            
        //}

        public static bool AddBranch(string branchName, string contact, string address, string status, int bankCode)
        {
            return BranchDL.CreateBranch(branchName, contact, address, status, bankCode) > 0;
        }

        public static bool UpdateBranch(int branchID, string branchName, string contact, string address, string status, int bankCode)
        {
            return BranchDL.UpdateBranch(branchID, branchName, contact, address, status, bankCode) > 0;
        }

        public static bool DeleteBranch(int branchID)
        {
            return BranchDL.DeleteBranch(branchID) > 0;
        }

        public static DataTable GetAllBranches()
        {
            return BranchDL.GetAllBranches();
        }

       
        public static DataTable getBranchById(int id)
        {
            return BranchDL.getBranchById(id);
        }

    }

}
