using System.Diagnostics.CodeAnalysis;
using ChessApplication.GUI.UserControls.Chat;
using ChessApplication.GUI.UserControls.History;
using ChessApplication.GUI.UserControls.Notifications;

namespace ChessApplication.GUI.Forms
{
    public partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        [ExcludeFromCodeCoverage]
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.newGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newGameToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.quitApplicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemHighlightAvailableMoves = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemEnableHighlightAvailableMoves = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemDisableHighlightAvailableMoves = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemSound = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemEnableSound = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemDisableSound = new System.Windows.Forms.ToolStripMenuItem();
            this.panelChessboard = new System.Windows.Forms.Panel();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.notifications = new ChessApplication.GUI.UserControls.Notifications.NotificationsUserControl();
            this.chatBox = new ChessApplication.GUI.UserControls.Chat.ChatBoxUserControl();
            this.historyEntries = new ChessApplication.GUI.UserControls.History.HistoryUserControl();
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
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1184, 24);
            this.menuStrip1.TabIndex = 5;
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
            this.toolStripMenuItemHighlightAvailableMoves,
            this.toolStripMenuItemSound});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // toolStripMenuItemHighlightAvailableMoves
            // 
            this.toolStripMenuItemHighlightAvailableMoves.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemEnableHighlightAvailableMoves,
            this.toolStripMenuItemDisableHighlightAvailableMoves});
            this.toolStripMenuItemHighlightAvailableMoves.Name = "toolStripMenuItemHighlightAvailableMoves";
            this.toolStripMenuItemHighlightAvailableMoves.Size = new System.Drawing.Size(211, 22);
            this.toolStripMenuItemHighlightAvailableMoves.Text = "Highlight available moves";
            // 
            // toolStripMenuItemEnableHighlightAvailableMoves
            // 
            this.toolStripMenuItemEnableHighlightAvailableMoves.Name = "toolStripMenuItemEnableHighlightAvailableMoves";
            this.toolStripMenuItemEnableHighlightAvailableMoves.Size = new System.Drawing.Size(112, 22);
            this.toolStripMenuItemEnableHighlightAvailableMoves.Text = "Enable";
            this.toolStripMenuItemEnableHighlightAvailableMoves.Click += new System.EventHandler(this.ToolStripEnableHighlightAvailableMoves);
            // 
            // toolStripMenuItemDisableHighlightAvailableMoves
            // 
            this.toolStripMenuItemDisableHighlightAvailableMoves.Name = "toolStripMenuItemDisableHighlightAvailableMoves";
            this.toolStripMenuItemDisableHighlightAvailableMoves.Size = new System.Drawing.Size(112, 22);
            this.toolStripMenuItemDisableHighlightAvailableMoves.Text = "Disable";
            this.toolStripMenuItemDisableHighlightAvailableMoves.Click += new System.EventHandler(this.ToolStripDisableHighlightAvailableMoves);
            // 
            // toolStripMenuItemSound
            // 
            this.toolStripMenuItemSound.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemEnableSound,
            this.toolStripMenuItemDisableSound});
            this.toolStripMenuItemSound.Name = "toolStripMenuItemSound";
            this.toolStripMenuItemSound.Size = new System.Drawing.Size(211, 22);
            this.toolStripMenuItemSound.Text = "Sound";
            // 
            // toolStripMenuItemEnableSound
            // 
            this.toolStripMenuItemEnableSound.Name = "toolStripMenuItemEnableSound";
            this.toolStripMenuItemEnableSound.Size = new System.Drawing.Size(112, 22);
            this.toolStripMenuItemEnableSound.Text = "Enable";
            this.toolStripMenuItemEnableSound.Click += new System.EventHandler(this.ToolStripEnableSound);
            // 
            // toolStripMenuItemDisableSound
            // 
            this.toolStripMenuItemDisableSound.Name = "toolStripMenuItemDisableSound";
            this.toolStripMenuItemDisableSound.Size = new System.Drawing.Size(112, 22);
            this.toolStripMenuItemDisableSound.Text = "Disable";
            this.toolStripMenuItemDisableSound.Click += new System.EventHandler(this.ToolStripDisableSound);
            // 
            // panelChessboard
            // 
            this.panelChessboard.Location = new System.Drawing.Point(25, 37);
            this.panelChessboard.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panelChessboard.Name = "panelChessboard";
            this.panelChessboard.Size = new System.Drawing.Size(595, 800);
            this.panelChessboard.TabIndex = 7;
            // 
            // menuStrip2
            // 
            this.menuStrip2.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip2.Location = new System.Drawing.Point(56, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuStrip2.Size = new System.Drawing.Size(202, 24);
            this.menuStrip2.TabIndex = 6;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // notifications
            // 
            this.notifications.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.notifications.Location = new System.Drawing.Point(830, 37);
            this.notifications.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.notifications.Name = "notifications";
            this.notifications.Size = new System.Drawing.Size(350, 175);
            this.notifications.TabIndex = 9;
            // 
            // chatBox
            // 
            this.chatBox.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.chatBox.Location = new System.Drawing.Point(624, 361);
            this.chatBox.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.chatBox.Name = "chatBox";
            this.chatBox.OnSentChat = null;
            this.chatBox.Size = new System.Drawing.Size(560, 260);
            this.chatBox.TabIndex = 10;
            this.chatBox.Username = "Undefined PlayerUsername";
            // 
            // historyEntries
            // 
            this.historyEntries.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.historyEntries.Location = new System.Drawing.Point(626, 37);
            this.historyEntries.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.historyEntries.Name = "historyEntries";
            this.historyEntries.Size = new System.Drawing.Size(200, 300);
            this.historyEntries.TabIndex = 11;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CadetBlue;
            this.ClientSize = new System.Drawing.Size(1184, 836);
            this.Controls.Add(this.historyEntries);
            this.Controls.Add(this.chatBox);
            this.Controls.Add(this.notifications);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.panelChessboard);
            this.Controls.Add(this.menuStrip2);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "MainForm";
            this.Text = "Chess application";
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
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemHighlightAvailableMoves;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemEnableHighlightAvailableMoves;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemDisableHighlightAvailableMoves;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemSound;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemEnableSound;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemDisableSound;
        private System.Windows.Forms.Panel panelChessboard;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private NotificationsUserControl notifications;
        private ChatBoxUserControl chatBox;
        private HistoryUserControl historyEntries;
    }
}

