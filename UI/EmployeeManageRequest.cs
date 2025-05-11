using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.UI
{
    public partial class EmployeeManageRequest : Form
    {
        public EmployeeManageRequest()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            ViewChequeRequest viewChequeRequest = new ViewChequeRequest();
            viewChequeRequest.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            ViewCardRequest viewCardRequest = new ViewCardRequest();
            viewCardRequest.Show();
        }
    }
}
