namespace InventoryManagement.Views
{
    partial class MainForm
    {
        private Label lblTitle;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabelDateTime;

        private void InitializeComponent()
        {
            lblTitle = new Label();
            txtusername = new TextBox();
            txtpassword = new TextBox();
            label1 = new Label();
            label2 = new Label();
            btnlogin = new Button();
            statusStrip1 = new StatusStrip();
            toolStripStatusLabelDateTime = new ToolStripStatusLabel();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Arial", 16F, FontStyle.Bold);
            lblTitle.Location = new Point(200, 47);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(484, 37);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Inventory Management System";
            lblTitle.TextAlign = ContentAlignment.TopCenter;
            // 
            // txtusername
            // 
            txtusername.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtusername.Location = new Point(342, 126);
            txtusername.Name = "txtusername";
            txtusername.Size = new Size(150, 37);
            txtusername.TabIndex = 3;
            // 
            // txtpassword
            // 
            txtpassword.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtpassword.Location = new Point(342, 205);
            txtpassword.Name = "txtpassword";
            txtpassword.Size = new Size(150, 37);
            txtpassword.TabIndex = 4;
            txtpassword.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(211, 126);
            label1.Name = "label1";
            label1.Size = new Size(115, 30);
            label1.TabIndex = 5;
            label1.Text = "UserName";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(211, 212);
            label2.Name = "label2";
            label2.Size = new Size(103, 30);
            label2.TabIndex = 6;
            label2.Text = "Password";
            // 
            // btnlogin
            // 
            btnlogin.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnlogin.Location = new Point(275, 290);
            btnlogin.Name = "btnlogin";
            btnlogin.Size = new Size(138, 47);
            btnlogin.TabIndex = 7;
            btnlogin.Text = "Login";
            btnlogin.UseVisualStyleBackColor = true;
            btnlogin.Click += btnLogin_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(24, 24);
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabelDateTime });
            statusStrip1.Location = new Point(0, 376);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(748, 32);
            statusStrip1.TabIndex = 8;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabelDateTime
            // 
            toolStripStatusLabelDateTime.Name = "toolStripStatusLabelDateTime";
            toolStripStatusLabelDateTime.Size = new Size(88, 25);
            toolStripStatusLabelDateTime.Text = "Loading...";
            // 
            // MainForm
            // 
            ClientSize = new Size(748, 408);
            Controls.Add(statusStrip1);
            Controls.Add(btnlogin);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtpassword);
            Controls.Add(txtusername);
            Controls.Add(lblTitle);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Inventory Management System";
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private TextBox txtusername;
        private TextBox txtpassword;
        private Label label1;
        private Label label2;
        private Button btnlogin;
    }
}
