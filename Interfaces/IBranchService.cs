using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Domain;
namespace WindowsFormsApp1.Interfaces
{
    public interface IBranchService
    {
        void AddBranch(Branch b);
        void DeleteBranch(int id);    
        void EditBranch(int id ,Branch b);

        List<Branch> GetAllBranches();

        Branch GetBranchById(int id);
    }
}
