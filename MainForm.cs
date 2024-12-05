using System;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using System.Text;
using System.Security.Cryptography;



namespace InventoryManagement.Views
{
    public partial class MainForm : Form
    {
        private System.Windows.Forms.Timer timer;
        string connectionString = " Data source = Pavleen; initial catalog=InventoryDB; integrated security= true";


        public MainForm()
        {
            InitializeComponent();
            InitializeDateTimeFooter();
            SetBackgroundImage();

        }
        private void SetBackgroundImage()
        {
            // Set the background image of the form
            this.BackgroundImage = Image.FromFile("inventory.jpg");

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


        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtusername.Text.Trim();
            string password = txtpassword.Text.Trim();

            // Check if username and password match in the database
            if (AuthenticateUser(username, password))
            {
                // Open the appropriate form based on the username
                if (username.ToLower() == "manager")
                {
                    var managerForm = new ManagerForm();
                    managerForm.Show();
                }
                else if (username.ToLower() == "clerk")
                {
                    var clerkForm = new ClerkForm();
                    clerkForm.Show();
                }

            this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid username or password.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private bool AuthenticateUser(string username, string password)
        {


            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Query to fetch user based on username
                    string query = "SELECT PasswordHash FROM Users WHERE Username = @Username";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Username", username);

                        object result = command.ExecuteScalar();

                        if (result != null)
                        {
                            string storedPasswordHash = result.ToString();

                            // Compare hashed passwords
                            return VerifyPassword(password, storedPasswordHash);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error connecting to database: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return false;
        }

        private bool VerifyPassword(string password, string storedHash)
        {
            // Generate the hash of the entered password
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(password);
                byte[] hash = sha256.ComputeHash(bytes);

                // Convert the byte array into a hexadecimal string
                string hashedPassword = BytesToHexString(hash);


                // Compare the entered password's hash (as hex) with the stored hash
                return string.Equals(hashedPassword, storedHash, StringComparison.OrdinalIgnoreCase);
            }
        }

        // Helper method to convert byte array to hexadecimal string
        private string BytesToHexString(byte[] bytes)
        {
            StringBuilder sb = new StringBuilder(bytes.Length * 2);
            foreach (byte b in bytes)
            {
                sb.Append(b.ToString("x2")); // Convert each byte to a 2-character hex string
            }
            return sb.ToString();
        }
    }
}

