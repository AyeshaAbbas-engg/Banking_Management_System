using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.UI
{
    public partial class ViewChequeRequest : Form
    {
        public ViewChequeRequest()
        {
            InitializeComponent();
            this.Load += ViewChequeRequest_Load;
        }

        private void ViewChequeRequest_Load(object sender, EventArgs e)
        {
            string query = @"
        SELECT 
            sr.RequestID,
            c.Name AS CustomerName,
            b.BranchName,
            a.AccountNumber,
            sr.ServiceType,
            sr.Status,
            sr.RequestDate
        FROM 
            servicerequests sr
        JOIN 
            customer c ON sr.CustomerID = c.CustomerID
        JOIN 
            branch b ON sr.BranchID = b.BranchID
        JOIN 
            account a ON sr.AccountID = a.AccountID
        WHERE 
            sr.ServiceType = 10;";
            DataTable dt = DataBaseHelper.Instance.ExecuteQuery(query);

            // Show how many rows were fetched
            MessageBox.Show("Rows: " + dt.Rows.Count);

            dataGridView1.DataSource = dt;
           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
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

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
