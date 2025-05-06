using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Domain
{
    public abstract class User
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        protected string PasswordHash { get; set; }
        public User(int id, string username, string email, string passwordHash)
        {
            this.UserID = id;
            this.UserName = username;
            this.Email = email;
            this.PasswordHash = passwordHash;
        }

        public abstract string GetRole(); 
    }
}
