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
        int id;
        public Transaction(int id)
        {
            InitializeComponent();
            LoadToBranches();
            LoadAccountSender();

           
            LoadTFromBranches();
            
            
            this.id = id;
            
        }
        private int GetBranchIdByAccount(int accountId)
        {
            string query = $"SELECT BranchID FROM account WHERE AccountID = {accountId}";
            object result = DataBaseHelper.Instance.ExecuteScalar(query);
            return result != null ? Convert.ToInt32(result) : -1;
        }

        
        private void LoadAccountSender()
        {
            string query = $"select CONCAT(a.AccountNumber, ' (', a.AccountType, ')') AS DisplayText,a.AccountID from account  a join customer c on c.CustomerID=a.CustomerID where c.UserID ={id} and a.Status ='Active'";
            DataTable dt = DataBaseHelper.Instance.ExecuteQuery(query);
            comboBox.DataSource = dt;
            
            comboBox.DisplayMember = "DisplayText";
            comboBox.ValueMember = "AccountID";
            

        }
        private void loadAcountreceiver()
        {

        }

        private void LoadToBranches()
        {
            string fullText = textBox2.Text;
            string acc = fullText.Split(' ')[0];
            string query = $"select b.BranchName,b.BranchID from branch b join account a on a.BranchID=b.BranchID where a.AccountNumber = '{acc}'";
            DataTable dt = DataBaseHelper.Instance.ExecuteQuery(query);
            comboBox4.DataSource = dt;
            comboBox4.DisplayMember = "BranchName";
            comboBox4.ValueMember = "BranchID";
        }
        private void LoadTFromBranches()
        {
            string accNo = comboBox.ValueMember;
            
            string query = $"select b.BranchName,b.BranchID from branch b join account a on a.BranchID=b.BranchID where a.AccountID ='{accNo}'";
            DataTable dt = DataBaseHelper.Instance.ExecuteQuery(query);
            comboBoxb.DataSource = dt;
            comboBoxb.DisplayMember = "BranchName";
            comboBoxb.ValueMember = "BranchID";
        }
        
       

       

       

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            CustomerDashBoard customerDashBoard = new CustomerDashBoard(id);
            customerDashBoard.Show();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            try
            {
                int senderId = Convert.ToInt32(comboBox.SelectedValue);
                int receiverId = Convert.ToInt32(textBox2.Text);
                int TobranchId = Convert.ToInt32(comboBoxb.SelectedValue);
                int FrombranchId = Convert.ToInt32(comboBox4.SelectedValue);
                decimal amount = Convert.ToInt32(textBox1.Text);

                bool success = TransactionBL.PerformTransaction(senderId, receiverId, TobranchId, FrombranchId, amount);
                if (success)
                    MessageBox.Show("Transaction completed successfully.");

              this.Hide();
              CustomerDashBoard customerDashBoard = new CustomerDashBoard(id);
              customerDashBoard.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Block non-digit input
                return;
            }

            if (char.IsDigit(e.KeyChar))
            {
                // Calculate future length after this input
                int futureLength = textBox2.Text.Length - textBox2.SelectionLength + 1;
                if (futureLength > 9)
                {
                    e.Handled = true; // Block input if it would exceed 4 digits
                }
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text.Length > 9)
            {
                textBox2.Text = textBox2.Text.Substring(0, 9); // Trim to 4 digits
                textBox2.SelectionStart = textBox2.Text.Length; // Move cursor to end
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            string accNo = textBox2.Text.Trim();

            if (!string.IsNullOrEmpty(accNo))
            {
                string query = $"SELECT AccountType FROM Account WHERE AccountNumber = '{accNo}'";
                object result = DataBaseHelper.Instance.ExecuteScalar(query);

                if (result != null)
                {
                    string accountType = result.ToString();
                    textBox2.Text = accNo + $" ({accountType})"; // or show in label
                    LoadToBranches();
                }
                else
                {
                    MessageBox.Show("Invalid account number.");
                }
            }
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Transaction_Load(object sender, EventArgs e)
        {
            LoadToBranches();
           
            LoadAccountSender();
        }

        private void comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox.SelectedIndex != -1)
            {
                LoadTFromBranches();
            }
        }

        private void comboBoxb_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void comboBox_Leave(object sender, EventArgs e)
        {
            if (comboBox.SelectedItem is DataRowView drv)
            {
                string accNo = drv["AccountID"].ToString();

                string query = $"SELECT b.BranchName, b.BranchID " +
                               $"FROM branch b JOIN account a ON a.BranchID = b.BranchID " +
                               $"WHERE a.AccountID = '{accNo}'";

                DataTable dt = DataBaseHelper.Instance.ExecuteQuery(query);
                comboBoxb.DataSource = dt;
                comboBoxb.DisplayMember = "BranchName";
                comboBoxb.ValueMember = "BranchID";
            }
        }
    }
}
