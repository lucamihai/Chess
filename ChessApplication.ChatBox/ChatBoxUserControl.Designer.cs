namespace ChessApplication.ChatBox
{
    partial class ChatBoxUserControl
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
            this.labelChatBox = new System.Windows.Forms.Label();
            this.textBoxChat = new System.Windows.Forms.TextBox();
            this.textBoxInput = new System.Windows.Forms.TextBox();
            this.buttonSend = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelChatBox
            // 
            this.labelChatBox.AutoSize = true;
            this.labelChatBox.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelChatBox.Location = new System.Drawing.Point(17, 7);
            this.labelChatBox.Name = "labelChatBox";
            this.labelChatBox.Size = new System.Drawing.Size(65, 19);
            this.labelChatBox.TabIndex = 3;
            this.labelChatBox.Text = "SentChat";
            // 
            // textBoxChat
            // 
            this.textBoxChat.Location = new System.Drawing.Point(3, 39);
            this.textBoxChat.Multiline = true;
            this.textBoxChat.Name = "textBoxChat";
            this.textBoxChat.ReadOnly = true;
            this.textBoxChat.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxChat.Size = new System.Drawing.Size(554, 129);
            this.textBoxChat.TabIndex = 2;
            // 
            // textBoxInput
            // 
            this.textBoxInput.Location = new System.Drawing.Point(3, 174);
            this.textBoxInput.Multiline = true;
            this.textBoxInput.Name = "textBoxInput";
            this.textBoxInput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxInput.Size = new System.Drawing.Size(554, 38);
            this.textBoxInput.TabIndex = 4;
            this.textBoxInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxInputKeyDown);
            // 
            // buttonSend
            // 
            this.buttonSend.Location = new System.Drawing.Point(21, 218);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(75, 23);
            this.buttonSend.TabIndex = 5;
            this.buttonSend.Text = "Send";
            this.buttonSend.UseVisualStyleBackColor = true;
            this.buttonSend.Click += new System.EventHandler(this.Send);
            // 
            // ChatBoxUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.Controls.Add(this.buttonSend);
            this.Controls.Add(this.textBoxInput);
            this.Controls.Add(this.labelChatBox);
            this.Controls.Add(this.textBoxChat);
            this.Name = "ChatBoxUserControl";
            this.Size = new System.Drawing.Size(560, 260);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelChatBox;
        private System.Windows.Forms.TextBox textBoxChat;
        private System.Windows.Forms.TextBox textBoxInput;
        private System.Windows.Forms.Button buttonSend;
    }
}
