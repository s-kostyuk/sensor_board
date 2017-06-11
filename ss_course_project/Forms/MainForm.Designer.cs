namespace ss_course_project.gui.Forms
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelCards = new System.Windows.Forms.FlowLayoutPanel();
            this.panelAddCard = new System.Windows.Forms.Panel();
            this.panelCards.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelCards
            // 
            this.panelCards.AutoScroll = true;
            this.panelCards.Controls.Add(this.panelAddCard);
            this.panelCards.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCards.Location = new System.Drawing.Point(0, 0);
            this.panelCards.Name = "panelCards";
            this.panelCards.Size = new System.Drawing.Size(603, 312);
            this.panelCards.TabIndex = 0;
            // 
            // panelAddCard
            // 
            this.panelAddCard.BackColor = System.Drawing.SystemColors.Window;
            this.panelAddCard.BackgroundImage = global::ss_course_project.gui.Properties.Resources.course_plus_sign;
            this.panelAddCard.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panelAddCard.Location = new System.Drawing.Point(3, 3);
            this.panelAddCard.Name = "panelAddCard";
            this.panelAddCard.Size = new System.Drawing.Size(144, 86);
            this.panelAddCard.TabIndex = 0;
            this.panelAddCard.Click += new System.EventHandler(this.panelAddCard_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(603, 312);
            this.Controls.Add(this.panelCards);
            this.Name = "MainForm";
            this.Text = "Sensor-Board v0.1";
            this.panelCards.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel panelCards;
        private System.Windows.Forms.Panel panelAddCard;
    }
}

