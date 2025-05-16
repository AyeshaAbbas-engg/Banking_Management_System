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

namespace WindowsFormsApp1.UI
{
    public partial class CustomerLoan : Form
    {
        public int id;
        public CustomerLoan(int id)
        {
            InitializeComponent();
            this.id = id;
            LoadAccounts(id);
        }
        private void LoadAccounts(int customerId)
        {
            string query = $@"
            SELECT AccountID, CONCAT('A/C# ', AccountNumber, ' (', AccountType, ')') AS DisplayName
            FROM account
            WHERE CustomerID = {customerId} ";
            DataTable dt = DataBaseHelper.Instance.ExecuteQuery(query);
            comboBox2.DataSource = dt;
            comboBox2.DisplayMember = "DisplayName";
            comboBox2.ValueMember = "AccountID";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            decimal amount;
            if (comboBox1.SelectedItem != null)
            {
                amount = Convert.ToDecimal(comboBox1.SelectedItem);

            }
            else
            {
                MessageBox.Show("Please select a loan amount.");
                return;
            }


            int accountId = (int)comboBox2.SelectedValue;
            int branchID = RequestBL.GetBranchID(accountId);
            int customerID = RequestBL.GetCustomerID(accountId);
            int result = RequestBL.CreateloanRequest(customerID, branchID, accountId, amount);
            if (result > 0)
            {
                MessageBox.Show("Loan request submitted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Failed to submit loan request.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            CustomerDashBoard customerDashBoard = new CustomerDashBoard(id);
            customerDashBoard.Show();
        }

        private void CustomerLoan_Load(object sender, EventArgs e)
        {
            MessageBox.Show(id.ToString());

        }
    }
}
