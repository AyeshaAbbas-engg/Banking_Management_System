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
        int id;
        public static EmployeedashBoard instance;   
        public EmployeedashBoard(int id)
        {
            InitializeComponent();
            this.id = id;
            instance = this;

        } public EmployeedashBoard()
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
            
            AccountManagement accountManagement = new AccountManagement(id);
            accountManagement.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            EmployeeManageRequest employeeManageRequest = new EmployeeManageRequest();
            employeeManageRequest.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            Complain complain = new Complain(id);
            complain.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
            ChequeLeafFrm frm = new ChequeLeafFrm();
            frm.Show();
            this.Close();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            EmployeeReport employeeReport = new EmployeeReport();
            employeeReport.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            DepositFrm frm = new DepositFrm();
            frm.Show();
            this.Close();
        }
    }
}
