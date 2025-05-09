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
using WindowsFormsApp1.Domain;

namespace WindowsFormsApp1.UI
{
    public partial class AddBfrmcs : Form
    {
        Branch b;
        public const int Bankcode = 1;
        public AddBfrmcs()
        {
            InitializeComponent();
            LoadStatus();
        }
        private void AddBranch_Load(object sender, EventArgs e)
        {
            MaximizeBox = false;
            MinimizeBox = false;
            LoadStatus();
        }
        private void LoadStatus()
        {
            string query = $"select * from lookup where LookupID between 5 and 6 ";
            DataTable dt = DataBaseHelper.Instance.ExecuteQuery(query);
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "Value_";
            comboBox1.ValueMember = "LookupID";
        }
       
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void Employee_Loa(object sender, EventArgs e)
        {
            //LoadActiveEmployees();
        }
        private void label3_Click(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) ||
                string.IsNullOrWhiteSpace(textBox2.Text) ||
                string.IsNullOrWhiteSpace(textBox3.Text) ||
         
                comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Please fill in all fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                BranchBL newBranch = new BranchBL(
                    textBox1.Text,                      
                    textBox2.Text,                      
                    textBox3.Text,
                    comboBox1.SelectedValue.ToString(),
                    Bankcode
                );

                bool success = BranchDL.AddBranch(newBranch);
                if (success)
                {
                    MessageBox.Show("Branch added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Branch could not be added.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
