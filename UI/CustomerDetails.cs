using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Org.BouncyCastle.Tls.Crypto;
using WindowsFormsApp1.BL;
using WindowsFormsApp1.DL;

namespace WindowsFormsApp1.UI
{
    public partial class CustomerDetails : Form
    {
        public int id;
        
        public CustomerDetails()
        {
            

            InitializeComponent();
            
        }

        private void tableLayoutPanel10_Paint(object sender, PaintEventArgs e)
        {

        }
       

        private void button2_Click(object sender, EventArgs e)
        {
            CustomerBL c= new CustomerBL(textBox1.Text, textBox2.Text, textBox6.Text, textBox4.Text, textBox3.Text,textBox5.Text, dateTimePicker1.Value.Date,1);
            CustomerDL.AddCustomertouser(c);
            
         
            CustomerDL.AddCustomer(c);
            id = CustomerDL.latestID();
            this.Hide();
            Account acc = new Account(id);
            acc.Show();

        }

        private void CustomerDetails_Load(object sender, EventArgs e)
        {
           
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy-MM-dd";
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            AccountManagement accountManagement = new AccountManagement();
            accountManagement.Show();

        }
    }
}
