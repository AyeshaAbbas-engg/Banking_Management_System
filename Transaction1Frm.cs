using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Transaction1Frm : Form
    {
        public Transaction1Frm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
      

        private void roundedButton1_Load(object sender, EventArgs e)
        {
            roundedButton1.Text = "+ Add New Payee";
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
