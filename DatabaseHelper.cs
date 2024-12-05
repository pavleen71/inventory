using InventoryManagementSystem.NewFolder;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace InventoryManagementSystem
{
    public class DatabaseHelper
    {
        private readonly string connectionString;

        public DatabaseHelper()
        {
            connectionString = "Data Source=Pavleen;Initial Catalog=InventoryDB;Integrated Security=True";
        }

        // Fetch all products from the database
        public List<Product> GetProducts()
        {
            List<Product> products = new List<Product>();
            SqlConnection conn = null;
            SqlCommand cmd = null;
            SqlDataReader reader = null;

            try
            {
                conn = new SqlConnection(connectionString);
                conn.Open();
                string query = "SELECT * FROM Products";
                cmd = new SqlCommand(query, conn);
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Product product = new Product
                    {
                        ProductId = (int)reader["ProductId"],
                        ProductName = reader["ProductName"].ToString(),
                        StockLevel = (int)reader["StockLevel"],
                        Price = (decimal)reader["Price"],
                        RestockDate = (DateTime)reader["RestockDate"],
                        CategoryId = (int)reader["CategoryId"]
                    };
                    products.Add(product);
                }
            }
            finally
            {
                reader?.Close();
                cmd?.Dispose();
                conn?.Close();
                conn?.Dispose();
            }

            return products;
        }

        // Add a new product
        public void AddProduct(Product product)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                conn = new SqlConnection(connectionString);
                conn.Open();
                string query = "INSERT INTO Products (ProductName, StockLevel, Price, CategoryId) " +
                               "VALUES (@ProductName, @StockLevel, @Price, @CategoryId)";
                cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@ProductName", product.ProductName);
                cmd.Parameters.AddWithValue("@StockLevel", product.StockLevel);
                cmd.Parameters.AddWithValue("@Price", product.Price);
                cmd.Parameters.AddWithValue("@CategoryId", product.CategoryId);

                cmd.ExecuteNonQuery();
            }
            finally
            {
                cmd?.Dispose();
                conn?.Close();
                conn?.Dispose();
            }
        }

        // Update an existing product
        public void UpdateProduct(Product product)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                conn = new SqlConnection(connectionString);
                conn.Open();
                string query = "UPDATE Products SET ProductName = @ProductName, StockLevel = @StockLevel, Price = @Price, " +
                               "CategoryId = @CategoryId WHERE ProductId = @ProductId";
                cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@ProductId", product.ProductId);
                cmd.Parameters.AddWithValue("@ProductName", product.ProductName);
                cmd.Parameters.AddWithValue("@StockLevel", product.StockLevel);
                cmd.Parameters.AddWithValue("@Price", product.Price);
                cmd.Parameters.AddWithValue("@CategoryId", product.CategoryId);

                cmd.ExecuteNonQuery();
            }
            finally
            {
                cmd?.Dispose();
                conn?.Close();
                conn?.Dispose();
            }
        }

        // Delete a product
        public void DeleteProduct(int productId)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                conn = new SqlConnection(connectionString);
                conn.Open();
                string query = "DELETE FROM Products WHERE ProductId = @ProductId";
                cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@ProductId", productId);

                cmd.ExecuteNonQuery();
            }
            finally
            {
                cmd?.Dispose();
                conn?.Close();
                conn?.Dispose();
            }
        }

        // Place an order
        public void PlaceOrder(Order order)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                conn = new SqlConnection(connectionString);
                conn.Open();
                string query = "INSERT INTO Orders (ProductId, Quantity, OrderDate, Status) " +
                               "VALUES (@ProductId, @Quantity, @OrderDate, @Status)";
                cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@ProductId", order.ProductId);
                cmd.Parameters.AddWithValue("@Quantity", order.Quantity);
                cmd.Parameters.AddWithValue("@OrderDate", order.OrderDate);
                cmd.Parameters.AddWithValue("@Status", order.Status);

                cmd.ExecuteNonQuery();
            }
            finally
            {
                cmd?.Dispose();
                conn?.Close();
                conn?.Dispose();
            }
        }

        // Update product price
        public void UpdateProductPrice(int productId, decimal newPrice)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                conn = new SqlConnection(connectionString);
                conn.Open();
                string query = "UPDATE Products SET Price = @Price WHERE ProductId = @ProductId";
                cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@Price", newPrice);
                cmd.Parameters.AddWithValue("@ProductId", productId);

                cmd.ExecuteNonQuery();
                
            }
            finally
            {
                cmd?.Dispose();
                conn?.Close();
                conn?.Dispose();
            }
        }

        // Fetch products with low stock
        public List<Product> GetLowStockProducts()
        {
            List<Product> lowStockProducts = new List<Product>();
            SqlConnection conn = null;
            SqlCommand cmd = null;
            SqlDataReader reader = null;

            try
            {
                conn = new SqlConnection(connectionString);
                conn.Open();
                string query = "SELECT * FROM Products WHERE StockLevel < 10"; // Example threshold
                cmd = new SqlCommand(query, conn);
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Product product = new Product
                    {
                        ProductId = (int)reader["ProductId"],
                        ProductName = reader["ProductName"].ToString(),
                        StockLevel = (int)reader["StockLevel"],
                        Price = (decimal)reader["Price"],
                        CategoryId = (int)reader["CategoryId"]
                    };
                    lowStockProducts.Add(product);
                }
            }
            finally
            {
                reader?.Close();
                cmd?.Dispose();
                conn?.Close();
                conn?.Dispose();
            }

            return lowStockProducts;
        }

        // Fetch all orders
        public List<Order> GetOrders()
        {
            List<Order> orders = new List<Order>();
            SqlConnection conn = null;
            SqlCommand cmd = null;
            SqlDataReader reader = null;

            try
            {
                conn = new SqlConnection(connectionString);
                conn.Open();
                string query = "SELECT * FROM Orders";
                cmd = new SqlCommand(query, conn);
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Order order = new Order
                    {
                        OrderId = (int)reader["OrderId"],
                        ProductId = (int)reader["ProductId"],
                        Quantity = (int)reader["Quantity"],
                        OrderDate = (DateTime)reader["OrderDate"],
                        Status = reader["Status"].ToString()
                    };
                    orders.Add(order);
                }
            }
            finally
            {
                reader?.Close();
                cmd?.Dispose();
                conn?.Close();
                conn?.Dispose();
            }

            return orders;
        }

        // Add a category
        public void AddCategory(string categoryName)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                conn = new SqlConnection(connectionString);
                conn.Open();
                string query = "INSERT INTO Categories (CategoryName) VALUES (@CategoryName)";
                cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@CategoryName", categoryName);

                cmd.ExecuteNonQuery();
            }
            finally
            {
                cmd?.Dispose();
                conn?.Close();
                conn?.Dispose();
            }
        }

        // Delete a category
        public void DeleteCategory(int categoryId)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                conn = new SqlConnection(connectionString);
                conn.Open();
                string query = "DELETE FROM Categories WHERE CategoryId = @CategoryId";
                cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@CategoryId", categoryId);

                cmd.ExecuteNonQuery();
            }
            finally
            {
                cmd?.Dispose();
                conn?.Close();
                conn?.Dispose();
            }
        }
    }
}
