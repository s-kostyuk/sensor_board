using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net.Mqtt;

namespace ss_course_project.services.Settings
{
    public class MqttClientBuilder
    {
        public static async Task<IMqttClient> Build(MqttClientSetting settings)
        {
            IMqttClient client;
            client = await MqttClient.CreateAsync(settings.Host, settings.Port);

            await client.ConnectAsync(
                new MqttClientCredentials(
                      clientId: settings.ClientId.ToString()
                    , userName: settings.UserName
                    , password: settings.Password
                    )
                );

            return client;
        }
    }
}
