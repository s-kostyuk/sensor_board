using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;

using System.Net.Mqtt;
using Newtonsoft.Json;

using ss_course_project.services.Repositories;
using ss_course_project.services.Settings;
using ss_course_project.services.Model;


namespace ss_course_project.test_app
{
    class Program
    {
        static void Main(string[] args)
        {
            MqttInit();

            Thread.Sleep(Timeout.Infinite);
        }

        static async void MqttInit()
        {
            RestoreSettings();
            //GenerateSettings();
            connections = new ConnectionRepo();

            sensor_builder = new MqttSensorBuilder(connections);
            
            foreach (var item in settings.ClientSettings)
            {
                IMqttClient client = await MqttClientBuilder.Build(item.Value);
                connections.AddClient(item.Value.ClientId, client);
            }

            foreach (var item in settings.SensorSettings)
            {
                MqttTempSensor sensor = await sensor_builder.Build(item.Value);
                sensor.PropertyChanged += Sensor_PropertyChanged;
                sensors.Sensors.Add(sensor);
            }

            SaveSettings();
        }

        private static void GenerateSettings()
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

            settings.AddClientSetting(main_broker.ClientId, main_broker);
            settings.AddSensorSetting(room_sensor.Id, room_sensor);
            settings.AddSensorSetting(tulip_setting.Id, tulip_setting);
            settings.AddSensorSetting(notebook_setting.Id, notebook_setting);
        }

        private static void Sensor_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            MqttTempSensor sensor = (MqttTempSensor)sender;

            Console.WriteLine(
                string.Format(
                    "Sensor value updated:\nName: {0}\nID: {1}\nValue: {2}\nLastUpdated: {3}\n"
                    , sensor.FriendlyName
                    , sensor.Id.ToString()
                    , sensor.Value
                    , sensor.LastUpdated.ToString()
                    )
                    );
        }

        private static void RestoreSettings()
        {
            string path = "settings2.json";

            StreamReader reader = new StreamReader(
                File.Open(path, FileMode.Open)
                );

            string source_data = reader.ReadToEnd();

            settings = JsonConvert.DeserializeObject <SettingsRepository> (source_data);

            reader.Dispose();
        }

        private static void SaveSettings()
        {
            string path = "settings2.json";

            StreamWriter writer = new StreamWriter(
                File.Open(path, FileMode.OpenOrCreate)
                );

            writer.Write(JsonConvert.SerializeObject(
                settings, Formatting.Indented
                ));

            writer.Dispose();
        }

        private static SettingsRepository settings = new SettingsRepository();
        private static ConnectionRepo connections;
        private static MqttSensorBuilder sensor_builder;
        private static SensorsRepository sensors = new SensorsRepository();
    }

    
}



