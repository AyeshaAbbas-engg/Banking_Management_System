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
    public partial class ViewCardRequest : Form
    {
        public ViewCardRequest()
        {
            InitializeComponent();
            this.Load += ViewCardRequest_Load;
        }
        private void ViewCardRequest_Load(object sender, EventArgs e)
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
            sr.ServiceType = 9;";
            DataTable dt = DataBaseHelper.Instance.ExecuteQuery(query);

            // Show how many rows were fetched
            MessageBox.Show("Rows: " + dt.Rows.Count);

            dataGridView1.DataSource = dt;

        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
