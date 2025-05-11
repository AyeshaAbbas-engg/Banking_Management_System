using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.BL;
using WindowsFormsApp1.DL;
using static WindowsFormsApp1.DL.AccountDetailDl;

namespace WindowsFormsApp1.UI
{
    public partial class Account : Form
    {
        public int id;
        public Account(int id)
        {
            this.id = id;
            InitializeComponent();
            PopulateBranchComboBox();
            PopulateBranchComboBox1();
        }
        private void PopulateBranchComboBox()
        {
            string query = "SELECT BranchID, BranchName FROM branch";
            DataTable dt = DataBaseHelper.GetData(query);

            comboBox3.DataSource = dt;
            comboBox3.DisplayMember = "BranchName";
            comboBox3.ValueMember = "BranchID";
        }
        private void PopulateBranchComboBox1()
        {
            string query = "SELECT * from lookup where LookupID between 7 and 8";
            DataTable dt = DataBaseHelper.GetData(query);

            comboBox2.DataSource = dt;
            comboBox2.DisplayMember = "Value_";
            comboBox2.ValueMember = "LookupID";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string AccountType = comboBox2.Text;
            decimal Balance = Convert.ToDecimal(textBox2.Text);
            int branch = Convert.ToInt32(comboBox3.SelectedValue);
            decimal InterestRate = Convert.ToDecimal(textBox4.Text);
            
            if (AccountType == "Saving")
            {
                string uniqueAccNumber = AccountHelper.GenerateUniqueAccountNumber();
                SavingAccountBL s = new SavingAccountBL(AccountType, Balance, branch, id, InterestRate,uniqueAccNumber);
                if (AccountDetailDl.AddAccount(s))
                {
                    MessageBox.Show("Saving Account Added Successfully");
                }
                else
                {
                    MessageBox.Show("Error in Adding Saving Account");
                }

            }
            else if (AccountType == "Current")
            {
                decimal OverdraftLimit = Convert.ToDecimal(textBox4.Text);
                string uniqueAccNumber = AccountHelper.GenerateUniqueAccountNumber();
                CurrentAccountBL c = new CurrentAccountBL(AccountType, Balance, branch, id, OverdraftLimit,uniqueAccNumber);
                if (AccountDetailDl.AddAccount(c))
                {
                    MessageBox.Show("Current Account Added Successfully");
                }
                else
                {
                    MessageBox.Show("Error in Adding Current Account");
                }
            }
            this.Hide();
            AccountManagement am = new AccountManagement();
            am.Show();
        }

        private void Account_Load(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
