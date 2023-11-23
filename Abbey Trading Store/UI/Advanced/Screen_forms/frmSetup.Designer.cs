namespace Abbey_Trading_Store.UI.Advanced.Screen_forms
{
    partial class frmSetup
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
            this.Username = new System.Windows.Forms.Label();
            this.box_1 = new MaterialSkin.Controls.MaterialCheckbox();
            this.box_2 = new MaterialSkin.Controls.MaterialCheckbox();
            this.start_btn = new MaterialSkin.Controls.MaterialButton();
            this.P_b_1 = new MaterialSkin.Controls.MaterialProgressBar();
            this.P_b_2 = new MaterialSkin.Controls.MaterialProgressBar();
            this.label_1 = new System.Windows.Forms.Label();
            this.Dat_action = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.server = new MaterialSkin.Controls.MaterialCheckbox();
            this.client = new MaterialSkin.Controls.MaterialCheckbox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.Machines = new Abbey_Trading_Store.DAL.DAL_Properties.DGV();
            this.selected_server = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Dat_action)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Machines)).BeginInit();
            this.SuspendLayout();
            // 
            // Username
            // 
            this.Username.AutoSize = true;
            this.Username.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Username.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.Username.Location = new System.Drawing.Point(226, 20);
            this.Username.Name = "Username";
            this.Username.Size = new System.Drawing.Size(325, 24);
            this.Username.TabIndex = 5;
            this.Username.Text = "ENVIRONMENT SETUP FOR IMS";
            this.Username.Click += new System.EventHandler(this.Username_Click);
            // 
            // box_1
            // 
            this.box_1.AutoSize = true;
            this.box_1.Depth = 0;
            this.box_1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(161)))), ((int)(((byte)(179)))));
            this.box_1.Location = new System.Drawing.Point(94, 379);
            this.box_1.Margin = new System.Windows.Forms.Padding(0);
            this.box_1.MouseLocation = new System.Drawing.Point(-1, -1);
            this.box_1.MouseState = MaterialSkin.MouseState.HOVER;
            this.box_1.Name = "box_1";
            this.box_1.ReadOnly = false;
            this.box_1.Ripple = true;
            this.box_1.Size = new System.Drawing.Size(244, 37);
            this.box_1.TabIndex = 6;
            this.box_1.Text = "Downloaded Database Server";
            this.box_1.UseVisualStyleBackColor = true;
            // 
            // box_2
            // 
            this.box_2.AutoSize = true;
            this.box_2.Depth = 0;
            this.box_2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(161)))), ((int)(((byte)(179)))));
            this.box_2.Location = new System.Drawing.Point(94, 440);
            this.box_2.Margin = new System.Windows.Forms.Padding(0);
            this.box_2.MouseLocation = new System.Drawing.Point(-1, -1);
            this.box_2.MouseState = MaterialSkin.MouseState.HOVER;
            this.box_2.Name = "box_2";
            this.box_2.ReadOnly = false;
            this.box_2.Ripple = true;
            this.box_2.Size = new System.Drawing.Size(215, 37);
            this.box_2.TabIndex = 7;
            this.box_2.Text = "Installed Database Server";
            this.box_2.UseVisualStyleBackColor = true;
            // 
            // start_btn
            // 
            this.start_btn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.start_btn.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.start_btn.Depth = 0;
            this.start_btn.HighEmphasis = true;
            this.start_btn.Icon = null;
            this.start_btn.Location = new System.Drawing.Point(671, 507);
            this.start_btn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.start_btn.MouseState = MaterialSkin.MouseState.HOVER;
            this.start_btn.Name = "start_btn";
            this.start_btn.NoAccentTextColor = System.Drawing.Color.Empty;
            this.start_btn.Size = new System.Drawing.Size(115, 36);
            this.start_btn.TabIndex = 10;
            this.start_btn.Text = "Start Setup";
            this.start_btn.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.start_btn.UseAccentColor = false;
            this.start_btn.UseVisualStyleBackColor = true;
            this.start_btn.Click += new System.EventHandler(this.start_btn_Click);
            // 
            // P_b_1
            // 
            this.P_b_1.Depth = 0;
            this.P_b_1.Location = new System.Drawing.Point(355, 399);
            this.P_b_1.MouseState = MaterialSkin.MouseState.HOVER;
            this.P_b_1.Name = "P_b_1";
            this.P_b_1.Size = new System.Drawing.Size(197, 5);
            this.P_b_1.TabIndex = 11;
            // 
            // P_b_2
            // 
            this.P_b_2.Depth = 0;
            this.P_b_2.Location = new System.Drawing.Point(355, 458);
            this.P_b_2.MouseState = MaterialSkin.MouseState.HOVER;
            this.P_b_2.Name = "P_b_2";
            this.P_b_2.Size = new System.Drawing.Size(197, 5);
            this.P_b_2.TabIndex = 12;
            // 
            // label_1
            // 
            this.label_1.AutoSize = true;
            this.label_1.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.label_1.Location = new System.Drawing.Point(562, 390);
            this.label_1.Name = "label_1";
            this.label_1.Size = new System.Drawing.Size(69, 17);
            this.label_1.TabIndex = 15;
            this.label_1.Text = "Progress...";
            // 
            // Dat_action
            // 
            this.Dat_action.Image = global::Abbey_Trading_Store.Properties.Resources.Copy_of_Untitled_Design;
            this.Dat_action.Location = new System.Drawing.Point(558, 440);
            this.Dat_action.Name = "Dat_action";
            this.Dat_action.Size = new System.Drawing.Size(132, 37);
            this.Dat_action.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Dat_action.TabIndex = 16;
            this.Dat_action.TabStop = false;
            this.Dat_action.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(46, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 18);
            this.label1.TabIndex = 17;
            this.label1.Text = "Installation Type";
            // 
            // server
            // 
            this.server.AutoSize = true;
            this.server.Depth = 0;
            this.server.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(161)))), ((int)(((byte)(179)))));
            this.server.Location = new System.Drawing.Point(94, 96);
            this.server.Margin = new System.Windows.Forms.Padding(0);
            this.server.MouseLocation = new System.Drawing.Point(-1, -1);
            this.server.MouseState = MaterialSkin.MouseState.HOVER;
            this.server.Name = "server";
            this.server.ReadOnly = false;
            this.server.Ripple = true;
            this.server.Size = new System.Drawing.Size(162, 37);
            this.server.TabIndex = 18;
            this.server.Text = "Server Installation";
            this.server.UseVisualStyleBackColor = true;
            this.server.CheckedChanged += new System.EventHandler(this.server_CheckedChanged);
            // 
            // client
            // 
            this.client.AutoSize = true;
            this.client.Depth = 0;
            this.client.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(161)))), ((int)(((byte)(179)))));
            this.client.Location = new System.Drawing.Point(454, 96);
            this.client.Margin = new System.Windows.Forms.Padding(0);
            this.client.MouseLocation = new System.Drawing.Point(-1, -1);
            this.client.MouseState = MaterialSkin.MouseState.HOVER;
            this.client.Name = "client";
            this.client.ReadOnly = false;
            this.client.Ripple = true;
            this.client.Size = new System.Drawing.Size(158, 37);
            this.client.TabIndex = 19;
            this.client.Text = "Client Installation";
            this.client.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(46, 147);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(186, 18);
            this.label2.TabIndex = 20;
            this.label2.Text = "Other Network Installations";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.Machines);
            this.panel1.Location = new System.Drawing.Point(49, 179);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(686, 166);
            this.panel1.TabIndex = 21;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(47, 348);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(142, 18);
            this.label3.TabIndex = 22;
            this.label3.Text = "Installation Progress";
            // 
            // Machines
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            this.Machines.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.Machines.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.Machines.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.Machines.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Machines.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.Machines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Machines.DefaultCellStyle = dataGridViewCellStyle2;
            this.Machines.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Machines.EnableHeadersVisualStyles = false;
            this.Machines.Location = new System.Drawing.Point(0, 0);
            this.Machines.Name = "Machines";
            this.Machines.RowHeadersVisible = false;
            this.Machines.RowTemplate.Height = 30;
            this.Machines.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.Machines.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.Machines.Size = new System.Drawing.Size(686, 166);
            this.Machines.TabIndex = 28;
            this.Machines.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Machines_CellContentDoubleClick);
            // 
            // selected_server
            // 
            this.selected_server.AutoSize = true;
            this.selected_server.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selected_server.ForeColor = System.Drawing.Color.White;
            this.selected_server.Location = new System.Drawing.Point(528, 155);
            this.selected_server.Name = "selected_server";
            this.selected_server.Size = new System.Drawing.Size(0, 15);
            this.selected_server.TabIndex = 23;
            // 
            // frmSetup
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.ClientSize = new System.Drawing.Size(799, 558);
            this.Controls.Add(this.selected_server);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.client);
            this.Controls.Add(this.server);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Dat_action);
            this.Controls.Add(this.label_1);
            this.Controls.Add(this.P_b_2);
            this.Controls.Add(this.P_b_1);
            this.Controls.Add(this.start_btn);
            this.Controls.Add(this.box_2);
            this.Controls.Add(this.box_1);
            this.Controls.Add(this.Username);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmSetup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmSetup";
            this.Activated += new System.EventHandler(this.frmSetup_Activated);
            this.Load += new System.EventHandler(this.frmSetup_Load);
            this.Shown += new System.EventHandler(this.frmSetup_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.Dat_action)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Machines)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Username;
        public MaterialSkin.Controls.MaterialCheckbox box_1;
        public MaterialSkin.Controls.MaterialCheckbox box_2;
        public MaterialSkin.Controls.MaterialButton start_btn;
        private MaterialSkin.Controls.MaterialProgressBar P_b_1;
        private MaterialSkin.Controls.MaterialProgressBar P_b_2;
        private System.Windows.Forms.Label label_1;
        private System.Windows.Forms.PictureBox Dat_action;
        private System.Windows.Forms.Label label1;
        public MaterialSkin.Controls.MaterialCheckbox server;
        public MaterialSkin.Controls.MaterialCheckbox client;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private DAL.DAL_Properties.DGV Machines;
        private System.Windows.Forms.Label selected_server;
    }
}