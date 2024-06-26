namespace EN2NGui
{
    partial class Spla
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
            this.LStats = new System.Windows.Forms.Label();
            this.Ebutton = new System.Windows.Forms.Button();
            this.Cbutton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LStats
            // 
            this.LStats.AutoSize = true;
            this.LStats.BackColor = System.Drawing.Color.Transparent;
            this.LStats.Font = new System.Drawing.Font("黑体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LStats.ForeColor = System.Drawing.Color.CadetBlue;
            this.LStats.Location = new System.Drawing.Point(105, 175);
            this.LStats.Name = "LStats";
            this.LStats.Size = new System.Drawing.Size(39, 19);
            this.LStats.TabIndex = 0;
            this.LStats.Text = "NaN";
            // 
            // Ebutton
            // 
            this.Ebutton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Ebutton.BackColor = System.Drawing.Color.SeaShell;
            this.Ebutton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Ebutton.Enabled = false;
            this.Ebutton.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Ebutton.ForeColor = System.Drawing.Color.RosyBrown;
            this.Ebutton.Location = new System.Drawing.Point(652, 440);
            this.Ebutton.Margin = new System.Windows.Forms.Padding(1);
            this.Ebutton.Name = "Ebutton";
            this.Ebutton.Size = new System.Drawing.Size(120, 40);
            this.Ebutton.TabIndex = 1;
            this.Ebutton.Text = "NaN";
            this.Ebutton.UseVisualStyleBackColor = false;
            this.Ebutton.Visible = false;
            this.Ebutton.Click += new System.EventHandler(this.Ebutton_Click);
            // 
            // Cbutton
            // 
            this.Cbutton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Cbutton.BackColor = System.Drawing.Color.Beige;
            this.Cbutton.Enabled = false;
            this.Cbutton.Font = new System.Drawing.Font("等线", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Cbutton.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.Cbutton.Location = new System.Drawing.Point(331, 312);
            this.Cbutton.Name = "Cbutton";
            this.Cbutton.Size = new System.Drawing.Size(80, 35);
            this.Cbutton.TabIndex = 2;
            this.Cbutton.Text = "NaN";
            this.Cbutton.UseVisualStyleBackColor = false;
            this.Cbutton.Visible = false;
            this.Cbutton.Click += new System.EventHandler(this.Cbutton_Click);
            // 
            // Spla
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(794, 494);
            this.ControlBox = false;
            this.Controls.Add(this.Cbutton);
            this.Controls.Add(this.Ebutton);
            this.Controls.Add(this.LStats);
            this.Cursor = System.Windows.Forms.Cursors.AppStarting;
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(900, 600);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(800, 500);
            this.Name = "Spla";
            this.Opacity = 0.92D;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NaN";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Spla_FormClosing);
            this.Shown += new System.EventHandler(this.Spla_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LStats;
        private System.Windows.Forms.Button Ebutton;
        private System.Windows.Forms.Button Cbutton;
    }
}