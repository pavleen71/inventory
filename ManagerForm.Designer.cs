namespace InventoryManagement.Views
{
    partial class ManagerForm
    {
        private System.ComponentModel.IContainer components = null;
        private Button btnReviewOrders;
        private Button btnAnalyzeInventory;
        private Button btnUpdatePrice;
        private Button btnCheckStock;
        private DataGridView dgvProducts;
        private DataGridView dgvOrders;
        private Label lblManagerTitle;
        private TextBox txtProductId;
        private TextBox txtNewPrice;

        // Clean up any resources being used.
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        // Required method for Designer support
        private void InitializeComponent()
        {
            btnReviewOrders = new Button();
            btnAnalyzeInventory = new Button();
            btnUpdatePrice = new Button();
            btnCheckStock = new Button();
            dgvProducts = new DataGridView();
            dgvOrders = new DataGridView();
            lblManagerTitle = new Label();
            txtProductId = new TextBox();
            txtNewPrice = new TextBox();
            statusStrip1 = new StatusStrip();
            toolStripStatusLabelDateTime = new ToolStripStatusLabel();
            btnlogout = new Button();
            btngraph = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvOrders).BeginInit();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // btnReviewOrders
            // 
            btnReviewOrders.Location = new Point(50, 70);
            btnReviewOrders.Name = "btnReviewOrders";
            btnReviewOrders.Size = new Size(120, 40);
            btnReviewOrders.TabIndex = 1;
            btnReviewOrders.Text = "Review Orders";
            btnReviewOrders.Click += btnReviewOrders_Click;
            // 
            // btnAnalyzeInventory
            // 
            btnAnalyzeInventory.Location = new Point(236, 70);
            btnAnalyzeInventory.Name = "btnAnalyzeInventory";
            btnAnalyzeInventory.Size = new Size(120, 40);
            btnAnalyzeInventory.TabIndex = 2;
            btnAnalyzeInventory.Text = "Analyze Inventory";
            btnAnalyzeInventory.Click += btnAnalyzeInventory_Click;
            // 
            // btnUpdatePrice
            // 
            btnUpdatePrice.Location = new Point(406, 70);
            btnUpdatePrice.Name = "btnUpdatePrice";
            btnUpdatePrice.Size = new Size(120, 40);
            btnUpdatePrice.TabIndex = 3;
            btnUpdatePrice.Text = "Update Price";
            btnUpdatePrice.Click += btnUpdatePrice_Click;
            // 
            // btnCheckStock
            // 
            btnCheckStock.Location = new Point(589, 70);
            btnCheckStock.Name = "btnCheckStock";
            btnCheckStock.Size = new Size(120, 40);
            btnCheckStock.TabIndex = 4;
            btnCheckStock.Text = "Check Stock";
            btnCheckStock.Click += btnCheckStock_Click;
            // 
            // dgvProducts
            // 
            dgvProducts.ColumnHeadersHeight = 34;
            dgvProducts.Location = new Point(50, 130);
            dgvProducts.Name = "dgvProducts";
            dgvProducts.RowHeadersWidth = 62;
            dgvProducts.Size = new Size(404, 200);
            dgvProducts.TabIndex = 5;
            // 
            // dgvOrders
            // 
            dgvOrders.ColumnHeadersHeight = 34;
            dgvOrders.Location = new Point(495, 130);
            dgvOrders.Name = "dgvOrders";
            dgvOrders.RowHeadersWidth = 62;
            dgvOrders.Size = new Size(419, 200);
            dgvOrders.TabIndex = 6;
            // 
            // lblManagerTitle
            // 
            lblManagerTitle.AutoSize = true;
            lblManagerTitle.Font = new Font("Arial", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblManagerTitle.Location = new Point(383, 20);
            lblManagerTitle.Name = "lblManagerTitle";
            lblManagerTitle.Padding = new Padding(12, 0, 12, 0);
            lblManagerTitle.Size = new Size(267, 37);
            lblManagerTitle.TabIndex = 0;
            lblManagerTitle.Text = "Manager Panel";
            // 
            // txtProductId
            // 
            txtProductId.Location = new Point(50, 350);
            txtProductId.Name = "txtProductId";
            txtProductId.PlaceholderText = "Product ID";
            txtProductId.Size = new Size(100, 31);
            txtProductId.TabIndex = 7;
            // 
            // txtNewPrice
            // 
            txtNewPrice.Location = new Point(200, 350);
            txtNewPrice.Name = "txtNewPrice";
            txtNewPrice.PlaceholderText = "New Price";
            txtNewPrice.Size = new Size(100, 31);
            txtNewPrice.TabIndex = 8;
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(24, 24);
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabelDateTime });
            statusStrip1.Location = new Point(0, 405);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(1024, 32);
            statusStrip1.TabIndex = 9;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabelDateTime
            // 
            toolStripStatusLabelDateTime.Name = "toolStripStatusLabelDateTime";
            toolStripStatusLabelDateTime.Size = new Size(84, 25);
            toolStripStatusLabelDateTime.Text = "Loading..";
            // 
            // btnlogout
            // 
            btnlogout.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnlogout.Location = new Point(865, 342);
            btnlogout.Name = "btnlogout";
            btnlogout.Size = new Size(112, 45);
            btnlogout.TabIndex = 10;
            btnlogout.Text = "LogOut";
            btnlogout.UseVisualStyleBackColor = true;
            btnlogout.Click += btnlogout_Click;
            // 
            // btngraph
            // 
            btngraph.Location = new Point(762, 73);
            btngraph.Name = "btngraph";
            btngraph.Size = new Size(177, 34);
            btngraph.TabIndex = 11;
            btngraph.Text = "Graphical Report";
            btngraph.UseVisualStyleBackColor = true;
            btngraph.Click += btngraph_Click;
            // 
            // ManagerForm
            // 
            ClientSize = new Size(1024, 437);
            Controls.Add(btngraph);
            Controls.Add(btnlogout);
            Controls.Add(statusStrip1);
            Controls.Add(lblManagerTitle);
            Controls.Add(btnReviewOrders);
            Controls.Add(btnAnalyzeInventory);
            Controls.Add(btnUpdatePrice);
            Controls.Add(btnCheckStock);
            Controls.Add(dgvProducts);
            Controls.Add(dgvOrders);
            Controls.Add(txtProductId);
            Controls.Add(txtNewPrice);
            Name = "ManagerForm";
            Text = "Manager Panel";
            ((System.ComponentModel.ISupportInitialize)dgvProducts).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvOrders).EndInit();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabelDateTime;
        private Button btnlogout;
        private Button btngraph;
    }
}
