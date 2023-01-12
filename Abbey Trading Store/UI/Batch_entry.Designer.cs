namespace Abbey_Trading_Store.UI
{
    partial class Batch_entry
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
            this.Choose_file = new System.Windows.Forms.Button();
            this.dgv_Batch = new System.Windows.Forms.DataGridView();
            this.Generate = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Batch)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Choose_file
            // 
            this.Choose_file.BackColor = System.Drawing.Color.Turquoise;
            this.Choose_file.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Choose_file.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Choose_file.Location = new System.Drawing.Point(12, 440);
            this.Choose_file.Name = "Choose_file";
            this.Choose_file.Size = new System.Drawing.Size(119, 41);
            this.Choose_file.TabIndex = 38;
            this.Choose_file.Text = "Choose file";
            this.Choose_file.UseVisualStyleBackColor = false;
            this.Choose_file.Click += new System.EventHandler(this.Choose_file_Click);
            // 
            // dgv_Batch
            // 
            this.dgv_Batch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Batch.Location = new System.Drawing.Point(12, 64);
            this.dgv_Batch.Name = "dgv_Batch";
            this.dgv_Batch.Size = new System.Drawing.Size(792, 370);
            this.dgv_Batch.TabIndex = 37;
            // 
            // Generate
            // 
            this.Generate.BackColor = System.Drawing.Color.Turquoise;
            this.Generate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Generate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Generate.Location = new System.Drawing.Point(685, 440);
            this.Generate.Name = "Generate";
            this.Generate.Size = new System.Drawing.Size(119, 41);
            this.Generate.TabIndex = 36;
            this.Generate.Text = "Generate";
            this.Generate.UseVisualStyleBackColor = false;
            this.Generate.Click += new System.EventHandler(this.Generate_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkGreen;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(816, 46);
            this.panel1.TabIndex = 33;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(284, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(259, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "BATCH PRODUCT ENTRY";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(729, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 34);
            this.button1.TabIndex = 1;
            this.button1.Text = "Exit";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(133, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 21);
            this.label2.TabIndex = 34;
            this.label2.Text = "Category";
            // 
            // Batch_entry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(816, 493);
            this.Controls.Add(this.Choose_file);
            this.Controls.Add(this.dgv_Batch);
            this.Controls.Add(this.Generate);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Batch_entry";
            this.Text = "Batch_entry";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Batch)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Choose_file;
        private System.Windows.Forms.DataGridView dgv_Batch;
        private System.Windows.Forms.Button Generate;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
    }
}