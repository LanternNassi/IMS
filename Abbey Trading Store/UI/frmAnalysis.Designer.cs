namespace Abbey_Trading_Store.UI
{
    partial class frmAnalysis
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.Total_profits = new System.Windows.Forms.Label();
            this.Total_sales = new System.Windows.Forms.Label();
            this.generate = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.Overall_dgv = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.TDD = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.Added_by = new System.Windows.Forms.ComboBox();
            this.Product = new System.Windows.Forms.ComboBox();
            this.Customer = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.Quantity = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cbbx = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Overall_dgv)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TDD)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(7, 41);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1151, 428);
            this.panel1.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.Total_profits);
            this.panel4.Controls.Add(this.Total_sales);
            this.panel4.Controls.Add(this.generate);
            this.panel4.Controls.Add(this.label11);
            this.panel4.Controls.Add(this.label10);
            this.panel4.Controls.Add(this.Overall_dgv);
            this.panel4.Location = new System.Drawing.Point(672, 4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(474, 420);
            this.panel4.TabIndex = 2;
            // 
            // Total_profits
            // 
            this.Total_profits.AutoSize = true;
            this.Total_profits.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Total_profits.ForeColor = System.Drawing.Color.Red;
            this.Total_profits.Location = new System.Drawing.Point(340, 338);
            this.Total_profits.Name = "Total_profits";
            this.Total_profits.Size = new System.Drawing.Size(0, 21);
            this.Total_profits.TabIndex = 44;
            // 
            // Total_sales
            // 
            this.Total_sales.AutoSize = true;
            this.Total_sales.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Total_sales.ForeColor = System.Drawing.Color.Red;
            this.Total_sales.Location = new System.Drawing.Point(98, 338);
            this.Total_sales.Name = "Total_sales";
            this.Total_sales.Size = new System.Drawing.Size(0, 21);
            this.Total_sales.TabIndex = 43;
            // 
            // generate
            // 
            this.generate.BackColor = System.Drawing.Color.Fuchsia;
            this.generate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.generate.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.generate.Location = new System.Drawing.Point(161, 380);
            this.generate.Name = "generate";
            this.generate.Size = new System.Drawing.Size(192, 35);
            this.generate.TabIndex = 42;
            this.generate.Text = "Print";
            this.generate.UseVisualStyleBackColor = false;
            this.generate.Click += new System.EventHandler(this.generate_Click_1);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(236, 338);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(98, 21);
            this.label11.TabIndex = 29;
            this.label11.Text = "Total profits :";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(3, 338);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(89, 21);
            this.label10.TabIndex = 28;
            this.label10.Text = "Total Sales :";
            // 
            // Overall_dgv
            // 
            this.Overall_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Overall_dgv.Location = new System.Drawing.Point(3, 3);
            this.Overall_dgv.Name = "Overall_dgv";
            this.Overall_dgv.Size = new System.Drawing.Size(466, 322);
            this.Overall_dgv.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.TDD);
            this.panel3.Location = new System.Drawing.Point(282, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(384, 420);
            this.panel3.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(3, 2);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(140, 21);
            this.label5.TabIndex = 42;
            this.label5.Text = "Transaction Details";
            // 
            // TDD
            // 
            this.TDD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TDD.Location = new System.Drawing.Point(4, 26);
            this.TDD.Name = "TDD";
            this.TDD.Size = new System.Drawing.Size(375, 389);
            this.TDD.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.Added_by);
            this.panel2.Controls.Add(this.Product);
            this.panel2.Controls.Add(this.Customer);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.Quantity);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.cbbx);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Location = new System.Drawing.Point(6, 5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(270, 420);
            this.panel2.TabIndex = 0;
            // 
            // Added_by
            // 
            this.Added_by.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.Added_by.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.Added_by.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Added_by.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.Added_by.FormattingEnabled = true;
            this.Added_by.Location = new System.Drawing.Point(93, 226);
            this.Added_by.Name = "Added_by";
            this.Added_by.Size = new System.Drawing.Size(172, 28);
            this.Added_by.Sorted = true;
            this.Added_by.TabIndex = 45;
            this.Added_by.SelectedIndexChanged += new System.EventHandler(this.Added_by_SelectedIndexChanged);
            this.Added_by.TextUpdate += new System.EventHandler(this.Added_by_TextUpdate);
            // 
            // Product
            // 
            this.Product.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.Product.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.Product.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Product.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.Product.FormattingEnabled = true;
            this.Product.Location = new System.Drawing.Point(93, 128);
            this.Product.Name = "Product";
            this.Product.Size = new System.Drawing.Size(172, 28);
            this.Product.Sorted = true;
            this.Product.TabIndex = 43;
            this.Product.SelectedIndexChanged += new System.EventHandler(this.Product_SelectedIndexChanged);
            this.Product.TextUpdate += new System.EventHandler(this.Product_TextUpdate);
            // 
            // Customer
            // 
            this.Customer.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.Customer.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.Customer.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Customer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.Customer.FormattingEnabled = true;
            this.Customer.Location = new System.Drawing.Point(93, 85);
            this.Customer.Name = "Customer";
            this.Customer.Size = new System.Drawing.Size(172, 28);
            this.Customer.Sorted = true;
            this.Customer.TabIndex = 42;
            this.Customer.SelectedIndexChanged += new System.EventHandler(this.Customer_SelectedIndexChanged);
            this.Customer.TextUpdate += new System.EventHandler(this.Customer_TextUpdate);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(3, 228);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(76, 21);
            this.label9.TabIndex = 40;
            this.label9.Text = "Added by";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(3, 182);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 21);
            this.label8.TabIndex = 38;
            this.label8.Text = "Quantity";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // Quantity
            // 
            this.Quantity.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Quantity.ForeColor = System.Drawing.Color.Red;
            this.Quantity.Location = new System.Drawing.Point(93, 178);
            this.Quantity.Name = "Quantity";
            this.Quantity.Size = new System.Drawing.Size(172, 25);
            this.Quantity.TabIndex = 37;
            this.Quantity.TextChanged += new System.EventHandler(this.Quantity_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(3, 135);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 21);
            this.label7.TabIndex = 36;
            this.label7.Text = "Product";
            // 
            // cbbx
            // 
            this.cbbx.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbx.ForeColor = System.Drawing.Color.Red;
            this.cbbx.FormattingEnabled = true;
            this.cbbx.Items.AddRange(new object[] {
            "Sales",
            "Purchase"});
            this.cbbx.Location = new System.Drawing.Point(93, 35);
            this.cbbx.Name = "cbbx";
            this.cbbx.Size = new System.Drawing.Size(172, 25);
            this.cbbx.TabIndex = 35;
            this.cbbx.TextChanged += new System.EventHandler(this.cbbx_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 21);
            this.label4.TabIndex = 31;
            this.label4.Text = "Customer";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 21);
            this.label3.TabIndex = 27;
            this.label3.Text = "Type";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(56, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 21);
            this.label6.TabIndex = 41;
            this.label6.Text = "Start Date :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(788, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 21);
            this.label1.TabIndex = 42;
            this.label1.Text = "End Date";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(140, 10);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 43;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(866, 12);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker2.TabIndex = 44;
            this.dateTimePicker2.ValueChanged += new System.EventHandler(this.dateTimePicker2_ValueChanged);
            // 
            // frmAnalysis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1170, 481);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.panel1);
            this.Name = "frmAnalysis";
            this.Text = "Transactions Analysis";
            this.Load += new System.EventHandler(this.frmAnalysis_Load);
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Overall_dgv)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TDD)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox Quantity;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbbx;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView TDD;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox Added_by;
        private System.Windows.Forms.ComboBox Product;
        private System.Windows.Forms.ComboBox Customer;
        private System.Windows.Forms.Label Total_profits;
        private System.Windows.Forms.Label Total_sales;
        private System.Windows.Forms.Button generate;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridView Overall_dgv;
    }
}