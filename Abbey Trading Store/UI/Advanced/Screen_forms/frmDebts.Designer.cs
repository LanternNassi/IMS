namespace Abbey_Trading_Store.UI.Advanced.Screen_forms
{
    partial class frmDebts
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.materialButton2 = new MaterialSkin.Controls.MaterialButton();
            this.PaidAmount = new MaterialSkin.Controls.MaterialTextBox2();
            this.id = new MaterialSkin.Controls.MaterialTextBox2();
            this.CustomerName = new MaterialSkin.Controls.MaterialTextBox2();
            this.RemainAmount = new MaterialSkin.Controls.MaterialTextBox2();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.materialButton1 = new MaterialSkin.Controls.MaterialButton();
            this.materialButton4 = new MaterialSkin.Controls.MaterialButton();
            this.label10 = new System.Windows.Forms.Label();
            this.circularProgressBar2 = new CircularProgressBar.CircularProgressBar();
            this.label11 = new System.Windows.Forms.Label();
            this.circularProgressBar1 = new CircularProgressBar.CircularProgressBar();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.DebtsDGV = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.TRACKDGV = new System.Windows.Forms.DataGridView();
            this.searchtxtbx = new MaterialSkin.Controls.MaterialTextBox();
            this.materialButton3 = new MaterialSkin.Controls.MaterialButton();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DebtsDGV)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TRACKDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.materialButton2);
            this.panel1.Controls.Add(this.PaidAmount);
            this.panel1.Controls.Add(this.id);
            this.panel1.Controls.Add(this.CustomerName);
            this.panel1.Controls.Add(this.RemainAmount);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(262, 572);
            this.panel1.TabIndex = 24;
            // 
            // materialButton2
            // 
            this.materialButton2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButton2.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.materialButton2.Depth = 0;
            this.materialButton2.HighEmphasis = true;
            this.materialButton2.Icon = global::Abbey_Trading_Store.Properties.Resources.print;
            this.materialButton2.Location = new System.Drawing.Point(82, 492);
            this.materialButton2.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButton2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButton2.Name = "materialButton2";
            this.materialButton2.NoAccentTextColor = System.Drawing.Color.Empty;
            this.materialButton2.Size = new System.Drawing.Size(78, 36);
            this.materialButton2.TabIndex = 25;
            this.materialButton2.Text = "Add";
            this.materialButton2.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButton2.UseAccentColor = false;
            this.materialButton2.UseVisualStyleBackColor = true;
            this.materialButton2.Click += new System.EventHandler(this.materialButton2_Click);
            // 
            // PaidAmount
            // 
            this.PaidAmount.AnimateReadOnly = false;
            this.PaidAmount.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.PaidAmount.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.PaidAmount.Depth = 0;
            this.PaidAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.PaidAmount.HideSelection = true;
            this.PaidAmount.LeadingIcon = null;
            this.PaidAmount.Location = new System.Drawing.Point(82, 406);
            this.PaidAmount.MaxLength = 32767;
            this.PaidAmount.MouseState = MaterialSkin.MouseState.OUT;
            this.PaidAmount.Name = "PaidAmount";
            this.PaidAmount.PasswordChar = '\0';
            this.PaidAmount.PrefixSuffixText = null;
            this.PaidAmount.ReadOnly = false;
            this.PaidAmount.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.PaidAmount.SelectedText = "";
            this.PaidAmount.SelectionLength = 0;
            this.PaidAmount.SelectionStart = 0;
            this.PaidAmount.ShortcutsEnabled = true;
            this.PaidAmount.Size = new System.Drawing.Size(177, 48);
            this.PaidAmount.TabIndex = 24;
            this.PaidAmount.TabStop = false;
            this.PaidAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.PaidAmount.TrailingIcon = null;
            this.PaidAmount.UseSystemPasswordChar = false;
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
            this.id.Location = new System.Drawing.Point(82, 72);
            this.id.MaxLength = 32767;
            this.id.MouseState = MaterialSkin.MouseState.OUT;
            this.id.Name = "id";
            this.id.PasswordChar = '\0';
            this.id.PrefixSuffixText = null;
            this.id.ReadOnly = false;
            this.id.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.id.SelectedText = "";
            this.id.SelectionLength = 0;
            this.id.SelectionStart = 0;
            this.id.ShortcutsEnabled = true;
            this.id.Size = new System.Drawing.Size(177, 48);
            this.id.TabIndex = 23;
            this.id.TabStop = false;
            this.id.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.id.TrailingIcon = null;
            this.id.UseSystemPasswordChar = false;
            // 
            // CustomerName
            // 
            this.CustomerName.AnimateReadOnly = false;
            this.CustomerName.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.CustomerName.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.CustomerName.Depth = 0;
            this.CustomerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.CustomerName.HideSelection = true;
            this.CustomerName.LeadingIcon = null;
            this.CustomerName.Location = new System.Drawing.Point(82, 172);
            this.CustomerName.MaxLength = 32767;
            this.CustomerName.MouseState = MaterialSkin.MouseState.OUT;
            this.CustomerName.Name = "CustomerName";
            this.CustomerName.PasswordChar = '\0';
            this.CustomerName.PrefixSuffixText = null;
            this.CustomerName.ReadOnly = false;
            this.CustomerName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CustomerName.SelectedText = "";
            this.CustomerName.SelectionLength = 0;
            this.CustomerName.SelectionStart = 0;
            this.CustomerName.ShortcutsEnabled = true;
            this.CustomerName.Size = new System.Drawing.Size(177, 48);
            this.CustomerName.TabIndex = 22;
            this.CustomerName.TabStop = false;
            this.CustomerName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.CustomerName.TrailingIcon = null;
            this.CustomerName.UseSystemPasswordChar = false;
            // 
            // RemainAmount
            // 
            this.RemainAmount.AnimateReadOnly = false;
            this.RemainAmount.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.RemainAmount.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.RemainAmount.Depth = 0;
            this.RemainAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.RemainAmount.HideSelection = true;
            this.RemainAmount.LeadingIcon = null;
            this.RemainAmount.Location = new System.Drawing.Point(82, 279);
            this.RemainAmount.MaxLength = 32767;
            this.RemainAmount.MouseState = MaterialSkin.MouseState.OUT;
            this.RemainAmount.Name = "RemainAmount";
            this.RemainAmount.PasswordChar = '\0';
            this.RemainAmount.PrefixSuffixText = null;
            this.RemainAmount.ReadOnly = false;
            this.RemainAmount.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.RemainAmount.SelectedText = "";
            this.RemainAmount.SelectionLength = 0;
            this.RemainAmount.SelectionStart = 0;
            this.RemainAmount.ShortcutsEnabled = true;
            this.RemainAmount.Size = new System.Drawing.Size(177, 48);
            this.RemainAmount.TabIndex = 20;
            this.RemainAmount.TabStop = false;
            this.RemainAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.RemainAmount.TrailingIcon = null;
            this.RemainAmount.UseSystemPasswordChar = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.label8.Location = new System.Drawing.Point(3, 406);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(82, 17);
            this.label8.TabIndex = 19;
            this.label8.Text = "Paid Amount";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.label7.Location = new System.Drawing.Point(6, 82);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(19, 17);
            this.label7.TabIndex = 17;
            this.label7.Text = "id";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.label6.Location = new System.Drawing.Point(3, 293);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 17);
            this.label6.TabIndex = 15;
            this.label6.Text = "Rem Amount";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.label2.Location = new System.Drawing.Point(5, 181);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Customer";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.materialButton1);
            this.panel4.Controls.Add(this.materialButton4);
            this.panel4.Controls.Add(this.label10);
            this.panel4.Controls.Add(this.circularProgressBar2);
            this.panel4.Controls.Add(this.label11);
            this.panel4.Controls.Add(this.circularProgressBar1);
            this.panel4.Location = new System.Drawing.Point(300, 11);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(552, 109);
            this.panel4.TabIndex = 30;
            // 
            // materialButton1
            // 
            this.materialButton1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButton1.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.materialButton1.Depth = 0;
            this.materialButton1.HighEmphasis = true;
            this.materialButton1.Icon = global::Abbey_Trading_Store.Properties.Resources.settings;
            this.materialButton1.Location = new System.Drawing.Point(16, 62);
            this.materialButton1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButton1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButton1.Name = "materialButton1";
            this.materialButton1.NoAccentTextColor = System.Drawing.Color.Empty;
            this.materialButton1.Size = new System.Drawing.Size(185, 36);
            this.materialButton1.TabIndex = 36;
            this.materialButton1.Text = "GENERATE Details";
            this.materialButton1.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButton1.UseAccentColor = false;
            this.materialButton1.UseVisualStyleBackColor = true;
            // 
            // materialButton4
            // 
            this.materialButton4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButton4.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.materialButton4.Depth = 0;
            this.materialButton4.HighEmphasis = true;
            this.materialButton4.Icon = global::Abbey_Trading_Store.Properties.Resources.settings;
            this.materialButton4.Location = new System.Drawing.Point(16, 6);
            this.materialButton4.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButton4.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButton4.Name = "materialButton4";
            this.materialButton4.NoAccentTextColor = System.Drawing.Color.Empty;
            this.materialButton4.Size = new System.Drawing.Size(191, 36);
            this.materialButton4.TabIndex = 35;
            this.materialButton4.Text = "GENERATE Debtors";
            this.materialButton4.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButton4.UseAccentColor = false;
            this.materialButton4.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(468, 93);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(75, 15);
            this.label10.TabIndex = 22;
            this.label10.Text = "search count";
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
            this.circularProgressBar2.Location = new System.Drawing.Point(457, 6);
            this.circularProgressBar2.MarqueeAnimationSpeed = 2000;
            this.circularProgressBar2.Name = "circularProgressBar2";
            this.circularProgressBar2.OuterColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.circularProgressBar2.OuterMargin = -25;
            this.circularProgressBar2.OuterWidth = 26;
            this.circularProgressBar2.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.circularProgressBar2.ProgressWidth = 10;
            this.circularProgressBar2.SecondaryFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.circularProgressBar2.Size = new System.Drawing.Size(86, 84);
            this.circularProgressBar2.StartAngle = 270;
            this.circularProgressBar2.SubscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.circularProgressBar2.SubscriptMargin = new System.Windows.Forms.Padding(10, -35, 0, 0);
            this.circularProgressBar2.SubscriptText = "";
            this.circularProgressBar2.SuperscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.circularProgressBar2.SuperscriptMargin = new System.Windows.Forms.Padding(10, 35, 0, 0);
            this.circularProgressBar2.SuperscriptText = "";
            this.circularProgressBar2.TabIndex = 21;
            this.circularProgressBar2.Text = "30%";
            this.circularProgressBar2.TextMargin = new System.Windows.Forms.Padding(4, 4, 0, 0);
            this.circularProgressBar2.Value = 68;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(254, 93);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(38, 15);
            this.label11.TabIndex = 20;
            this.label11.Text = "count";
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
            this.circularProgressBar1.Location = new System.Drawing.Point(230, 3);
            this.circularProgressBar1.MarqueeAnimationSpeed = 2000;
            this.circularProgressBar1.Name = "circularProgressBar1";
            this.circularProgressBar1.OuterColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.circularProgressBar1.OuterMargin = -25;
            this.circularProgressBar1.OuterWidth = 26;
            this.circularProgressBar1.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.circularProgressBar1.ProgressWidth = 10;
            this.circularProgressBar1.SecondaryFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.circularProgressBar1.Size = new System.Drawing.Size(84, 87);
            this.circularProgressBar1.StartAngle = 270;
            this.circularProgressBar1.SubscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.circularProgressBar1.SubscriptMargin = new System.Windows.Forms.Padding(10, -35, 0, 0);
            this.circularProgressBar1.SubscriptText = "";
            this.circularProgressBar1.SuperscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.circularProgressBar1.SuperscriptMargin = new System.Windows.Forms.Padding(10, 35, 0, 0);
            this.circularProgressBar1.SuperscriptText = "";
            this.circularProgressBar1.TabIndex = 19;
            this.circularProgressBar1.Text = "30%";
            this.circularProgressBar1.TextMargin = new System.Windows.Forms.Padding(4, 4, 0, 0);
            this.circularProgressBar1.Value = 68;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.label3.Location = new System.Drawing.Point(13, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 17);
            this.label3.TabIndex = 16;
            this.label3.Text = "Debtors";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.label5.Location = new System.Drawing.Point(313, 399);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 17);
            this.label5.TabIndex = 31;
            this.label5.Text = "Details";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.DebtsDGV);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Font = new System.Drawing.Font("Nirmala UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(300, 129);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(818, 240);
            this.panel2.TabIndex = 28;
            // 
            // DebtsDGV
            // 
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            this.DebtsDGV.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.DebtsDGV.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.DebtsDGV.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DebtsDGV.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.DebtsDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Nirmala UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DebtsDGV.DefaultCellStyle = dataGridViewCellStyle6;
            this.DebtsDGV.EnableHeadersVisualStyles = false;
            this.DebtsDGV.Location = new System.Drawing.Point(0, 20);
            this.DebtsDGV.Name = "DebtsDGV";
            this.DebtsDGV.RowHeadersVisible = false;
            this.DebtsDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.DebtsDGV.Size = new System.Drawing.Size(815, 217);
            this.DebtsDGV.TabIndex = 24;
            this.DebtsDGV.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DebtsDGV_CellClick_1);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.TRACKDGV);
            this.panel3.Font = new System.Drawing.Font("Nirmala UI", 9.75F);
            this.panel3.Location = new System.Drawing.Point(300, 399);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(805, 173);
            this.panel3.TabIndex = 29;
            // 
            // TRACKDGV
            // 
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.White;
            this.TRACKDGV.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            this.TRACKDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.TRACKDGV.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.TRACKDGV.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TRACKDGV.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.TRACKDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Nirmala UI", 9.75F);
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.TRACKDGV.DefaultCellStyle = dataGridViewCellStyle8;
            this.TRACKDGV.EnableHeadersVisualStyles = false;
            this.TRACKDGV.Location = new System.Drawing.Point(3, 22);
            this.TRACKDGV.Name = "TRACKDGV";
            this.TRACKDGV.RowHeadersVisible = false;
            this.TRACKDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.TRACKDGV.Size = new System.Drawing.Size(799, 151);
            this.TRACKDGV.TabIndex = 24;
            // 
            // searchtxtbx
            // 
            this.searchtxtbx.AnimateReadOnly = false;
            this.searchtxtbx.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.searchtxtbx.Depth = 0;
            this.searchtxtbx.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.searchtxtbx.LeadingIcon = global::Abbey_Trading_Store.Properties.Resources.search__1_;
            this.searchtxtbx.Location = new System.Drawing.Point(858, 11);
            this.searchtxtbx.MaxLength = 50;
            this.searchtxtbx.MouseState = MaterialSkin.MouseState.OUT;
            this.searchtxtbx.Multiline = false;
            this.searchtxtbx.Name = "searchtxtbx";
            this.searchtxtbx.Size = new System.Drawing.Size(272, 50);
            this.searchtxtbx.TabIndex = 32;
            this.searchtxtbx.Text = "";
            this.searchtxtbx.TrailingIcon = null;
            // 
            // materialButton3
            // 
            this.materialButton3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButton3.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.materialButton3.Depth = 0;
            this.materialButton3.HighEmphasis = true;
            this.materialButton3.Icon = global::Abbey_Trading_Store.Properties.Resources.print;
            this.materialButton3.Location = new System.Drawing.Point(915, 73);
            this.materialButton3.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButton3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButton3.Name = "materialButton3";
            this.materialButton3.NoAccentTextColor = System.Drawing.Color.Empty;
            this.materialButton3.Size = new System.Drawing.Size(152, 36);
            this.materialButton3.TabIndex = 33;
            this.materialButton3.Text = "Print Invoice";
            this.materialButton3.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButton3.UseAccentColor = false;
            this.materialButton3.UseVisualStyleBackColor = true;
            this.materialButton3.Click += new System.EventHandler(this.materialButton3_Click);
            // 
            // frmDebts
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.ClientSize = new System.Drawing.Size(1130, 572);
            this.Controls.Add(this.materialButton3);
            this.Controls.Add(this.searchtxtbx);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmDebts";
            this.Text = "frmDebts";
            this.Load += new System.EventHandler(this.frmDebts_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DebtsDGV)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TRACKDGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private MaterialSkin.Controls.MaterialTextBox2 PaidAmount;
        private MaterialSkin.Controls.MaterialTextBox2 id;
        private MaterialSkin.Controls.MaterialTextBox2 CustomerName;
        private MaterialSkin.Controls.MaterialTextBox2 RemainAmount;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label10;
        private CircularProgressBar.CircularProgressBar circularProgressBar2;
        private System.Windows.Forms.Label label11;
        private CircularProgressBar.CircularProgressBar circularProgressBar1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private MaterialSkin.Controls.MaterialButton materialButton1;
        private MaterialSkin.Controls.MaterialButton materialButton4;
        private MaterialSkin.Controls.MaterialButton materialButton2;
        private MaterialSkin.Controls.MaterialTextBox searchtxtbx;
        private MaterialSkin.Controls.MaterialButton materialButton3;
        private System.Windows.Forms.DataGridView DebtsDGV;
        private System.Windows.Forms.DataGridView TRACKDGV;
    }
}