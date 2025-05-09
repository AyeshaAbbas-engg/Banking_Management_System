using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Mysqlx.Crud;
using WindowsFormsApp1.DL;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1.UI
{
    public partial class AccountManagement : Form
    {
        public string accountNumber;
        public string accountType;
        public decimal limit;
        public decimal interest;
        public AccountManagement()
        {
            InitializeComponent();
            LoadActiveEmployees();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            CustomerDetails customerDetails = new CustomerDetails();
            customerDetails.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public void LoadActiveEmployees()
        {
            string query = $"select c.Name as CustomerName,c.Email as CustomerEmail,b.BranchName as Branch,a.AccountNumber as AccountNumber,a.AccountType as AccountType,a.Balance as Balance from customer c join account a on c.CustomerID=a.CustomerID JOIN branch b on b.BranchID=a.BranchID where a.Status='Active' and b.Status='Active'";
            DataTable dt = DataBaseHelper.GetData(query);
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;  
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.EnableHeadersVisualStyles = false;  
            dataGridView1.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dataGridView1.DefaultCellStyle.BackColor = Color.White;
            dataGridView1.DefaultCellStyle.ForeColor = Color.Black;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.LightSkyBlue;
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.Black;

            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;  

            dataGridView1.ReadOnly = true; 
            dataGridView1.AllowUserToAddRows = false;  
            dataGridView1.AllowUserToResizeRows = false; 

            dataGridView1.BorderStyle = BorderStyle.FixedSingle;
            dataGridView1.GridColor = Color.LightGray;
            dataGridView1.DataSource = dt;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            ExistingEmployee em = new ExistingEmployee();
            em.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select row you want to update.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (accountType == "Saving")
            {
                updateSavingAccount update = new updateSavingAccount(interest,accountNumber);
                update.Show();
            }
            else if (accountType == "Current")
            {
                UpdateAccount updateAccount = new UpdateAccount(limit,accountNumber);
                updateAccount.Show();
            }
            return;

        }
        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow line = dataGridView1.Rows[e.RowIndex];
                accountNumber = line.Cells[3].Value.ToString();
                accountType=AccountDetailDl.AccountType(accountNumber);
                limit = AccountDetailDl.OverDraft(accountNumber);
                interest= AccountDetailDl.Interest(accountNumber);
                
                
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select row you want to update.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (AccountDetailDl.DeleteAccout(accountNumber))
            {
                MessageBox.Show("Account Deleted Successfully");
                LoadActiveEmployees();
            }
            else
            {
                MessageBox.Show("Account Not Deleted");
                LoadActiveEmployees();
            }
        }
    }
}
