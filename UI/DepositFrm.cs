using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.UI
{
    public partial class DepositFrm : Form
    {
        public DepositFrm()
        {
            InitializeComponent();
            LoadAccount();

        }
        private void LoadAccount()
        {
            string query = $"Select AccountID , AccountNumber from account";
            comboBox1.DataSource = DataBaseHelper.Instance.ExecuteQuery(query);
            comboBox1.DisplayMember= "AccountNumber";
            comboBox1.ValueMember = "AccountID";
        }
        private void DepositFrm_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
             
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int account = Convert.ToInt32(comboBox1.SelectedValue);
            int amount = Convert.ToInt32(textBox1.Text);
            string query = $"Update account SET Balance = '{amount}' where AccountNumber = '{account}' ";

            EmployeedashBoard em = new EmployeedashBoard();
            em.Show();
            this.Close();
        }
    }
}
