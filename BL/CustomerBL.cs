using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Domain;

namespace WindowsFormsApp1.BL
{
    internal class CustomerBL: User
    {
        public string CNIC { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int BranchID { get; set; }
        public int userID { get; set; }
        public CustomerBL(string username, string email, string passwordHash, string phone, string cnic, string address, DateTime dateOfBirth, int branchID)
            : base(username, email, passwordHash, phone)
        {
            this.CNIC = cnic;
            this.Address = address;
            this.DateOfBirth = dateOfBirth;
            BranchID = branchID;
           
        }
        public CustomerBL(string username, string email, string passwordHash, string phone, string cnic, string address, DateTime dateOfBirth,int branchID, int id)
            : base(username, email, passwordHash, phone)
        {
            this.CNIC = cnic;
            this.Address = address;
            this.DateOfBirth = dateOfBirth;
            BranchID = branchID;
            this.UserID = id;
        }
        public CustomerBL(int id)
        {
            this.UserID = id;
        }
        public override string GetRole()
        {
            return "Customer";
        }
    }
}
