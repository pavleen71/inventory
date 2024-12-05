using InventoryManagementSystem.NewFolder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace InventoryManagementSystem
{
    public partial class ChartForm : Form
    {


        public ChartForm(List<Product> products)
        {
            InitializeComponent();
            CreateChart(products);
        }

        private void CreateChart(List<Product> products)
        {
            // Create a new Chart control
            Chart chart = new Chart
            {
                Dock = DockStyle.Fill // Fill the form with the chart
            };
            this.Controls.Add(chart); // Add the chart to the form's controls

            // Set up the chart area
            ChartArea chartArea = new ChartArea("MainArea");
            chart.ChartAreas.Add(chartArea);

            // Initialize the X-axis categories (product names)
            List<string> productNames = products.Select(p => p.ProductName).ToList();

            // Set the X-axis labels (product names)
            ; // Rotate labels for readability
            chartArea.AxisX.Interval = 1; // Set the interval for X-axis labels

            // Loop through the products and create a new series for each product
            foreach (var product in products)
            {
                // Create a new Series for each product
                Series series = new Series(product.ProductName)
                {
                    ChartType = SeriesChartType.Bar, // Bar chart type
                    XValueType = ChartValueType.String, // Ensure x-axis is treated as strings (product names)
                    YValueType = ChartValueType.Int32 // Y-axis is treated as integers (stock levels)
                };

                // Add product name (X value) and stock level (Y value) to the series
                series.Points.AddY(product.StockLevel);
                
                // Add the series to the chart
                chart.Series.Add(series);
            }
           

            // Customize the chart appearance
            // Optionally remove legends
            chart.Titles.Clear();
            chart.Titles.Add("Product Stock Levels");

            // Adjust the size of the chart dynamically based on the number of products
            if (products.Count > 10)
            {
                chart.Width = products.Count * 50; // Increase the width if there are more than 10 products
            }

            // Ensure minimum chart width
            chart.Width = Math.Max(chart.Width, 600);
        }



        private void ChartForm_Load(object sender, EventArgs e)
        {

        }
    }
    }
