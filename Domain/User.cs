using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Domain
{
    public abstract class User
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }

        public string phone { get; set; }

        public int UserID { get; set; }

        public User( string username, string email, string passwordHash, string phone)
        {
            this.phone = phone;
            this.UserName = username;
            this.Email = email;
            this.PasswordHash = passwordHash;
        }
        public User() { }
        public abstract string GetRole(); 
    }
}
