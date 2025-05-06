using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Org.BouncyCastle.Asn1.Cmp;

namespace WindowsFormsApp1.UI
{
    public partial class UC_BranchCard : UserControl
    {
        public UC_BranchCard()
        {
            InitializeComponent();
        }

        public int BranchID { get; set; }

        public string BranchName
        {
            get { return lblBranchName.Text; }
            set { lblBranchName.Text = "🏦 " + value; }
        }

        public string Contact
        {
            get { return lblContact.Text; }
            set { lblContact.Text = "📞 " + value; }
        }

        public string Address
        {
            get { return lblAddress.Text; }
            set { lblAddress.Text = "📍 " + value; }
        }

        public string Status
        {
            get { return lblStatus.Text; }
            set { lblStatus.Text = "📌 " + value; }
        }

        public int BankCode
        {
            get { return Convert.ToInt32(lblBankCode.Text); }
            set { lblBankCode.Text = "🏛️ " + value.ToString(); }
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void lblBankCode_Click(object sender, EventArgs e)
        {

        }
    }
}
