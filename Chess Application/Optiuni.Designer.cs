namespace Chess_Application.Clase
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
            this.checkBoxAlb = new System.Windows.Forms.CheckBox();
            this.checkBoxNegru = new System.Windows.Forms.CheckBox();
            this.textBoxUsername = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // checkBoxAlb
            // 
            this.checkBoxAlb.AutoSize = true;
            this.checkBoxAlb.Location = new System.Drawing.Point(362, 236);
            this.checkBoxAlb.Name = "checkBoxAlb";
            this.checkBoxAlb.Size = new System.Drawing.Size(41, 17);
            this.checkBoxAlb.TabIndex = 0;
            this.checkBoxAlb.Text = "Alb";
            this.checkBoxAlb.UseVisualStyleBackColor = true;
            this.checkBoxAlb.CheckedChanged += new System.EventHandler(this.checkBoxAlb_CheckedChanged);
            // 
            // checkBoxNegru
            // 
            this.checkBoxNegru.AutoSize = true;
            this.checkBoxNegru.Location = new System.Drawing.Point(409, 236);
            this.checkBoxNegru.Name = "checkBoxNegru";
            this.checkBoxNegru.Size = new System.Drawing.Size(55, 17);
            this.checkBoxNegru.TabIndex = 1;
            this.checkBoxNegru.Text = "Negru";
            this.checkBoxNegru.UseVisualStyleBackColor = true;
            this.checkBoxNegru.CheckedChanged += new System.EventHandler(this.checkBoxNegru_CheckedChanged);
            // 
            // textBoxUsername
            // 
            this.textBoxUsername.Location = new System.Drawing.Point(362, 175);
            this.textBoxUsername.Name = "textBoxUsername";
            this.textBoxUsername.Size = new System.Drawing.Size(100, 20);
            this.textBoxUsername.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(367, 156);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Alege username";
            // 
            // Optiuni
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxUsername);
            this.Controls.Add(this.checkBoxNegru);
            this.Controls.Add(this.checkBoxAlb);
            this.Name = "Optiuni";
            this.Size = new System.Drawing.Size(955, 617);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBoxAlb;
        private System.Windows.Forms.CheckBox checkBoxNegru;
        private System.Windows.Forms.TextBox textBoxUsername;
        private System.Windows.Forms.Label label1;
    }
}
