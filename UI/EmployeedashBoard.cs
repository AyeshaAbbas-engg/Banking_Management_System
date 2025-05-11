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
        public EmployeedashBoard(int id)
        {
            InitializeComponent();
            this.id = id;
           
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
            DialogResult result = MessageBox.Show("Do you want to block Cheque?\nClick 'No' to block Credit.",
                                          "Select Block Option",
                                          MessageBoxButtons.YesNoCancel,
                                          MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Open Cheque blocking form
                 BlockCredit chequeForm = new BlockCredit(1);
                chequeForm.Show();
            }
            else if (result == DialogResult.No)
            {
                // Open Credit blocking form
                BlockCredit creditForm = new BlockCredit(2);
                creditForm.Show();
            }
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
    }
}
