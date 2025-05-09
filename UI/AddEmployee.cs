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
using WindowsFormsApp1.BL;
using Mysqlx.Crud;

namespace WindowsFormsApp1.UI
{
    public partial class AddEmployee : Form
    {
        Employee eme;
        public AddEmployee(Employee eem)
        {
            InitializeComponent();
            this.eme = eem;
        }
        private void PopulateBranchComboBox()
        {
            string query = "SELECT BranchID, BranchName FROM branch";
            DataTable dt = DataBaseHelper.GetData(query);

            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "BranchName";  // what shows in dropdown
            comboBox1.ValueMember = "BranchID";      // actual value (hidden)
        }
        private void AddEmployee_Load(object sender, EventArgs e)
        {
            MaximizeBox = false;
            MinimizeBox = false;
            PopulateBranchComboBox();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            EmployeeBL em= new EmployeeBL(textBox1.Text,textBox2.Text,textBox3.Text,textBox4.Text, Convert.ToInt32(comboBox1.SelectedValue));
            EmployeeDL.AddEmployeetouser(em); 
            EmployeeDL.AddEmployee(em);
            MessageBox.Show("Employee Added Successfully");
            this.Close();
            eme.LoadActiveEmployees();
        }

    }
}
