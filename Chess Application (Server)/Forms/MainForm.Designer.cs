﻿namespace Chess_Application.Forms
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
            this.panelChessboard = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
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
            // panelChessboard
            // 
            this.panelChessboard.Location = new System.Drawing.Point(25, 36);
            this.panelChessboard.Name = "panelChessboard";
            this.panelChessboard.Size = new System.Drawing.Size(955, 800);
            this.panelChessboard.TabIndex = 4;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CadetBlue;
            this.ClientSize = new System.Drawing.Size(1184, 836);
            this.Controls.Add(this.panelChessboard);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.menuStrip2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Sah";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem newGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newGameToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem quitApplicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem modIncepatorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemEnableBeginnersMode;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemDisableBeginnersMode;
        private System.Windows.Forms.ToolStripMenuItem sunetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemEnableSound;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemDisableSound;
        private System.Windows.Forms.Panel panelChessboard;
    }
}

