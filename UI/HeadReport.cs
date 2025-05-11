using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text.pdf;
using iTextSharp.text;
using WindowsFormsApp1.DL;

namespace WindowsFormsApp1.UI
{
    public partial class HeadReport : Form
    {
        public HeadReport()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Show();
        }
       
        private void LOadReport()
        {
            dataGridView1.DataSource = ReportDL.CustomerRecentTrnasaction();
        }
        private void LOadReport1()
        {
            dataGridView1.DataSource = ReportDL.TakeAccountSummaryPerBranch();
        }
        private void Show()
        {
            if (dataGridView1.Rows.Count > 0)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "PDF Files|*.pdf";
                sfd.FileName = "Report.pdf";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    Document doc = new Document();
                    PdfWriter.GetInstance(doc, new FileStream(sfd.FileName, FileMode.Create));
                    doc.Open();

                    PdfPTable table = new PdfPTable(dataGridView1.Columns.Count);
                    foreach (DataGridViewColumn col in dataGridView1.Columns)
                    {
                        table.AddCell(new Phrase(col.HeaderText));
                    }

                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            table.AddCell(cell.Value?.ToString() ?? "");
                        }
                    }

                    doc.Add(table);
                    doc.Close();
                    MessageBox.Show("PDF exported successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedReport = comboBox1.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(selectedReport))
            {
                MessageBox.Show("Please select a report type.");
                return;
            }

            switch (selectedReport)
            {
                case "Account Report":
                    dataGridView1.DataSource = ReportDL.TakeAccountSummaryPerBranch();
                    break;
                case "Transaction Report":
                    dataGridView1.DataSource = ReportDL.TotalTransactionperbranch();
                    break;
                
                default:
                    MessageBox.Show("Invalid report selection.");
                    break;
            }
        
    }
    }
}
