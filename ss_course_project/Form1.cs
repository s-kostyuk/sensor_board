using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*****************************************************************************/

namespace ss_course_project
{
    public partial class Form1 : Form
    {
        /*-------------------------------------------------------------------*/

        public Form1()
        {
            InitializeComponent();
        }

        /*-------------------------------------------------------------------*/

        private void set_standart_panel_props(Panel panel, int index = 0)
        {
            panel.BackColor = System.Drawing.SystemColors.Window;
            panel.Name = string.Format("panel{0}", index);
            panel.Size = new System.Drawing.Size(144, 86);
            panel.TabIndex = index;
        }

        /*-------------------------------------------------------------------*/

        private void movePanelAddCard(int new_index)
        {
            this.panelAddCard.TabIndex = new_index;
            this.panelCards.Controls.SetChildIndex(panelAddCard, new_index);
        }

        /*-------------------------------------------------------------------*/

        private void panelAddCard_Click(object sender, EventArgs e)
        {
            int new_index = this.panelCards.Controls.Count - 1;

            Panel new_panel = new Panel();
            set_standart_panel_props(new_panel, new_index);

            this.panelCards.Controls.Add(new_panel);

            movePanelAddCard(new_index + 1);
        }

        /*-------------------------------------------------------------------*/
    }
}

/*****************************************************************************/
