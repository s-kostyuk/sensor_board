using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using System.Net.Mqtt;

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
            var client = await MqttClient.CreateAsync(".....");

            await client.ConnectAsync(new MqttClientCredentials("SensorBoard"));

            await client.SubscribeAsync("/sensors/TEMP1", MqttQualityOfService.AtLeastOnce);

            SensorObserver so = new SensorObserver();

            client.MessageStream.Subscribe(so);
        }
    }

    class SensorObserver : IObserver<MqttApplicationMessage>
    {
        public void OnCompleted()
        {
            Console.WriteLine("Completed");
        }

        public void OnError(Exception error)
        {
            Console.WriteLine(string.Format("Error: {0}", error.Message));
        }

        public void OnNext(MqttApplicationMessage message)
        {
            Console.WriteLine("New message received");
            Console.WriteLine(DateTime.Now);
            Console.WriteLine(message.Topic);
            Console.WriteLine(Encoding.UTF8.GetString(message.Payload));
        }
    }
}



