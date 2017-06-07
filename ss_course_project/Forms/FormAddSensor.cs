using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

/*****************************************************************************/

using System.Net.Mqtt;

/*****************************************************************************/

using ss_course_project.services.Repositories;
using ss_course_project.services.Settings;

/*****************************************************************************/

namespace ss_course_project.gui.Forms
{
    public partial class FormAddSensor : Form
    {
        /*-------------------------------------------------------------------*/

        

        /*-------------------------------------------------------------------*/

        public FormAddSensor(ConnectionRepo available_connections, ref MqttSensorSetting target_setting)
        {
            InitializeComponent();

            m_target_setting = target_setting;
            m_available_connections = available_connections;

            m_buffer_setting.Id = Guid.NewGuid();
            m_buffer_setting.QosLevel = MqttQualityOfService.AtLeastOnce;
            
            this.textBoxID.Text = m_buffer_setting.Id.ToString();

            // FIXME: Привязка к Enum так не делается
            BindingSource qos_binding = new BindingSource();
            qos_binding.DataSource = this.m_buffer_setting.QosLevel;

            this.comboBoxQosLevel.DataSource = qos_binding; 
        }

        /*-------------------------------------------------------------------*/

        private MqttSensorSetting m_target_setting;
        private ConnectionRepo m_available_connections;
        private MqttSensorSetting m_buffer_setting = new MqttSensorSetting();
        
        /*-------------------------------------------------------------------*/

        private void buttonOK_Click(object sender, EventArgs e)
        {
            m_target_setting = m_buffer_setting;
            this.DialogResult = DialogResult.OK;
        }

        /*-------------------------------------------------------------------*/

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        /*-------------------------------------------------------------------*/
        
    }
}

/*****************************************************************************/
