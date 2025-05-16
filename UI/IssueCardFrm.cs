using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.BL;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1.UI
{
    public partial class IssueCardFrm : Form
    {
        public IssueCardFrm()
        {
            InitializeComponent();
            LoadRequester();
            LoadCustomer();
        }
        private void LoadCustomer()
        {
            string query = @"
        SELECT c.Name, r.RequestID 
        FROM servicerequests r
        JOIN customer c ON r.CustomerID = c.CustomerID
        WHERE r.Status = 'Active'"; // optional: filter only active requests
            DataTable dt = DataBaseHelper.Instance.ExecuteQuery(query);

            
            comboBox2.DataSource = dt;
            comboBox2.DisplayMember = "Name";
            comboBox2.ValueMember = "CustomerID";
        }
        private void LoadRequester()
        {
            string query = @"
        SELECT c.Name, r.RequestID 
        FROM servicerequests r
        JOIN customer c ON r.CustomerID = c.CustomerID
        WHERE r.Status = 'Active'"; // optional: filter only active requests

            DataTable dt = DataBaseHelper.Instance.ExecuteQuery(query);

            // Example: bind to DataGridView
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "RequestID";
            comboBox1.ValueMember = "RequestID";
        }
        private void button2_Click(object sender, EventArgs e)
        {
            int requestID = Convert.ToInt32(comboBox1.SelectedValue);
            int customerID = Convert.ToInt32(comboBox2.SelectedValue);
            decimal creditLimit = Convert.ToDecimal(textBox2.Text);
            string pin = Convert.ToString(textBox3.Text);

            // Create a CreditCardBL object to issue the card
            CreditCardBL creditCardBL = new CreditCardBL
            {
                RequestID = requestID,
                CustomerID = customerID,
                CreditLimit = creditLimit,
                 pin = pin

            };

            bool success = creditCardBL.IssueCreditCard();

            if (success)
            {
                MessageBox.Show("Credit Card Issued Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Failed to issue credit card. Please try again.", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            EmployeedashBoard employeedashBoard = new EmployeedashBoard();
            employeedashBoard.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
 }

