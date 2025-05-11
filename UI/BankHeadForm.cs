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
    public partial class BankHeadForm : Form
    {
        public BankHeadForm()
        {
            InitializeComponent();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void roundedButton1_Load(object sender, EventArgs e)
        {
           
        }

        private void roundedButton2_Load(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Employee employee = new Employee();
            employee.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void BankHeadForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
    "Do you want to add a new branch?\nClick 'Yes' to add, 'No' to view existing.",
    "Branch Action",
    MessageBoxButtons.YesNoCancel,
    MessageBoxIcon.Question
);

            if (result == DialogResult.Yes)
            {
                this.Hide();
                AddBranch a = new AddBranch();
                a.Show();
                // Example: new AddBranchForm().ShowDialog();
            }
            else if (result == DialogResult.No)
            {
                this.Hide();
                BranchViewFrm branchViewFrm = new BranchViewFrm();
                branchViewFrm.Show();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            AssignManager a = new AssignManager();
            a.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            HeadReport h = new HeadReport();
            h.Show();
        }
    }
}
