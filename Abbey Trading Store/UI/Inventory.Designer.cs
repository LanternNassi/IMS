namespace Abbey_Trading_Store.UI
{
    partial class Inventory
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Inventory));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.Show_all_inventory = new System.Windows.Forms.Button();
            this.Category_combobox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dgv_Inventory = new System.Windows.Forms.DataGridView();
            this.Show_all = new System.Windows.Forms.Button();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.Report_label = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Inventory)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkGreen;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1230, 46);
            this.panel1.TabIndex = 24;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(557, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "INVENTORY";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(1140, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 34);
            this.button1.TabIndex = 1;
            this.button1.Text = "Exit";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Show_all_inventory
            // 
            this.Show_all_inventory.BackColor = System.Drawing.Color.Turquoise;
            this.Show_all_inventory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Show_all_inventory.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Show_all_inventory.Location = new System.Drawing.Point(466, 56);
            this.Show_all_inventory.Name = "Show_all_inventory";
            this.Show_all_inventory.Size = new System.Drawing.Size(119, 41);
            this.Show_all_inventory.TabIndex = 30;
            this.Show_all_inventory.Text = "SHOW ALL";
            this.Show_all_inventory.UseVisualStyleBackColor = false;
            this.Show_all_inventory.Click += new System.EventHandler(this.Show_all_inventory_Click);
            // 
            // Category_combobox
            // 
            this.Category_combobox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Category_combobox.ForeColor = System.Drawing.Color.Red;
            this.Category_combobox.FormattingEnabled = true;
            this.Category_combobox.Items.AddRange(new object[] {
            "Sales",
            "Purchase"});
            this.Category_combobox.Location = new System.Drawing.Point(221, 67);
            this.Category_combobox.Name = "Category_combobox";
            this.Category_combobox.Size = new System.Drawing.Size(217, 29);
            this.Category_combobox.TabIndex = 29;
            this.Category_combobox.SelectedIndexChanged += new System.EventHandler(this.Category_combobox_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(133, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 21);
            this.label2.TabIndex = 28;
            this.label2.Text = "Category";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // dgv_Inventory
            // 
            this.dgv_Inventory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Inventory.Location = new System.Drawing.Point(12, 105);
            this.dgv_Inventory.Name = "dgv_Inventory";
            this.dgv_Inventory.Size = new System.Drawing.Size(615, 404);
            this.dgv_Inventory.TabIndex = 31;
            this.dgv_Inventory.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Inventory_CellContentClick);
            // 
            // Show_all
            // 
            this.Show_all.BackColor = System.Drawing.Color.Turquoise;
            this.Show_all.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Show_all.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Show_all.Location = new System.Drawing.Point(608, 56);
            this.Show_all.Name = "Show_all";
            this.Show_all.Size = new System.Drawing.Size(119, 41);
            this.Show_all.TabIndex = 32;
            this.Show_all.Text = "PRINT ALL";
            this.Show_all.UseVisualStyleBackColor = false;
            this.Show_all.Click += new System.EventHandler(this.Show_all_Click);
            // 
            // reportViewer1
            // 
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Abbey_Trading_Store.Reports.Inventory Report.InventoryReport.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(644, 105);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(574, 404);
            this.reportViewer1.TabIndex = 33;
            // 
            // Report_label
            // 
            this.Report_label.AutoSize = true;
            this.Report_label.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Report_label.Location = new System.Drawing.Point(1136, 56);
            this.Report_label.Name = "Report_label";
            this.Report_label.Size = new System.Drawing.Size(57, 21);
            this.Report_label.TabIndex = 35;
            this.Report_label.Text = "Report";
            // 
            // Inventory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.ClientSize = new System.Drawing.Size(1230, 521);
            this.Controls.Add(this.Report_label);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.Show_all);
            this.Controls.Add(this.dgv_Inventory);
            this.Controls.Add(this.Show_all_inventory);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Category_combobox);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Inventory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inventory";
            this.Load += new System.EventHandler(this.Inventory_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Inventory)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button Show_all_inventory;
        private System.Windows.Forms.ComboBox Category_combobox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgv_Inventory;
        private System.Windows.Forms.Button Show_all;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.Label Report_label;
    }
}