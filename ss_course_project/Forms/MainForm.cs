using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ss_course_project.services.Repositories;

/*****************************************************************************/

namespace ss_course_project.gui.Forms
{
    public partial class MainForm : Form
    {
        /*-------------------------------------------------------------------*/

        const int card_padding = 3;
        const int standart_card_height = 86;
        const int standart_card_width = 144;
        static Size standart_card_size = new Size(standart_card_width, standart_card_height);
        static Size large_card_size = get_size_of_card(3, 2);

        /*-------------------------------------------------------------------*/

        public MainForm()
        {
            InitializeComponent();
        }

        /*-------------------------------------------------------------------*/

        private static Size get_size_of_card(int width_in_cards, int height_in_cards)
        {
            const int sum_padding = card_padding * 2;

            return new Size(
                  standart_card_width  * width_in_cards  + sum_padding * (width_in_cards  - 1)
                , standart_card_height * height_in_cards + sum_padding * (height_in_cards - 1)
            );
        }

        /*-------------------------------------------------------------------*/

        private void fill_standart_panel(Panel panel, string cardName = "Card Name")
        {
            Label labelValue = new System.Windows.Forms.Label();
            Label labelCardName = new System.Windows.Forms.Label();

            // 
            // labelCardName
            // 
            labelCardName.Anchor = ((AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            labelCardName.Location = new System.Drawing.Point(53, 73);
            labelCardName.Name = "labelCardName";
            labelCardName.Size = new System.Drawing.Size(88, 13);
            labelCardName.TabIndex = 1;
            labelCardName.Text = "Card Name";
            labelCardName.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // labelValue
            // 
            labelValue.BackColor = System.Drawing.Color.Transparent;
            labelValue.Dock = System.Windows.Forms.DockStyle.Fill;
            labelValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            labelValue.Location = new System.Drawing.Point(0, 0);
            labelValue.Name = "labelValue";
            labelValue.Size = new System.Drawing.Size(144, 86);
            labelValue.TabIndex = 0;
            labelValue.Text = "Null";
            labelValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            panel.Controls.Add(labelCardName);
            panel.Controls.Add(labelValue);
        }

        /*-------------------------------------------------------------------*/

        private void set_base_panel_props(Panel panel, int index = 0)
        {
            panel.BackColor = System.Drawing.SystemColors.Window;
            panel.Name = string.Format("panel{0}", index);
            panel.TabIndex = index;
        }

        /*-------------------------------------------------------------------*/

        private void set_big_panel_props(Panel panel, int index = 0)
        {
            set_base_panel_props(panel, index);
            panel.Size = large_card_size;
        }

        /*-------------------------------------------------------------------*/

        private void set_standart_panel_props(Panel panel, int index = 0)
        {
            set_base_panel_props(panel, index);
            panel.Size = standart_card_size;
        }

        /*-------------------------------------------------------------------*/

        private Panel get_standart_panel(int index = 0)
        {
            Panel new_panel = new Panel();
            set_standart_panel_props(new_panel, index);
            fill_standart_panel(new_panel);
            
            return new_panel;
        }

        /*-------------------------------------------------------------------*/

        private void movePanelAddCard(int new_index)
        {
            this.panelAddCard.TabIndex = new_index;
            this.panelCards.Controls.SetChildIndex(panelAddCard, new_index);
        }

        /*-------------------------------------------------------------------*/

        private void moveToLastPanelAddCard()
        {
            int last_index = this.panelCards.Controls.Count - 1;

            movePanelAddCard(last_index);
        }

        /*-------------------------------------------------------------------*/

        private void panelAddCard_Click(object sender, EventArgs e)
        {
            int new_index = this.panelCards.Controls.Count - 1;

            

            Panel new_panel = get_standart_panel(new_index);

            this.panelCards.Controls.Add(new_panel);

            movePanelAddCard(new_index + 1);
        }

        /*-------------------------------------------------------------------*/

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Panel p in this.panelCards.Controls)
            {
                if (p.Controls.ContainsKey("labelValue"))
                {
                    p.Controls["labelValue"].Text = string.Format("{0} °C", rand.Next(20, 31));
                }
            } 
        }

        /*-------------------------------------------------------------------*/

        private Random rand = new Random();
        private SensorsRepository sensors;
        private Updaters.UpdatersRepository updaters = new Updaters.UpdatersRepository();

        /*-------------------------------------------------------------------*/

        private void enableLargePanelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Panel largeCard = new Panel();

            set_big_panel_props(largeCard, 0);

            this.panelCards.Controls.Add(largeCard);
            this.panelCards.Controls.SetChildIndex(largeCard, 0);

            moveToLastPanelAddCard();
        }

        /*-------------------------------------------------------------------*/
    }
}

/*****************************************************************************/
