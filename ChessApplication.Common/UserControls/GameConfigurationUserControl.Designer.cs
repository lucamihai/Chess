namespace ChessApplication.Common.UserControls
{
    partial class GameConfigurationUserControl
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
            this.radioButtonServer = new System.Windows.Forms.RadioButton();
            this.radioButtonClient = new System.Windows.Forms.RadioButton();
            this.radioButtonSinglePlayer = new System.Windows.Forms.RadioButton();
            this.labelSelectUserType = new System.Windows.Forms.Label();
            this.labelPlayerVsPlayer = new System.Windows.Forms.Label();
            this.labelPlayerVsComputer = new System.Windows.Forms.Label();
            this.buttonBegin = new System.Windows.Forms.Button();
            this.panelSelectUserType = new System.Windows.Forms.Panel();
            this.panelSelectChessboard = new System.Windows.Forms.Panel();
            this.labelSelectChessboard = new System.Windows.Forms.Label();
            this.radioButtonChessboardClassic = new System.Windows.Forms.RadioButton();
            this.radioButtonChessboardShatranj = new System.Windows.Forms.RadioButton();
            this.panelSelectUserType.SuspendLayout();
            this.panelSelectChessboard.SuspendLayout();
            this.SuspendLayout();
            // 
            // radioButtonServer
            // 
            this.radioButtonServer.AutoSize = true;
            this.radioButtonServer.Checked = true;
            this.radioButtonServer.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonServer.Location = new System.Drawing.Point(120, 114);
            this.radioButtonServer.Name = "radioButtonServer";
            this.radioButtonServer.Size = new System.Drawing.Size(67, 23);
            this.radioButtonServer.TabIndex = 0;
            this.radioButtonServer.TabStop = true;
            this.radioButtonServer.Text = "Server";
            this.radioButtonServer.UseVisualStyleBackColor = true;
            // 
            // radioButtonClient
            // 
            this.radioButtonClient.AutoSize = true;
            this.radioButtonClient.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonClient.Location = new System.Drawing.Point(120, 137);
            this.radioButtonClient.Name = "radioButtonClient";
            this.radioButtonClient.Size = new System.Drawing.Size(62, 23);
            this.radioButtonClient.TabIndex = 1;
            this.radioButtonClient.TabStop = true;
            this.radioButtonClient.Text = "Client";
            this.radioButtonClient.UseVisualStyleBackColor = true;
            // 
            // radioButtonSinglePlayer
            // 
            this.radioButtonSinglePlayer.AutoSize = true;
            this.radioButtonSinglePlayer.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonSinglePlayer.Location = new System.Drawing.Point(120, 203);
            this.radioButtonSinglePlayer.Name = "radioButtonSinglePlayer";
            this.radioButtonSinglePlayer.Size = new System.Drawing.Size(104, 23);
            this.radioButtonSinglePlayer.TabIndex = 2;
            this.radioButtonSinglePlayer.TabStop = true;
            this.radioButtonSinglePlayer.Text = "Single player";
            this.radioButtonSinglePlayer.UseVisualStyleBackColor = true;
            // 
            // labelSelectUserType
            // 
            this.labelSelectUserType.AutoSize = true;
            this.labelSelectUserType.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSelectUserType.Location = new System.Drawing.Point(52, 42);
            this.labelSelectUserType.Name = "labelSelectUserType";
            this.labelSelectUserType.Size = new System.Drawing.Size(149, 24);
            this.labelSelectUserType.TabIndex = 3;
            this.labelSelectUserType.Text = "Select user type";
            // 
            // labelPlayerVsPlayer
            // 
            this.labelPlayerVsPlayer.AutoSize = true;
            this.labelPlayerVsPlayer.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPlayerVsPlayer.Location = new System.Drawing.Point(88, 89);
            this.labelPlayerVsPlayer.Name = "labelPlayerVsPlayer";
            this.labelPlayerVsPlayer.Size = new System.Drawing.Size(143, 22);
            this.labelPlayerVsPlayer.TabIndex = 4;
            this.labelPlayerVsPlayer.Text = "Player vs Player";
            // 
            // labelPlayerVsComputer
            // 
            this.labelPlayerVsComputer.AutoSize = true;
            this.labelPlayerVsComputer.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPlayerVsComputer.Location = new System.Drawing.Point(88, 178);
            this.labelPlayerVsComputer.Name = "labelPlayerVsComputer";
            this.labelPlayerVsComputer.Size = new System.Drawing.Size(172, 22);
            this.labelPlayerVsComputer.TabIndex = 5;
            this.labelPlayerVsComputer.Text = "Player vs Computer";
            // 
            // buttonBegin
            // 
            this.buttonBegin.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBegin.Location = new System.Drawing.Point(378, 465);
            this.buttonBegin.Name = "buttonBegin";
            this.buttonBegin.Size = new System.Drawing.Size(88, 32);
            this.buttonBegin.TabIndex = 6;
            this.buttonBegin.Text = "Begin";
            this.buttonBegin.UseVisualStyleBackColor = true;
            this.buttonBegin.Click += new System.EventHandler(this.Begin);
            // 
            // panelSelectUserType
            // 
            this.panelSelectUserType.Controls.Add(this.labelSelectUserType);
            this.panelSelectUserType.Controls.Add(this.radioButtonServer);
            this.panelSelectUserType.Controls.Add(this.labelPlayerVsComputer);
            this.panelSelectUserType.Controls.Add(this.radioButtonClient);
            this.panelSelectUserType.Controls.Add(this.labelPlayerVsPlayer);
            this.panelSelectUserType.Controls.Add(this.radioButtonSinglePlayer);
            this.panelSelectUserType.Location = new System.Drawing.Point(91, 86);
            this.panelSelectUserType.Name = "panelSelectUserType";
            this.panelSelectUserType.Size = new System.Drawing.Size(299, 279);
            this.panelSelectUserType.TabIndex = 7;
            // 
            // panelSelectChessboard
            // 
            this.panelSelectChessboard.Controls.Add(this.labelSelectChessboard);
            this.panelSelectChessboard.Controls.Add(this.radioButtonChessboardClassic);
            this.panelSelectChessboard.Controls.Add(this.radioButtonChessboardShatranj);
            this.panelSelectChessboard.Location = new System.Drawing.Point(464, 86);
            this.panelSelectChessboard.Name = "panelSelectChessboard";
            this.panelSelectChessboard.Size = new System.Drawing.Size(299, 279);
            this.panelSelectChessboard.TabIndex = 8;
            // 
            // labelSelectChessboard
            // 
            this.labelSelectChessboard.AutoSize = true;
            this.labelSelectChessboard.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSelectChessboard.Location = new System.Drawing.Point(52, 42);
            this.labelSelectChessboard.Name = "labelSelectChessboard";
            this.labelSelectChessboard.Size = new System.Drawing.Size(168, 24);
            this.labelSelectChessboard.TabIndex = 3;
            this.labelSelectChessboard.Text = "Select chessboard";
            // 
            // radioButtonChessboardClassic
            // 
            this.radioButtonChessboardClassic.AutoSize = true;
            this.radioButtonChessboardClassic.Checked = true;
            this.radioButtonChessboardClassic.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonChessboardClassic.Location = new System.Drawing.Point(76, 80);
            this.radioButtonChessboardClassic.Name = "radioButtonChessboardClassic";
            this.radioButtonChessboardClassic.Size = new System.Drawing.Size(70, 23);
            this.radioButtonChessboardClassic.TabIndex = 0;
            this.radioButtonChessboardClassic.TabStop = true;
            this.radioButtonChessboardClassic.Text = "Classic";
            this.radioButtonChessboardClassic.UseVisualStyleBackColor = true;
            // 
            // radioButtonChessboardShatranj
            // 
            this.radioButtonChessboardShatranj.AutoSize = true;
            this.radioButtonChessboardShatranj.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonChessboardShatranj.Location = new System.Drawing.Point(76, 103);
            this.radioButtonChessboardShatranj.Name = "radioButtonChessboardShatranj";
            this.radioButtonChessboardShatranj.Size = new System.Drawing.Size(77, 23);
            this.radioButtonChessboardShatranj.TabIndex = 1;
            this.radioButtonChessboardShatranj.TabStop = true;
            this.radioButtonChessboardShatranj.Text = "Shatranj";
            this.radioButtonChessboardShatranj.UseVisualStyleBackColor = true;
            // 
            // GameConfigurationUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Controls.Add(this.panelSelectChessboard);
            this.Controls.Add(this.panelSelectUserType);
            this.Controls.Add(this.buttonBegin);
            this.Name = "GameConfigurationUserControl";
            this.Size = new System.Drawing.Size(923, 616);
            this.panelSelectUserType.ResumeLayout(false);
            this.panelSelectUserType.PerformLayout();
            this.panelSelectChessboard.ResumeLayout(false);
            this.panelSelectChessboard.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton radioButtonServer;
        private System.Windows.Forms.RadioButton radioButtonClient;
        private System.Windows.Forms.RadioButton radioButtonSinglePlayer;
        private System.Windows.Forms.Label labelSelectUserType;
        private System.Windows.Forms.Label labelPlayerVsPlayer;
        private System.Windows.Forms.Label labelPlayerVsComputer;
        private System.Windows.Forms.Button buttonBegin;
        private System.Windows.Forms.Panel panelSelectUserType;
        private System.Windows.Forms.Panel panelSelectChessboard;
        private System.Windows.Forms.Label labelSelectChessboard;
        private System.Windows.Forms.RadioButton radioButtonChessboardClassic;
        private System.Windows.Forms.RadioButton radioButtonChessboardShatranj;
    }
}
