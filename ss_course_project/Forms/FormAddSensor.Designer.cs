namespace ss_course_project.gui.Forms
{
    partial class FormAddSensor
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.splitContainerBooksMenu = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.comboBoxUnits = new System.Windows.Forms.ComboBox();
            this.labelUnits = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.labelName = new System.Windows.Forms.Label();
            this.comboBoxQosLevel = new System.Windows.Forms.ComboBox();
            this.labelQosLevel = new System.Windows.Forms.Label();
            this.textBoxTopic = new System.Windows.Forms.TextBox();
            this.labelTopic = new System.Windows.Forms.Label();
            this.labelConnection = new System.Windows.Forms.Label();
            this.labelId = new System.Windows.Forms.Label();
            this.textBoxID = new System.Windows.Forms.TextBox();
            this.comboBoxConnection = new System.Windows.Forms.ComboBox();
            this.flowLayoutPanelButtons = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerBooksMenu)).BeginInit();
            this.splitContainerBooksMenu.Panel1.SuspendLayout();
            this.splitContainerBooksMenu.Panel2.SuspendLayout();
            this.splitContainerBooksMenu.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanelButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(8, 8);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(100, 23);
            this.buttonOK.TabIndex = 0;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.Location = new System.Drawing.Point(114, 8);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(100, 23);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // splitContainerBooksMenu
            // 
            this.splitContainerBooksMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerBooksMenu.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainerBooksMenu.Location = new System.Drawing.Point(0, 0);
            this.splitContainerBooksMenu.Name = "splitContainerBooksMenu";
            this.splitContainerBooksMenu.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerBooksMenu.Panel1
            // 
            this.splitContainerBooksMenu.Panel1.Controls.Add(this.tableLayoutPanel1);
            // 
            // splitContainerBooksMenu.Panel2
            // 
            this.splitContainerBooksMenu.Panel2.Controls.Add(this.flowLayoutPanelButtons);
            this.splitContainerBooksMenu.Size = new System.Drawing.Size(307, 299);
            this.splitContainerBooksMenu.SplitterDistance = 255;
            this.splitContainerBooksMenu.TabIndex = 5;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 78F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.comboBoxUnits, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.labelUnits, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.textBoxName, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.labelName, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.comboBoxQosLevel, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.labelQosLevel, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.textBoxTopic, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.labelTopic, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.labelConnection, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelId, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBoxID, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.comboBoxConnection, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(5);
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(307, 255);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // comboBoxUnits
            // 
            this.comboBoxUnits.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBoxUnits.FormattingEnabled = true;
            this.comboBoxUnits.Items.AddRange(new object[] {
            "°C",
            "°F",
            "%"});
            this.comboBoxUnits.Location = new System.Drawing.Point(86, 128);
            this.comboBoxUnits.Name = "comboBoxUnits";
            this.comboBoxUnits.Size = new System.Drawing.Size(213, 21);
            this.comboBoxUnits.TabIndex = 11;
            // 
            // labelUnits
            // 
            this.labelUnits.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelUnits.Location = new System.Drawing.Point(8, 125);
            this.labelUnits.Name = "labelUnits";
            this.labelUnits.Size = new System.Drawing.Size(72, 24);
            this.labelUnits.TabIndex = 10;
            this.labelUnits.Text = "Units:";
            this.labelUnits.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxName
            // 
            this.textBoxName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxName.Location = new System.Drawing.Point(86, 104);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(213, 20);
            this.textBoxName.TabIndex = 9;
            // 
            // labelName
            // 
            this.labelName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelName.Location = new System.Drawing.Point(8, 101);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(72, 24);
            this.labelName.TabIndex = 8;
            this.labelName.Text = "Name:";
            this.labelName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // comboBoxQosLevel
            // 
            this.comboBoxQosLevel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBoxQosLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxQosLevel.FormattingEnabled = true;
            this.comboBoxQosLevel.Location = new System.Drawing.Point(86, 80);
            this.comboBoxQosLevel.Name = "comboBoxQosLevel";
            this.comboBoxQosLevel.Size = new System.Drawing.Size(213, 21);
            this.comboBoxQosLevel.TabIndex = 7;
            // 
            // labelQosLevel
            // 
            this.labelQosLevel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelQosLevel.Location = new System.Drawing.Point(8, 77);
            this.labelQosLevel.Name = "labelQosLevel";
            this.labelQosLevel.Size = new System.Drawing.Size(72, 24);
            this.labelQosLevel.TabIndex = 6;
            this.labelQosLevel.Text = "QoS Level:";
            this.labelQosLevel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxTopic
            // 
            this.textBoxTopic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxTopic.Location = new System.Drawing.Point(86, 56);
            this.textBoxTopic.Name = "textBoxTopic";
            this.textBoxTopic.Size = new System.Drawing.Size(213, 20);
            this.textBoxTopic.TabIndex = 5;
            // 
            // labelTopic
            // 
            this.labelTopic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelTopic.Location = new System.Drawing.Point(8, 53);
            this.labelTopic.Name = "labelTopic";
            this.labelTopic.Size = new System.Drawing.Size(72, 24);
            this.labelTopic.TabIndex = 4;
            this.labelTopic.Text = "Topic:";
            this.labelTopic.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelConnection
            // 
            this.labelConnection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelConnection.Location = new System.Drawing.Point(8, 29);
            this.labelConnection.Name = "labelConnection";
            this.labelConnection.Size = new System.Drawing.Size(72, 24);
            this.labelConnection.TabIndex = 2;
            this.labelConnection.Text = "Connection:";
            this.labelConnection.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelId
            // 
            this.labelId.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelId.Location = new System.Drawing.Point(8, 5);
            this.labelId.Name = "labelId";
            this.labelId.Size = new System.Drawing.Size(72, 24);
            this.labelId.TabIndex = 0;
            this.labelId.Text = "ID:";
            this.labelId.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxID
            // 
            this.textBoxID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxID.Location = new System.Drawing.Point(86, 8);
            this.textBoxID.Name = "textBoxID";
            this.textBoxID.ReadOnly = true;
            this.textBoxID.Size = new System.Drawing.Size(213, 20);
            this.textBoxID.TabIndex = 1;
            // 
            // comboBoxConnection
            // 
            this.comboBoxConnection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBoxConnection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxConnection.FormattingEnabled = true;
            this.comboBoxConnection.Location = new System.Drawing.Point(86, 32);
            this.comboBoxConnection.Name = "comboBoxConnection";
            this.comboBoxConnection.Size = new System.Drawing.Size(213, 21);
            this.comboBoxConnection.TabIndex = 3;
            // 
            // flowLayoutPanelButtons
            // 
            this.flowLayoutPanelButtons.Controls.Add(this.buttonOK);
            this.flowLayoutPanelButtons.Controls.Add(this.buttonCancel);
            this.flowLayoutPanelButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelButtons.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanelButtons.Name = "flowLayoutPanelButtons";
            this.flowLayoutPanelButtons.Padding = new System.Windows.Forms.Padding(5);
            this.flowLayoutPanelButtons.Size = new System.Drawing.Size(307, 40);
            this.flowLayoutPanelButtons.TabIndex = 0;
            // 
            // FormAddSensor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(307, 299);
            this.Controls.Add(this.splitContainerBooksMenu);
            this.Name = "FormAddSensor";
            this.Text = "FormAddSensor";
            this.splitContainerBooksMenu.Panel1.ResumeLayout(false);
            this.splitContainerBooksMenu.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerBooksMenu)).EndInit();
            this.splitContainerBooksMenu.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.flowLayoutPanelButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.SplitContainer splitContainerBooksMenu;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelButtons;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label labelId;
        private System.Windows.Forms.TextBox textBoxID;
        private System.Windows.Forms.Label labelConnection;
        private System.Windows.Forms.ComboBox comboBoxConnection;
        private System.Windows.Forms.ComboBox comboBoxQosLevel;
        private System.Windows.Forms.Label labelQosLevel;
        private System.Windows.Forms.TextBox textBoxTopic;
        private System.Windows.Forms.Label labelTopic;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label labelUnits;
        private System.Windows.Forms.ComboBox comboBoxUnits;
    }
}