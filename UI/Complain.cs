using System;
using System.Collections;
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
    public partial class Complain : Form
    {
        EmployeeBL employeeBL;
        int id;
        public Complain()
        {
            InitializeComponent();
            loadComplain();
           
            //employeeBL = eb;
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ComplainBL cb = new ComplainBL(comboBox1.Text ,richTextBox1.Text);
            ComplainDL.AddComplain(cb);
            MessageBox.Show("Average Time Of Resolution of Any Complain is 2 days");

            loadComplain();
        }
        private void loadComplain()
        {
            string query = $"select Complains.ComplainType , Complains.Description , DateOfComplain ,ResolutionDate ,Status_ from Complains  where UserID = 1;";
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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
