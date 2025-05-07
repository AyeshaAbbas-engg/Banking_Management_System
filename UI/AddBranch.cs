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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1.UI
{
    public partial class AddBranch : Form
    {
        private const int DefaultBankCode = 1;
        public AddBranch()
        {
            InitializeComponent();
            LoadBranches();


        }
        private void LoadBranches()
        {
            DataTable dt = BranchBL.GetAllBranches();
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
        private void AddBranch_Load(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataTable dt = BranchBL.GetAllBranches();
            dataGridView1.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddBfrmcs addForm = new AddBfrmcs();
            addForm.ShowDialog();

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int branchID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["BranchID"].Value);

                EditBranch editForm = new EditBranch(branchID);
                editForm.ShowDialog(); // modal, blocks mainform until closed

                // Optionally: reload data after editing
                LoadBranches();
            }
            else
            {
                MessageBox.Show("Please select a branch to edit.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (dataGridView1.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["BranchID"].Value);

                DialogResult result = MessageBox.Show($"Are you sure you want to delete Branch ID: {id}?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    BranchDL.SoftDeleteBranch(id);
                    MessageBox.Show("Branch Deleted Successfully");
                    LoadBranches();
                }
            }
            else
            {
                MessageBox.Show("Please select a row first.");
            }
        }
    }
}
