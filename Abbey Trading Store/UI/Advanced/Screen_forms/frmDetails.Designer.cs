﻿namespace Abbey_Trading_Store.UI.Advanced.Screen_forms
{
    partial class frmDetails
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
            this.materialButton2 = new MaterialSkin.Controls.MaterialButton();
            this.dgv_TD = new System.Windows.Forms.DataGridView();
            this.lbltop = new System.Windows.Forms.Label();
            this.lbl2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_TD)).BeginInit();
            this.SuspendLayout();
            // 
            // materialButton2
            // 
            this.materialButton2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButton2.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.materialButton2.Depth = 0;
            this.materialButton2.HighEmphasis = true;
            this.materialButton2.Icon = global::Abbey_Trading_Store.Properties.Resources.print;
            this.materialButton2.Location = new System.Drawing.Point(665, 15);
            this.materialButton2.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButton2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButton2.Name = "materialButton2";
            this.materialButton2.NoAccentTextColor = System.Drawing.Color.Empty;
            this.materialButton2.Size = new System.Drawing.Size(91, 36);
            this.materialButton2.TabIndex = 17;
            this.materialButton2.Text = "Print";
            this.materialButton2.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButton2.UseAccentColor = false;
            this.materialButton2.UseVisualStyleBackColor = true;
            // 
            // dgv_TD
            // 
            this.dgv_TD.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.dgv_TD.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv_TD.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgv_TD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_TD.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_TD.EnableHeadersVisualStyles = false;
            this.dgv_TD.Location = new System.Drawing.Point(12, 64);
            this.dgv_TD.Name = "dgv_TD";
            this.dgv_TD.RowHeadersVisible = false;
            this.dgv_TD.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgv_TD.Size = new System.Drawing.Size(758, 275);
            this.dgv_TD.TabIndex = 20;
            // 
            // lbltop
            // 
            this.lbltop.AutoSize = true;
            this.lbltop.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltop.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.lbltop.Location = new System.Drawing.Point(271, 24);
            this.lbltop.Name = "lbltop";
            this.lbltop.Size = new System.Drawing.Size(45, 17);
            this.lbltop.TabIndex = 21;
            this.lbltop.Text = "label1";
            this.lbltop.Click += new System.EventHandler(this.label1_Click);
            // 
            // lbl2
            // 
            this.lbl2.AutoSize = true;
            this.lbl2.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.lbl2.Location = new System.Drawing.Point(443, 24);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(45, 17);
            this.lbl2.TabIndex = 22;
            this.lbl2.Text = "label1";
            // 
            // frmDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.ClientSize = new System.Drawing.Size(783, 351);
            this.Controls.Add(this.lbl2);
            this.Controls.Add(this.lbltop);
            this.Controls.Add(this.dgv_TD);
            this.Controls.Add(this.materialButton2);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "frmDetails";
            this.Text = "frmDetails";
            this.Load += new System.EventHandler(this.frmDetails_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_TD)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialButton materialButton2;
        private System.Windows.Forms.DataGridView dgv_TD;
        private System.Windows.Forms.Label lbltop;
        private System.Windows.Forms.Label lbl2;
    }
}