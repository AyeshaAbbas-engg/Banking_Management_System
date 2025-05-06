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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1.UI
{
    public partial class AddBranch : Form
    {
        private const int DefaultBankCode = 1;
        public AddBranch()
        {
            InitializeComponent();
            LoadStatus();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void LoadStatus()
        {
            string query = $"select * from lookup where LookupID between 5 and 6 ";
            DataTable dt = DataBaseHelper.Instance.ExecuteQuery(query);
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "Value";
            comboBox1.ValueMember = "LookupID";
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            string branchName = textBox1.Text;
            string contact = textBox2.Text;
            string address = textBox3.Text;
            string status = comboBox1.SelectedValue.ToString();


            bool result = BranchBL.AddBranch(branchName, contact, address, status, DefaultBankCode);

            if (result)
            {
                MessageBox.Show("Branch added successfully!");
                
            }
            else
            {
                MessageBox.Show("Failed to add branch.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
