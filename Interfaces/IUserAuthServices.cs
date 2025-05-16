using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Domain;

namespace WindowsFormsApp1.Interfaces
{
    internal interface IUserAuthServices
    {
        User LogInSuccessful(string username, string password);
    }
}
