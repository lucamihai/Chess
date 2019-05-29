namespace ChessApplication.Common.UserControls
{
    partial class ChessboardOptionsUserControl
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
            this.radioButtonBlack = new System.Windows.Forms.RadioButton();
            this.radioButtonWhite = new System.Windows.Forms.RadioButton();
            this.labelError = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.textBoxUsername = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // radioButtonBlack
            // 
            this.radioButtonBlack.AutoSize = true;
            this.radioButtonBlack.Location = new System.Drawing.Point(474, 228);
            this.radioButtonBlack.Name = "radioButtonBlack";
            this.radioButtonBlack.Size = new System.Drawing.Size(52, 17);
            this.radioButtonBlack.TabIndex = 25;
            this.radioButtonBlack.Text = "Black";
            this.radioButtonBlack.UseVisualStyleBackColor = true;
            // 
            // radioButtonWhite
            // 
            this.radioButtonWhite.AutoSize = true;
            this.radioButtonWhite.Checked = true;
            this.radioButtonWhite.Location = new System.Drawing.Point(383, 228);
            this.radioButtonWhite.Name = "radioButtonWhite";
            this.radioButtonWhite.Size = new System.Drawing.Size(53, 17);
            this.radioButtonWhite.TabIndex = 24;
            this.radioButtonWhite.TabStop = true;
            this.radioButtonWhite.Text = "White";
            this.radioButtonWhite.UseVisualStyleBackColor = true;
            // 
            // labelError
            // 
            this.labelError.AutoSize = true;
            this.labelError.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelError.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelError.Location = new System.Drawing.Point(383, 399);
            this.labelError.Name = "labelError";
            this.labelError.Size = new System.Drawing.Size(92, 18);
            this.labelError.TabIndex = 23;
            this.labelError.Text = "Error label";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(425, 295);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 16);
            this.label2.TabIndex = 22;
            this.label2.Text = "Username";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(401, 200);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 16);
            this.label1.TabIndex = 21;
            this.label1.Text = "Choose piece color";
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(465, 339);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(75, 23);
            this.btnConfirm.TabIndex = 20;
            this.btnConfirm.Text = "Confirm";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.ConfirmEvent);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(383, 340);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 19;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.CancelEvent);
            // 
            // textBoxUsername
            // 
            this.textBoxUsername.Location = new System.Drawing.Point(383, 314);
            this.textBoxUsername.Name = "textBoxUsername";
            this.textBoxUsername.Size = new System.Drawing.Size(157, 20);
            this.textBoxUsername.TabIndex = 18;
            this.textBoxUsername.Text = "Server";
            // 
            // Options
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Controls.Add(this.radioButtonBlack);
            this.Controls.Add(this.radioButtonWhite);
            this.Controls.Add(this.labelError);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.textBoxUsername);
            this.Name = "Options";
            this.Size = new System.Drawing.Size(923, 616);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton radioButtonBlack;
        private System.Windows.Forms.RadioButton radioButtonWhite;
        private System.Windows.Forms.Label labelError;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox textBoxUsername;
    }
}
