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
    public partial class ServiceRequests : Form
    {
        public ServiceRequests()
        {
            InitializeComponent();
            LoadCustomerName();
            LoadServiceTypes(); // Load once on form load
        }

        private void LoadCustomerName()
        {
            string query = "SELECT CustomerID, Name FROM Customer";
            DataTable dt = DataBaseHelper.Instance.ExecuteQuery(query);
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "CustomerID";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedValue is int customerId)
            {
                LoadBranches(customerId);
                comboBox3.DataSource = null; // Clear accounts
            }
        }

        private void LoadBranches(int customerId)
        {
            string query = $@"
            SELECT DISTINCT B.BranchID, B.BranchName
            FROM Branch B
            JOIN account A ON A.BranchID = B.BranchID
            WHERE A.CustomerID = {customerId}";
            DataTable dt = DataBaseHelper.Instance.ExecuteQuery(query);
            comboBox2.DataSource = dt;
            comboBox2.DisplayMember = "BranchName";
            comboBox2.ValueMember = "BranchID";
        }

        //private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    MessageBox.Show("Branch changed");
           
        //}

        private void LoadAccounts(int customerId, int branchId)
        {
            string query = $@"
            SELECT AccountID, CONCAT('A/C# ', AccountNumber, ' (', AccountType, ')') AS DisplayName
            FROM account
            WHERE CustomerID = {customerId} AND BranchID = {branchId}";
            DataTable dt = DataBaseHelper.Instance.ExecuteQuery(query);
            comboBox3.DataSource = dt;
            comboBox3.DisplayMember = "DisplayName";
            comboBox3.ValueMember = "AccountID";
        }

        private void LoadServiceTypes()
        {
            string query = "SELECT LookupID, Value_ FROM Lookup WHERE Category = 'ServiceType'";
            DataTable dt = DataBaseHelper.Instance.ExecuteQuery(query);
            comboBox4.DataSource = dt;
            comboBox4.DisplayMember = "Value_";
            comboBox4.ValueMember = "LookupID";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1 || comboBox2.SelectedIndex == -1 ||
        comboBox3.SelectedIndex == -1 || comboBox4.SelectedIndex == -1)
            {
                MessageBox.Show("Please fill all fields before submitting the request.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int customerID = Convert.ToInt32(comboBox1.SelectedValue);
            int branchID = Convert.ToInt32(comboBox2.SelectedValue);
            int accountID = Convert.ToInt32(comboBox3.SelectedValue);
            int serviceTypeID = Convert.ToInt32(comboBox4.SelectedValue);
            DateTime requestDate = DateTime.Now;

            int result = RequestBL.CreateRequest(customerID, branchID, accountID, serviceTypeID, requestDate);

            if (result > 0)
            {
                MessageBox.Show("Request submitted successfully.");
            }
            else
            {
                MessageBox.Show("Failed to submit request.");
            }
        }

        private void comboBox2_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (comboBox1.SelectedValue is int customerId &&
               comboBox2.SelectedValue is int branchId)
            {
                LoadAccounts(customerId, branchId);
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }

}
