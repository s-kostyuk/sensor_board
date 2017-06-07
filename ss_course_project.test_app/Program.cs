using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
using System.IO.Ports;

using System.Net.Mqtt;
using Newtonsoft.Json;

using ss_course_project.services;
using ss_course_project.services.Repositories;
using ss_course_project.services.Settings;
using ss_course_project.services.Model;


namespace ss_course_project.test_app
{
    class Program
    {
        static void Main(string[] args)
        {
            string first_port_name = SerialPort.GetPortNames().First();

            SerialPort port = new SerialPort(first_port_name, 115200);

            port.DataReceived += Port_DataReceived;
            //Init();

            port.Open();
            
            Thread.Sleep(Timeout.Infinite);
        }

        private static void Port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort port = (SerialPort)sender;

            string data = port.ReadLine();

            Console.WriteLine(data);
        }

        private static async void Init()
        {
            await controller.Init();
            SubscribeSensors();
        }

        
        private static void SubscribeSensors()
        {
            foreach (var item in controller.Sensors.Sensors)
            {
                item.PropertyChanged += Sensor_PropertyChanged;
            }
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
        
        private static Controller controller = new Controller();
    }

    
}



