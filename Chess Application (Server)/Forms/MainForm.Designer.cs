namespace Chess_Application.Forms
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.panelChessBoard = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.newGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newGameToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.quitApplicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modIncepatorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemEnableBeginnersMode = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemDisableBeginnersMode = new System.Windows.Forms.ToolStripMenuItem();
            this.sunetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemEnableSound = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemDisableSound = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tbServerDate = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.labelTurn = new System.Windows.Forms.Label();
            this.panelCapturedWhitePieces = new System.Windows.Forms.Panel();
            this.panelCapturedBlackPieces = new System.Windows.Forms.Panel();
            this.historyEntries = new Chess_Application.Common.UserControls.History();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelChessBoard
            // 
            this.panelChessBoard.Location = new System.Drawing.Point(236, 173);
            this.panelChessBoard.Name = "panelChessBoard";
            this.panelChessBoard.Size = new System.Drawing.Size(525, 512);
            this.panelChessBoard.TabIndex = 1;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newGameToolStripMenuItem,
            this.optionsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1184, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // newGameToolStripMenuItem
            // 
            this.newGameToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newGameToolStripMenuItem1,
            this.quitApplicationToolStripMenuItem});
            this.newGameToolStripMenuItem.Name = "newGameToolStripMenuItem";
            this.newGameToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.newGameToolStripMenuItem.Text = "File";
            // 
            // newGameToolStripMenuItem1
            // 
            this.newGameToolStripMenuItem1.Name = "newGameToolStripMenuItem1";
            this.newGameToolStripMenuItem1.Size = new System.Drawing.Size(159, 22);
            this.newGameToolStripMenuItem1.Text = "New game";
            this.newGameToolStripMenuItem1.Click += new System.EventHandler(this.ToolStripNewGame);
            // 
            // quitApplicationToolStripMenuItem
            // 
            this.quitApplicationToolStripMenuItem.Name = "quitApplicationToolStripMenuItem";
            this.quitApplicationToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.quitApplicationToolStripMenuItem.Text = "Quit application";
            this.quitApplicationToolStripMenuItem.Click += new System.EventHandler(this.ToolStripQuit);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.modIncepatorToolStripMenuItem,
            this.sunetToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // modIncepatorToolStripMenuItem
            // 
            this.modIncepatorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemEnableBeginnersMode,
            this.toolStripMenuItemDisableBeginnersMode});
            this.modIncepatorToolStripMenuItem.Name = "modIncepatorToolStripMenuItem";
            this.modIncepatorToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.modIncepatorToolStripMenuItem.Text = "Mod incepator";
            // 
            // toolStripMenuItemEnableBeginnersMode
            // 
            this.toolStripMenuItemEnableBeginnersMode.Name = "toolStripMenuItemEnableBeginnersMode";
            this.toolStripMenuItemEnableBeginnersMode.Size = new System.Drawing.Size(149, 22);
            this.toolStripMenuItemEnableBeginnersMode.Text = "Activeaza-l";
            this.toolStripMenuItemEnableBeginnersMode.Click += new System.EventHandler(this.ToolStripEnableBeginnerMode);
            // 
            // toolStripMenuItemDisableBeginnersMode
            // 
            this.toolStripMenuItemDisableBeginnersMode.Name = "toolStripMenuItemDisableBeginnersMode";
            this.toolStripMenuItemDisableBeginnersMode.Size = new System.Drawing.Size(149, 22);
            this.toolStripMenuItemDisableBeginnersMode.Text = "Dezactiveaza-l";
            this.toolStripMenuItemDisableBeginnersMode.Click += new System.EventHandler(this.ToolStripDisableBeginnerMode);
            // 
            // sunetToolStripMenuItem
            // 
            this.sunetToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemEnableSound,
            this.toolStripMenuItemDisableSound});
            this.sunetToolStripMenuItem.Name = "sunetToolStripMenuItem";
            this.sunetToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.sunetToolStripMenuItem.Text = "Sunet";
            // 
            // toolStripMenuItemEnableSound
            // 
            this.toolStripMenuItemEnableSound.Name = "toolStripMenuItemEnableSound";
            this.toolStripMenuItemEnableSound.Size = new System.Drawing.Size(149, 22);
            this.toolStripMenuItemEnableSound.Text = "Activeaza-l";
            this.toolStripMenuItemEnableSound.Click += new System.EventHandler(this.ToolStripEnableSound);
            // 
            // toolStripMenuItemDisableSound
            // 
            this.toolStripMenuItemDisableSound.Name = "toolStripMenuItemDisableSound";
            this.toolStripMenuItemDisableSound.Size = new System.Drawing.Size(149, 22);
            this.toolStripMenuItemDisableSound.Text = "Dezactiveaza-l";
            this.toolStripMenuItemDisableSound.Click += new System.EventHandler(this.ToolStripDisableSound);
            // 
            // menuStrip2
            // 
            this.menuStrip2.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip2.Location = new System.Drawing.Point(48, -1);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(202, 24);
            this.menuStrip2.TabIndex = 3;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 20F);
            this.label1.Location = new System.Drawing.Point(18, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 31);
            this.label1.TabIndex = 5;
            this.label1.Text = "H";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 20F);
            this.label2.Location = new System.Drawing.Point(18, 466);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 31);
            this.label2.TabIndex = 6;
            this.label2.Text = "A";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 20F);
            this.label3.Location = new System.Drawing.Point(18, 402);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 31);
            this.label3.TabIndex = 7;
            this.label3.Text = "B";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 20F);
            this.label4.Location = new System.Drawing.Point(18, 338);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 31);
            this.label4.TabIndex = 8;
            this.label4.Text = "C";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 20F);
            this.label5.Location = new System.Drawing.Point(18, 274);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 31);
            this.label5.TabIndex = 9;
            this.label5.Text = "D";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 20F);
            this.label6.Location = new System.Drawing.Point(18, 210);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 31);
            this.label6.TabIndex = 10;
            this.label6.Text = "E";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 20F);
            this.label7.Location = new System.Drawing.Point(18, 146);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 31);
            this.label7.TabIndex = 11;
            this.label7.Text = "F";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 20F);
            this.label8.Location = new System.Drawing.Point(18, 82);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(33, 31);
            this.label8.TabIndex = 12;
            this.label8.Text = "G";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Location = new System.Drawing.Point(176, 173);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(54, 512);
            this.panel1.TabIndex = 13;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label16);
            this.panel3.Controls.Add(this.label15);
            this.panel3.Controls.Add(this.label14);
            this.panel3.Controls.Add(this.label13);
            this.panel3.Controls.Add(this.label12);
            this.panel3.Controls.Add(this.label11);
            this.panel3.Controls.Add(this.label10);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Location = new System.Drawing.Point(236, 691);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(512, 35);
            this.panel3.TabIndex = 14;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Times New Roman", 20F);
            this.label16.Location = new System.Drawing.Point(82, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(28, 31);
            this.label16.TabIndex = 18;
            this.label16.Text = "2";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Times New Roman", 20F);
            this.label15.Location = new System.Drawing.Point(210, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(28, 31);
            this.label15.TabIndex = 17;
            this.label15.Text = "4";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Times New Roman", 20F);
            this.label14.Location = new System.Drawing.Point(146, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(28, 31);
            this.label14.TabIndex = 16;
            this.label14.Text = "3";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Times New Roman", 20F);
            this.label13.Location = new System.Drawing.Point(466, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(28, 31);
            this.label13.TabIndex = 15;
            this.label13.Text = "8";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Times New Roman", 20F);
            this.label12.Location = new System.Drawing.Point(402, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(28, 31);
            this.label12.TabIndex = 14;
            this.label12.Text = "7";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Times New Roman", 20F);
            this.label11.Location = new System.Drawing.Point(338, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(28, 31);
            this.label11.TabIndex = 13;
            this.label11.Text = "6";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Times New Roman", 20F);
            this.label10.Location = new System.Drawing.Point(274, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(28, 31);
            this.label10.TabIndex = 12;
            this.label10.Text = "5";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Times New Roman", 20F);
            this.label9.Location = new System.Drawing.Point(18, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(28, 31);
            this.label9.TabIndex = 11;
            this.label9.Text = "1";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(812, 460);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(259, 156);
            this.textBox1.TabIndex = 21;
            // 
            // tbServerDate
            // 
            this.tbServerDate.Location = new System.Drawing.Point(812, 622);
            this.tbServerDate.Name = "tbServerDate";
            this.tbServerDate.Size = new System.Drawing.Size(259, 20);
            this.tbServerDate.TabIndex = 22;
            this.tbServerDate.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.tbServerDate_PreviewKeyDown);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(881, 652);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 23;
            this.button1.Text = "Trimite";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.SendChatMessage);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(449, 62);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(66, 13);
            this.label17.TabIndex = 31;
            this.label17.Text = "Spoils o\' war";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(460, 728);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(66, 13);
            this.label18.TabIndex = 48;
            this.label18.Text = "Spoils o\' war";
            // 
            // labelTurn
            // 
            this.labelTurn.AutoSize = true;
            this.labelTurn.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.labelTurn.Location = new System.Drawing.Point(864, 383);
            this.labelTurn.Name = "labelTurn";
            this.labelTurn.Size = new System.Drawing.Size(131, 19);
            this.labelTurn.TabIndex = 49;
            this.labelTurn.Text = "Randul pieselor albe";
            // 
            // panelCapturedWhitePieces
            // 
            this.panelCapturedWhitePieces.Location = new System.Drawing.Point(324, 79);
            this.panelCapturedWhitePieces.Name = "panelCapturedWhitePieces";
            this.panelCapturedWhitePieces.Size = new System.Drawing.Size(320, 88);
            this.panelCapturedWhitePieces.TabIndex = 51;
            // 
            // panelCapturedBlackPieces
            // 
            this.panelCapturedBlackPieces.Location = new System.Drawing.Point(324, 744);
            this.panelCapturedBlackPieces.Name = "panelCapturedBlackPieces";
            this.panelCapturedBlackPieces.Size = new System.Drawing.Size(320, 88);
            this.panelCapturedBlackPieces.TabIndex = 52;
            // 
            // historyEntries
            // 
            this.historyEntries.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.historyEntries.Location = new System.Drawing.Point(812, 79);
            this.historyEntries.Name = "historyEntries";
            this.historyEntries.Size = new System.Drawing.Size(200, 300);
            this.historyEntries.TabIndex = 53;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CadetBlue;
            this.ClientSize = new System.Drawing.Size(1184, 836);
            this.Controls.Add(this.historyEntries);
            this.Controls.Add(this.panelCapturedBlackPieces);
            this.Controls.Add(this.panelCapturedWhitePieces);
            this.Controls.Add(this.labelTurn);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tbServerDate);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panelChessBoard);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.menuStrip2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Sah";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panelChessBoard;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem newGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newGameToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem quitApplicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ToolStripMenuItem modIncepatorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemEnableBeginnersMode;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemDisableBeginnersMode;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox tbServerDate;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripMenuItem sunetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemEnableSound;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemDisableSound;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        public System.Windows.Forms.Label labelTurn;
        private System.Windows.Forms.Panel panelCapturedWhitePieces;
        private System.Windows.Forms.Panel panelCapturedBlackPieces;
        private Common.UserControls.History historyEntries;
    }
}

