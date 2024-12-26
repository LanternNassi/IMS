namespace Abbey_Trading_Store.UI.Advanced.Screen_forms
{
    partial class frmSettings
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.ovPanel = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.BackupsDGV = new Abbey_Trading_Store.DAL.DAL_Properties.DGV();
            this.panel8 = new System.Windows.Forms.Panel();
            this.materialButton2 = new MaterialSkin.Controls.MaterialButton();
            this.label9 = new System.Windows.Forms.Label();
            this.AppInfo_flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.client_id_txtbx = new MaterialSkin.Controls.MaterialTextBox2();
            this.label17 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.name_txtbx = new MaterialSkin.Controls.MaterialTextBox2();
            this.label1 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.number_txtbx = new MaterialSkin.Controls.MaterialTextBox2();
            this.label2 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.description_txtbx = new MaterialSkin.Controls.MaterialTextBox2();
            this.label3 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.sms_api_txtbx = new MaterialSkin.Controls.MaterialTextBox2();
            this.label4 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.sms_name_txtbx = new MaterialSkin.Controls.MaterialTextBox2();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.materialButton1 = new MaterialSkin.Controls.MaterialButton();
            this.ovPanel.SuspendLayout();
            this.panel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BackupsDGV)).BeginInit();
            this.panel8.SuspendLayout();
            this.AppInfo_flowLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ovPanel
            // 
            this.ovPanel.AutoScroll = true;
            this.ovPanel.Controls.Add(this.panel9);
            this.ovPanel.Controls.Add(this.panel8);
            this.ovPanel.Controls.Add(this.AppInfo_flowLayoutPanel1);
            this.ovPanel.Controls.Add(this.panel1);
            this.ovPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ovPanel.Location = new System.Drawing.Point(0, 0);
            this.ovPanel.Name = "ovPanel";
            this.ovPanel.Size = new System.Drawing.Size(1130, 592);
            this.ovPanel.TabIndex = 0;
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.BackupsDGV);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel9.Font = new System.Drawing.Font("Nirmala UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel9.Location = new System.Drawing.Point(0, 312);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(1130, 230);
            this.panel9.TabIndex = 3;
            // 
            // BackupsDGV
            // 
            this.BackupsDGV.AllowUserToAddRows = false;
            this.BackupsDGV.AllowUserToDeleteRows = false;
            this.BackupsDGV.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            this.BackupsDGV.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.BackupsDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.BackupsDGV.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.BackupsDGV.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.BackupsDGV.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.BackupsDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Nirmala UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.BackupsDGV.DefaultCellStyle = dataGridViewCellStyle2;
            this.BackupsDGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BackupsDGV.EnableHeadersVisualStyles = false;
            this.BackupsDGV.Location = new System.Drawing.Point(0, 0);
            this.BackupsDGV.Name = "BackupsDGV";
            this.BackupsDGV.RowHeadersVisible = false;
            this.BackupsDGV.RowTemplate.Height = 30;
            this.BackupsDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.BackupsDGV.Size = new System.Drawing.Size(1130, 230);
            this.BackupsDGV.TabIndex = 26;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.materialButton2);
            this.panel8.Controls.Add(this.label9);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel8.Location = new System.Drawing.Point(0, 261);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(1130, 51);
            this.panel8.TabIndex = 2;
            // 
            // materialButton2
            // 
            this.materialButton2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.materialButton2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButton2.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.materialButton2.Depth = 0;
            this.materialButton2.HighEmphasis = true;
            this.materialButton2.Icon = global::Abbey_Trading_Store.Properties.Resources.people;
            this.materialButton2.Location = new System.Drawing.Point(953, 9);
            this.materialButton2.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButton2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButton2.Name = "materialButton2";
            this.materialButton2.NoAccentTextColor = System.Drawing.Color.Empty;
            this.materialButton2.Size = new System.Drawing.Size(164, 36);
            this.materialButton2.TabIndex = 27;
            this.materialButton2.Text = "Create BackUp Point";
            this.materialButton2.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButton2.UseAccentColor = false;
            this.materialButton2.UseVisualStyleBackColor = true;
            this.materialButton2.Click += new System.EventHandler(this.materialButton2_Click);
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Nirmala UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(12, 9);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(285, 20);
            this.label9.TabIndex = 17;
            this.label9.Text = "APPLICATION BACKUP MANAGEMENT";
            // 
            // AppInfo_flowLayoutPanel1
            // 
            this.AppInfo_flowLayoutPanel1.Controls.Add(this.panel2);
            this.AppInfo_flowLayoutPanel1.Controls.Add(this.panel3);
            this.AppInfo_flowLayoutPanel1.Controls.Add(this.panel4);
            this.AppInfo_flowLayoutPanel1.Controls.Add(this.panel5);
            this.AppInfo_flowLayoutPanel1.Controls.Add(this.panel6);
            this.AppInfo_flowLayoutPanel1.Controls.Add(this.panel7);
            this.AppInfo_flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.AppInfo_flowLayoutPanel1.Location = new System.Drawing.Point(0, 41);
            this.AppInfo_flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.AppInfo_flowLayoutPanel1.Name = "AppInfo_flowLayoutPanel1";
            this.AppInfo_flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(4);
            this.AppInfo_flowLayoutPanel1.Size = new System.Drawing.Size(1130, 220);
            this.AppInfo_flowLayoutPanel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.client_id_txtbx);
            this.panel2.Controls.Add(this.label17);
            this.panel2.Location = new System.Drawing.Point(7, 7);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(365, 100);
            this.panel2.TabIndex = 0;
            // 
            // client_id_txtbx
            // 
            this.client_id_txtbx.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.client_id_txtbx.AnimateReadOnly = false;
            this.client_id_txtbx.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.client_id_txtbx.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.client_id_txtbx.Depth = 0;
            this.client_id_txtbx.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.client_id_txtbx.HideSelection = true;
            this.client_id_txtbx.LeadingIcon = null;
            this.client_id_txtbx.Location = new System.Drawing.Point(9, 44);
            this.client_id_txtbx.MaxLength = 32767;
            this.client_id_txtbx.MouseState = MaterialSkin.MouseState.OUT;
            this.client_id_txtbx.Name = "client_id_txtbx";
            this.client_id_txtbx.PasswordChar = '\0';
            this.client_id_txtbx.PrefixSuffixText = null;
            this.client_id_txtbx.ReadOnly = true;
            this.client_id_txtbx.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.client_id_txtbx.SelectedText = "";
            this.client_id_txtbx.SelectionLength = 0;
            this.client_id_txtbx.SelectionStart = 0;
            this.client_id_txtbx.ShortcutsEnabled = true;
            this.client_id_txtbx.Size = new System.Drawing.Size(342, 48);
            this.client_id_txtbx.TabIndex = 23;
            this.client_id_txtbx.TabStop = false;
            this.client_id_txtbx.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.client_id_txtbx.TrailingIcon = null;
            this.client_id_txtbx.UseSystemPasswordChar = false;
            // 
            // label17
            // 
            this.label17.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.label17.Location = new System.Drawing.Point(16, 12);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(55, 17);
            this.label17.TabIndex = 22;
            this.label17.Text = "Client Id";
            this.label17.Click += new System.EventHandler(this.label17_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.name_txtbx);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Location = new System.Drawing.Point(378, 7);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(365, 100);
            this.panel3.TabIndex = 1;
            // 
            // name_txtbx
            // 
            this.name_txtbx.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.name_txtbx.AnimateReadOnly = false;
            this.name_txtbx.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.name_txtbx.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.name_txtbx.Depth = 0;
            this.name_txtbx.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.name_txtbx.HideSelection = true;
            this.name_txtbx.LeadingIcon = null;
            this.name_txtbx.Location = new System.Drawing.Point(12, 42);
            this.name_txtbx.MaxLength = 32767;
            this.name_txtbx.MouseState = MaterialSkin.MouseState.OUT;
            this.name_txtbx.Name = "name_txtbx";
            this.name_txtbx.PasswordChar = '\0';
            this.name_txtbx.PrefixSuffixText = null;
            this.name_txtbx.ReadOnly = true;
            this.name_txtbx.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.name_txtbx.SelectedText = "";
            this.name_txtbx.SelectionLength = 0;
            this.name_txtbx.SelectionStart = 0;
            this.name_txtbx.ShortcutsEnabled = true;
            this.name_txtbx.Size = new System.Drawing.Size(342, 48);
            this.name_txtbx.TabIndex = 25;
            this.name_txtbx.TabStop = false;
            this.name_txtbx.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.name_txtbx.TrailingIcon = null;
            this.name_txtbx.UseSystemPasswordChar = false;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.label1.Location = new System.Drawing.Point(19, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 17);
            this.label1.TabIndex = 24;
            this.label1.Text = "Business Name";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.number_txtbx);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Location = new System.Drawing.Point(749, 7);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(365, 100);
            this.panel4.TabIndex = 2;
            // 
            // number_txtbx
            // 
            this.number_txtbx.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.number_txtbx.AnimateReadOnly = false;
            this.number_txtbx.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.number_txtbx.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.number_txtbx.Depth = 0;
            this.number_txtbx.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.number_txtbx.HideSelection = true;
            this.number_txtbx.LeadingIcon = null;
            this.number_txtbx.Location = new System.Drawing.Point(12, 42);
            this.number_txtbx.MaxLength = 32767;
            this.number_txtbx.MouseState = MaterialSkin.MouseState.OUT;
            this.number_txtbx.Name = "number_txtbx";
            this.number_txtbx.PasswordChar = '\0';
            this.number_txtbx.PrefixSuffixText = null;
            this.number_txtbx.ReadOnly = true;
            this.number_txtbx.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.number_txtbx.SelectedText = "";
            this.number_txtbx.SelectionLength = 0;
            this.number_txtbx.SelectionStart = 0;
            this.number_txtbx.ShortcutsEnabled = true;
            this.number_txtbx.Size = new System.Drawing.Size(342, 48);
            this.number_txtbx.TabIndex = 25;
            this.number_txtbx.TabStop = false;
            this.number_txtbx.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.number_txtbx.TrailingIcon = null;
            this.number_txtbx.UseSystemPasswordChar = false;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.label2.Location = new System.Drawing.Point(19, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 17);
            this.label2.TabIndex = 24;
            this.label2.Text = "Telephone Number";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.description_txtbx);
            this.panel5.Controls.Add(this.label3);
            this.panel5.Location = new System.Drawing.Point(7, 113);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(365, 100);
            this.panel5.TabIndex = 3;
            // 
            // description_txtbx
            // 
            this.description_txtbx.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.description_txtbx.AnimateReadOnly = false;
            this.description_txtbx.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.description_txtbx.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.description_txtbx.Depth = 0;
            this.description_txtbx.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.description_txtbx.HideSelection = true;
            this.description_txtbx.LeadingIcon = null;
            this.description_txtbx.Location = new System.Drawing.Point(12, 42);
            this.description_txtbx.MaxLength = 32767;
            this.description_txtbx.MouseState = MaterialSkin.MouseState.OUT;
            this.description_txtbx.Name = "description_txtbx";
            this.description_txtbx.PasswordChar = '\0';
            this.description_txtbx.PrefixSuffixText = null;
            this.description_txtbx.ReadOnly = true;
            this.description_txtbx.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.description_txtbx.SelectedText = "";
            this.description_txtbx.SelectionLength = 0;
            this.description_txtbx.SelectionStart = 0;
            this.description_txtbx.ShortcutsEnabled = true;
            this.description_txtbx.Size = new System.Drawing.Size(342, 48);
            this.description_txtbx.TabIndex = 25;
            this.description_txtbx.TabStop = false;
            this.description_txtbx.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.description_txtbx.TrailingIcon = null;
            this.description_txtbx.UseSystemPasswordChar = false;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.label3.Location = new System.Drawing.Point(19, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 17);
            this.label3.TabIndex = 24;
            this.label3.Text = "Description";
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.sms_api_txtbx);
            this.panel6.Controls.Add(this.label4);
            this.panel6.Location = new System.Drawing.Point(378, 113);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(365, 100);
            this.panel6.TabIndex = 4;
            // 
            // sms_api_txtbx
            // 
            this.sms_api_txtbx.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sms_api_txtbx.AnimateReadOnly = false;
            this.sms_api_txtbx.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.sms_api_txtbx.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.sms_api_txtbx.Depth = 0;
            this.sms_api_txtbx.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.sms_api_txtbx.HideSelection = true;
            this.sms_api_txtbx.LeadingIcon = null;
            this.sms_api_txtbx.Location = new System.Drawing.Point(12, 42);
            this.sms_api_txtbx.MaxLength = 32767;
            this.sms_api_txtbx.MouseState = MaterialSkin.MouseState.OUT;
            this.sms_api_txtbx.Name = "sms_api_txtbx";
            this.sms_api_txtbx.PasswordChar = '\0';
            this.sms_api_txtbx.PrefixSuffixText = null;
            this.sms_api_txtbx.ReadOnly = true;
            this.sms_api_txtbx.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.sms_api_txtbx.SelectedText = "";
            this.sms_api_txtbx.SelectionLength = 0;
            this.sms_api_txtbx.SelectionStart = 0;
            this.sms_api_txtbx.ShortcutsEnabled = true;
            this.sms_api_txtbx.Size = new System.Drawing.Size(342, 48);
            this.sms_api_txtbx.TabIndex = 27;
            this.sms_api_txtbx.TabStop = false;
            this.sms_api_txtbx.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.sms_api_txtbx.TrailingIcon = null;
            this.sms_api_txtbx.UseSystemPasswordChar = false;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.label4.Location = new System.Drawing.Point(19, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 17);
            this.label4.TabIndex = 26;
            this.label4.Text = "SMS API Key";
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.sms_name_txtbx);
            this.panel7.Controls.Add(this.label5);
            this.panel7.Location = new System.Drawing.Point(749, 113);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(365, 100);
            this.panel7.TabIndex = 5;
            // 
            // sms_name_txtbx
            // 
            this.sms_name_txtbx.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sms_name_txtbx.AnimateReadOnly = false;
            this.sms_name_txtbx.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.sms_name_txtbx.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.sms_name_txtbx.Depth = 0;
            this.sms_name_txtbx.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.sms_name_txtbx.HideSelection = true;
            this.sms_name_txtbx.LeadingIcon = null;
            this.sms_name_txtbx.Location = new System.Drawing.Point(12, 42);
            this.sms_name_txtbx.MaxLength = 32767;
            this.sms_name_txtbx.MouseState = MaterialSkin.MouseState.OUT;
            this.sms_name_txtbx.Name = "sms_name_txtbx";
            this.sms_name_txtbx.PasswordChar = '\0';
            this.sms_name_txtbx.PrefixSuffixText = null;
            this.sms_name_txtbx.ReadOnly = true;
            this.sms_name_txtbx.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.sms_name_txtbx.SelectedText = "";
            this.sms_name_txtbx.SelectionLength = 0;
            this.sms_name_txtbx.SelectionStart = 0;
            this.sms_name_txtbx.ShortcutsEnabled = true;
            this.sms_name_txtbx.Size = new System.Drawing.Size(342, 48);
            this.sms_name_txtbx.TabIndex = 27;
            this.sms_name_txtbx.TabStop = false;
            this.sms_name_txtbx.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.sms_name_txtbx.TrailingIcon = null;
            this.sms_name_txtbx.UseSystemPasswordChar = false;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.label5.Location = new System.Drawing.Point(19, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 17);
            this.label5.TabIndex = 26;
            this.label5.Text = "SMS Username";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.materialButton1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1130, 41);
            this.panel1.TabIndex = 0;
            // 
            // materialButton1
            // 
            this.materialButton1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.materialButton1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButton1.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.materialButton1.Depth = 0;
            this.materialButton1.HighEmphasis = true;
            this.materialButton1.Icon = global::Abbey_Trading_Store.Properties.Resources.people;
            this.materialButton1.Location = new System.Drawing.Point(7, 3);
            this.materialButton1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButton1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButton1.Name = "materialButton1";
            this.materialButton1.NoAccentTextColor = System.Drawing.Color.Empty;
            this.materialButton1.Size = new System.Drawing.Size(183, 36);
            this.materialButton1.TabIndex = 26;
            this.materialButton1.Text = "Edit Information";
            this.materialButton1.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButton1.UseAccentColor = false;
            this.materialButton1.UseVisualStyleBackColor = true;
            this.materialButton1.Click += new System.EventHandler(this.materialButton1_Click);
            // 
            // frmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.ClientSize = new System.Drawing.Size(1130, 592);
            this.Controls.Add(this.ovPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmSettings";
            this.Text = "frmSettings";
            this.Load += new System.EventHandler(this.frmSettings_Load);
            this.ovPanel.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.BackupsDGV)).EndInit();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.AppInfo_flowLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel ovPanel;
        private System.Windows.Forms.FlowLayoutPanel AppInfo_flowLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private MaterialSkin.Controls.MaterialButton materialButton1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel7;
        private MaterialSkin.Controls.MaterialTextBox2 client_id_txtbx;
        private System.Windows.Forms.Label label17;
        private MaterialSkin.Controls.MaterialTextBox2 name_txtbx;
        private System.Windows.Forms.Label label1;
        private MaterialSkin.Controls.MaterialTextBox2 number_txtbx;
        private System.Windows.Forms.Label label2;
        private MaterialSkin.Controls.MaterialTextBox2 description_txtbx;
        private System.Windows.Forms.Label label3;
        private MaterialSkin.Controls.MaterialTextBox2 sms_api_txtbx;
        private System.Windows.Forms.Label label4;
        private MaterialSkin.Controls.MaterialTextBox2 sms_name_txtbx;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label label9;
        private DAL.DAL_Properties.DGV BackupsDGV;
        private MaterialSkin.Controls.MaterialButton materialButton2;
    }
}