using InventoryManagementSystem.NewFolder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;


namespace InventoryManagementSystem
{
    public partial class additem : Form
    {
         private string connectionString = "Data Source=Pavleen;Initial Catalog=InventoryDB;Integrated Security=True";
        public additem()
        {
            InitializeComponent();
            
        }

        private void btn_Add(object sender, EventArgs e)
        {
            // Collect the data from the form controls
            string itemName = txtItemName.Text;
            string category = txtCategory.Text;
            int quantity;
            decimal price;
            DateTime restockDate = dtpRestockDate.Value;

            // Validate inputs (make sure quantity and price are valid numbers)
            if (!int.TryParse(txtQuantity.Text, out quantity))
            {
                MessageBox.Show("Please enter a valid quantity.");
                return;
            }

            if (!decimal.TryParse(txtPrice.Text, out price))
            {
                MessageBox.Show("Please enter a valid price.");
                return;
            }

            // Check if the category exists in the database
            int categoryId = GetCategoryId(category);
            if (categoryId == -1)
            {
                MessageBox.Show("The category does not exist.");
                return;
            }

            try
            {
                // Insert the product into the Products table
                InsertProduct(itemName, quantity, price, restockDate, categoryId);

                // Optionally, clear the form fields after adding the item
                txtItemName.Clear();
                txtCategory.Clear();
                txtQuantity.Clear();
                txtPrice.Clear();
                dtpRestockDate.Value = DateTime.Now;

                MessageBox.Show("Item added successfully!");

                // Notify the parent form that the operation was successful
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding item: {ex.Message}");
            }
        }


        private int GetCategoryId(string categoryName)
        {
            int categoryId = -1;

            // Establish connection to the database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                // Check if the category exists in the Categories table
                string query = "SELECT CategoryId FROM Categories WHERE CategoryName = @CategoryName";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Add parameter to prevent SQL injection
                    command.Parameters.AddWithValue("@CategoryName", categoryName);

                    // Execute the query and retrieve the CategoryId
                    var result = command.ExecuteScalar();

                    if (result != null)
                    {
                        categoryId = Convert.ToInt32(result);
                    }
                }
            }

            return categoryId;
        }

        private void InsertProduct(string productName, int stockLevel, decimal price, DateTime restockDate, int categoryId)
        {
            // Establish connection to the database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                // Insert the product into the Products table
                string query = "INSERT INTO Products (ProductName, StockLevel, Price, RestockDate, CategoryId) " +
                               "VALUES (@ProductName, @StockLevel, @Price, @RestockDate, @CategoryId)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Add parameters to prevent SQL injection
                    command.Parameters.AddWithValue("@ProductName", productName);
                    command.Parameters.AddWithValue("@StockLevel", stockLevel);
                    command.Parameters.AddWithValue("@Price", price);
                    command.Parameters.AddWithValue("@RestockDate", restockDate);
                    command.Parameters.AddWithValue("@CategoryId", categoryId);

                    // Execute the query to insert the product
                    command.ExecuteNonQuery();
                }
            }
        }

    }
}
