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
        int id;
        public ServiceRequests(int id)
        {
            InitializeComponent();
            this.id = id;
            LoadCustomerName();
            LoadServiceTypes(); // Load once on form load
        }

        private void LoadCustomerName()
        {
            string query = $"SELECT CustomerID, Name FROM Customer where UserID ={id} ";
            DataTable dt = DataBaseHelper.Instance.ExecuteQuery(query);
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "CustomerID";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedValue is int customerId)
            {
                LoadBranches();
                
            }
        }

        private void LoadBranches()
        {
            string query = $"select b.BranchName,b.BranchID from branch b join account a on a.BranchID = b.BranchID join customer c on c.CustomerID= a.CustomerID where c.UserID ={id}";
            DataTable dt = DataBaseHelper.Instance.ExecuteQuery(query);
            comboBox2.DataSource = dt;
            comboBox2.DisplayMember = "BranchName";
            comboBox2.ValueMember = "BranchID";
        }

        

        private void LoadAccounts()
        {
            string query = $"SELECT CONCAT('A/C# ', a.AccountNumber, ' (', a.AccountType, ')') AS DisplayName, a.AccountID FROM account AS a JOIN  customer AS c ON c.CustomerID = a.CustomerID WHERE c.UserID = {id} AND a.BranchID = '{comboBox2.SelectedValue}'";
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
            this.Hide();
            CustomerDashBoard customerDashBoard = new CustomerDashBoard(id);
            customerDashBoard.Show();
        }

        private void comboBox2_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            LoadAccounts();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            CustomerDashBoard customerDashBoard = new CustomerDashBoard(id);
            customerDashBoard.Show();
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox2_Leave(object sender, EventArgs e)
        {
            
            
                LoadAccounts();
            
        }

        private void comboBox1_Leave(object sender, EventArgs e)
        {
            LoadBranches();
        }
    }

}
