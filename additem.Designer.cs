using static System.Net.Mime.MediaTypeNames;
using System.Windows.Forms;
using System.Xml.Linq;

namespace InventoryManagementSystem

{
    partial class additem   
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblItemName = new Label();
            txtItemName = new TextBox();
            dtpRestockDate = new DateTimePicker();
            btnAdd = new Button();
            lblCategory = new Label();
            lblQuantity = new Label();
            lblPrice = new Label();
            lblRestockDate = new Label();
            txtPrice = new TextBox();
            txtQuantity = new TextBox();
            txtCategory = new TextBox();
            SuspendLayout();
            // 
            // lblItemName
            // 
            lblItemName.AutoSize = true;
            lblItemName.Location = new Point(39, 40);
            lblItemName.Name = "lblItemName";
            lblItemName.Size = new Size(100, 25);
            lblItemName.TabIndex = 0;
            lblItemName.Text = "Item Name";
            // 
            // txtItemName
            // 
            txtItemName.Location = new Point(324, 34);
            txtItemName.Name = "txtItemName";
            txtItemName.Size = new Size(125, 31);
            txtItemName.TabIndex = 1;
            // 
            // dtpRestockDate
            // 
            dtpRestockDate.Location = new Point(324, 251);
            dtpRestockDate.Name = "dtpRestockDate";
            dtpRestockDate.Size = new Size(250, 31);
            dtpRestockDate.TabIndex = 3;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(240, 335);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(94, 45);
            btnAdd.TabIndex = 4;
            btnAdd.Text = "Add Item";
            btnAdd.Click += btn_Add;
            // 
            // lblCategory
            // 
            lblCategory.AutoSize = true;
            lblCategory.Location = new Point(43, 88);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new Size(84, 25);
            lblCategory.TabIndex = 5;
            lblCategory.Text = "Category";
            // 
            // lblQuantity
            // 
            lblQuantity.AutoSize = true;
            lblQuantity.Location = new Point(47, 141);
            lblQuantity.Name = "lblQuantity";
            lblQuantity.Size = new Size(80, 25);
            lblQuantity.TabIndex = 6;
            lblQuantity.Text = "Quantity";
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.Location = new Point(62, 193);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(49, 25);
            lblPrice.TabIndex = 7;
            lblPrice.Text = "Price";
            // 
            // lblRestockDate
            // 
            lblRestockDate.AutoSize = true;
            lblRestockDate.Location = new Point(47, 257);
            lblRestockDate.Name = "lblRestockDate";
            lblRestockDate.Size = new Size(115, 25);
            lblRestockDate.TabIndex = 8;
            lblRestockDate.Text = "Restock Date";
            // 
            // txtPrice
            // 
            txtPrice.Location = new Point(324, 193);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(125, 31);
            txtPrice.TabIndex = 9;
            // 
            // txtQuantity
            // 
            txtQuantity.Location = new Point(324, 138);
            txtQuantity.Name = "txtQuantity";
            txtQuantity.Size = new Size(125, 31);
            txtQuantity.TabIndex = 10;
            // 
            // txtCategory
            // 
            txtCategory.Location = new Point(324, 82);
            txtCategory.Name = "txtCategory";
            txtCategory.Size = new Size(125, 31);
            txtCategory.TabIndex = 11;
            // 
            // additem
            // 
            ClientSize = new Size(643, 392);
            Controls.Add(txtCategory);
            Controls.Add(lblItemName);
            Controls.Add(txtItemName);
            Controls.Add(dtpRestockDate);
            Controls.Add(btnAdd);
            Controls.Add(lblCategory);
            Controls.Add(lblQuantity);
            Controls.Add(lblPrice);
            Controls.Add(lblRestockDate);
            Controls.Add(txtPrice);
            Controls.Add(txtQuantity);
            Name = "additem";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Add Item Form";
            ResumeLayout(false);
            PerformLayout();
        }


        #endregion

        private Label lblItemName;
        private TextBox txtItemName;
        private DateTimePicker dtpRestockDate;
        private Button btnAdd;
        private Label lblCategory;
        private Label lblQuantity;
        private Label lblPrice;
        private Label lblRestockDate;
        private TextBox txtPrice;
        private TextBox txtQuantity;
        private TextBox txtCategory;
    }
}