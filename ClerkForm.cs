using InventoryManagementSystem;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace InventoryManagement.Views
{
    public partial class ClerkForm : Form
    {
        private System.Windows.Forms.Timer timer;
        private additem newItem;

        public ClerkForm()
        {
            InitializeComponent();
            LoadInventory();
            InitializeDateTimeFooter();
            SetBackgroundImage();
        }
        private void SetBackgroundImage()
        {
            // Set the background image of the form
            this.BackgroundImage = Image.FromFile("clerk.jpg");

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




        private string connectionString = " Data source = Pavleen; initial catalog=InventoryDB; integrated security= true";


        // Load inventory into DataGridView
        private void LoadInventory()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter("SELECT \r\n    p.ProductId,\r\n    p.ProductName,\r\n    c.CategoryName,\r\n    p.StockLevel,\r\n    p.Price,\r\n    p.RestockDate,\r\n    ISNULL(SUM(o.Quantity), 0) AS TotalOrders\r\nFROM \r\n    Products p\r\nJOIN \r\n    Categories c ON p.CategoryId = c.CategoryId\r\nLEFT JOIN \r\n    Orders o ON p.ProductId = o.ProductId\r\nGROUP BY \r\n    p.ProductId, p.ProductName, c.CategoryName, p.StockLevel, p.Price, p.RestockDate\r\nORDER BY \r\n    p.ProductName;", conn);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    dgvInventory.DataSource = table;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading inventory: {ex.Message}");
            }
        }

        // Add a new category
        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            string categoryName = Prompt.ShowDialog("Enter category name:", "Add Category");
            if (string.IsNullOrWhiteSpace(categoryName)) return;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO Categories (CategoryName) VALUES (@CategoryName)", conn);
                    cmd.Parameters.AddWithValue("@CategoryName", categoryName);
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Category added successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding category: {ex.Message}");
            }
        }

        // Delete a category
        private void btnDeleteCategory_Click(object sender, EventArgs e)
        {
            string categoryName = Prompt.ShowDialog("Enter category name to delete:", "Delete Category");
            if (string.IsNullOrWhiteSpace(categoryName)) return;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("DELETE FROM Categories WHERE CategoryName = @CategoryName", conn);
                    cmd.Parameters.AddWithValue("@CategoryName", categoryName);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Category deleted successfully.");
                    }
                    else
                    {
                        MessageBox.Show("Category not found.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting category: {ex.Message}");
            }
        }

        // Place an order
        private void btnPlaceOrder_Click(object sender, EventArgs e)
        {
            // Prompt user for input
            string productId = Prompt.ShowDialog("Enter Product ID:", "Place Order");
            string quantityStr = Prompt.ShowDialog("Enter Quantity:", "Place Order");

            // Validate input
            if (!int.TryParse(productId, out int productIdInt) || !int.TryParse(quantityStr, out int quantity))
            {
                MessageBox.Show("Invalid input. Please enter valid Product ID and Quantity.");
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Begin a transaction
                    using (SqlTransaction transaction = conn.BeginTransaction())
                    {
                        try
                        {
                            // Update stock level and set the restock date to today's date
                            SqlCommand updateProductCmd = new SqlCommand(
                                "UPDATE Products " +
                                "SET StockLevel = StockLevel + @Quantity, RestockDate = @RestockDate " +
                                "WHERE ProductId = @ProductId", conn, transaction);

                            updateProductCmd.Parameters.AddWithValue("@ProductId", productIdInt);
                            updateProductCmd.Parameters.AddWithValue("@Quantity", quantity);
                            updateProductCmd.Parameters.AddWithValue("@RestockDate", DateTime.Now);

                            int rowsAffected = updateProductCmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                // Insert the order into the Orders table
                                SqlCommand insertOrderCmd = new SqlCommand(
                                    "INSERT INTO Orders (ProductId, Quantity, OrderDate, Status) " +
                                    "VALUES (@ProductId, @Quantity, @OrderDate, @Status)", conn, transaction);

                                insertOrderCmd.Parameters.AddWithValue("@ProductId", productIdInt);
                                insertOrderCmd.Parameters.AddWithValue("@Quantity", quantity);
                                insertOrderCmd.Parameters.AddWithValue("@OrderDate", DateTime.Now);
                                insertOrderCmd.Parameters.AddWithValue("@Status", "Processing");

                                insertOrderCmd.ExecuteNonQuery();

                                // Commit the transaction
                                transaction.Commit();

                                MessageBox.Show("Order placed successfully. Restock date updated to today. Order status: Processing.");
                                LoadInventory(); // Refresh the inventory view
                            }
                            else
                            {
                                // Rollback the transaction if the Product ID is invalid
                                transaction.Rollback();
                                MessageBox.Show("Invalid Product ID or order could not be placed.");
                            }
                        }
                        catch (Exception ex)
                        {
                            // Rollback the transaction in case of an error
                            transaction.Rollback();
                            throw; // Re-throw the exception to be caught by the outer catch block
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error placing order: {ex.Message}");
            }
        }


        private void btnlogout_Click(object sender, EventArgs e)
        {

            this.Close();
            MainForm mainForm = new MainForm();
            mainForm.Show();
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            // Open the add item form
            additem newItemForm = new additem();

            // Show the form as a dialog and wait for it to close
            if (newItemForm.ShowDialog() == DialogResult.OK)
            {
                // Reload inventory after the form is closed
                LoadInventory();
            }
        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Check if a row is selected
            if (dgvInventory.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a product to delete.");
                return;
            }

            // Get the ProductId of the selected row
            int selectedRowIndex = dgvInventory.SelectedRows[0].Index;
            int productId = Convert.ToInt32(dgvInventory.Rows[selectedRowIndex].Cells["ProductId"].Value);

            // Confirm deletion with the user
            DialogResult result = MessageBox.Show("Are you sure you want to delete this product?",
                                                  "Confirm Delete",
                                                  MessageBoxButtons.YesNo,
                                                  MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        // Delete the product from the database
                        SqlCommand cmd = new SqlCommand("DELETE FROM Products WHERE ProductId = @ProductId", conn);
                        cmd.Parameters.AddWithValue("@ProductId", productId);
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Product deleted successfully.");
                            // Refresh the inventory
                            LoadInventory();
                        }
                        else
                        {
                            MessageBox.Show("Product not found or could not be deleted.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting product: {ex.Message}");
                }
            }
        }

        private void btnNotifications_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Query to get products with stock level less than 3
                    SqlCommand cmd = new SqlCommand(
                        "SELECT ProductId, ProductName, StockLevel, RestockDate " +
                        "FROM Products " +
                        "WHERE StockLevel < 3", conn);

                    SqlDataReader reader = cmd.ExecuteReader();

                    // Check if any product meets the condition
                    if (!reader.HasRows)
                    {
                        MessageBox.Show("All products have sufficient stock.");
                        return;
                    }

                    // Build a message with the product details
                    string message = "The following products have low stock levels:\n\n";
                    while (reader.Read())
                    {
                        int productId = reader.GetInt32(0);
                        string productName = reader.GetString(1);
                        int stockLevel = reader.GetInt32(2);
                        string restockDate = reader.IsDBNull(3) ? "Not Scheduled" : reader.GetDateTime(3).ToString("dd MMM yyyy");

                        message += $"Product ID: {productId}\n" +
                                   $"Product Name: {productName}\n" +
                                   $"Stock Level: {stockLevel}\n" +
                                   $"Restock Date: {restockDate}\n\n";
                    }

                    reader.Close();

                    // Display the message
                    MessageBox.Show(message, "Low Stock Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error checking stock levels: {ex.Message}");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Check if a row is selected
            if (dgvInventory.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a product to update the stock level.");
                return;
            }

            // Get the ProductId of the selected row
            int selectedRowIndex = dgvInventory.SelectedRows[0].Index;
            int productId = Convert.ToInt32(dgvInventory.Rows[selectedRowIndex].Cells["ProductId"].Value);

            // Prompt the user to enter a new stock level
            string newStockLevelStr = Prompt.ShowDialog("Enter new stock level:", "Update Stock Level");

            // Validate the input
            if (!int.TryParse(newStockLevelStr, out int newStockLevel) || newStockLevel < 0)
            {
                MessageBox.Show("Please enter a valid stock level (non-negative integer).");
                return;
            }

            try
            {
                // Update the stock level in the database
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(
                        "UPDATE Products SET StockLevel = @StockLevel WHERE ProductId = @ProductId", conn);
                    cmd.Parameters.AddWithValue("@StockLevel", newStockLevel);
                    cmd.Parameters.AddWithValue("@ProductId", productId);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Stock level updated successfully.");
                        LoadInventory(); // Refresh the inventory view
                    }
                    else
                    {
                        MessageBox.Show("Failed to update stock level. Product not found.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating stock level: {ex.Message}");
            }
        }

    }

    // Utility class for prompting user input
    public static class Prompt
    {
        public static string ShowDialog(string text, string caption)
        {
            Form prompt = new Form()
            {
                Width = 400,
                Height = 150,
                Text = caption
            };
            Label label = new Label() { Left = 20, Top = 20, Text = text };
            TextBox inputBox = new TextBox() { Left = 20, Top = 50, Width = 340 };
            Button confirmation = new Button() { Text = "OK", Left = 150, Width = 100, Top = 80, DialogResult = DialogResult.OK };
            prompt.Controls.Add(label);
            prompt.Controls.Add(inputBox);
            prompt.Controls.Add(confirmation);
            prompt.AcceptButton = confirmation;

            return prompt.ShowDialog() == DialogResult.OK ? inputBox.Text : null;
        }
    }
}
