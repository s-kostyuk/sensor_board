using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text;

using System.Net.Mqtt;
using System.Globalization;

namespace ss_course_project.gui
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {

            //mqtt_thread.IsBackground = true;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            form1 = new Form1();
            //mqtt_thread.Start();
            MqttInit();

            Application.Run(form1);


            client.Dispose();

        }

        static async void MqttInit()
        {
            client = await MqttClient.CreateAsync("ks-cube.tk");

            await client.ConnectAsync(new MqttClientCredentials("SensorBoard"));

            await client.SubscribeAsync("/sensors/TEMP1", MqttQualityOfService.AtLeastOnce);

            SensorObserver so = new SensorObserver(form1);

            client.MessageStream.Subscribe(so);

            
        }

        static Form1 form1;
        static IMqttClient client;
    }

    class SensorObserver : IObserver<MqttApplicationMessage>
    {
        public SensorObserver(Form1 form)
        {
            this.form = form;
        }

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
            string payload = Encoding.UTF8.GetString(message.Payload);

            form.panelCards.Controls["panel0"].Controls["labelValue"].Text
                = string.Format(
                    "{0:N1}°C", double.Parse(payload, NumberStyles.Any, CultureInfo.InvariantCulture)
                    );
        }

        private Form1 form;
    }
}
