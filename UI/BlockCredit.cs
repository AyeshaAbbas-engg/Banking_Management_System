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
    public partial class BlockCredit : Form
    {
        int id;
        string q1 = $"select c.CardID , a.AccountNumber , c.IssueDate , c.ExpiryDate , c.CardNumber ,c.CreditLimit from creditcards c join account a on a.AccountID=c.AccountID ";
        string q2 = $"select c.ChequeBookID , a.AccountNumber , c.IssueDate ,c.UsedLeaves  from chequebooks c join account a on a.AccountID=c.AccountID ";
        string query;
        public BlockCredit(int id)
        {
            InitializeComponent();
            this.id = id;
            
            if (id == 1)
            {
                button1.Visible = true;
                query = q2;
            }
            else
            {
                button3.Visible = true;
                query = q1;
            }
        }

        private void BlockCredit_Load(object sender, EventArgs e)
        {

        }
        private void loadcustomers()
        {
           
        
            
            DataTable dt = DataBaseHelper.GetData(query);
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;  // fill the grid
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.EnableHeadersVisualStyles = false;  // allow header styling
            dataGridView1.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dataGridView1.DefaultCellStyle.BackColor = Color.White;
            dataGridView1.DefaultCellStyle.ForeColor = Color.Black;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.LightSkyBlue;
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.Black;

            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;  // alternate row color

            dataGridView1.ReadOnly = true;  // make it non-editable (optional)
            dataGridView1.AllowUserToAddRows = false;  // remove empty row
            dataGridView1.AllowUserToResizeRows = false; // fix row size

            dataGridView1.BorderStyle = BorderStyle.FixedSingle;
            dataGridView1.GridColor = Color.LightGray;
            dataGridView1.DataSource = dt;

        
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ChequeBookID"].Value);

                DialogResult result = MessageBox.Show($"Are you sure you want to Block ChequeBook ", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {

                    ChequeDL.Block(id);
                    loadcustomers();
                }
            }
            else
            {
                MessageBox.Show("Please select a row first.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (dataGridView1.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["CardID"].Value);

                DialogResult result = MessageBox.Show($"Are you sure you want to Block CreditCard ", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {

                    CreditCardDL.Block(id);
                    loadcustomers();
                }
            }
            else
            {
                MessageBox.Show("Please select a row first.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            
        }
    }
}
