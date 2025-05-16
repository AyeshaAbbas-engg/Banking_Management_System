using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.DL;

namespace WindowsFormsApp1.UI
{
    public partial class CustomerLoanPayment : Form
    {

        int id;
        public CustomerLoanPayment(int id)
        {
            InitializeComponent();
            this.id = id;
            loadAccount();
        }
        public void loadAccount()
        {
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

            comboBox1.DataSource = LoanPaymentDL.LoadLoan(id);
            comboBox1.DisplayMember = "DisplayName";
            comboBox1.ValueMember = "AccountID";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an installment to pay.");
                return;
            }

            int installmentID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["InstallmentID"].Value);
            int accountID = Convert.ToInt32(comboBox1.SelectedValue);
            int performedBy = id;
            int receivedBy = 1;

            string message = LoanPaymentDL.PayInstallment(installmentID, accountID, performedBy, receivedBy);
            MessageBox.Show(message);


            if (comboBox2.SelectedValue != null && int.TryParse(comboBox2.SelectedValue.ToString(), out int loanID))
            {
                loadHistory(loanID);
                label6.Text = loadtotal(loanID).ToString();
                label7.Text = loadRemaining(loanID).ToString();
            }

        
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedValue is int AccountID)
            {
                LoadLoans(AccountID);
                label6.Text = null;
                label7.Text = null;
                dataGridView1.DataSource = null;
            }
        }
        public void LoadLoans(int AccountID)
        {
            string query = $@"
            SELECT LoanID           FROM loan
            WHERE AccountID = {AccountID} ";
            DataTable dt = DataBaseHelper.Instance.ExecuteQuery(query);
            comboBox2.DataSource = dt;
            comboBox2.DisplayMember = "DisplayName";
            comboBox2.ValueMember = "LoanID";
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedValue != null && int.TryParse(comboBox2.SelectedValue.ToString(), out int loanID))
            {
                loadHistory(loanID);
                label6.Text = loadtotal(loanID).ToString();
                label7.Text = loadRemaining(loanID).ToString();
            }
        }
        public void loadHistory(int loanID)
        {
            dataGridView1.DataSource = LoanPaymentDL.loadInstallments(loanID);

        }
        public static int loadtotal(int loanID)
        {
            string query = $@"
            SELECT SUM(Amount) AS TotalAmount
            FROM loaninstallments
            WHERE LoanID = {loanID} ";
            DataTable dt = DataBaseHelper.Instance.ExecuteQuery(query);
            if (dt.Rows.Count > 0)
            {
                return Convert.ToInt32(dt.Rows[0]["TotalAmount"]);
            }
            else
            {
                return 0;
            }
        }
        public static int loadRemaining(int loanID)
        {
            string query = $@"
            SELECT SUM(Amount) AS TotalAmount
            FROM loaninstallments
            WHERE LoanID = {loanID} AND Status = 'Pending' ";
            DataTable dt = DataBaseHelper.Instance.ExecuteQuery(query);
            if (dt.Rows.Count > 0)
            {
                return Convert.ToInt32(dt.Rows[0]["TotalAmount"]);
            }
            else
            {
                return 0;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();

            CustomerDashBoard customerDashboard = new CustomerDashBoard(id);
            customerDashboard.Show();
        }
    }
}
