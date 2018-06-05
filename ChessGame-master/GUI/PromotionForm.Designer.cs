namespace GUI
{
    partial class PromotionForm
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
            this.pbRook = new System.Windows.Forms.PictureBox();
            this.pbQueen = new System.Windows.Forms.PictureBox();
            this.pbKnight = new System.Windows.Forms.PictureBox();
            this.pbBishop = new System.Windows.Forms.PictureBox();
            this.btok = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbRook)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbQueen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbKnight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBishop)).BeginInit();
            this.SuspendLayout();
            // 
            // pbRook
            // 
            this.pbRook.BackColor = System.Drawing.Color.Lime;
            this.pbRook.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pbRook.Location = new System.Drawing.Point(12, 12);
            this.pbRook.Name = "pbRook";
            this.pbRook.Size = new System.Drawing.Size(95, 113);
            this.pbRook.TabIndex = 0;
            this.pbRook.TabStop = false;
            this.pbRook.Click += new System.EventHandler(this.pbRook_Click);
            // 
            // pbQueen
            // 
            this.pbQueen.BackColor = System.Drawing.Color.Lime;
            this.pbQueen.Location = new System.Drawing.Point(143, 12);
            this.pbQueen.Name = "pbQueen";
            this.pbQueen.Size = new System.Drawing.Size(95, 113);
            this.pbQueen.TabIndex = 1;
            this.pbQueen.TabStop = false;
            this.pbQueen.Click += new System.EventHandler(this.pbQueen_Click);
            // 
            // pbKnight
            // 
            this.pbKnight.BackColor = System.Drawing.Color.Lime;
            this.pbKnight.Location = new System.Drawing.Point(274, 12);
            this.pbKnight.Name = "pbKnight";
            this.pbKnight.Size = new System.Drawing.Size(95, 113);
            this.pbKnight.TabIndex = 2;
            this.pbKnight.TabStop = false;
            this.pbKnight.Click += new System.EventHandler(this.pbKnight_Click);
            // 
            // pbBishop
            // 
            this.pbBishop.BackColor = System.Drawing.Color.Lime;
            this.pbBishop.Location = new System.Drawing.Point(400, 12);
            this.pbBishop.Name = "pbBishop";
            this.pbBishop.Size = new System.Drawing.Size(95, 113);
            this.pbBishop.TabIndex = 3;
            this.pbBishop.TabStop = false;
            this.pbBishop.Click += new System.EventHandler(this.pbBishop_Click);
            // 
            // btok
            // 
            this.btok.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(0)))), ((int)(((byte)(229)))));
            this.btok.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btok.Location = new System.Drawing.Point(115, 140);
            this.btok.Name = "btok";
            this.btok.Size = new System.Drawing.Size(290, 26);
            this.btok.TabIndex = 4;
            this.btok.Text = "Chọn";
            this.btok.UseVisualStyleBackColor = false;
            this.btok.Click += new System.EventHandler(this.btok_Click);
            // 
            // PromotionForm
            // 
            this.AcceptButton = this.btok;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(229)))), ((int)(((byte)(252)))));
            this.ClientSize = new System.Drawing.Size(512, 178);
            this.Controls.Add(this.btok);
            this.Controls.Add(this.pbBishop);
            this.Controls.Add(this.pbKnight);
            this.Controls.Add(this.pbQueen);
            this.Controls.Add(this.pbRook);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PromotionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PromotionForm";
            ((System.ComponentModel.ISupportInitialize)(this.pbRook)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbQueen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbKnight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBishop)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbRook;
        private System.Windows.Forms.PictureBox pbQueen;
        private System.Windows.Forms.PictureBox pbKnight;
        private System.Windows.Forms.PictureBox pbBishop;
        private System.Windows.Forms.Button btok;
    }
}