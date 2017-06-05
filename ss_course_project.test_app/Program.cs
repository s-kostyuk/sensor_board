using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace ss_course_project.test_app
{
    class Program
    {
        static void Main(string[] args)
        {
            MqttClient client = new MqttClient("....");
            client.Connect("Sensor-Board");

            client.Subscribe(new string[]{ "/sensors/TEMP1"}, new byte[]{ MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE });

            client.MqttMsgPublishReceived += Client_MqttMsgPublishReceived;
        }

        private static void Client_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
        {
            Console.WriteLine(string.Format("\nNew message received\n{0}", DateTime.Now));
            Console.WriteLine(
                string.Format("topic: {0}\nmessage: {1}",
                    e.Topic, System.Text.Encoding.UTF8.GetString(e.Message)
                )
                );
        }
    }
}
