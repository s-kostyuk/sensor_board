using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using System.Net.Mqtt;

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
            cs = new MqttClientSetting();
            cs.ClientId = Guid.NewGuid();
            cs.ClientPubicId = "SensorBoard";
            cs.Host = ".....";
            cs.Port = 1883;

            connection_guid = Guid.NewGuid();

            connections = new ConnectionRepo();
            client = await MqttClientBuilder.Build(cs);

            connections.AddClient(connection_guid, client);

            ss = new MqttSensorSetting();
            ss.Id = Guid.NewGuid();
            ss.QosLevel = MqttQualityOfService.AtLeastOnce;
            ss.Topic = "/sensors/TEMP1";
            ss.ConnectionId = connection_guid;

            sb = new MqttSensorBuilder(connections);
            sensor = await sb.Build(ss);

            sensor.PropertyChanged += Sensor_PropertyChanged;
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

        private static IMqttClient client;
        private static Guid connection_guid;
        private static MqttClientSetting cs;
        private static MqttSensorSetting ss;
        private static ConnectionRepo connections;
        private static MqttTempSensor sensor;
        private static MqttSensorBuilder sb;
    }
}



