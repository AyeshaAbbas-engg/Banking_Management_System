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
using WindowsFormsApp1.BL;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
namespace WindowsFormsApp1.UI
{
    public partial class IssueeCbookFrm : Form
    {
       private static IssueeCbookFrm instance;
        public IssueeCbookFrm()
        {
            InitializeComponent();
            LoadAccount();
            LoadRequester();
            instance = this;
        }
        private void LoadAccount()
        {
            string query = $"select * from account ";
            DataTable dt = DataBaseHelper.Instance.ExecuteQuery(query);
            comboBox2.DataSource = dt;
            comboBox2.DisplayMember = "AccountNumber";
            comboBox2.ValueMember = "AccountID";
        }

        private void LoadRequester()
        {
            string query = @"
        SELECT c.Name, r.RequestID 
        FROM servicerequests r
        JOIN customer c ON r.CustomerID = c.CustomerID
        WHERE r.Status = 'Active'"; // optional: filter only active requests

            DataTable dt = DataBaseHelper.Instance.ExecuteQuery(query);

            // Example: bind to DataGridView
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "RequestID";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ViewChequeRequest viewChequeRequest = new ViewChequeRequest();
            viewChequeRequest.ShowDialog();
            this.Close();   
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedValue == null || comboBox2.SelectedValue == null)
            {
                MessageBox.Show("Please select both Requester and Account.");
                return;
            }

            ChequeBL cb = new ChequeBL
            {
                RequestID = Convert.ToInt32(comboBox1.SelectedValue),
                AccountID = Convert.ToInt32(comboBox2.SelectedValue),
                IssueDate = DateTime.Today,
                TotalLeaves = Convert.ToInt32(textBox1.Text)

            };

            bool isAdded = ChequeDL.AddChequeBook(cb);
            if (isAdded)
                MessageBox.Show("Cheque Book issued successfully.");
            else
                MessageBox.Show("Failed to issue Cheque Book.");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }
    }
  }

