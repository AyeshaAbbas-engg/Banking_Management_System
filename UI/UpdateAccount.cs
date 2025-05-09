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
    public partial class UpdateAccount : Form
    {
        public string accountNumber;
        public UpdateAccount(decimal limit,string accountNumber)
        {
            InitializeComponent();
            textBox1.Text = limit.ToString();
            this.accountNumber = accountNumber;
        }

        private void UpdateAccount_Load(object sender, EventArgs e)
        {
           
            MaximizeBox = false;
            MinimizeBox = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            decimal limit=decimal.Parse(textBox1.Text);
            if(AccountDetailDl.UpdateAccount(accountNumber, limit))
            {
                MessageBox.Show("Account Updated Successfully");
                this.Hide();

            }
            else
            {

                MessageBox.Show("Account Not Updated");
                this.Hide();
            }
        }
    }
}
