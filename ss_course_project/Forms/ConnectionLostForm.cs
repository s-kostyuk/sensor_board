using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ss_course_project.gui.Forms
{
    public partial class ConnectionLostForm : Form
    {
        public ConnectionLostForm()
        {
            InitializeComponent();
        }

        private void buttonTryAgain_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Retry;
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Abort;
        }
    }
}
