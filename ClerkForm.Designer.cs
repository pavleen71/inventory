namespace InventoryManagement.Views
{
    partial class ClerkForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnAddCategory;
        private System.Windows.Forms.Button btnDeleteCategory;
        private System.Windows.Forms.Button btnPlaceOrder;
        private System.Windows.Forms.DataGridView dgvInventory;
        private System.Windows.Forms.Label lblClerkTitle;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnAddCategory = new Button();
            btnDeleteCategory = new Button();
            btnPlaceOrder = new Button();
            dgvInventory = new DataGridView();
            lblClerkTitle = new Label();
            btnlogout = new Button();
            btnAddItem = new Button();
            statusStrip1 = new StatusStrip();
            toolStripStatusLabelDateTime = new ToolStripStatusLabel();
            btnDelete = new Button();
            btnNotifications = new Button();
            btnUpdate = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvInventory).BeginInit();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // btnAddCategory
            // 
            btnAddCategory.Location = new Point(22, 88);
            btnAddCategory.Margin = new Padding(4);
            btnAddCategory.Name = "btnAddCategory";
            btnAddCategory.Size = new Size(175, 50);
            btnAddCategory.TabIndex = 1;
            btnAddCategory.Text = "Add Category";
            btnAddCategory.UseVisualStyleBackColor = true;
            btnAddCategory.Click += btnAddCategory_Click;
            // 
            // btnDeleteCategory
            // 
            btnDeleteCategory.Location = new Point(233, 88);
            btnDeleteCategory.Margin = new Padding(4);
            btnDeleteCategory.Name = "btnDeleteCategory";
            btnDeleteCategory.Size = new Size(175, 50);
            btnDeleteCategory.TabIndex = 2;
            btnDeleteCategory.Text = "Delete Category";
            btnDeleteCategory.UseVisualStyleBackColor = true;
            btnDeleteCategory.Click += btnDeleteCategory_Click;
            // 
            // btnPlaceOrder
            // 
            btnPlaceOrder.Location = new Point(442, 88);
            btnPlaceOrder.Margin = new Padding(4);
            btnPlaceOrder.Name = "btnPlaceOrder";
            btnPlaceOrder.Size = new Size(175, 50);
            btnPlaceOrder.TabIndex = 3;
            btnPlaceOrder.Text = "Place Order";
            btnPlaceOrder.UseVisualStyleBackColor = true;
            btnPlaceOrder.Click += btnPlaceOrder_Click;
            // 
            // dgvInventory
            // 
            dgvInventory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvInventory.Location = new Point(87, 189);
            dgvInventory.Margin = new Padding(4);
            dgvInventory.Name = "dgvInventory";
            dgvInventory.RowHeadersWidth = 51;
            dgvInventory.RowTemplate.Height = 29;
            dgvInventory.Size = new Size(929, 312);
            dgvInventory.TabIndex = 4;
            // 
            // lblClerkTitle
            // 
            lblClerkTitle.AutoSize = true;
            lblClerkTitle.Font = new Font("Arial", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblClerkTitle.Location = new Point(502, 25);
            lblClerkTitle.Margin = new Padding(4, 0, 4, 0);
            lblClerkTitle.Name = "lblClerkTitle";
            lblClerkTitle.Size = new Size(343, 37);
            lblClerkTitle.TabIndex = 0;
            lblClerkTitle.Text = "Inventory Clerk Panel";
            lblClerkTitle.TextAlign = ContentAlignment.TopCenter;
            // 
            // btnlogout
            // 
            btnlogout.Location = new Point(1120, 481);
            btnlogout.Name = "btnlogout";
            btnlogout.Size = new Size(112, 60);
            btnlogout.TabIndex = 5;
            btnlogout.Text = "LogOut";
            btnlogout.UseVisualStyleBackColor = true;
            btnlogout.Click += btnlogout_Click;
            // 
            // btnAddItem
            // 
            btnAddItem.Location = new Point(649, 88);
            btnAddItem.Margin = new Padding(4);
            btnAddItem.Name = "btnAddItem";
            btnAddItem.Size = new Size(175, 50);
            btnAddItem.TabIndex = 6;
            btnAddItem.Text = "Add Item";
            btnAddItem.UseVisualStyleBackColor = true;
            btnAddItem.Click += btnAddItem_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(24, 24);
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabelDateTime });
            statusStrip1.Location = new Point(0, 570);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(1327, 32);
            statusStrip1.TabIndex = 7;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabelDateTime
            // 
            toolStripStatusLabelDateTime.Name = "toolStripStatusLabelDateTime";
            toolStripStatusLabelDateTime.Size = new Size(76, 25);
            toolStripStatusLabelDateTime.Text = "Loading";
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(866, 88);
            btnDelete.Margin = new Padding(4);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(175, 50);
            btnDelete.TabIndex = 8;
            btnDelete.Text = "Delete Item";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnNotifications
            // 
            btnNotifications.Location = new Point(1081, 189);
            btnNotifications.Margin = new Padding(4);
            btnNotifications.Name = "btnNotifications";
            btnNotifications.Size = new Size(175, 50);
            btnNotifications.TabIndex = 9;
            btnNotifications.Text = "Notifications";
            btnNotifications.UseVisualStyleBackColor = true;
            btnNotifications.Click += btnNotifications_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(1081, 88);
            btnUpdate.Margin = new Padding(4);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(175, 50);
            btnUpdate.TabIndex = 10;
            btnUpdate.Text = "Update Stock ";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // ClerkForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1327, 602);
            Controls.Add(btnUpdate);
            Controls.Add(btnNotifications);
            Controls.Add(btnDelete);
            Controls.Add(statusStrip1);
            Controls.Add(btnAddItem);
            Controls.Add(btnlogout);
            Controls.Add(lblClerkTitle);
            Controls.Add(btnAddCategory);
            Controls.Add(btnDeleteCategory);
            Controls.Add(btnPlaceOrder);
            Controls.Add(dgvInventory);
            Margin = new Padding(4);
            Name = "ClerkForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Inventory Clerk Panel";
            ((System.ComponentModel.ISupportInitialize)dgvInventory).EndInit();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private Button btnlogout;
        private Button btnAddItem;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabelDateTime;
        private Button btnDelete;
        private Button btnNotifications;
        private Button btnUpdate;
    }
}
