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
            client = await MqttClientBuilder.Build(cs);

            connections.AddClient(cs.ClientId, client);

            sb = new MqttSensorBuilder(connections);
            sensor = await sb.Build(ss);

            MqttSensorSetting tulip_setting = new MqttSensorSetting();

            tulip_setting.Id = Guid.NewGuid();
            tulip_setting.QosLevel = MqttQualityOfService.AtLeastOnce;
            tulip_setting.Topic = "/sensors/tulip";
            tulip_setting.ConnectionId = cs.ClientId;

            MqttTempSensor tulip = await sb.Build(tulip_setting);

            MqttSensorSetting notebook_setting = new MqttSensorSetting();

            notebook_setting.Id = Guid.NewGuid();
            notebook_setting.QosLevel = MqttQualityOfService.AtLeastOnce;
            notebook_setting.Topic = "/sensors/book1/cpu";
            notebook_setting.ConnectionId = cs.ClientId;

            MqttTempSensor notebook = await sb.Build(notebook_setting);

            sensor.PropertyChanged += Sensor_PropertyChanged;
            tulip.PropertyChanged += Sensor_PropertyChanged;
            notebook.PropertyChanged += Sensor_PropertyChanged;

            SaveSettings();
        }

        private static void GenerateSettings()
        {
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
            string path = "settings.json";

            StreamReader reader = new StreamReader(
                File.Open(path, FileMode.Open)
                );

            string source_data = reader.ReadToEnd();

            SettingHandler sh = JsonConvert.DeserializeObject <SettingHandler> (source_data);

            ss = sh.ss;
            cs = sh.cs;

            reader.Dispose();
        }

        private static void SaveSettings()
        {
            string path = "settings.json";

            StreamWriter writer = new StreamWriter(
                File.Open(path, FileMode.OpenOrCreate)
                );

            writer.Write(JsonConvert.SerializeObject(
                new SettingHandler(cs, ss), Formatting.Indented
                ));

            writer.Dispose();
        }
        

        private static IMqttClient client;
        private static MqttClientSetting cs;
        private static MqttSensorSetting ss;
        private static ConnectionRepo connections;
        private static MqttTempSensor sensor;
        private static MqttSensorBuilder sb;
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



