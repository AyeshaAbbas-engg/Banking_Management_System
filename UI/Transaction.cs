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
    public partial class Transaction : Form
    {
        public Transaction()
        {
            InitializeComponent();
            LoadToBranches();
            LoadAccountSender();
            LoadAccountReceiver();
            LoadTransaction();
            LoadTFromBranches();
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            comboBox2.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
        }
        private int GetBranchIdByAccount(int accountId)
        {
            string query = $"SELECT BranchID FROM account WHERE AccountID = {accountId}";
            object result = DataBaseHelper.Instance.ExecuteScalar(query);
            return result != null ? Convert.ToInt32(result) : -1;
        }

        private void LoadTransaction()
        {
            string query = "Select * from lookup where LookupID between 12 and 13";
            DataTable dt = DataBaseHelper.Instance.ExecuteQuery(query);
            comboBox5.DataSource = dt;
            comboBox5.DisplayMember = "Value_";
            comboBox5.ValueMember = "LookupID";
        }
        private void LoadAccountSender()
        {
            string query = $"Select * from account where AccountType = 'Current'";
            DataTable dt = DataBaseHelper.Instance.ExecuteQuery(query);
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "AccountNumber";
            comboBox1.ValueMember = "AccountID";

        }
        private void LoadAccountReceiver()
        {
            string query = $"Select * from account where AccountType = 'Current'";
            DataTable dt = DataBaseHelper.Instance.ExecuteQuery(query);
            comboBox2.DataSource = dt;
            comboBox2.DisplayMember = "AccountNumber";
            comboBox2.ValueMember = "AccountID";

        }

        private void LoadToBranches()
        {
            string query = $"Select * from branch";
            DataTable dt = DataBaseHelper.Instance.ExecuteQuery(query);
            comboBox4.DataSource = dt;
            comboBox4.DisplayMember = "BranchName";
            comboBox4.ValueMember = "BranchID";
        }
        private void LoadTFromBranches()
        {
            string query = $"Select * from branch";
            DataTable dt = DataBaseHelper.Instance.ExecuteQuery(query);
            comboBox3.DataSource = dt;
            comboBox3.DisplayMember = "BranchName";
            comboBox3.ValueMember = "BranchID";
        }
        private void button2_Click(object sender, EventArgs e)
        {

            try
            {
                int senderId = Convert.ToInt32(comboBox1.SelectedValue);
                int receiverId = Convert.ToInt32(comboBox2.SelectedValue);
                int TobranchId = Convert.ToInt32(comboBox3.SelectedValue); 
                int FrombranchId = Convert.ToInt32(comboBox4.SelectedValue);
                decimal amount = numericUpDown1.Value;
                int TransactionType = Convert.ToInt32(comboBox1.SelectedValue);
                bool success = TransactionBL.PerformTransaction(senderId, receiverId, TobranchId, FrombranchId, amount);
                if (success)
                    MessageBox.Show("Transaction completed successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (comboBox1.SelectedValue != null && int.TryParse(comboBox1.SelectedValue.ToString(), out int accountId))
            {
                int branchId = GetBranchIdByAccount(accountId);
                comboBox3.SelectedValue = branchId;
            }
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedValue != null && int.TryParse(comboBox2.SelectedValue.ToString(), out int accountId))
            {
                int branchId = GetBranchIdByAccount(accountId);
                comboBox4.SelectedValue = branchId;
            }
        }
    }
}
