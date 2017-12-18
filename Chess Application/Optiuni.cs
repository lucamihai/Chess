using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess_Application
{
    
    public partial class Optiuni : UserControl
    {
        public System.Delegate _SchimbareUsername;
        public Delegate apeleaza
        {
            set { _SchimbareUsername = value; }
        }
        public Optiuni()
        {
            InitializeComponent();
            //this.Hide();
        }

        private void checkBoxWhite_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxWhite.Checked == true && checkBoxBlack.Checked == true) checkBoxBlack.Checked = false;
        }

        private void checkBoxBlack_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxWhite.Checked == true && checkBoxBlack.Checked == true) checkBoxWhite.Checked = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (textBoxUsername.Text != null && !textBoxUsername.Text.EndsWith(" "))
            {
                Form1._username = textBoxUsername.Text;
                //object[] obj = new object[1];
                //obj[0] = textBoxUsername.Text as object;
                //_SchimbareUsername.DynamicInvoke(obj);
                //MethodInvoker m = new MethodInvoker(() => Form1.serverForm.textBox1.Text += (usernameClient + ": " + dateServer + Environment.NewLine));
                labelError.Text = "";
                this.Hide();
            }
            else labelError.Text = "Format username inacceptabil";
            if (checkBoxWhite.Checked == true)
            {
                Form1._culoriUseri = "1 2";
            }
            else Form1._culoriUseri = "2 1";
        }
    }
}
