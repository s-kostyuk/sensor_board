using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

/*****************************************************************************/

using System.Net.Mqtt;
using Newtonsoft.Json;

/*****************************************************************************/

using ss_course_project.services.Repositories;
using ss_course_project.services.Settings;
using ss_course_project.services.Model;

/*****************************************************************************/

namespace ss_course_project.services
{
    public class Controller : IDisposable
    {
        /*-------------------------------------------------------------------*/

        public SensorsRepository Sensors { get { return m_sensors; } }
        public ConnectionRepo Connections { get { return m_connections; } }
        public SettingsRepository Settings { get { return m_settings; } }
        public MqttSensorBuilder SensorBuilder { get { return m_sensor_builder; } }
        
        /*-------------------------------------------------------------------*/

        public Controller()
        {
            m_sensor_builder = new MqttSensorBuilder(m_connections);
        }

        /*-------------------------------------------------------------------*/

        public void Dispose()
        {
            m_connections.Dispose();
        }

        /*-------------------------------------------------------------------*/

        public async Task Init()
        {
            RestoreSettings();
            //GenerateSettings();

            foreach (var item in m_settings.ClientSettings)
            {
                IMqttClient client = await MqttClientBuilder.Build(item.Value);
                m_connections.AddClient(item.Value.ClientId, client);
            }

            foreach (var item in m_settings.SensorSettings)
            {
                MqttTempSensor sensor = m_sensor_builder.Build(item.Value);
                m_sensors.Sensors.Add(sensor);
            }

            SaveSettings();
        }

        /*-------------------------------------------------------------------*/

        public async Task ConnectAll()
        {
            foreach (var item in m_settings.ClientSettings)
            {
                IMqttClient client = m_connections.GetClient(item.Key);
                await MqttClientBuilder.Connect(client, item.Value);
            }

            foreach (var item in m_settings.SensorSettings)
            {
                IMqttClient client = m_connections.GetClient(item.Value.ConnectionId);
                await m_sensor_builder.SubscribeTopics(client, item.Value);
            }
        }

        /*-------------------------------------------------------------------*/

        public void RestoreSettings()
        {
            string path = "settings2.json";

            StreamReader reader = new StreamReader(
                File.Open(path, FileMode.Open)
                );

            string source_data = reader.ReadToEnd();

            m_settings = JsonConvert.DeserializeObject<SettingsRepository>(source_data);

            reader.Dispose();
        }

        /*-------------------------------------------------------------------*/

        public void SaveSettings()
        {
            string path = "settings2.json";

            StreamWriter writer = new StreamWriter(
                File.Open(path, FileMode.OpenOrCreate)
                );

            writer.Write(JsonConvert.SerializeObject(
                m_settings, Formatting.Indented
                ));

            writer.Dispose();
        }

        /*-------------------------------------------------------------------*/

        private void GenerateSettings()
        {

            MqttClientSetting main_broker;

            main_broker = new MqttClientSetting();
            main_broker.ClientId = Guid.NewGuid();
            main_broker.ClientPubicId = "SensorBoard";
            main_broker.Host = ".....";
            main_broker.Port = 1883;

            MqttSensorSetting room_sensor;

            room_sensor = new MqttSensorSetting();
            room_sensor.Id = Guid.NewGuid();
            room_sensor.QosLevel = MqttQualityOfService.AtLeastOnce;
            room_sensor.Topic = "/sensors/TEMP1";
            room_sensor.ConnectionId = main_broker.ClientId;

            MqttSensorSetting tulip_setting = new MqttSensorSetting();

            tulip_setting.Id = Guid.NewGuid();
            tulip_setting.QosLevel = MqttQualityOfService.AtLeastOnce;
            tulip_setting.Topic = "/sensors/tulip";
            tulip_setting.ConnectionId = main_broker.ClientId;

            MqttSensorSetting notebook_setting = new MqttSensorSetting();

            notebook_setting.Id = Guid.NewGuid();
            notebook_setting.QosLevel = MqttQualityOfService.AtLeastOnce;
            notebook_setting.Topic = "/sensors/book1/cpu";
            notebook_setting.ConnectionId = main_broker.ClientId;

            m_settings.AddClientSetting(main_broker.ClientId, main_broker);
            m_settings.AddSensorSetting(room_sensor.Id, room_sensor);
            m_settings.AddSensorSetting(tulip_setting.Id, tulip_setting);
            m_settings.AddSensorSetting(notebook_setting.Id, notebook_setting);
        }
        
        /*-------------------------------------------------------------------*/

        private SettingsRepository m_settings = new SettingsRepository();
        private ConnectionRepo m_connections = new ConnectionRepo();
        private MqttSensorBuilder m_sensor_builder;
        private SensorsRepository m_sensors = new SensorsRepository();

        /*-------------------------------------------------------------------*/
    }
}

/*****************************************************************************/
