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
    public partial class BnakFundMangement : Form
    {
        public decimal totalfund;
        public BnakFundMangement()
        {
            InitializeComponent();
            loadTotalFund();
            loadData();
        }
        public void loadTotalFund()
        {

            totalfund = BankFundManagementBL.LoadTotalFund();
            label6.Text = totalfund.ToString();
        }
        public void loadData()
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

            dataGridView1.DataSource = BankFundManagementDL.loadHistory();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(comboBox1.Text) || string.IsNullOrEmpty(richTextBox1.Text) || string.IsNullOrEmpty(richTextBox2.Text))
            {
                MessageBox.Show("Enter all fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            BankFundManagementBL b = new BankFundManagementBL();
            b.type = comboBox1.Text;

            b.amount = decimal.Parse(richTextBox1.Text);
            b.note = richTextBox2.Text;
            b.performedBy = 1;
            b.source = "Manual";
            if(b.amount> totalfund && b.type == "Deducted")
            {
                MessageBox.Show("Insufficient Fund");
                return;
            }
            if (BankFundManagementBL.fundTransaction(b))
            {
                MessageBox.Show("Updated Successfully");
                loadData();
                loadTotalFund();
            }
            else
            {
                MessageBox.Show("Failed to update");
                loadData();
                loadTotalFund();
            }
        }
        private void richTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Block non-digit input
                return;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            BankHeadForm bankHeadForm = new BankHeadForm();
            bankHeadForm.Show();
        }
    }
}
