using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace WindowsFormsApp1.BL
{
    internal class ComplainBL
    {
        public string ComplainType { get; set; }
        public string ComplainText { get; set; }
        
        public ComplainBL(string ct , string ctxt)
        {
            ComplainType = ct;
            ComplainText = ctxt;
        }
    }
}
