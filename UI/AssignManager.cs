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
    public partial class AssignManager : Form
    {
        public AssignManager()
        {
            InitializeComponent();
            LoadActiveEmployees();
        }
        public void LoadActiveEmployees()
        {
            string query = $"SELECT E.EmployeeID,E.Name,E.Email, B.BranchName, IFNULL(M.Name, 'No Manager') AS ManagerName FROM Employee E JOIN  Branch B ON E.BranchID = B.BranchID LEFT JOIN  Employee M ON M.EmployeeID = E.ManagerID WHERE E.Status = 'Active'";

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
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row to Corrosponding you want to Assign Manager .", "No Row Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            else
            {

                int selectedEmployeeId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["EmployeeID"].Value);
                 string selectedBranchID = dataGridView1.SelectedRows[0].Cells["BranchName"].Value.ToString();

                EmployeeDL.AssignManager(selectedEmployeeId, selectedBranchID);
                MessageBox.Show("Manager Assigned Successfully");
                LoadActiveEmployees();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RemoveManager rm = new RemoveManager(this);
            rm.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            BankHeadForm b = new BankHeadForm();
            b.Show();
        }
    }
}
