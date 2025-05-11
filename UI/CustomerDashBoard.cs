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
    public partial class CustomerDashBoard : Form
    {
        int id;
        public CustomerDashBoard(int id)
        {
            InitializeComponent();
            this.id = id;
            MessageBox.Show(id.ToString());
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Transaction transaction = new Transaction(id);
            transaction.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            ServiceRequests serviceRequests = new ServiceRequests(id);
            serviceRequests.Show();
        }

        private void CustomerDashBoard_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            ChangePin changePin = new ChangePin(id);
            changePin.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
            Complain complain = new Complain(id);
            complain.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddingCard addingCard= new AddingCard(id);
            addingCard.Show();
        }
    }
}
