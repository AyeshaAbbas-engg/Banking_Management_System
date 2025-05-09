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
    public partial class ExistingEmployee : Form
    {
        public ExistingEmployee()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name=textBox1.Text;
            string email=textBox2.Text;
            string cnic=textBox3.Text;
            int id=AccountDetailDl.SearchCustomer(name, email, cnic);
            this.Hide();
            Account ac = new Account(id);
            ac.Show();
        }

        private void ExistingEmployee_Load(object sender, EventArgs e)
        {

            MaximizeBox = false;
            MinimizeBox = false;
        }
    }
}
