namespace InventoryManagementSystem
{
    partial class AnalysisForm
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
            dgvAnalysis = new DataGridView();
            btnSaveReport = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvAnalysis).BeginInit();
            SuspendLayout();
            // 
            // dgvAnalysis
            // 
            dgvAnalysis.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAnalysis.Location = new Point(53, 33);
            dgvAnalysis.Name = "dgvAnalysis";
            dgvAnalysis.RowHeadersWidth = 62;
            dgvAnalysis.Size = new Size(661, 278);
            dgvAnalysis.TabIndex = 0;
            // 
            // btnSaveReport
            // 
            btnSaveReport.Location = new Point(327, 353);
            btnSaveReport.Name = "btnSaveReport";
            btnSaveReport.Size = new Size(190, 53);
            btnSaveReport.TabIndex = 1;
            btnSaveReport.Text = "Save Report";
            btnSaveReport.UseVisualStyleBackColor = true;
            btnSaveReport.Click += btnSaveReport_Click;
            // 
            // AnalysisForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnSaveReport);
            Controls.Add(dgvAnalysis);
            Name = "AnalysisForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AnalysisForm";
            ((System.ComponentModel.ISupportInitialize)dgvAnalysis).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvAnalysis;
        private Button btnSaveReport;
    }
}