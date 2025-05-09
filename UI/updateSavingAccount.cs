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
    public partial class updateSavingAccount : Form
    {
        public string accountNumber;
        public updateSavingAccount(decimal interest,string accountNumber)
        {
            InitializeComponent();
            textBox1.Text = interest.ToString();
            this.accountNumber = accountNumber;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            decimal interest = decimal.Parse(textBox1.Text);
            if (AccountDetailDl.UpdateSavingAccount(accountNumber, interest))
            {
                MessageBox.Show("Account Updated");
                this.Hide();
            }
            else
            {
                MessageBox.Show("Account Not Updated");
                this.Hide();
            }
                   }

        private void updateSavingAccount_Load(object sender, EventArgs e)
        {
            MaximizeBox = false;
            MinimizeBox = false;
        }
    }
}
