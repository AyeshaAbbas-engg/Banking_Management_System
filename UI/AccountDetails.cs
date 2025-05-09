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
using static WindowsFormsApp1.DL.AccountDetailDl;

namespace WindowsFormsApp1.UI
{
    public partial class AccountDetails : Form
    {
        public int id;
        private CustomerDetails sform;
        public AccountDetails(int id)
        {
            this.id = id;
            InitializeComponent();
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            originalWidth = button1.Width;
            originalHeight = button1.Height;
            originalWidth = button2.Width;
            originalHeight = button2.Height;
            timer1.Interval = 15;  // speed of animation
            //sform = c;
            PopulateBranchComboBox1();
            PopulateBranchComboBox();
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);

        }
        bool isHovering = false;
        int targetWidth = 110;  // desired bigger width
        int targetHeight = 55;  // desired bigger height
        int originalWidth;
        int originalHeight;

        private void PopulateBranchComboBox()
        {
            string query = "SELECT BranchID, BranchName FROM branch";
            DataTable dt = DataBaseHelper.GetData(query);

            comboBox3.DataSource = dt;
            comboBox3.DisplayMember = "BranchName";  
            comboBox3.ValueMember = "BranchID";      
        }
        private void PopulateBranchComboBox1()
        {
            string query = "SELECT * from lookup where LookupID between 7 and 8";
            DataTable dt = DataBaseHelper.GetData(query);

            comboBox2.DataSource = dt;
            comboBox2.DisplayMember = "Value_";  
            comboBox2.ValueMember = "LookupID";      
        }


        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void AccountDetails_Load_1(object sender, EventArgs e)
        {
            PopulateBranchComboBox();
            textBox2.Text = "0";
            comboBox2_SelectedIndexChanged(null, null);
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            //if (textBox2.Text == "0")
            //{
            //    textBox2.Text = "";  // Clear the 0 for user input
            //}
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            //if (string.IsNullOrWhiteSpace(textBox2.Text))
            //{
            //    textBox2.Text = "0";  // Put back 0 if nothing was entered
            //}
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (comboBox3.SelectedValue != null)
            //{
            //    DataRowView row = comboBox3.SelectedValue as DataRowView;
            //    int selectedBranchID = Convert.ToInt32(row["BranchID"]);

                
            //}
        }

        private void tableLayoutPanel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {
            if(comboBox2.Text=="Current Account")
            {
                label6.Text = "Over-Draft Limit";
            }
        }

        
       
        

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            int step = 2; // speed of resizing

            if (isHovering)
            {
                if (button1.Width < targetWidth)
                    button1.Width += step;
                if (button1.Height < targetHeight)
                    button1.Height += step;

                if (button1.Width >= targetWidth && button1.Height >= targetHeight)
                    timer1.Stop();
            }
            else
            {
                if (button1.Width > originalWidth)
                    button1.Width -= step;
                if (button1.Height > originalHeight)
                    button1.Height -= step;

                if (button1.Width <= originalWidth && button1.Height <= originalHeight)
                    timer1.Stop();
            }
        

    }

        

       

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            CustomerDetails c = new CustomerDetails();
            c.Show();
        }

        private void button1_MouseEnter_1(object sender, EventArgs e)
        {
            isHovering = false;
            timer1.Start();
            button1.BackColor = Color.Gainsboro;
        }

        private void button1_MouseLeave_1(object sender, EventArgs e)
        {
            isHovering = false;
            timer1.Start();
            button2.BackColor = Color.Gainsboro;
        }

        private void button2_MouseEnter_1(object sender, EventArgs e)
        {
            isHovering = false;
            timer1.Start();
            button1.BackColor = Color.Gainsboro;
        }

        private void button2_MouseLeave_1(object sender, EventArgs e)
        {
            isHovering = false;
            timer1.Start();
            button2.BackColor = Color.Gainsboro;
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            string AccountType = comboBox2.Text;
            decimal Balance = Convert.ToDecimal(textBox2.Text);
            int branch = Convert.ToInt32(comboBox3.SelectedValue);
            decimal InterestRate = Convert.ToDecimal(textBox4.Text);
            if (AccountType == "Saving")
            {
                string uniqueAccNumber = AccountHelper.GenerateUniqueAccountNumber();
                SavingAccountBL s = new SavingAccountBL(AccountType, Balance, branch, id, InterestRate, uniqueAccNumber);
                if (AccountDetailDl.AddAccount(s))
                {
                    MessageBox.Show("Saving Account Added Successfully");
                }
                else
                {
                    MessageBox.Show("Error in Adding Saving Account");
                }

            }
            else if (AccountType == "Current")
            {
                string uniqueAccNumber = AccountHelper.GenerateUniqueAccountNumber();
                decimal OverdraftLimit = Convert.ToDecimal(textBox4.Text);
                CurrentAccountBL c = new CurrentAccountBL(AccountType, Balance, branch, id, OverdraftLimit, uniqueAccNumber);
                if (AccountDetailDl.AddAccount(c))
                {
                    MessageBox.Show("Current Account Added Successfully");
                }
                else
                {
                    MessageBox.Show("Error in Adding Current Account");
                }
            }
        }
    }
}
