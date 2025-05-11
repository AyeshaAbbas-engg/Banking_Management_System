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
    public partial class EmployeedashBoard : Form
    {
        public EmployeedashBoard()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            AccountManagement accountManagement = new AccountManagement();
            accountManagement.Show();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            AccountManagement accountManagement = new AccountManagement();
            accountManagement.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            EmployeeManageRequest employeeManageRequest = new EmployeeManageRequest();
            employeeManageRequest.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }
    }
}
