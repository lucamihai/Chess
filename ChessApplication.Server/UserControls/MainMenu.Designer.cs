namespace ChessApplication.Server.UserControls
{
    partial class MainMenu
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnExitApp = new System.Windows.Forms.Button();
            this.btnOptionsMenu = new System.Windows.Forms.Button();
            this.btnStartGame = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnExitApp
            // 
            this.btnExitApp.Location = new System.Drawing.Point(444, 342);
            this.btnExitApp.Name = "btnExitApp";
            this.btnExitApp.Size = new System.Drawing.Size(215, 40);
            this.btnExitApp.TabIndex = 8;
            this.btnExitApp.Text = "Exit";
            this.btnExitApp.UseVisualStyleBackColor = true;
            this.btnExitApp.Click += new System.EventHandler(this.Exit);
            // 
            // btnOptionsMenu
            // 
            this.btnOptionsMenu.Location = new System.Drawing.Point(444, 283);
            this.btnOptionsMenu.Name = "btnOptionsMenu";
            this.btnOptionsMenu.Size = new System.Drawing.Size(215, 40);
            this.btnOptionsMenu.TabIndex = 7;
            this.btnOptionsMenu.Text = "Options";
            this.btnOptionsMenu.UseVisualStyleBackColor = true;
            this.btnOptionsMenu.Click += new System.EventHandler(this.OptionsMenu);
            // 
            // btnStartGame
            // 
            this.btnStartGame.Location = new System.Drawing.Point(444, 226);
            this.btnStartGame.Name = "btnStartGame";
            this.btnStartGame.Size = new System.Drawing.Size(215, 40);
            this.btnStartGame.TabIndex = 6;
            this.btnStartGame.Text = "Start game";
            this.btnStartGame.UseVisualStyleBackColor = true;
            this.btnStartGame.Click += new System.EventHandler(this.StartGame);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.btnExitApp);
            this.Controls.Add(this.btnOptionsMenu);
            this.Controls.Add(this.btnStartGame);
            this.Name = "MainMenu";
            this.Size = new System.Drawing.Size(1103, 608);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnExitApp;
        private System.Windows.Forms.Button btnOptionsMenu;
        private System.Windows.Forms.Button btnStartGame;
    }
}
