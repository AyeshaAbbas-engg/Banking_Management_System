using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using WindowsFormsApp1.BL;
using WindowsFormsApp1.Domain;

namespace WindowsFormsApp1.UI
{
    public partial class LoginPage : Form
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Username = textBox1.Text.Trim();
            string email = textBox2.Text.Trim();
            string Password = textBox3.Text.Trim();
            if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password)||string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Please enter each field");
                return;
            }
            User user = UserBL.LogInSuccessful(Username,Password);

            if (user != null)
            {
                MessageBox.Show("Login Successful","Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Hide();
                if (user is Head)
                {
                    BankHeadForm b = new BankHeadForm();
                    this.Hide();
                    b.Show();
                }
                else if (user is Manager)
                {
                    MessageBox.Show("Login Successful Manager", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //ManagerDashboard managerDashboard = new ManagerDashboard(user);
                    //managerDashboard.Show();
                }
                else if (user is EmployeeBL)
                {
                    MessageBox.Show("Login Successful Employee", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    //EmployeeDashboard empDashboard = new EmployeeDashboard(user);
                    //empDashboard.Show();
                }
                else if (user is CustomerBL)
                {
                    MessageBox.Show("LogIn Successful Customer", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CustomerDashBoard customerDashBoard = new CustomerDashBoard(user.UserID);
                   
                    this.Hide();
                    customerDashBoard.Show();

                }
            }
            else
            {
                MessageBox.Show("Invalid", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        
    }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
