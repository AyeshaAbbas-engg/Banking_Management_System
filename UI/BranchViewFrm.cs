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

namespace WindowsFormsApp1.UI
{
    public partial class BranchViewFrm : Form
    {
        public BranchViewFrm()
        {
            InitializeComponent();
            LoadBranches();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void LoadBranches()
        {
            DataTable dt = BranchBL.GetAllBranches();
            MessageBox.Show("Rows: " + dt.Rows.Count);
            flowLayoutPanel1.Controls.Clear();

            foreach (DataRow row in dt.Rows)
            {
                UC_BranchCard card = new UC_BranchCard();
                card.BranchID = Convert.ToInt32(row["BranchID"]);
                card.BranchName = row["BranchName"].ToString();
                card.Contact = row["Contact"].ToString();
                card.Address = row["Address"].ToString();
                card.Status = row["Status"].ToString();
                card.BankCode = Convert.ToInt32(row["BankCode"]);

                

                flowLayoutPanel1.Controls.Add(card);
            }
        }
        private void FormX_Load(object sender, EventArgs e)
        {
            LoadBranches();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            BankHeadForm b = new BankHeadForm();
            b.Show();
        }
    }
}
