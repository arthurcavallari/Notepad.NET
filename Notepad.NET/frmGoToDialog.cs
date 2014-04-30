using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Notepad.NET
{
    public partial class frmGoToDialog : Form
    {
        public int goToLine = 1;
        public frmGoToDialog()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnGoTo_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            goToLine = Convert.ToInt32(txtGoToLine.Text);
            this.Close();
        }

        private void txtGoToLine_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                e.Handled = true;
                btnGoTo_Click(sender, e);
            }
            else if (!(Char.IsDigit(e.KeyChar) || e.KeyChar == '\b'))
            {
                e.Handled = true;
                System.Media.SystemSounds.Beep.Play();
            }
        }

        private void txtGoToLine_Validating(object sender, CancelEventArgs e)
        {
            
        }
    }
}
