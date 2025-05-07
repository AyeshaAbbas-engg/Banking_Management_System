using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using WindowsFormsApp1.BL;
using WindowsFormsApp1.DL;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1.UI
{
    public partial class EditBranch : Form
    {
        private int branchID;
        public EditBranch(int branchID)
        {
            InitializeComponent();
            this.branchID = branchID;
            LoadStatus();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
        private void EditBranch_Load(object sender, EventArgs e)
        {
            
            MaximizeBox = false;
            MinimizeBox = false;
            LoadBranchData();
        }
        private void LoadStatus()
        {
            string query = $"select * from lookup where LookupID between 5 and 6 ";
            DataTable dt = DataBaseHelper.Instance.ExecuteQuery(query);
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "Value_";
            comboBox1.ValueMember = "LookupID";
        }
        private void LoadBranchData()
        {
            string query = $"SELECT BranchName, Contact, Address, Status, BankCode FROM branch WHERE BranchID = {branchID}";
            DataTable dt = DataBaseHelper.GetData(query);

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                textBox1.Text = row["BranchName"].ToString();
                textBox2.Text = row["Contact"].ToString();
                textBox3.Text = row["Address"].ToString();

                comboBox1.SelectedIndex = comboBox1.FindStringExact(row["Status"].ToString());
                MessageBox.Show("Status: " + row["Status"].ToString());

            }
            else
            {
                MessageBox.Show("Branch not found.");
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BranchBL updatedBranch = new BranchBL(
                textBox1.Text,
                textBox2.Text,
                textBox3.Text,
                comboBox1.Text, 
                branchID
            );

            string query = $"UPDATE Branch SET " +
                $"BranchName = '{textBox1.Text}', " +
                $"Contact = '{textBox2.Text}', " +
                $"Address = '{textBox3.Text.Replace("'", "''")}', " +
                $"Status = '{comboBox1.Text}' " +
                $"WHERE BranchID = {branchID};";

            int result = DataBaseHelper.Instance.Update(query);
            MessageBox.Show(result > 0 ? "Updated" : "Failed");
            MessageBox.Show("Branch updated successfully.");
            this.Close();
        }

       

    }
}
