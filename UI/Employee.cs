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
    public partial class Employee : Form
    {
        public Employee()
        {
            InitializeComponent();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Employee_Load(object sender, EventArgs e)
        {
            LoadActiveEmployees();
        }
        public  void LoadActiveEmployees()
        {
            string query = $"SELECT EmployeeID, Employee.Name, Employee.Email, Employee.Phone, Branch.BranchName , Employee.Status FROM Employee JOIN Branch ON Employee.BranchID = Branch.BranchID WHERE Employee.Status in ('Active' , 'Inactive');\r\n";

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
        private void button1_Click(object sender, EventArgs e)
        {
            AddEmployee add = new AddEmployee(this);
            add.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row to update.", "No Row Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            else
            {

                int selectedEmployeeId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["EmployeeID"].Value);

                EditEmployee edit = new EditEmployee(this, selectedEmployeeId);
                edit.ShowDialog();
            }
                
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["EmployeeID"].Value);

                DialogResult result = MessageBox.Show($"Are you sure you want to delete Employee ID: {id}?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    EmployeeDL.SoftDelete(id);
                   MessageBox.Show("Employee Deleted Successfully");
                    LoadActiveEmployees();
                }
            }
            else
            {
                MessageBox.Show("Please select a row first.");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            BankHeadForm b = new BankHeadForm();
            b.Show();
        }
    }
}
