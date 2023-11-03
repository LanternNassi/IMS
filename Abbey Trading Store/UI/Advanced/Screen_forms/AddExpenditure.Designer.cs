namespace Abbey_Trading_Store.UI.Advanced.Screen_forms
{
    partial class AddExpenditure
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddExpenditure));
            this.cat_combobox = new MaterialSkin.Controls.MaterialComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.extra_txt = new MaterialSkin.Controls.MaterialMultiLineTextBox2();
            this.label1 = new System.Windows.Forms.Label();
            this.amount_txt = new MaterialSkin.Controls.MaterialTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.materialButton2 = new MaterialSkin.Controls.MaterialButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // cat_combobox
            // 
            this.cat_combobox.AutoResize = false;
            this.cat_combobox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cat_combobox.Depth = 0;
            this.cat_combobox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cat_combobox.DropDownHeight = 174;
            this.cat_combobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cat_combobox.DropDownWidth = 121;
            this.cat_combobox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.cat_combobox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cat_combobox.FormattingEnabled = true;
            this.cat_combobox.IntegralHeight = false;
            this.cat_combobox.ItemHeight = 43;
            this.cat_combobox.Location = new System.Drawing.Point(132, 26);
            this.cat_combobox.MaxDropDownItems = 4;
            this.cat_combobox.MouseState = MaterialSkin.MouseState.OUT;
            this.cat_combobox.Name = "cat_combobox";
            this.cat_combobox.Size = new System.Drawing.Size(268, 49);
            this.cat_combobox.StartIndex = 0;
            this.cat_combobox.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.label2.Location = new System.Drawing.Point(12, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Select a category";
            // 
            // extra_txt
            // 
            this.extra_txt.AnimateReadOnly = false;
            this.extra_txt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.extra_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.extra_txt.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.extra_txt.Depth = 0;
            this.extra_txt.HideSelection = true;
            this.extra_txt.Location = new System.Drawing.Point(132, 99);
            this.extra_txt.MaxLength = 32767;
            this.extra_txt.MouseState = MaterialSkin.MouseState.OUT;
            this.extra_txt.Name = "extra_txt";
            this.extra_txt.PasswordChar = '\0';
            this.extra_txt.ReadOnly = false;
            this.extra_txt.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.extra_txt.SelectedText = "";
            this.extra_txt.SelectionLength = 0;
            this.extra_txt.SelectionStart = 0;
            this.extra_txt.ShortcutsEnabled = true;
            this.extra_txt.Size = new System.Drawing.Size(268, 103);
            this.extra_txt.TabIndex = 5;
            this.extra_txt.TabStop = false;
            this.extra_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.extra_txt.UseSystemPasswordChar = false;
            this.extra_txt.TextChanged += new System.EventHandler(this.extra_txt_TextChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.label1.Location = new System.Drawing.Point(12, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "Extra info";
            // 
            // amount_txt
            // 
            this.amount_txt.AnimateReadOnly = false;
            this.amount_txt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.amount_txt.Depth = 0;
            this.amount_txt.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.amount_txt.LeadingIcon = null;
            this.amount_txt.Location = new System.Drawing.Point(132, 220);
            this.amount_txt.MaxLength = 50;
            this.amount_txt.MouseState = MaterialSkin.MouseState.OUT;
            this.amount_txt.Multiline = false;
            this.amount_txt.Name = "amount_txt";
            this.amount_txt.Size = new System.Drawing.Size(268, 50);
            this.amount_txt.TabIndex = 7;
            this.amount_txt.Text = "";
            this.amount_txt.TrailingIcon = null;
            this.amount_txt.TextChanged += new System.EventHandler(this.amount_txt_TextChanged);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.label3.Location = new System.Drawing.Point(12, 232);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "Amount ";
            // 
            // materialButton2
            // 
            this.materialButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.materialButton2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButton2.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.materialButton2.Depth = 0;
            this.materialButton2.Enabled = false;
            this.materialButton2.HighEmphasis = true;
            this.materialButton2.Icon = ((System.Drawing.Image)(resources.GetObject("materialButton2.Icon")));
            this.materialButton2.Location = new System.Drawing.Point(291, 288);
            this.materialButton2.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButton2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButton2.Name = "materialButton2";
            this.materialButton2.NoAccentTextColor = System.Drawing.Color.Empty;
            this.materialButton2.Size = new System.Drawing.Size(186, 36);
            this.materialButton2.TabIndex = 17;
            this.materialButton2.Text = "SAVE EXPENDITURE";
            this.materialButton2.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButton2.UseAccentColor = false;
            this.materialButton2.UseVisualStyleBackColor = true;
            this.materialButton2.Click += new System.EventHandler(this.materialButton2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(423, 42);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 18;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // AddExpenditure
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.ClientSize = new System.Drawing.Size(499, 339);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.materialButton2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.amount_txt);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.extra_txt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cat_combobox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "AddExpenditure";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Expenditure";
            this.Load += new System.EventHandler(this.AddExpenditure_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialComboBox cat_combobox;
        private System.Windows.Forms.Label label2;
        private MaterialSkin.Controls.MaterialMultiLineTextBox2 extra_txt;
        private System.Windows.Forms.Label label1;
        private MaterialSkin.Controls.MaterialTextBox amount_txt;
        private System.Windows.Forms.Label label3;
        private MaterialSkin.Controls.MaterialButton materialButton2;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}