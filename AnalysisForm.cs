using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Windows.Forms;
using InventoryManagementSystem.NewFolder;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace InventoryManagementSystem
{
    public partial class AnalysisForm : Form
    {
        public AnalysisForm()
        {
            InitializeComponent();
        }

        public AnalysisForm(List<Product> products)
        {
            InitializeComponent();
            dgvAnalysis.DataSource = products.Select(p => new
            {
                ProductID = p.ProductId,
                ProductName = p.ProductName,
                StockLevel = p.StockLevel,
                RestockDate = p.RestockDate,
                Category = p.CategoryId,
                Price = p.Price
            }).ToList();
        }
        public AnalysisForm(List<Order> orders)
        {
            InitializeComponent();
            dgvAnalysis.DataSource = orders.Select(p => new
            {
                OrderID = p.OrderId,
                ProductId = p.ProductId,
                Quantity = p.Quantity,
                OrderDate = p.OrderDate,
                
                status = p.Status
            }).ToList();
        }

        private void btnSaveReport_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "PDF files (*.pdf)|*.pdf",
                Title = "Save Inventory Analysis Report"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Create a new document
                    iTextSharp.text.Document document = new iTextSharp.text.Document();
                    PdfWriter.GetInstance(document, new FileStream(saveFileDialog.FileName, FileMode.Create));

                    // Open the document to add content
                    document.Open();

                    // Add title to the PDF
                    document.Add(new Paragraph("Inventory Analysis Report"));
                    document.Add(new Paragraph($"Date: {DateTime.Now.ToString("MM/dd/yyyy")}"));
                    document.Add(new Paragraph("\n"));

                    // Create a table for the data
                    PdfPTable table = new PdfPTable(dgvAnalysis.Columns.Count);

                    // Add headers
                    foreach (DataGridViewColumn column in dgvAnalysis.Columns)
                    {
                        table.AddCell(column.HeaderText);
                    }

                    // Add rows from DataGridView
                    foreach (DataGridViewRow row in dgvAnalysis.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            foreach (DataGridViewCell cell in row.Cells)
                            {
                                table.AddCell(cell.Value?.ToString() ?? "");
                            }
                        }
                    }

                    // Add table to document
                    document.Add(table);

                    // Close the document
                    document.Close();

                    MessageBox.Show("Report saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error saving report: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
