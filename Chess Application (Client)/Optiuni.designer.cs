namespace Chess_Application
{
    partial class Optiuni
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
            this.textBoxUsername = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.checkBoxWhite = new System.Windows.Forms.CheckBox();
            this.checkBoxBlack = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelError = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBoxUsername
            // 
            this.textBoxUsername.Location = new System.Drawing.Point(354, 369);
            this.textBoxUsername.Name = "textBoxUsername";
            this.textBoxUsername.Size = new System.Drawing.Size(157, 20);
            this.textBoxUsername.TabIndex = 0;
            this.textBoxUsername.Text = "Client";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(354, 395);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Anulare";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(436, 394);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(75, 23);
            this.btnConfirm.TabIndex = 2;
            this.btnConfirm.Text = "Confirmare";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // checkBoxWhite
            // 
            this.checkBoxWhite.AutoSize = true;
            this.checkBoxWhite.Checked = true;
            this.checkBoxWhite.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxWhite.Location = new System.Drawing.Point(354, 263);
            this.checkBoxWhite.Name = "checkBoxWhite";
            this.checkBoxWhite.Size = new System.Drawing.Size(41, 17);
            this.checkBoxWhite.TabIndex = 3;
            this.checkBoxWhite.Text = "Alb";
            this.checkBoxWhite.UseVisualStyleBackColor = true;
            this.checkBoxWhite.CheckedChanged += new System.EventHandler(this.checkBoxWhite_CheckedChanged);
            // 
            // checkBoxBlack
            // 
            this.checkBoxBlack.AutoSize = true;
            this.checkBoxBlack.Location = new System.Drawing.Point(456, 263);
            this.checkBoxBlack.Name = "checkBoxBlack";
            this.checkBoxBlack.Size = new System.Drawing.Size(55, 17);
            this.checkBoxBlack.TabIndex = 4;
            this.checkBoxBlack.Text = "Negru";
            this.checkBoxBlack.UseVisualStyleBackColor = true;
            this.checkBoxBlack.CheckedChanged += new System.EventHandler(this.checkBoxBlack_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(406, 247);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Culoarea";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(406, 353);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Username";
            // 
            // labelError
            // 
            this.labelError.AutoSize = true;
            this.labelError.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelError.Location = new System.Drawing.Point(354, 454);
            this.labelError.Name = "labelError";
            this.labelError.Size = new System.Drawing.Size(0, 18);
            this.labelError.TabIndex = 7;
            // 
            // Optiuni
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Controls.Add(this.labelError);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkBoxBlack);
            this.Controls.Add(this.checkBoxWhite);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.textBoxUsername);
            this.Name = "Optiuni";
            this.Size = new System.Drawing.Size(923, 616);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxUsername;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.CheckBox checkBoxWhite;
        private System.Windows.Forms.CheckBox checkBoxBlack;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelError;
    }
}
