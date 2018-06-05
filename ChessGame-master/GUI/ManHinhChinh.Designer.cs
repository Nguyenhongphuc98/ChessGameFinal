namespace GUI
{
    partial class ManHinhChinh
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
            this.components = new System.ComponentModel.Container();
            this.btPlay = new Bunifu.Framework.UI.BunifuTileButton();
            this.btabout = new Bunifu.Framework.UI.BunifuTileButton();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.btexit = new Bunifu.Framework.UI.BunifuTileButton();
            this.bunifuElipse2 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.bunifuElipse3 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.bunifuElipse4 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.SuspendLayout();
            // 
            // btPlay
            // 
            this.btPlay.BackColor = System.Drawing.Color.SeaGreen;
            this.btPlay.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btPlay.color = System.Drawing.Color.SeaGreen;
            this.btPlay.colorActive = System.Drawing.Color.MediumSeaGreen;
            this.btPlay.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btPlay.Font = new System.Drawing.Font("Century Gothic", 20F, System.Drawing.FontStyle.Bold);
            this.btPlay.ForeColor = System.Drawing.Color.White;
            this.btPlay.Image = null;
            this.btPlay.ImagePosition = 27;
            this.btPlay.ImageZoom = 50;
            this.btPlay.LabelPosition = 55;
            this.btPlay.LabelText = "Start";
            this.btPlay.Location = new System.Drawing.Point(423, 170);
            this.btPlay.Margin = new System.Windows.Forms.Padding(6);
            this.btPlay.Name = "btPlay";
            this.btPlay.Size = new System.Drawing.Size(235, 72);
            this.btPlay.TabIndex = 0;
            this.btPlay.Click += new System.EventHandler(this.btPlay_Click);
            // 
            // btabout
            // 
            this.btabout.BackColor = System.Drawing.Color.SeaGreen;
            this.btabout.color = System.Drawing.Color.SeaGreen;
            this.btabout.colorActive = System.Drawing.Color.MediumSeaGreen;
            this.btabout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btabout.Font = new System.Drawing.Font("Century Gothic", 20F, System.Drawing.FontStyle.Bold);
            this.btabout.ForeColor = System.Drawing.Color.White;
            this.btabout.Image = null;
            this.btabout.ImagePosition = 27;
            this.btabout.ImageZoom = 50;
            this.btabout.LabelPosition = 54;
            this.btabout.LabelText = "About";
            this.btabout.Location = new System.Drawing.Point(423, 276);
            this.btabout.Margin = new System.Windows.Forms.Padding(6);
            this.btabout.Name = "btabout";
            this.btabout.Size = new System.Drawing.Size(235, 74);
            this.btabout.TabIndex = 1;
            this.btabout.Click += new System.EventHandler(this.btabout_Click);
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 20;
            this.bunifuElipse1.TargetControl = this;
            // 
            // btexit
            // 
            this.btexit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(103)))), ((int)(((byte)(146)))));
            this.btexit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btexit.color = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(103)))), ((int)(((byte)(146)))));
            this.btexit.colorActive = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(103)))), ((int)(((byte)(146)))));
            this.btexit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btexit.Font = new System.Drawing.Font("Century Gothic", 20F, System.Drawing.FontStyle.Bold);
            this.btexit.ForeColor = System.Drawing.Color.White;
            this.btexit.Image = null;
            this.btexit.ImagePosition = 27;
            this.btexit.ImageZoom = 50;
            this.btexit.LabelPosition = 54;
            this.btexit.LabelText = "Exit";
            this.btexit.Location = new System.Drawing.Point(423, 382);
            this.btexit.Margin = new System.Windows.Forms.Padding(6);
            this.btexit.Name = "btexit";
            this.btexit.Size = new System.Drawing.Size(235, 74);
            this.btexit.TabIndex = 2;
            this.btexit.Click += new System.EventHandler(this.btexit_Click);
            // 
            // bunifuElipse2
            // 
            this.bunifuElipse2.ElipseRadius = 115;
            this.bunifuElipse2.TargetControl = this.btPlay;
            // 
            // bunifuElipse3
            // 
            this.bunifuElipse3.ElipseRadius = 115;
            this.bunifuElipse3.TargetControl = this.btexit;
            // 
            // bunifuElipse4
            // 
            this.bunifuElipse4.ElipseRadius = 115;
            this.bunifuElipse4.TargetControl = this.btabout;
            // 
            // ManHinhChinh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::GUI.Properties.Resources.thumb_1920_460230;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1067, 600);
            this.Controls.Add(this.btexit);
            this.Controls.Add(this.btabout);
            this.Controls.Add(this.btPlay);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ManHinhChinh";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ManHinhChinh";
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuTileButton btPlay;
        private Bunifu.Framework.UI.BunifuTileButton btabout;
        private Bunifu.Framework.UI.BunifuTileButton btexit;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse2;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse3;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse4;
    }
}