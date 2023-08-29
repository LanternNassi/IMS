using Abbey_Trading_Store.DAL.DAL_Properties;

namespace Abbey_Trading_Store.UI.Advanced.Screen_forms
{
    partial class frmProducts
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProducts));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label5 = new System.Windows.Forms.Label();
            this.circularProgressBar2 = new CircularProgressBar.CircularProgressBar();
            this.label3 = new System.Windows.Forms.Label();
            this.circularProgressBar1 = new CircularProgressBar.CircularProgressBar();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.search = new MaterialSkin.Controls.MaterialTextBox();
            this.materialButton4 = new MaterialSkin.Controls.MaterialButton();
            this.materialButton3 = new MaterialSkin.Controls.MaterialButton();
            this.materialButton2 = new MaterialSkin.Controls.MaterialButton();
            this.description = new MaterialSkin.Controls.MaterialMultiLineTextBox2();
            this.name = new MaterialSkin.Controls.MaterialTextBox2();
            this.id = new MaterialSkin.Controls.MaterialTextBox2();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.materialButton1 = new MaterialSkin.Controls.MaterialButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.WP = new MaterialSkin.Controls.MaterialTextBox2();
            this.label9 = new System.Windows.Forms.Label();
            this.SP_txtbx = new MaterialSkin.Controls.MaterialTextBox2();
            this.label8 = new System.Windows.Forms.Label();
            this.category_comboBox1 = new MaterialSkin.Controls.MaterialComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.rate = new MaterialSkin.Controls.MaterialTextBox2();
            this.label6 = new System.Windows.Forms.Label();
            this.materialButton5 = new MaterialSkin.Controls.MaterialButton();
            this.materialButton6 = new MaterialSkin.Controls.MaterialButton();
            this.dataGridView1 = new Abbey_Trading_Store.DAL.DAL_Properties.DGV();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(417, 99);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 15);
            this.label5.TabIndex = 3;
            this.label5.Text = "search count";
            // 
            // circularProgressBar2
            // 
            this.circularProgressBar2.AnimationFunction = WinFormAnimation.KnownAnimationFunctions.CircularEaseIn;
            this.circularProgressBar2.AnimationSpeed = 500;
            this.circularProgressBar2.BackColor = System.Drawing.Color.Transparent;
            this.circularProgressBar2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.circularProgressBar2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.circularProgressBar2.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.circularProgressBar2.InnerMargin = 2;
            this.circularProgressBar2.InnerWidth = -1;
            this.circularProgressBar2.Location = new System.Drawing.Point(400, 3);
            this.circularProgressBar2.MarqueeAnimationSpeed = 2000;
            this.circularProgressBar2.Name = "circularProgressBar2";
            this.circularProgressBar2.OuterColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.circularProgressBar2.OuterMargin = -25;
            this.circularProgressBar2.OuterWidth = 26;
            this.circularProgressBar2.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.circularProgressBar2.ProgressWidth = 10;
            this.circularProgressBar2.SecondaryFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.circularProgressBar2.Size = new System.Drawing.Size(92, 90);
            this.circularProgressBar2.StartAngle = 270;
            this.circularProgressBar2.SubscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.circularProgressBar2.SubscriptMargin = new System.Windows.Forms.Padding(10, -35, 0, 0);
            this.circularProgressBar2.SubscriptText = "";
            this.circularProgressBar2.SuperscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.circularProgressBar2.SuperscriptMargin = new System.Windows.Forms.Padding(10, 35, 0, 0);
            this.circularProgressBar2.SuperscriptText = "";
            this.circularProgressBar2.TabIndex = 2;
            this.circularProgressBar2.Text = "30%";
            this.circularProgressBar2.TextMargin = new System.Windows.Forms.Padding(4, 4, 0, 0);
            this.circularProgressBar2.Value = 68;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(77, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 15);
            this.label3.TabIndex = 1;
            this.label3.Text = "count";
            // 
            // circularProgressBar1
            // 
            this.circularProgressBar1.AnimationFunction = WinFormAnimation.KnownAnimationFunctions.CircularEaseIn;
            this.circularProgressBar1.AnimationSpeed = 500;
            this.circularProgressBar1.BackColor = System.Drawing.Color.Transparent;
            this.circularProgressBar1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.circularProgressBar1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.circularProgressBar1.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.circularProgressBar1.InnerMargin = 2;
            this.circularProgressBar1.InnerWidth = -1;
            this.circularProgressBar1.Location = new System.Drawing.Point(54, 3);
            this.circularProgressBar1.MarqueeAnimationSpeed = 2000;
            this.circularProgressBar1.Name = "circularProgressBar1";
            this.circularProgressBar1.OuterColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.circularProgressBar1.OuterMargin = -25;
            this.circularProgressBar1.OuterWidth = 26;
            this.circularProgressBar1.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.circularProgressBar1.ProgressWidth = 10;
            this.circularProgressBar1.SecondaryFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.circularProgressBar1.Size = new System.Drawing.Size(92, 90);
            this.circularProgressBar1.StartAngle = 270;
            this.circularProgressBar1.SubscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.circularProgressBar1.SubscriptMargin = new System.Windows.Forms.Padding(10, -35, 0, 0);
            this.circularProgressBar1.SubscriptText = "";
            this.circularProgressBar1.SuperscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.circularProgressBar1.SuperscriptMargin = new System.Windows.Forms.Padding(10, 35, 0, 0);
            this.circularProgressBar1.SuperscriptText = "";
            this.circularProgressBar1.TabIndex = 0;
            this.circularProgressBar1.Text = "30%";
            this.circularProgressBar1.TextMargin = new System.Windows.Forms.Padding(4, 4, 0, 0);
            this.circularProgressBar1.Value = 68;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dataGridView1);
            this.panel2.Font = new System.Drawing.Font("Nirmala UI", 9.75F);
            this.panel2.Location = new System.Drawing.Point(274, 206);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(852, 366);
            this.panel2.TabIndex = 21;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.circularProgressBar2);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.circularProgressBar1);
            this.panel3.Location = new System.Drawing.Point(274, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(537, 120);
            this.panel3.TabIndex = 20;
            // 
            // search
            // 
            this.search.AnimateReadOnly = false;
            this.search.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.search.Depth = 0;
            this.search.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.search.LeadingIcon = global::Abbey_Trading_Store.Properties.Resources.search__1_;
            this.search.Location = new System.Drawing.Point(824, 49);
            this.search.MaxLength = 50;
            this.search.MouseState = MaterialSkin.MouseState.OUT;
            this.search.Multiline = false;
            this.search.Name = "search";
            this.search.Size = new System.Drawing.Size(294, 50);
            this.search.TabIndex = 19;
            this.search.Text = "";
            this.search.TrailingIcon = null;
            this.search.TextChanged += new System.EventHandler(this.search_TextChanged);
            // 
            // materialButton4
            // 
            this.materialButton4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButton4.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.materialButton4.Depth = 0;
            this.materialButton4.HighEmphasis = true;
            this.materialButton4.Icon = global::Abbey_Trading_Store.Properties.Resources.print;
            this.materialButton4.Location = new System.Drawing.Point(1022, 129);
            this.materialButton4.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButton4.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButton4.Name = "materialButton4";
            this.materialButton4.NoAccentTextColor = System.Drawing.Color.Empty;
            this.materialButton4.Size = new System.Drawing.Size(91, 36);
            this.materialButton4.TabIndex = 18;
            this.materialButton4.Text = "PRINT";
            this.materialButton4.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButton4.UseAccentColor = false;
            this.materialButton4.UseVisualStyleBackColor = true;
            // 
            // materialButton3
            // 
            this.materialButton3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButton3.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.materialButton3.Depth = 0;
            this.materialButton3.Enabled = false;
            this.materialButton3.HighEmphasis = true;
            this.materialButton3.Icon = global::Abbey_Trading_Store.Properties.Resources.delete;
            this.materialButton3.Location = new System.Drawing.Point(818, 129);
            this.materialButton3.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButton3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButton3.Name = "materialButton3";
            this.materialButton3.NoAccentTextColor = System.Drawing.Color.Empty;
            this.materialButton3.Size = new System.Drawing.Size(101, 36);
            this.materialButton3.TabIndex = 17;
            this.materialButton3.Text = "DELETE";
            this.materialButton3.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButton3.UseAccentColor = false;
            this.materialButton3.UseVisualStyleBackColor = true;
            this.materialButton3.Click += new System.EventHandler(this.materialButton3_Click);
            // 
            // materialButton2
            // 
            this.materialButton2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButton2.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.materialButton2.Depth = 0;
            this.materialButton2.Enabled = false;
            this.materialButton2.HighEmphasis = true;
            this.materialButton2.Icon = global::Abbey_Trading_Store.Properties.Resources.recovery;
            this.materialButton2.Location = new System.Drawing.Point(593, 129);
            this.materialButton2.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButton2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButton2.Name = "materialButton2";
            this.materialButton2.NoAccentTextColor = System.Drawing.Color.Empty;
            this.materialButton2.Size = new System.Drawing.Size(105, 36);
            this.materialButton2.TabIndex = 16;
            this.materialButton2.Text = "UPDATE";
            this.materialButton2.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButton2.UseAccentColor = false;
            this.materialButton2.UseVisualStyleBackColor = true;
            this.materialButton2.Click += new System.EventHandler(this.materialButton2_Click);
            // 
            // description
            // 
            this.description.AnimateReadOnly = false;
            this.description.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.description.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.description.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.description.Depth = 0;
            this.description.HideSelection = true;
            this.description.Location = new System.Drawing.Point(82, 224);
            this.description.MaxLength = 32767;
            this.description.MouseState = MaterialSkin.MouseState.OUT;
            this.description.Name = "description";
            this.description.PasswordChar = '\0';
            this.description.ReadOnly = false;
            this.description.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.description.SelectedText = "";
            this.description.SelectionLength = 0;
            this.description.SelectionStart = 0;
            this.description.ShortcutsEnabled = true;
            this.description.Size = new System.Drawing.Size(177, 103);
            this.description.TabIndex = 14;
            this.description.TabStop = false;
            this.description.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.description.UseSystemPasswordChar = false;
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
            this.name.Location = new System.Drawing.Point(82, 72);
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
            this.name.TabIndex = 10;
            this.name.TabStop = false;
            this.name.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.name.TrailingIcon = null;
            this.name.UseSystemPasswordChar = false;
            this.name.TextChanged += new System.EventHandler(this.name_TextChanged);
            // 
            // id
            // 
            this.id.AnimateReadOnly = false;
            this.id.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.id.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.id.Depth = 0;
            this.id.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.id.HideSelection = true;
            this.id.LeadingIcon = null;
            this.id.Location = new System.Drawing.Point(82, 3);
            this.id.MaxLength = 32767;
            this.id.MouseState = MaterialSkin.MouseState.OUT;
            this.id.Name = "id";
            this.id.PasswordChar = '\0';
            this.id.PrefixSuffixText = null;
            this.id.ReadOnly = true;
            this.id.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.id.SelectedText = "";
            this.id.SelectionLength = 0;
            this.id.SelectionStart = 0;
            this.id.ShortcutsEnabled = true;
            this.id.Size = new System.Drawing.Size(177, 48);
            this.id.TabIndex = 9;
            this.id.TabStop = false;
            this.id.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.id.TrailingIcon = null;
            this.id.UseSystemPasswordChar = false;
            this.id.Click += new System.EventHandler(this.id_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.label4.Location = new System.Drawing.Point(2, 239);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Description";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.label2.Location = new System.Drawing.Point(3, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.label1.Location = new System.Drawing.Point(3, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(19, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "id";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // materialButton1
            // 
            this.materialButton1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButton1.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.materialButton1.Depth = 0;
            this.materialButton1.Enabled = false;
            this.materialButton1.HighEmphasis = true;
            this.materialButton1.Icon = global::Abbey_Trading_Store.Properties.Resources.people;
            this.materialButton1.Location = new System.Drawing.Point(398, 129);
            this.materialButton1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButton1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButton1.Name = "materialButton1";
            this.materialButton1.NoAccentTextColor = System.Drawing.Color.Empty;
            this.materialButton1.Size = new System.Drawing.Size(78, 36);
            this.materialButton1.TabIndex = 15;
            this.materialButton1.Text = "Add";
            this.materialButton1.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButton1.UseAccentColor = false;
            this.materialButton1.UseVisualStyleBackColor = true;
            this.materialButton1.Click += new System.EventHandler(this.materialButton1_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.WP);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.SP_txtbx);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.category_comboBox1);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.rate);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.description);
            this.panel1.Controls.Add(this.name);
            this.panel1.Controls.Add(this.id);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(262, 572);
            this.panel1.TabIndex = 14;
            // 
            // WP
            // 
            this.WP.AnimateReadOnly = false;
            this.WP.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.WP.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.WP.Depth = 0;
            this.WP.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.WP.HideSelection = true;
            this.WP.LeadingIcon = null;
            this.WP.Location = new System.Drawing.Point(82, 495);
            this.WP.MaxLength = 32767;
            this.WP.MouseState = MaterialSkin.MouseState.OUT;
            this.WP.Name = "WP";
            this.WP.PasswordChar = '\0';
            this.WP.PrefixSuffixText = null;
            this.WP.ReadOnly = false;
            this.WP.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.WP.SelectedText = "";
            this.WP.SelectionLength = 0;
            this.WP.SelectionStart = 0;
            this.WP.ShortcutsEnabled = true;
            this.WP.Size = new System.Drawing.Size(177, 48);
            this.WP.TabIndex = 22;
            this.WP.TabStop = false;
            this.WP.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.WP.TrailingIcon = null;
            this.WP.UseSystemPasswordChar = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.label9.Location = new System.Drawing.Point(3, 505);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(68, 17);
            this.label9.TabIndex = 21;
            this.label9.Text = "Wholesale";
            // 
            // SP_txtbx
            // 
            this.SP_txtbx.AnimateReadOnly = false;
            this.SP_txtbx.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.SP_txtbx.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.SP_txtbx.Depth = 0;
            this.SP_txtbx.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.SP_txtbx.HideSelection = true;
            this.SP_txtbx.LeadingIcon = null;
            this.SP_txtbx.Location = new System.Drawing.Point(82, 423);
            this.SP_txtbx.MaxLength = 32767;
            this.SP_txtbx.MouseState = MaterialSkin.MouseState.OUT;
            this.SP_txtbx.Name = "SP_txtbx";
            this.SP_txtbx.PasswordChar = '\0';
            this.SP_txtbx.PrefixSuffixText = null;
            this.SP_txtbx.ReadOnly = false;
            this.SP_txtbx.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.SP_txtbx.SelectedText = "";
            this.SP_txtbx.SelectionLength = 0;
            this.SP_txtbx.SelectionStart = 0;
            this.SP_txtbx.ShortcutsEnabled = true;
            this.SP_txtbx.Size = new System.Drawing.Size(177, 48);
            this.SP_txtbx.TabIndex = 20;
            this.SP_txtbx.TabStop = false;
            this.SP_txtbx.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.SP_txtbx.TrailingIcon = null;
            this.SP_txtbx.UseSystemPasswordChar = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.label8.Location = new System.Drawing.Point(3, 433);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(78, 17);
            this.label8.TabIndex = 19;
            this.label8.Text = "Selling Price";
            // 
            // category_comboBox1
            // 
            this.category_comboBox1.AutoResize = false;
            this.category_comboBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.category_comboBox1.Depth = 0;
            this.category_comboBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.category_comboBox1.DropDownHeight = 174;
            this.category_comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.category_comboBox1.DropDownWidth = 121;
            this.category_comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.category_comboBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.category_comboBox1.FormattingEnabled = true;
            this.category_comboBox1.IntegralHeight = false;
            this.category_comboBox1.ItemHeight = 43;
            this.category_comboBox1.Location = new System.Drawing.Point(82, 145);
            this.category_comboBox1.MaxDropDownItems = 4;
            this.category_comboBox1.MouseState = MaterialSkin.MouseState.OUT;
            this.category_comboBox1.Name = "category_comboBox1";
            this.category_comboBox1.Size = new System.Drawing.Size(177, 49);
            this.category_comboBox1.StartIndex = 0;
            this.category_comboBox1.TabIndex = 18;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.label7.Location = new System.Drawing.Point(3, 158);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 17);
            this.label7.TabIndex = 17;
            this.label7.Text = "Category";
            // 
            // rate
            // 
            this.rate.AnimateReadOnly = false;
            this.rate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.rate.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.rate.Depth = 0;
            this.rate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.rate.HideSelection = true;
            this.rate.LeadingIcon = null;
            this.rate.Location = new System.Drawing.Point(82, 355);
            this.rate.MaxLength = 32767;
            this.rate.MouseState = MaterialSkin.MouseState.OUT;
            this.rate.Name = "rate";
            this.rate.PasswordChar = '\0';
            this.rate.PrefixSuffixText = null;
            this.rate.ReadOnly = false;
            this.rate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rate.SelectedText = "";
            this.rate.SelectionLength = 0;
            this.rate.SelectionStart = 0;
            this.rate.ShortcutsEnabled = true;
            this.rate.Size = new System.Drawing.Size(177, 48);
            this.rate.TabIndex = 16;
            this.rate.TabStop = false;
            this.rate.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.rate.TrailingIcon = null;
            this.rate.UseSystemPasswordChar = false;
            this.rate.Click += new System.EventHandler(this.rate_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.label6.Location = new System.Drawing.Point(3, 365);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 17);
            this.label6.TabIndex = 15;
            this.label6.Text = "Rate";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // materialButton5
            // 
            this.materialButton5.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButton5.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.materialButton5.Depth = 0;
            this.materialButton5.Enabled = false;
            this.materialButton5.HighEmphasis = true;
            this.materialButton5.Icon = ((System.Drawing.Image)(resources.GetObject("materialButton5.Icon")));
            this.materialButton5.Location = new System.Drawing.Point(955, 4);
            this.materialButton5.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButton5.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButton5.Name = "materialButton5";
            this.materialButton5.NoAccentTextColor = System.Drawing.Color.Empty;
            this.materialButton5.Size = new System.Drawing.Size(129, 36);
            this.materialButton5.TabIndex = 22;
            this.materialButton5.Text = "0 Changes";
            this.materialButton5.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButton5.UseAccentColor = false;
            this.materialButton5.UseVisualStyleBackColor = true;
            this.materialButton5.Click += new System.EventHandler(this.materialButton5_Click);
            // 
            // materialButton6
            // 
            this.materialButton6.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButton6.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.materialButton6.Depth = 0;
            this.materialButton6.Enabled = false;
            this.materialButton6.HighEmphasis = true;
            this.materialButton6.Icon = global::Abbey_Trading_Store.Properties.Resources.recovery;
            this.materialButton6.Location = new System.Drawing.Point(818, 6);
            this.materialButton6.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButton6.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButton6.Name = "materialButton6";
            this.materialButton6.NoAccentTextColor = System.Drawing.Color.Empty;
            this.materialButton6.Size = new System.Drawing.Size(107, 36);
            this.materialButton6.TabIndex = 23;
            this.materialButton6.Text = "Alt Qty";
            this.materialButton6.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButton6.UseAccentColor = false;
            this.materialButton6.UseVisualStyleBackColor = true;
            this.materialButton6.Click += new System.EventHandler(this.materialButton6_Click);
            // 
            // dataGridView1
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Nirmala UI", 9.75F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Right;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 30;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView1.Size = new System.Drawing.Size(852, 366);
            this.dataGridView1.TabIndex = 24;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick_1);
            // 
            // frmProducts
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.ClientSize = new System.Drawing.Size(1130, 572);
            this.Controls.Add(this.materialButton6);
            this.Controls.Add(this.materialButton5);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.search);
            this.Controls.Add(this.materialButton4);
            this.Controls.Add(this.materialButton3);
            this.Controls.Add(this.materialButton2);
            this.Controls.Add(this.materialButton1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmProducts";
            this.Text = "frmProducts";
            this.Load += new System.EventHandler(this.frmProducts_Load);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label5;
        private CircularProgressBar.CircularProgressBar circularProgressBar2;
        private System.Windows.Forms.Label label3;
        private CircularProgressBar.CircularProgressBar circularProgressBar1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private MaterialSkin.Controls.MaterialTextBox search;
        private MaterialSkin.Controls.MaterialButton materialButton4;
        private MaterialSkin.Controls.MaterialButton materialButton3;
        private MaterialSkin.Controls.MaterialButton materialButton2;
        private MaterialSkin.Controls.MaterialMultiLineTextBox2 description;
        private MaterialSkin.Controls.MaterialTextBox2 name;
        private MaterialSkin.Controls.MaterialTextBox2 id;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private MaterialSkin.Controls.MaterialButton materialButton1;
        private System.Windows.Forms.Panel panel1;
        private MaterialSkin.Controls.MaterialTextBox2 rate;
        private System.Windows.Forms.Label label6;
        private MaterialSkin.Controls.MaterialTextBox2 SP_txtbx;
        private System.Windows.Forms.Label label8;
        private MaterialSkin.Controls.MaterialComboBox category_comboBox1;
        private System.Windows.Forms.Label label7;
        private MaterialSkin.Controls.MaterialTextBox2 WP;
        private System.Windows.Forms.Label label9;
        private DGV dataGridView1;
        private MaterialSkin.Controls.MaterialButton materialButton5;
        private MaterialSkin.Controls.MaterialButton materialButton6;
    }
}