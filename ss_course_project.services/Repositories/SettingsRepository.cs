using System;
using System.Collections.Generic;

using ss_course_project.services.Settings;

/*****************************************************************************/

namespace ss_course_project.services.Repositories
{
    public class SettingsRepository
    {
        /*-------------------------------------------------------------------*/

        public IReadOnlyDictionary<Guid, MqttClientSetting> ClientSettings
        {
            get { return m_client_settings; }
        }

        /*-------------------------------------------------------------------*/

        public IReadOnlyDictionary<Guid, MqttSensorSetting> SensorSettings
        {
            get { return m_sensor_settings; }
        }

        /*-------------------------------------------------------------------*/

        public SettingsRepository() { }

        /*-------------------------------------------------------------------*/

        public void AddClientSetting(Guid client_id, MqttClientSetting setting)
        {
            m_client_settings.Add(client_id, setting);
        }

        /*-------------------------------------------------------------------*/

        public void RemoveClientSetting(Guid client_id)
        {
            m_client_settings.Remove(client_id);
        }

        /*-------------------------------------------------------------------*/

        public void AddSensorSetting(Guid client_id, MqttSensorSetting setting)
        {
            m_sensor_settings.Add(client_id, setting);
        }

        /*-------------------------------------------------------------------*/

        public void RemoveSensortSetting(Guid client_id)
        {
            m_sensor_settings.Remove(client_id);
        }

        /*-------------------------------------------------------------------*/

        Dictionary<Guid, MqttClientSetting> m_client_settings 
            = new Dictionary<Guid, MqttClientSetting>();

        Dictionary<Guid, MqttSensorSetting> m_sensor_settings
                = new Dictionary<Guid, MqttSensorSetting>();

        /*-------------------------------------------------------------------*/
    }
}

/*****************************************************************************/
