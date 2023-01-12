namespace Abbey_Trading_Store.UI
{
    partial class Debts
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
            this.TopLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.DebtsDGV = new System.Windows.Forms.DataGridView();
            this.TRACKDGV = new System.Windows.Forms.DataGridView();
            this.Print = new System.Windows.Forms.Button();
            this.Add = new System.Windows.Forms.Button();
            this.InvoiceButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.id = new System.Windows.Forms.TextBox();
            this.CustomerName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.PaidAmount = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.RemainAmount = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.PrintDebtors = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.searchtxtbx = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DebtsDGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TRACKDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // TopLabel
            // 
            this.TopLabel.AutoSize = true;
            this.TopLabel.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TopLabel.ForeColor = System.Drawing.Color.White;
            this.TopLabel.Location = new System.Drawing.Point(483, 9);
            this.TopLabel.Name = "TopLabel";
            this.TopLabel.Size = new System.Drawing.Size(76, 30);
            this.TopLabel.TabIndex = 0;
            this.TopLabel.Text = "DEBTS";
            this.TopLabel.Click += new System.EventHandler(this.label1_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkGreen;
            this.panel1.Controls.Add(this.TopLabel);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1005, 46);
            this.panel1.TabIndex = 24;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(918, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 34);
            this.button1.TabIndex = 1;
            this.button1.Text = "Exit";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // DebtsDGV
            // 
            this.DebtsDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DebtsDGV.Location = new System.Drawing.Point(12, 107);
            this.DebtsDGV.Name = "DebtsDGV";
            this.DebtsDGV.Size = new System.Drawing.Size(397, 344);
            this.DebtsDGV.TabIndex = 25;
            this.DebtsDGV.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DebtsDGV_RowHeaderMouseClick);
            // 
            // TRACKDGV
            // 
            this.TRACKDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TRACKDGV.Location = new System.Drawing.Point(621, 107);
            this.TRACKDGV.Name = "TRACKDGV";
            this.TRACKDGV.Size = new System.Drawing.Size(372, 344);
            this.TRACKDGV.TabIndex = 26;
            // 
            // Print
            // 
            this.Print.BackColor = System.Drawing.Color.Red;
            this.Print.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Print.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Print.ForeColor = System.Drawing.Color.White;
            this.Print.Location = new System.Drawing.Point(887, 466);
            this.Print.Name = "Print";
            this.Print.Size = new System.Drawing.Size(106, 38);
            this.Print.TabIndex = 41;
            this.Print.Text = "Print";
            this.Print.UseVisualStyleBackColor = false;
            this.Print.Click += new System.EventHandler(this.Print_Click);
            // 
            // Add
            // 
            this.Add.BackColor = System.Drawing.Color.ForestGreen;
            this.Add.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Add.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Add.ForeColor = System.Drawing.Color.White;
            this.Add.Location = new System.Drawing.Point(467, 466);
            this.Add.Name = "Add";
            this.Add.Size = new System.Drawing.Size(106, 38);
            this.Add.TabIndex = 40;
            this.Add.Text = "ADD";
            this.Add.UseVisualStyleBackColor = false;
            this.Add.Click += new System.EventHandler(this.Add_Click);
            // 
            // InvoiceButton
            // 
            this.InvoiceButton.BackColor = System.Drawing.Color.Lime;
            this.InvoiceButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.InvoiceButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InvoiceButton.Location = new System.Drawing.Point(887, 52);
            this.InvoiceButton.Name = "InvoiceButton";
            this.InvoiceButton.Size = new System.Drawing.Size(106, 38);
            this.InvoiceButton.TabIndex = 42;
            this.InvoiceButton.Text = "Invoice";
            this.InvoiceButton.UseVisualStyleBackColor = false;
            this.InvoiceButton.Click += new System.EventHandler(this.Invoice_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(452, 92);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(107, 21);
            this.label5.TabIndex = 43;
            this.label5.Text = "Transaction id";
            // 
            // id
            // 
            this.id.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.id.ForeColor = System.Drawing.Color.Red;
            this.id.Location = new System.Drawing.Point(431, 126);
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Size = new System.Drawing.Size(174, 27);
            this.id.TabIndex = 44;
            this.id.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // CustomerName
            // 
            this.CustomerName.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CustomerName.ForeColor = System.Drawing.Color.Red;
            this.CustomerName.Location = new System.Drawing.Point(431, 201);
            this.CustomerName.Name = "CustomerName";
            this.CustomerName.ReadOnly = true;
            this.CustomerName.Size = new System.Drawing.Size(174, 27);
            this.CustomerName.TabIndex = 46;
            this.CustomerName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(452, 167);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 21);
            this.label2.TabIndex = 45;
            this.label2.Text = "Customer Name";
            // 
            // PaidAmount
            // 
            this.PaidAmount.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PaidAmount.ForeColor = System.Drawing.Color.Red;
            this.PaidAmount.Location = new System.Drawing.Point(431, 360);
            this.PaidAmount.Name = "PaidAmount";
            this.PaidAmount.Size = new System.Drawing.Size(174, 27);
            this.PaidAmount.TabIndex = 48;
            this.PaidAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.PaidAmount.TextChanged += new System.EventHandler(this.PaidAmount_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(452, 326);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 21);
            this.label3.TabIndex = 47;
            this.label3.Text = "Paid Amount";
            // 
            // RemainAmount
            // 
            this.RemainAmount.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RemainAmount.ForeColor = System.Drawing.Color.Red;
            this.RemainAmount.Location = new System.Drawing.Point(431, 285);
            this.RemainAmount.Name = "RemainAmount";
            this.RemainAmount.ReadOnly = true;
            this.RemainAmount.Size = new System.Drawing.Size(174, 27);
            this.RemainAmount.TabIndex = 50;
            this.RemainAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(452, 249);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(143, 21);
            this.label4.TabIndex = 49;
            this.label4.Text = "Remaining amount";
            // 
            // PrintDebtors
            // 
            this.PrintDebtors.BackColor = System.Drawing.Color.Red;
            this.PrintDebtors.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PrintDebtors.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PrintDebtors.ForeColor = System.Drawing.Color.White;
            this.PrintDebtors.Location = new System.Drawing.Point(12, 466);
            this.PrintDebtors.Name = "PrintDebtors";
            this.PrintDebtors.Size = new System.Drawing.Size(106, 38);
            this.PrintDebtors.TabIndex = 51;
            this.PrintDebtors.Text = "Print";
            this.PrintDebtors.UseVisualStyleBackColor = false;
            this.PrintDebtors.Click += new System.EventHandler(this.PrintDebtors_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 21);
            this.label1.TabIndex = 52;
            this.label1.Text = "Search";
            // 
            // searchtxtbx
            // 
            this.searchtxtbx.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchtxtbx.ForeColor = System.Drawing.Color.Red;
            this.searchtxtbx.Location = new System.Drawing.Point(85, 71);
            this.searchtxtbx.Name = "searchtxtbx";
            this.searchtxtbx.Size = new System.Drawing.Size(235, 23);
            this.searchtxtbx.TabIndex = 53;
            this.searchtxtbx.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.searchtxtbx.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // Debts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1005, 516);
            this.Controls.Add(this.searchtxtbx);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PrintDebtors);
            this.Controls.Add(this.RemainAmount);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.PaidAmount);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.CustomerName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.id);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.InvoiceButton);
            this.Controls.Add(this.Print);
            this.Controls.Add(this.Add);
            this.Controls.Add(this.TRACKDGV);
            this.Controls.Add(this.DebtsDGV);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Debts";
            this.Text = "Debts";
            this.Load += new System.EventHandler(this.Debts_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DebtsDGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TRACKDGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label TopLabel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView DebtsDGV;
        private System.Windows.Forms.DataGridView TRACKDGV;
        private System.Windows.Forms.Button Print;
        private System.Windows.Forms.Button Add;
        private System.Windows.Forms.Button InvoiceButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox id;
        private System.Windows.Forms.TextBox CustomerName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox PaidAmount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox RemainAmount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button PrintDebtors;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox searchtxtbx;
    }
}