using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ss_course_project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void panel8_DoubleClick(object sender, EventArgs e)
        {
            var new_size = this.panel1.Size;

            new_size.Width = new_size.Width * 3;
            new_size.Height = new_size.Height * 2;

            this.panel1.Size = new_size;
        }
    }
}
