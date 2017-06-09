using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

            return client;
        }

        public static async Task Connect(IMqttClient client, MqttClientSetting settings)
        {
            await client.ConnectAsync(
                new MqttClientCredentials(
                      clientId: settings.ClientPubicId
                    , userName: settings.UserName
                    , password: settings.Password
                    )
                );
        }

    }
}
