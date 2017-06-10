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
using ss_course_project.gui.Utils;

/*****************************************************************************/

namespace ss_course_project.gui.Forms
{
    public partial class FormAddSensor : Form
    {
        
        /*-------------------------------------------------------------------*/

        public FormAddSensor(ConnectionRepo available_connections, Envelope<MqttSensorSetting> target_setting)
        {
            InitializeComponent();

            m_target_setting = target_setting;
            m_available_connections = available_connections;

            FillFormData();
        }

        /*-------------------------------------------------------------------*/

        private Envelope<MqttSensorSetting> m_target_setting;
        private ConnectionRepo m_available_connections;
        private MqttSensorSetting m_buffer_setting = new MqttSensorSetting();

        /*-------------------------------------------------------------------*/

        private void FillFormData()
        {
            m_buffer_setting.Id = Guid.NewGuid();
            m_buffer_setting.QosLevel = MqttQualityOfService.AtLeastOnce;

            this.textBoxID.Text = m_buffer_setting.Id.ToString();

            BindComboBoxQosLevel();
            BindComboConnections();
        }

        /*-------------------------------------------------------------------*/

        private void BindComboBoxQosLevel()
        {
            BindingSource qos_binding = new BindingSource();
            var ec = new EnumConverter(this.m_buffer_setting.QosLevel.GetType());
            qos_binding.DataSource = ec.GetStandardValues();
            this.comboBoxQosLevel.DataSource = qos_binding;

            this.comboBoxQosLevel.SelectedItem = m_buffer_setting.QosLevel;
        }

        /*-------------------------------------------------------------------*/

        private void BindComboConnections()
        {
            BindingSource connections_binding = new BindingSource();
            connections_binding.DataSource = m_available_connections.Clients.Keys;
            
            this.comboBoxConnection.DataSource = connections_binding;
        }

        /*-------------------------------------------------------------------*/

        private void SaveFormData()
        {
            m_buffer_setting.FriendlyName = textBoxName.Text;
            m_buffer_setting.ConnectionId = (Guid)comboBoxConnection.SelectedItem;
            m_buffer_setting.QosLevel = (MqttQualityOfService)comboBoxQosLevel.SelectedItem;
            m_buffer_setting.Units = comboBoxUnits.Text;
            m_buffer_setting.Topic = textBoxTopic.Text;
        }

        /*-------------------------------------------------------------------*/

        private void buttonOK_Click(object sender, EventArgs e)
        {
            SaveFormData();
            
            m_target_setting.Value = m_buffer_setting;
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
