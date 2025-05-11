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
using System.Xml.Linq;
using WindowsFormsApp1.DL;

using iTextSharp.text;
using iTextSharp.text.pdf;


namespace WindowsFormsApp1.UI
{
    public partial class CustomerReport : Form
    {
        public CustomerReport()
        {
            InitializeComponent();
            LOadReport();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Show();

        }
        private void LOadReport()
        {
            dataGridView1.DataSource = ReportDL.CustomerRecentTrnasaction();
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
    }
}
