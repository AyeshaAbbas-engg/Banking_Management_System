using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.BL;

namespace WindowsFormsApp1.DL
{
    internal class ComplainDL
    {
        public static void AddComplain(ComplainBL cb,int id)
        {
            string query = $"Insert into Complains (UserID , ComplainType , Description  ) Values ({id},'{cb.ComplainType}' ,'{cb.ComplainText}')";
            DataBaseHelper.Instance.Update(query);
        }
    }
}
