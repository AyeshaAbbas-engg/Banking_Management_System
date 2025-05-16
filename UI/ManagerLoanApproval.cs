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

namespace WindowsFormsApp1.UI
{
    public partial class ManagerLoanApproval : Form
    {
        public int id;
        public decimal amount;
        public int accountID;
        public ManagerLoanApproval()
        {
            InitializeComponent();
            loadRequest();
        }
        public void loadRequest()
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

            string query = $"SELECT r.LoanRequestID, c.Name AS CustomerName, b.BranchName,a.AccountNumber, r.Status,r.Amount,r.RequestDate FROM  laonrequest r  JOIN  customer c ON r.CustomerID = c.CustomerID  JOIN   branch b ON r.BranchID = b.BranchID     JOIN      account a ON r.AccountID = a.AccountID where r.Status='Pending';";
            DataTable dt = DataBaseHelper.Instance.ExecuteQuery(query);

            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow line = dataGridView1.Rows[e.RowIndex];
                id = int.Parse(line.Cells[0].Value.ToString());
                amount = Convert.ToDecimal(line.Cells[5].Value.ToString());
                accountID = RequestDL.loadAccount(id);

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select row of request you want to appprove", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!RequestDL.LoanAvailable(amount))
            {
                MessageBox.Show("Not possible reduce amount");
                return;
            }
            if (RequestBL.IssueLoan(id))
            {
                MessageBox.Show("Loan request approved successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadRequest();
            }
            if (RequestDL.loanApprove(id, accountID, amount, 1))
            {
                MessageBox.Show("loan given successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show("Failed to approve loan request", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            ManagerDashBoard managerDashBoard = new ManagerDashBoard();
            managerDashBoard.Show();
        }
    }
}
