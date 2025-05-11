using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.BL;
using WindowsFormsApp1.DL;

namespace WindowsFormsApp1.UI
{
    public partial class ATM : Form
    {
        int id;
        public ATM(int id)
        {
            InitializeComponent();
            this.id = id;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

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
                if (futureLength > 4)
                {
                    e.Handled = true; // Block input if it would exceed 4 digits
                }
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
                if (futureLength > 5)
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

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if(ATMDL.CreditNumberExists(textBox1.Text,textBox2.Text))
            {
                label5.Visible = true;
                label6.Visible = true;
                label3.Visible = false;
                label4.Visible = false;
                textBox1.Visible = false;
                textBox2.Visible = false;
                textBox3.Visible = true;
                button1.Visible = true;
                button2.Visible = true;
                button3.Visible = true;
                button4.Visible = true;
                button5.Visible = true;
            }
            else
                MessageBox.Show("Invalid Card Number or Pin");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                ATMBL atm = new ATMBL(textBox1.Text, textBox2.Text);

                bool success = atm.DoWithdral(textBox1.Text, textBox2.Text, 1000);

                if (success)
                {
                    MessageBox.Show("Withdrawal successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Withdrawal Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                ATMBL atm = new ATMBL(textBox1.Text, textBox2.Text);

                bool success = atm.DoWithdral(textBox1.Text, textBox2.Text, 2000);

                if (success)
                {
                    MessageBox.Show("Withdrawal successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Withdrawal Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                ATMBL atm = new ATMBL(textBox1.Text, textBox2.Text);

                bool success = atm.DoWithdral(textBox1.Text, textBox2.Text, 3000);

                if (success)
                {
                    MessageBox.Show("Withdrawal successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Withdrawal Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                ATMBL atm = new ATMBL(textBox1.Text, textBox2.Text);

                bool success = atm.DoWithdral(textBox1.Text, textBox2.Text, 5000);

                if (success)
                {
                    MessageBox.Show("Withdrawal successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Withdrawal Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                ATMBL atm = new ATMBL(textBox1.Text, textBox2.Text);

                bool success = atm.DoWithdral(textBox1.Text, textBox2.Text, Convert.ToInt32(textBox3.Text));

                if (success)
                {
                    MessageBox.Show("Withdrawal successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Withdrawal Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
