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
    public partial class ChangePin : Form
    {
        int id;
        public ChangePin(int id)
        {
            InitializeComponent();
            this.id = id;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Block non-digit input
                return;
            }

            if (char.IsDigit(e.KeyChar))
            {
                // Calculate future length after this input
                int futureLength = textBox1.Text.Length - textBox1.SelectionLength + 1;
                if (futureLength > 16)
                {
                    e.Handled = true; // Block input if it would exceed 4 digits
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 16)
            {
                textBox1.Text = textBox1.Text.Substring(0, 16); // Trim to 4 digits
                textBox1.SelectionStart = textBox1.Text.Length; // Move cursor to end
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text.Length > 4)
            {
                textBox2.Text = textBox2.Text.Substring(0, 4); // Trim to 4 digits
                textBox2.SelectionStart = textBox2.Text.Length; // Move cursor to end
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Block non-digit input
                return;
            }

            if (char.IsDigit(e.KeyChar))
            {
                // Calculate future length after this input
                int futureLength = textBox2.Text.Length - textBox2.SelectionLength + 1;
                if (futureLength > 16)
                {
                    e.Handled = true; // Block input if it would exceed 4 digits
                }
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.Text.Length > 4)
            {
                textBox3.Text = textBox3.Text.Substring(0, 4); // Trim to 4 digits
                textBox3.SelectionStart = textBox3.Text.Length; // Move cursor to end
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Block non-digit input
                return;
            }

            if (char.IsDigit(e.KeyChar))
            {
                // Calculate future length after this input
                int futureLength = textBox3.Text.Length - textBox3.SelectionLength + 1;
                if (futureLength > 4)
                {
                    e.Handled = true; // Block input if it would exceed 4 digits
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool valid= CreditCardDL.ValidateCardPin(textBox1.Text, textBox2.Text,id);
            if (valid)
            {
                CreditCardDL.UpdateCardPin(textBox1.Text, textBox3.Text,id);
                MessageBox.Show("Pin has been Changed Successfully");
            }
            else
                MessageBox.Show("Invalid CardNumber or Pin");
            this.Hide();    
            
        }
    }
}
