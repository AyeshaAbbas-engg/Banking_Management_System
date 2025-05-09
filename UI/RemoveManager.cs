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
    public partial class RemoveManager : Form
    {
        AssignManager am;
        public RemoveManager(AssignManager am)
        {
            InitializeComponent();
            PopulateBranchComboBox();
            this.am = am;
        }
        private void PopulateBranchComboBox()
        {
            string query = "SELECT branch.BranchID, branch.BranchName FROM branch join Employee on Employee.BranchID =  branch.BranchID where Employee.ManagerID is not null ";
            DataTable dt = DataBaseHelper.GetData(query);

            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "BranchName";  // what shows in dropdown
            comboBox1.ValueMember = "BranchID";      // actual value (hidden)
        }
        private void RemoveManager_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            EmployeeDL.SoftDeleteManager(Convert.ToInt32(comboBox1.SelectedValue));
            MessageBox.Show("Manager Removed Successfully");
            am.LoadActiveEmployees();
            this.Close();
        }
    }
}
