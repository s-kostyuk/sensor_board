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

            sb = new MqttSensorBuilder(connections);
            
            foreach (var item in settings.ClientSettings)
            {
                IMqttClient client = await MqttClientBuilder.Build(item.Value);
                connections.AddClient(item.Value.ClientId, client);
            }

            foreach (var item in settings.SensorSettings)
            {
                MqttTempSensor sensor = await sb.Build(item.Value);
                sensor.PropertyChanged += Sensor_PropertyChanged;
                sensors.Add(sensor);
            }

            SaveSettings();
        }

        private static void GenerateSettings()
        {
            MqttSensorSetting ss;
            MqttClientSetting cs;

            cs = new MqttClientSetting();
            cs.ClientId = Guid.NewGuid();
            cs.ClientPubicId = "SensorBoard";
            cs.Host = ".....";
            cs.Port = 1883;

            ss = new MqttSensorSetting();
            ss.Id = Guid.NewGuid();
            ss.QosLevel = MqttQualityOfService.AtLeastOnce;
            ss.Topic = "/sensors/TEMP1";
            ss.ConnectionId = cs.ClientId;

            MqttSensorSetting tulip_setting = new MqttSensorSetting();

            tulip_setting.Id = Guid.NewGuid();
            tulip_setting.QosLevel = MqttQualityOfService.AtLeastOnce;
            tulip_setting.Topic = "/sensors/tulip";
            tulip_setting.ConnectionId = cs.ClientId;
            
            MqttSensorSetting notebook_setting = new MqttSensorSetting();

            notebook_setting.Id = Guid.NewGuid();
            notebook_setting.QosLevel = MqttQualityOfService.AtLeastOnce;
            notebook_setting.Topic = "/sensors/book1/cpu";
            notebook_setting.ConnectionId = cs.ClientId;

            settings.AddClientSetting(cs.ClientId, cs);
            settings.AddSensorSetting(ss.Id, ss);
            settings.AddSensorSetting(tulip_setting.Id, tulip_setting);
            settings.AddSensorSetting(notebook_setting.Id, notebook_setting);
        }

        private static void Sensor_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            MqttTempSensor sensor = (MqttTempSensor)sender;

            Console.WriteLine(
                string.Format(
                    "Sensor value updated:\nID: {0}\nValue: {1}\nLastUpdated: {2}\n"
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
        private static MqttSensorBuilder sb;
        private static List<MqttTempSensor> sensors = new List<MqttTempSensor>();
    }

    class SettingHandler
    {
        public SettingHandler(MqttClientSetting cs, MqttSensorSetting ss)
        {
            this.cs = cs;
            this.ss = ss;
        }

        public MqttClientSetting cs { get; set; }
        public MqttSensorSetting ss { get; set; }
    }


}



