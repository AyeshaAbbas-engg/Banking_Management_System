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
    public partial class EditEmployee : Form
    {
        Employee eme;
        int id;
        public EditEmployee(Employee eme,int id)
        {
            InitializeComponent();
            this.eme = eme;
            this.id = id;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            EmployeeBL em = new EmployeeBL(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, Convert.ToInt32(comboBox1.SelectedValue),id,comboBox2.Text);
            EmployeeDL.UpdateEmployee(em,id);
            MessageBox.Show("Employee Updated Successfully");
            this.Close();
            eme.LoadActiveEmployees();
        }
        private void PopulateBranchComboBox()
        {
            string query = "SELECT BranchID, BranchName FROM branch";
            DataTable dt = DataBaseHelper.GetData(query);

            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "BranchName";  // what shows in dropdown
            comboBox1.ValueMember = "BranchID";      // actual value (hidden)
        }
        private void LoadEmployeeData()
        {
            string query = $"SELECT Employee.Name, Employee.Email, Employee.Phone, Branch.BranchName,users.Password_Hash, Branch.BranchID FROM Employee join Branch on Employee.BranchID=Branch.BranchID join users on Employee.UserID =users.UserID WHERE EmployeeID = {id}";
            DataTable dt = DataBaseHelper.GetData(query);

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                textBox1.Text = row["Name"].ToString();
                textBox2.Text = row["Email"].ToString();
                textBox3.Text = row["Password_Hash"].ToString();
                textBox4.Text = row["Phone"].ToString();
                PopulateBranchComboBox();
            }
            else
            {
                MessageBox.Show("Employee not found.");
                this.Close();
            }
        }

        private void EditEmployee_Load(object sender, EventArgs e)
        {
            LoadEmployeeData();
            MaximizeBox = false;
            MinimizeBox = false;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
