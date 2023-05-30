namespace Abbey_Trading_Store.UI.Advanced.Screen_forms
{
    partial class frmPurchaseAndSales
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.materialButton4 = new MaterialSkin.Controls.MaterialButton();
            this.invoice_txtbx = new MaterialSkin.Controls.MaterialTextBox2();
            this.address = new MaterialSkin.Controls.MaterialMultiLineTextBox2();
            this.label18 = new System.Windows.Forms.Label();
            this.email = new MaterialSkin.Controls.MaterialTextBox2();
            this.label17 = new System.Windows.Forms.Label();
            this.contact = new MaterialSkin.Controls.MaterialTextBox2();
            this.label16 = new System.Windows.Forms.Label();
            this.name = new MaterialSkin.Controls.MaterialTextBox2();
            this.label2 = new System.Windows.Forms.Label();
            this.search = new MaterialSkin.Controls.MaterialTextBox2();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.p_rate = new MaterialSkin.Controls.MaterialComboBox();
            this.p_search1 = new System.Windows.Forms.ComboBox();
            this.materialButton1 = new MaterialSkin.Controls.MaterialButton();
            this.p_quantity = new MaterialSkin.Controls.MaterialTextBox2();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.p_inventory = new MaterialSkin.Controls.MaterialTextBox2();
            this.label6 = new System.Windows.Forms.Label();
            this.p_name = new MaterialSkin.Controls.MaterialTextBox2();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label15 = new System.Windows.Forms.Label();
            this.materialButton2 = new MaterialSkin.Controls.MaterialButton();
            this.return_amount = new MaterialSkin.Controls.MaterialTextBox2();
            this.label13 = new System.Windows.Forms.Label();
            this.grandtotal = new MaterialSkin.Controls.MaterialTextBox2();
            this.label14 = new System.Windows.Forms.Label();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.paid_amount = new MaterialSkin.Controls.MaterialTextBox2();
            this.label12 = new System.Windows.Forms.Label();
            this.textBox13 = new MaterialSkin.Controls.MaterialTextBox2();
            this.label11 = new System.Windows.Forms.Label();
            this.subtotal = new MaterialSkin.Controls.MaterialTextBox2();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.materialButton4);
            this.panel1.Controls.Add(this.invoice_txtbx);
            this.panel1.Controls.Add(this.address);
            this.panel1.Controls.Add(this.label18);
            this.panel1.Controls.Add(this.email);
            this.panel1.Controls.Add(this.label17);
            this.panel1.Controls.Add(this.contact);
            this.panel1.Controls.Add(this.label16);
            this.panel1.Controls.Add(this.name);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.search);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1124, 108);
            this.panel1.TabIndex = 0;
            // 
            // materialButton4
            // 
            this.materialButton4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButton4.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.materialButton4.Depth = 0;
            this.materialButton4.HighEmphasis = true;
            this.materialButton4.Icon = global::Abbey_Trading_Store.Properties.Resources.settings;
            this.materialButton4.Location = new System.Drawing.Point(882, 64);
            this.materialButton4.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButton4.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButton4.Name = "materialButton4";
            this.materialButton4.NoAccentTextColor = System.Drawing.Color.Empty;
            this.materialButton4.Size = new System.Drawing.Size(227, 36);
            this.materialButton4.TabIndex = 34;
            this.materialButton4.Text = "GENERATE TRANSACTION";
            this.materialButton4.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButton4.UseAccentColor = false;
            this.materialButton4.UseVisualStyleBackColor = true;
            this.materialButton4.Click += new System.EventHandler(this.materialButton4_Click);
            // 
            // invoice_txtbx
            // 
            this.invoice_txtbx.AnimateReadOnly = false;
            this.invoice_txtbx.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.invoice_txtbx.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.invoice_txtbx.Depth = 0;
            this.invoice_txtbx.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.invoice_txtbx.HideSelection = true;
            this.invoice_txtbx.LeadingIcon = null;
            this.invoice_txtbx.Location = new System.Drawing.Point(943, 12);
            this.invoice_txtbx.MaxLength = 32767;
            this.invoice_txtbx.MouseState = MaterialSkin.MouseState.OUT;
            this.invoice_txtbx.Name = "invoice_txtbx";
            this.invoice_txtbx.PasswordChar = '\0';
            this.invoice_txtbx.PrefixSuffixText = null;
            this.invoice_txtbx.ReadOnly = false;
            this.invoice_txtbx.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.invoice_txtbx.SelectedText = "";
            this.invoice_txtbx.SelectionLength = 0;
            this.invoice_txtbx.SelectionStart = 0;
            this.invoice_txtbx.ShortcutsEnabled = true;
            this.invoice_txtbx.Size = new System.Drawing.Size(98, 48);
            this.invoice_txtbx.TabIndex = 20;
            this.invoice_txtbx.TabStop = false;
            this.invoice_txtbx.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.invoice_txtbx.TrailingIcon = null;
            this.invoice_txtbx.UseSystemPasswordChar = false;
            // 
            // address
            // 
            this.address.AnimateReadOnly = false;
            this.address.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.address.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.address.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.address.Depth = 0;
            this.address.HideSelection = true;
            this.address.Location = new System.Drawing.Point(665, 12);
            this.address.MaxLength = 32767;
            this.address.MouseState = MaterialSkin.MouseState.OUT;
            this.address.Name = "address";
            this.address.PasswordChar = '\0';
            this.address.ReadOnly = false;
            this.address.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.address.SelectedText = "";
            this.address.SelectionLength = 0;
            this.address.SelectionStart = 0;
            this.address.ShortcutsEnabled = true;
            this.address.Size = new System.Drawing.Size(177, 91);
            this.address.TabIndex = 19;
            this.address.TabStop = false;
            this.address.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.address.UseSystemPasswordChar = false;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.label18.Location = new System.Drawing.Point(588, 15);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(56, 17);
            this.label18.TabIndex = 18;
            this.label18.Text = "Address";
            // 
            // email
            // 
            this.email.AnimateReadOnly = false;
            this.email.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.email.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.email.Depth = 0;
            this.email.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.email.HideSelection = true;
            this.email.LeadingIcon = null;
            this.email.Location = new System.Drawing.Point(380, 60);
            this.email.MaxLength = 32767;
            this.email.MouseState = MaterialSkin.MouseState.OUT;
            this.email.Name = "email";
            this.email.PasswordChar = '\0';
            this.email.PrefixSuffixText = null;
            this.email.ReadOnly = false;
            this.email.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.email.SelectedText = "";
            this.email.SelectionLength = 0;
            this.email.SelectionStart = 0;
            this.email.ShortcutsEnabled = true;
            this.email.Size = new System.Drawing.Size(177, 48);
            this.email.TabIndex = 17;
            this.email.TabStop = false;
            this.email.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.email.TrailingIcon = null;
            this.email.UseSystemPasswordChar = false;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.label17.Location = new System.Drawing.Point(312, 76);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(39, 17);
            this.label17.TabIndex = 16;
            this.label17.Text = "Email";
            // 
            // contact
            // 
            this.contact.AnimateReadOnly = false;
            this.contact.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.contact.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.contact.Depth = 0;
            this.contact.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.contact.HideSelection = true;
            this.contact.LeadingIcon = null;
            this.contact.Location = new System.Drawing.Point(380, 3);
            this.contact.MaxLength = 32767;
            this.contact.MouseState = MaterialSkin.MouseState.OUT;
            this.contact.Name = "contact";
            this.contact.PasswordChar = '\0';
            this.contact.PrefixSuffixText = null;
            this.contact.ReadOnly = false;
            this.contact.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.contact.SelectedText = "";
            this.contact.SelectionLength = 0;
            this.contact.SelectionStart = 0;
            this.contact.ShortcutsEnabled = true;
            this.contact.Size = new System.Drawing.Size(177, 48);
            this.contact.TabIndex = 15;
            this.contact.TabStop = false;
            this.contact.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.contact.TrailingIcon = null;
            this.contact.UseSystemPasswordChar = false;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.label16.Location = new System.Drawing.Point(312, 19);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(52, 17);
            this.label16.TabIndex = 14;
            this.label16.Text = "Contact";
            // 
            // name
            // 
            this.name.AnimateReadOnly = false;
            this.name.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.name.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.name.Depth = 0;
            this.name.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.name.HideSelection = true;
            this.name.LeadingIcon = null;
            this.name.Location = new System.Drawing.Point(80, 57);
            this.name.MaxLength = 32767;
            this.name.MouseState = MaterialSkin.MouseState.OUT;
            this.name.Name = "name";
            this.name.PasswordChar = '\0';
            this.name.PrefixSuffixText = null;
            this.name.ReadOnly = false;
            this.name.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.name.SelectedText = "";
            this.name.SelectionLength = 0;
            this.name.SelectionStart = 0;
            this.name.ShortcutsEnabled = true;
            this.name.Size = new System.Drawing.Size(177, 48);
            this.name.TabIndex = 13;
            this.name.TabStop = false;
            this.name.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.name.TrailingIcon = null;
            this.name.UseSystemPasswordChar = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.label2.Location = new System.Drawing.Point(12, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 17);
            this.label2.TabIndex = 12;
            this.label2.Text = "Name";
            // 
            // search
            // 
            this.search.AnimateReadOnly = false;
            this.search.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.search.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.search.Depth = 0;
            this.search.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.search.HideSelection = true;
            this.search.LeadingIcon = null;
            this.search.Location = new System.Drawing.Point(80, 3);
            this.search.MaxLength = 32767;
            this.search.MouseState = MaterialSkin.MouseState.OUT;
            this.search.Name = "search";
            this.search.PasswordChar = '\0';
            this.search.PrefixSuffixText = null;
            this.search.ReadOnly = false;
            this.search.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.search.SelectedText = "";
            this.search.SelectionLength = 0;
            this.search.SelectionStart = 0;
            this.search.ShortcutsEnabled = true;
            this.search.Size = new System.Drawing.Size(177, 48);
            this.search.TabIndex = 11;
            this.search.TabStop = false;
            this.search.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.search.TrailingIcon = null;
            this.search.UseSystemPasswordChar = false;
            this.search.TextChanged += new System.EventHandler(this.search_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 17);
            this.label1.TabIndex = 10;
            this.label1.Text = "search";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.p_rate);
            this.panel2.Controls.Add(this.p_search1);
            this.panel2.Controls.Add(this.materialButton1);
            this.panel2.Controls.Add(this.p_quantity);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.p_inventory);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.p_name);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Location = new System.Drawing.Point(0, 111);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1130, 86);
            this.panel2.TabIndex = 1;
            // 
            // p_rate
            // 
            this.p_rate.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.p_rate.AutoResize = false;
            this.p_rate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.p_rate.Depth = 0;
            this.p_rate.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.p_rate.DropDownHeight = 174;
            this.p_rate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.p_rate.DropDownWidth = 121;
            this.p_rate.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.p_rate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.p_rate.FormattingEnabled = true;
            this.p_rate.IntegralHeight = false;
            this.p_rate.ItemHeight = 43;
            this.p_rate.Location = new System.Drawing.Point(686, 26);
            this.p_rate.MaxDropDownItems = 4;
            this.p_rate.MouseState = MaterialSkin.MouseState.OUT;
            this.p_rate.Name = "p_rate";
            this.p_rate.Size = new System.Drawing.Size(156, 49);
            this.p_rate.StartIndex = 0;
            this.p_rate.TabIndex = 26;
            this.p_rate.SelectedIndexChanged += new System.EventHandler(this.p_rate_SelectedIndexChanged);
            // 
            // p_search1
            // 
            this.p_search1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.p_search1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.p_search1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.p_search1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.p_search1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.p_search1.FormattingEnabled = true;
            this.p_search1.IntegralHeight = false;
            this.p_search1.Location = new System.Drawing.Point(53, 33);
            this.p_search1.Name = "p_search1";
            this.p_search1.Size = new System.Drawing.Size(175, 33);
            this.p_search1.TabIndex = 25;
            this.p_search1.SelectedIndexChanged += new System.EventHandler(this.p_search_SelectedIndexChanged);
            this.p_search1.TextUpdate += new System.EventHandler(this.p_search_TextUpdate);
            // 
            // materialButton1
            // 
            this.materialButton1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButton1.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.materialButton1.Depth = 0;
            this.materialButton1.HighEmphasis = true;
            this.materialButton1.Icon = global::Abbey_Trading_Store.Properties.Resources.people;
            this.materialButton1.Location = new System.Drawing.Point(1021, 36);
            this.materialButton1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButton1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButton1.Name = "materialButton1";
            this.materialButton1.NoAccentTextColor = System.Drawing.Color.Empty;
            this.materialButton1.Size = new System.Drawing.Size(78, 36);
            this.materialButton1.TabIndex = 24;
            this.materialButton1.Text = "Add";
            this.materialButton1.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButton1.UseAccentColor = false;
            this.materialButton1.UseVisualStyleBackColor = true;
            this.materialButton1.Click += new System.EventHandler(this.materialButton1_Click);
            // 
            // p_quantity
            // 
            this.p_quantity.AnimateReadOnly = false;
            this.p_quantity.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.p_quantity.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.p_quantity.Depth = 0;
            this.p_quantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.p_quantity.HideSelection = true;
            this.p_quantity.LeadingIcon = null;
            this.p_quantity.Location = new System.Drawing.Point(882, 27);
            this.p_quantity.MaxLength = 32767;
            this.p_quantity.MouseState = MaterialSkin.MouseState.OUT;
            this.p_quantity.Name = "p_quantity";
            this.p_quantity.PasswordChar = '\0';
            this.p_quantity.PrefixSuffixText = null;
            this.p_quantity.ReadOnly = false;
            this.p_quantity.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.p_quantity.SelectedText = "";
            this.p_quantity.SelectionLength = 0;
            this.p_quantity.SelectionStart = 0;
            this.p_quantity.ShortcutsEnabled = true;
            this.p_quantity.Size = new System.Drawing.Size(98, 48);
            this.p_quantity.TabIndex = 23;
            this.p_quantity.TabStop = false;
            this.p_quantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.p_quantity.TrailingIcon = null;
            this.p_quantity.UseSystemPasswordChar = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.label8.Location = new System.Drawing.Point(848, 36);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(28, 17);
            this.label8.TabIndex = 22;
            this.label8.Text = "Qty";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.label7.Location = new System.Drawing.Point(646, 36);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 17);
            this.label7.TabIndex = 20;
            this.label7.Text = "Rate";
            // 
            // p_inventory
            // 
            this.p_inventory.AnimateReadOnly = false;
            this.p_inventory.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.p_inventory.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.p_inventory.Depth = 0;
            this.p_inventory.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.p_inventory.HideSelection = true;
            this.p_inventory.LeadingIcon = null;
            this.p_inventory.Location = new System.Drawing.Point(542, 27);
            this.p_inventory.MaxLength = 32767;
            this.p_inventory.MouseState = MaterialSkin.MouseState.OUT;
            this.p_inventory.Name = "p_inventory";
            this.p_inventory.PasswordChar = '\0';
            this.p_inventory.PrefixSuffixText = null;
            this.p_inventory.ReadOnly = false;
            this.p_inventory.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.p_inventory.SelectedText = "";
            this.p_inventory.SelectionLength = 0;
            this.p_inventory.SelectionStart = 0;
            this.p_inventory.ShortcutsEnabled = true;
            this.p_inventory.Size = new System.Drawing.Size(98, 48);
            this.p_inventory.TabIndex = 19;
            this.p_inventory.TabStop = false;
            this.p_inventory.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.p_inventory.TrailingIcon = null;
            this.p_inventory.UseSystemPasswordChar = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.label6.Location = new System.Drawing.Point(474, 36);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 17);
            this.label6.TabIndex = 18;
            this.label6.Text = "Inventory";
            // 
            // p_name
            // 
            this.p_name.AnimateReadOnly = false;
            this.p_name.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.p_name.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.p_name.Depth = 0;
            this.p_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.p_name.HideSelection = true;
            this.p_name.LeadingIcon = null;
            this.p_name.Location = new System.Drawing.Point(292, 27);
            this.p_name.MaxLength = 32767;
            this.p_name.MouseState = MaterialSkin.MouseState.OUT;
            this.p_name.Name = "p_name";
            this.p_name.PasswordChar = '\0';
            this.p_name.PrefixSuffixText = null;
            this.p_name.ReadOnly = false;
            this.p_name.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.p_name.SelectedText = "";
            this.p_name.SelectionLength = 0;
            this.p_name.SelectionStart = 0;
            this.p_name.ShortcutsEnabled = true;
            this.p_name.Size = new System.Drawing.Size(176, 48);
            this.p_name.TabIndex = 17;
            this.p_name.TabStop = false;
            this.p_name.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.p_name.TrailingIcon = null;
            this.p_name.UseSystemPasswordChar = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.label5.Location = new System.Drawing.Point(243, 36);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 17);
            this.label5.TabIndex = 16;
            this.label5.Text = "Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.label4.Location = new System.Drawing.Point(1, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 17);
            this.label4.TabIndex = 14;
            this.label4.Text = "search";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(12, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 17);
            this.label3.TabIndex = 13;
            this.label3.Text = "Product Details";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(3, 189);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1124, 380);
            this.panel3.TabIndex = 2;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.label15);
            this.panel5.Controls.Add(this.materialButton2);
            this.panel5.Controls.Add(this.return_amount);
            this.panel5.Controls.Add(this.label13);
            this.panel5.Controls.Add(this.grandtotal);
            this.panel5.Controls.Add(this.label14);
            this.panel5.Controls.Add(this.reportViewer1);
            this.panel5.Location = new System.Drawing.Point(527, 3);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(600, 377);
            this.panel5.TabIndex = 1;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.White;
            this.label15.Location = new System.Drawing.Point(9, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(66, 17);
            this.label15.TabIndex = 25;
            this.label15.Text = "Overview";
            // 
            // materialButton2
            // 
            this.materialButton2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButton2.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.materialButton2.Depth = 0;
            this.materialButton2.HighEmphasis = true;
            this.materialButton2.Icon = global::Abbey_Trading_Store.Properties.Resources.diskette;
            this.materialButton2.Location = new System.Drawing.Point(382, 310);
            this.materialButton2.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButton2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButton2.Name = "materialButton2";
            this.materialButton2.NoAccentTextColor = System.Drawing.Color.Empty;
            this.materialButton2.Size = new System.Drawing.Size(190, 36);
            this.materialButton2.TabIndex = 32;
            this.materialButton2.Text = "Save Transaction";
            this.materialButton2.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButton2.UseAccentColor = false;
            this.materialButton2.UseVisualStyleBackColor = true;
            this.materialButton2.Click += new System.EventHandler(this.materialButton2_Click);
            // 
            // return_amount
            // 
            this.return_amount.AnimateReadOnly = false;
            this.return_amount.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.return_amount.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.return_amount.Depth = 0;
            this.return_amount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.return_amount.HideSelection = true;
            this.return_amount.LeadingIcon = null;
            this.return_amount.Location = new System.Drawing.Point(104, 326);
            this.return_amount.MaxLength = 32767;
            this.return_amount.MouseState = MaterialSkin.MouseState.OUT;
            this.return_amount.Name = "return_amount";
            this.return_amount.PasswordChar = '\0';
            this.return_amount.PrefixSuffixText = null;
            this.return_amount.ReadOnly = false;
            this.return_amount.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.return_amount.SelectedText = "";
            this.return_amount.SelectionLength = 0;
            this.return_amount.SelectionStart = 0;
            this.return_amount.ShortcutsEnabled = true;
            this.return_amount.Size = new System.Drawing.Size(245, 48);
            this.return_amount.TabIndex = 31;
            this.return_amount.TabStop = false;
            this.return_amount.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.return_amount.TrailingIcon = null;
            this.return_amount.UseSystemPasswordChar = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.label13.Location = new System.Drawing.Point(9, 338);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(94, 17);
            this.label13.TabIndex = 30;
            this.label13.Text = "Return amount";
            // 
            // grandtotal
            // 
            this.grandtotal.AnimateReadOnly = false;
            this.grandtotal.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.grandtotal.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.grandtotal.Depth = 0;
            this.grandtotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grandtotal.HideSelection = true;
            this.grandtotal.LeadingIcon = null;
            this.grandtotal.Location = new System.Drawing.Point(104, 272);
            this.grandtotal.MaxLength = 32767;
            this.grandtotal.MouseState = MaterialSkin.MouseState.OUT;
            this.grandtotal.Name = "grandtotal";
            this.grandtotal.PasswordChar = '\0';
            this.grandtotal.PrefixSuffixText = null;
            this.grandtotal.ReadOnly = false;
            this.grandtotal.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.grandtotal.SelectedText = "";
            this.grandtotal.SelectionLength = 0;
            this.grandtotal.SelectionStart = 0;
            this.grandtotal.ShortcutsEnabled = true;
            this.grandtotal.Size = new System.Drawing.Size(245, 48);
            this.grandtotal.TabIndex = 29;
            this.grandtotal.TabStop = false;
            this.grandtotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.grandtotal.TrailingIcon = null;
            this.grandtotal.UseSystemPasswordChar = false;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.label14.Location = new System.Drawing.Point(17, 284);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(76, 17);
            this.label14.TabIndex = 28;
            this.label14.Text = "Grand Total";
            // 
            // reportViewer1
            // 
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Abbey_Trading_Store.Invoice.Report1.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(8, 17);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(583, 249);
            this.reportViewer1.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.dataGridView1);
            this.panel4.Controls.Add(this.paid_amount);
            this.panel4.Controls.Add(this.label12);
            this.panel4.Controls.Add(this.textBox13);
            this.panel4.Controls.Add(this.label11);
            this.panel4.Controls.Add(this.subtotal);
            this.panel4.Controls.Add(this.label10);
            this.panel4.Controls.Add(this.label9);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Font = new System.Drawing.Font("Nirmala UI", 9.75F);
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(525, 380);
            this.panel4.TabIndex = 0;
            // 
            // dataGridView1
            // 
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Nirmala UI", 9.75F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.Location = new System.Drawing.Point(4, 20);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView1.Size = new System.Drawing.Size(517, 158);
            this.dataGridView1.TabIndex = 28;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick_1);
            // 
            // paid_amount
            // 
            this.paid_amount.AnimateReadOnly = false;
            this.paid_amount.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.paid_amount.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.paid_amount.Depth = 0;
            this.paid_amount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.paid_amount.HideSelection = true;
            this.paid_amount.LeadingIcon = null;
            this.paid_amount.Location = new System.Drawing.Point(95, 320);
            this.paid_amount.MaxLength = 32767;
            this.paid_amount.MouseState = MaterialSkin.MouseState.OUT;
            this.paid_amount.Name = "paid_amount";
            this.paid_amount.PasswordChar = '\0';
            this.paid_amount.PrefixSuffixText = null;
            this.paid_amount.ReadOnly = false;
            this.paid_amount.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.paid_amount.SelectedText = "";
            this.paid_amount.SelectionLength = 0;
            this.paid_amount.SelectionStart = 0;
            this.paid_amount.ShortcutsEnabled = true;
            this.paid_amount.Size = new System.Drawing.Size(245, 48);
            this.paid_amount.TabIndex = 27;
            this.paid_amount.TabStop = false;
            this.paid_amount.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.paid_amount.TrailingIcon = null;
            this.paid_amount.UseSystemPasswordChar = false;
            this.paid_amount.TextChanged += new System.EventHandler(this.paid_amount_TextChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.label12.Location = new System.Drawing.Point(8, 332);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(81, 17);
            this.label12.TabIndex = 26;
            this.label12.Text = "Paid amount";
            // 
            // textBox13
            // 
            this.textBox13.AnimateReadOnly = false;
            this.textBox13.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.textBox13.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBox13.Depth = 0;
            this.textBox13.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.textBox13.HideSelection = true;
            this.textBox13.LeadingIcon = null;
            this.textBox13.Location = new System.Drawing.Point(95, 254);
            this.textBox13.MaxLength = 32767;
            this.textBox13.MouseState = MaterialSkin.MouseState.OUT;
            this.textBox13.Name = "textBox13";
            this.textBox13.PasswordChar = '\0';
            this.textBox13.PrefixSuffixText = null;
            this.textBox13.ReadOnly = false;
            this.textBox13.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBox13.SelectedText = "";
            this.textBox13.SelectionLength = 0;
            this.textBox13.SelectionStart = 0;
            this.textBox13.ShortcutsEnabled = true;
            this.textBox13.Size = new System.Drawing.Size(245, 48);
            this.textBox13.TabIndex = 25;
            this.textBox13.TabStop = false;
            this.textBox13.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.textBox13.TrailingIcon = null;
            this.textBox13.UseSystemPasswordChar = false;
            this.textBox13.TextChanged += new System.EventHandler(this.textBox13_TextChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.label11.Location = new System.Drawing.Point(8, 266);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(58, 17);
            this.label11.TabIndex = 24;
            this.label11.Text = "Discount";
            // 
            // subtotal
            // 
            this.subtotal.AnimateReadOnly = false;
            this.subtotal.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.subtotal.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.subtotal.Depth = 0;
            this.subtotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.subtotal.HideSelection = true;
            this.subtotal.LeadingIcon = null;
            this.subtotal.Location = new System.Drawing.Point(95, 191);
            this.subtotal.MaxLength = 32767;
            this.subtotal.MouseState = MaterialSkin.MouseState.OUT;
            this.subtotal.Name = "subtotal";
            this.subtotal.PasswordChar = '\0';
            this.subtotal.PrefixSuffixText = null;
            this.subtotal.ReadOnly = false;
            this.subtotal.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.subtotal.SelectedText = "";
            this.subtotal.SelectionLength = 0;
            this.subtotal.SelectionStart = 0;
            this.subtotal.ShortcutsEnabled = true;
            this.subtotal.Size = new System.Drawing.Size(245, 48);
            this.subtotal.TabIndex = 23;
            this.subtotal.TabStop = false;
            this.subtotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.subtotal.TrailingIcon = null;
            this.subtotal.UseSystemPasswordChar = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.label10.Location = new System.Drawing.Point(8, 203);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(62, 17);
            this.label10.TabIndex = 22;
            this.label10.Text = "Sub Total";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(3, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(106, 17);
            this.label9.TabIndex = 14;
            this.label9.Text = "Added Products";
            // 
            // frmPurchaseAndSales
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.ClientSize = new System.Drawing.Size(1130, 572);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormStyle = MaterialSkin.Controls.MaterialForm.FormStyles.StatusAndActionBar_None;
            this.Name = "frmPurchaseAndSales";
            this.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.Text = "frmPurchaseAndSales";
            this.Load += new System.EventHandler(this.frmPurchaseAndSales_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private MaterialSkin.Controls.MaterialTextBox2 name;
        private System.Windows.Forms.Label label2;
        private MaterialSkin.Controls.MaterialTextBox2 search;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private MaterialSkin.Controls.MaterialTextBox2 p_inventory;
        private System.Windows.Forms.Label label6;
        private MaterialSkin.Controls.MaterialTextBox2 p_name;
        private System.Windows.Forms.Label label5;
        private MaterialSkin.Controls.MaterialTextBox2 p_quantity;
        private System.Windows.Forms.Label label8;
        private MaterialSkin.Controls.MaterialButton materialButton1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel5;
        private MaterialSkin.Controls.MaterialTextBox2 paid_amount;
        private System.Windows.Forms.Label label12;
        private MaterialSkin.Controls.MaterialTextBox2 textBox13;
        private System.Windows.Forms.Label label11;
        private MaterialSkin.Controls.MaterialTextBox2 subtotal;
        private System.Windows.Forms.Label label10;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private MaterialSkin.Controls.MaterialButton materialButton2;
        private MaterialSkin.Controls.MaterialTextBox2 return_amount;
        private System.Windows.Forms.Label label13;
        private MaterialSkin.Controls.MaterialTextBox2 grandtotal;
        private System.Windows.Forms.Label label14;
        private MaterialSkin.Controls.MaterialTextBox2 email;
        private System.Windows.Forms.Label label17;
        private MaterialSkin.Controls.MaterialTextBox2 contact;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private MaterialSkin.Controls.MaterialButton materialButton4;
        private MaterialSkin.Controls.MaterialTextBox2 invoice_txtbx;
        private MaterialSkin.Controls.MaterialMultiLineTextBox2 address;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ComboBox p_search1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private MaterialSkin.Controls.MaterialComboBox p_rate;
    }
}