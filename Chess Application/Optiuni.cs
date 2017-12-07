using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess_Application.Clase
{
    public partial class Optiuni : UserControl
    {
        public Optiuni()
        {
            InitializeComponent();
        }

        private void checkBoxAlb_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBoxAlb.Checked==true && checkBoxNegru.Checked == true)
            {
                checkBoxNegru.Checked = false;
            }
        }

        private void checkBoxNegru_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxAlb.Checked == true && checkBoxNegru.Checked == true)
            {
                checkBoxAlb.Checked = false;
            }
        }
    }
}
