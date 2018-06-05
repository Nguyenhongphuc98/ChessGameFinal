namespace GUI
{
    partial class Mode1AndMode2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Mode1AndMode2));
            this.tbmess = new System.Windows.Forms.TextBox();
            this.pnChat = new System.Windows.Forms.Panel();
            this.lvChat = new System.Windows.Forms.ListView();
            this.btnSendMessage = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reSetGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timerCheckEndGame = new System.Windows.Forms.Timer(this.components);
            this.timerProcessbarPlayer = new System.Windows.Forms.Timer(this.components);
            this.timerCheckMove = new System.Windows.Forms.Timer(this.components);
            this.proBlack = new System.Windows.Forms.ProgressBar();
            this.proWhite = new System.Windows.Forms.ProgressBar();
            this.pbPlayer2 = new System.Windows.Forms.PictureBox();
            this.pbPlayer1 = new System.Windows.Forms.PictureBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnPlay = new System.Windows.Forms.Button();
            this.btnUndo = new System.Windows.Forms.Button();
            this.pbSound = new System.Windows.Forms.PictureBox();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.btnRedo = new System.Windows.Forms.Button();
            this.pnChat.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlayer2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlayer1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSound)).BeginInit();
            this.SuspendLayout();
            // 
            // tbmess
            // 
            resources.ApplyResources(this.tbmess, "tbmess");
            this.tbmess.Name = "tbmess";
            // 
            // pnChat
            // 
            this.pnChat.Controls.Add(this.lvChat);
            this.pnChat.Controls.Add(this.btnSendMessage);
            this.pnChat.Controls.Add(this.tbmess);
            resources.ApplyResources(this.pnChat, "pnChat");
            this.pnChat.Name = "pnChat";
            // 
            // lvChat
            // 
            resources.ApplyResources(this.lvChat, "lvChat");
            this.lvChat.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lvChat.Name = "lvChat";
            this.lvChat.UseCompatibleStateImageBehavior = false;
            this.lvChat.View = System.Windows.Forms.View.List;
            // 
            // btnSendMessage
            // 
            this.btnSendMessage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            resources.ApplyResources(this.btnSendMessage, "btnSendMessage");
            this.btnSendMessage.Name = "btnSendMessage";
            this.btnSendMessage.UseVisualStyleBackColor = false;
            this.btnSendMessage.Click += new System.EventHandler(this.btnSendMessage_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem});
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Name = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoToolStripMenuItem,
            this.redoToolStripMenuItem,
            this.reSetGameToolStripMenuItem,
            this.toolStripMenuItem2,
            this.exitToolStripMenuItem});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            resources.ApplyResources(this.menuToolStripMenuItem, "menuToolStripMenuItem");
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            resources.ApplyResources(this.undoToolStripMenuItem, "undoToolStripMenuItem");
            this.undoToolStripMenuItem.Click += new System.EventHandler(this.undoToolStripMenuItem_Click);
            // 
            // redoToolStripMenuItem
            // 
            this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            resources.ApplyResources(this.redoToolStripMenuItem, "redoToolStripMenuItem");
            this.redoToolStripMenuItem.Click += new System.EventHandler(this.redoToolStripMenuItem_Click);
            // 
            // reSetGameToolStripMenuItem
            // 
            this.reSetGameToolStripMenuItem.Name = "reSetGameToolStripMenuItem";
            resources.ApplyResources(this.reSetGameToolStripMenuItem, "reSetGameToolStripMenuItem");
            this.reSetGameToolStripMenuItem.Click += new System.EventHandler(this.reSetGameToolStripMenuItem_Click_1);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            resources.ApplyResources(this.toolStripMenuItem2, "toolStripMenuItem2");
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            resources.ApplyResources(this.exitToolStripMenuItem, "exitToolStripMenuItem");
            // 
            // timerCheckEndGame
            // 
            this.timerCheckEndGame.Tick += new System.EventHandler(this.timerCheckEndGame_Tick);
            // 
            // timerProcessbarPlayer
            // 
            this.timerProcessbarPlayer.Interval = 1000;
            this.timerProcessbarPlayer.Tick += new System.EventHandler(this.timerProcessbarPlayer_Tick);
            // 
            // timerCheckMove
            // 
            this.timerCheckMove.Tick += new System.EventHandler(this.timerCheckMove_Tick);
            // 
            // proBlack
            // 
            resources.ApplyResources(this.proBlack, "proBlack");
            this.proBlack.Name = "proBlack";
            this.proBlack.Value = 100;
            // 
            // proWhite
            // 
            resources.ApplyResources(this.proWhite, "proWhite");
            this.proWhite.Name = "proWhite";
            this.proWhite.Value = 100;
            // 
            // pbPlayer2
            // 
            this.pbPlayer2.BackColor = System.Drawing.Color.Transparent;
            this.pbPlayer2.BackgroundImage = global::GUI.Properties.Resources.chess_PNG8448;
            resources.ApplyResources(this.pbPlayer2, "pbPlayer2");
            this.pbPlayer2.Name = "pbPlayer2";
            this.pbPlayer2.TabStop = false;
            // 
            // pbPlayer1
            // 
            this.pbPlayer1.BackColor = System.Drawing.Color.Transparent;
            this.pbPlayer1.BackgroundImage = global::GUI.Properties.Resources.chess_3413412_960_720;
            resources.ApplyResources(this.pbPlayer1, "pbPlayer1");
            this.pbPlayer1.Name = "pbPlayer1";
            this.pbPlayer1.TabStop = false;
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(135)))), ((int)(((byte)(128)))));
            resources.ApplyResources(this.btnReset, "btnReset");
            this.btnReset.ForeColor = System.Drawing.Color.GhostWhite;
            this.btnReset.Name = "btnReset";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(135)))), ((int)(((byte)(128)))));
            resources.ApplyResources(this.btnExit, "btnExit");
            this.btnExit.ForeColor = System.Drawing.Color.GhostWhite;
            this.btnExit.Name = "btnExit";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnPlay
            // 
            this.btnPlay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(135)))), ((int)(((byte)(7)))));
            this.btnPlay.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.btnPlay, "btnPlay");
            this.btnPlay.ForeColor = System.Drawing.Color.White;
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.UseVisualStyleBackColor = false;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // btnUndo
            // 
            this.btnUndo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(135)))), ((int)(((byte)(128)))));
            resources.ApplyResources(this.btnUndo, "btnUndo");
            this.btnUndo.ForeColor = System.Drawing.Color.GhostWhite;
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.UseVisualStyleBackColor = false;
            this.btnUndo.Click += new System.EventHandler(this.btnUndo_Click);
            // 
            // pbSound
            // 
            this.pbSound.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.pbSound, "pbSound");
            this.pbSound.Name = "pbSound";
            this.pbSound.TabStop = false;
            this.pbSound.Click += new System.EventHandler(this.pbSound_Click);
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 120;
            this.bunifuElipse1.TargetControl = this.btnPlay;
            // 
            // btnRedo
            // 
            this.btnRedo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(135)))), ((int)(((byte)(128)))));
            resources.ApplyResources(this.btnRedo, "btnRedo");
            this.btnRedo.ForeColor = System.Drawing.Color.GhostWhite;
            this.btnRedo.Name = "btnRedo";
            this.btnRedo.UseVisualStyleBackColor = false;
            this.btnRedo.Click += new System.EventHandler(this.btnRedo_Click);
            // 
            // Mode1AndMode2
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.Controls.Add(this.pbSound);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnPlay);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnRedo);
            this.Controls.Add(this.btnUndo);
            this.Controls.Add(this.proBlack);
            this.Controls.Add(this.proWhite);
            this.Controls.Add(this.pbPlayer2);
            this.Controls.Add(this.pbPlayer1);
            this.Controls.Add(this.pnChat);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Mode1AndMode2";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Mode1AndMode2_FormClosed);
            this.Load += new System.EventHandler(this.Mode1AndMode2_Load);
            this.pnChat.ResumeLayout(false);
            this.pnChat.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlayer2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlayer1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSound)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox tbmess;
        private System.Windows.Forms.Panel pnChat;
        private System.Windows.Forms.Button btnSendMessage;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reSetGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Timer timerCheckEndGame;
        private System.Windows.Forms.Timer timerProcessbarPlayer;
        private System.Windows.Forms.ListView lvChat;
        private System.Windows.Forms.Timer timerCheckMove;
        private System.Windows.Forms.ProgressBar proBlack;
        private System.Windows.Forms.ProgressBar proWhite;
        private System.Windows.Forms.PictureBox pbPlayer2;
        private System.Windows.Forms.PictureBox pbPlayer1;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Button btnUndo;
        private System.Windows.Forms.PictureBox pbSound;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.Button btnRedo;
        private System.Windows.Forms.ToolStripMenuItem redoToolStripMenuItem;
    }
}