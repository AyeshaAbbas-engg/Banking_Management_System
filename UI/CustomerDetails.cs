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

namespace WindowsFormsApp1.UI
{
    public partial class CustomerDetails : Form
    {
        
        public CustomerDetails()
        {

            InitializeComponent();
            
        }

        private void tableLayoutPanel10_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            AccountDetails acc = new AccountDetails();
            acc.Show();

        }
    }
}
