using InventoryManagementSystem;
using InventoryManagementSystem.NewFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace InventoryManagement.Views
{
    public partial class ManagerForm : Form
    {
        private DatabaseHelper dbHelper;
        private System.Windows.Forms.Timer timer;
        public ManagerForm()
        {
            InitializeComponent();
            this.Load += ManagerForm_Load;
            dbHelper = new DatabaseHelper(); // Initialize DatabaseHelper
            InitializeDateTimeFooter();
            SetBackgroundImage();
        }
        private void SetBackgroundImage()
        {
            // Set the background image of the form
            this.BackgroundImage = Image.FromFile("manager.jpg");

            // Optionally, you can set the background image layout
            this.BackgroundImageLayout = ImageLayout.Stretch; // or ImageLayout.Center, ImageLayout.Zoom, etc.
        }
        private void InitializeDateTimeFooter()
        {
            // Initialize the Timer
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 1000; // Update every second
            timer.Tick += Timer_Tick;
            timer.Start();
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            // Update the date and time in the status strip
            toolStripStatusLabelDateTime.Text = DateTime.Now.ToString("dddd, MMMM dd yyyy HH:mm:ss");
        }

        private void ManagerForm_Load(object sender, EventArgs e)
        {
            try
            {
                // Fetch products and orders from the database
                List<Product> products = dbHelper.GetProducts();
                List<Order> orders = dbHelper.GetOrders();

                // Bind the fetched data to the respective DataGridViews
                dgvProducts.DataSource = products;
                dgvOrders.DataSource = orders;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReviewOrders_Click(object sender, EventArgs e)
        {
            try
            {
                List<Order> orders = dbHelper.GetOrders();
                AnalysisForm analysisForm = new AnalysisForm(orders);
                analysisForm.Show(); ;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error reviewing orders: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAnalyzeInventory_Click(object sender, EventArgs e)
        {
            try
            {
                List<Product> products = dbHelper.GetProducts();

                // Open the analysis form
                AnalysisForm analysisForm = new AnalysisForm(products);
                analysisForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error analyzing inventory: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnUpdatePrice_Click(object sender, EventArgs e)
        {
            try
            {
                int productId = Convert.ToInt32(txtProductId.Text);
                decimal newPrice = Convert.ToDecimal(txtNewPrice.Text);

                dbHelper.UpdateProductPrice(productId, newPrice);
                MessageBox.Show($"Price updated successfully for Product ID: {productId}", "Update Price", MessageBoxButtons.OK, MessageBoxIcon.Information);

                dgvProducts.DataSource = dbHelper.GetProducts(); // Refresh products grid
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating price: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCheckStock_Click(object sender, EventArgs e)
        {
            try
            {
                List<Product> lowStockProducts = dbHelper.GetLowStockProducts();

                string message = lowStockProducts.Any()
                    ? string.Join(Environment.NewLine, lowStockProducts.Select(p => $"{p.ProductName}: {p.StockLevel} in stock"))
                    : "All products have sufficient stock.";

                MessageBox.Show(message, "Stock Check", MessageBoxButtons.OK, lowStockProducts.Any() ? MessageBoxIcon.Warning : MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error checking stock: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReviewOrders_Click_1(object sender, EventArgs e)
        {

        }

        private void btnlogout_Click(object sender, EventArgs e)
        {

            this.Close();
            MainForm mainForm = new MainForm();
            mainForm.Show();
        }

        private void btngraph_Click(object sender, EventArgs e)
        {
            try
            {
                // Fetch products data
                List<Product> products = dbHelper.GetProducts();


                // Create an instance of the ChartForm and pass the products data
                ChartForm chartForm = new ChartForm(products);
              

                foreach (var product in products)
                {
                    chartForm.Show();
                }

                // Show the MessageBox with the product information
               
                // Show the chart form
               
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error generating graph: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
