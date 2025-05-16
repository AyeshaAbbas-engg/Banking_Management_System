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
    public partial class ChequeLeafFrm : Form
    {
        public static ChequeLeafFrm instance;
        public ChequeLeafFrm()
        {
            InitializeComponent();
            LoadCheque();
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            instance = this;
        }
      
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {try
            {
                if (comboBox1.SelectedValue != null)
                {

                    int chequeBookID = Convert.ToInt32(comboBox1.SelectedValue);
                    int availableLeaves = AddChequeLeafDL.GetAvailableLeavesCount(chequeBookID);


                    MessageBox.Show($"There are {availableLeaves} available leaves in ChequeBook ID {chequeBookID}.",
                                "Leaf Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)

            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        

        private void LoadCheque()
        {
            string query = $"select * from ChequeBooks where Status = 'Issued'";
            DataTable dt = DataBaseHelper.Instance.ExecuteQuery(query);
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "ChequeBookID";
            comboBox1.ValueMember= "ChequeBookID";
        }
        private void button2_Click(object sender, EventArgs e)
        {
            AddChequeLeafBL leaf = new AddChequeLeafBL
            {
                ChequeBookID = Convert.ToInt32(comboBox1.SelectedValue),
                LeafNumber = Convert.ToInt32(textBox2.Text),
                IssueDate = DateTime.Now,

                Amount = Convert.ToDecimal(textBox1.Text),
                Status = "Issued"
            };

            bool success = AddChequeLeafDL.AddChequeLeaf(leaf);
            int chequeBookID = leaf.ChequeBookID;
            int remainingLeaves = AddChequeLeafDL.GetAvailableLeavesCount(chequeBookID);

            if (remainingLeaves <= 0)
            {
                // Fully used ho chuki hai, update status
                AddChequeLeafDL.MarkChequeBookAsUsed(chequeBookID);
            }


            if (success)
            {
                MessageBox.Show("Cheque leaf issued and ChequeBook updated!");
                //LoadChequeBookStatus();
            }
            else
            {
                MessageBox.Show("Failed to issue cheque leaf.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EmployeedashBoard employeeDashBoard = new EmployeedashBoard();
            employeeDashBoard.Show();
            this.Hide();
        }
    }
}
