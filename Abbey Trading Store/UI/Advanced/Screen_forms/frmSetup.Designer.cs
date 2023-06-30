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
            this.Username = new System.Windows.Forms.Label();
            this.box_1 = new MaterialSkin.Controls.MaterialCheckbox();
            this.box_2 = new MaterialSkin.Controls.MaterialCheckbox();
            this.box_3 = new MaterialSkin.Controls.MaterialCheckbox();
            this.box_4 = new MaterialSkin.Controls.MaterialCheckbox();
            this.start_btn = new MaterialSkin.Controls.MaterialButton();
            this.SuspendLayout();
            // 
            // Username
            // 
            this.Username.AutoSize = true;
            this.Username.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Username.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.Username.Location = new System.Drawing.Point(148, 22);
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
            this.box_1.Location = new System.Drawing.Point(28, 76);
            this.box_1.Margin = new System.Windows.Forms.Padding(0);
            this.box_1.MouseLocation = new System.Drawing.Point(-1, -1);
            this.box_1.MouseState = MaterialSkin.MouseState.HOVER;
            this.box_1.Name = "box_1";
            this.box_1.ReadOnly = true;
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
            this.box_2.Location = new System.Drawing.Point(28, 137);
            this.box_2.Margin = new System.Windows.Forms.Padding(0);
            this.box_2.MouseLocation = new System.Drawing.Point(-1, -1);
            this.box_2.MouseState = MaterialSkin.MouseState.HOVER;
            this.box_2.Name = "box_2";
            this.box_2.ReadOnly = true;
            this.box_2.Ripple = true;
            this.box_2.Size = new System.Drawing.Size(215, 37);
            this.box_2.TabIndex = 7;
            this.box_2.Text = "Installed Database Server";
            this.box_2.UseVisualStyleBackColor = true;
            // 
            // box_3
            // 
            this.box_3.AutoSize = true;
            this.box_3.Depth = 0;
            this.box_3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(161)))), ((int)(((byte)(179)))));
            this.box_3.Location = new System.Drawing.Point(28, 194);
            this.box_3.Margin = new System.Windows.Forms.Padding(0);
            this.box_3.MouseLocation = new System.Drawing.Point(-1, -1);
            this.box_3.MouseState = MaterialSkin.MouseState.HOVER;
            this.box_3.Name = "box_3";
            this.box_3.ReadOnly = true;
            this.box_3.Ripple = true;
            this.box_3.Size = new System.Drawing.Size(245, 37);
            this.box_3.TabIndex = 8;
            this.box_3.Text = "Created databases and tables";
            this.box_3.UseVisualStyleBackColor = true;
            // 
            // box_4
            // 
            this.box_4.AutoSize = true;
            this.box_4.Depth = 0;
            this.box_4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(161)))), ((int)(((byte)(179)))));
            this.box_4.Location = new System.Drawing.Point(28, 244);
            this.box_4.Margin = new System.Windows.Forms.Padding(0);
            this.box_4.MouseLocation = new System.Drawing.Point(-1, -1);
            this.box_4.MouseState = MaterialSkin.MouseState.HOVER;
            this.box_4.Name = "box_4";
            this.box_4.ReadOnly = true;
            this.box_4.Ripple = true;
            this.box_4.Size = new System.Drawing.Size(102, 37);
            this.box_4.TabIndex = 9;
            this.box_4.Text = "Complete";
            this.box_4.UseVisualStyleBackColor = true;
            // 
            // start_btn
            // 
            this.start_btn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.start_btn.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.start_btn.Depth = 0;
            this.start_btn.HighEmphasis = true;
            this.start_btn.Icon = null;
            this.start_btn.Location = new System.Drawing.Point(471, 292);
            this.start_btn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.start_btn.MouseState = MaterialSkin.MouseState.HOVER;
            this.start_btn.Name = "start_btn";
            this.start_btn.NoAccentTextColor = System.Drawing.Color.Empty;
            this.start_btn.Size = new System.Drawing.Size(158, 36);
            this.start_btn.TabIndex = 10;
            this.start_btn.Text = "Start Setup";
            this.start_btn.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.start_btn.UseAccentColor = false;
            this.start_btn.UseVisualStyleBackColor = true;
            this.start_btn.Click += new System.EventHandler(this.start_btn_Click);
            // 
            // frmSetup
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.ClientSize = new System.Drawing.Size(642, 343);
            this.Controls.Add(this.start_btn);
            this.Controls.Add(this.box_4);
            this.Controls.Add(this.box_3);
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
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Username;
        public MaterialSkin.Controls.MaterialCheckbox box_1;
        public MaterialSkin.Controls.MaterialCheckbox box_2;
        public MaterialSkin.Controls.MaterialCheckbox box_3;
        public MaterialSkin.Controls.MaterialCheckbox box_4;
        public MaterialSkin.Controls.MaterialButton start_btn;
    }
}