/*****************************************************************************/

/* FIXME List:
 Consider Change:
 * CC6 - Add Subscription Manager
 * CC7 - Unsubscribe on disposal
 */

/*****************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*****************************************************************************/

using System.Net.Mqtt;

/*****************************************************************************/

using ss_course_project.services.Model;

/*****************************************************************************/

namespace ss_course_project.services.Settings
{
    public class MqttSensorBuilder
    {
        public MqttSensorBuilder(Repositories.ConnectionRepo connections)
        {
            m_connections = connections;
        }

        public MqttTempSensor Build(MqttSensorSetting settings)
        {
            IMqttClient client = m_connections.GetClient(settings.ConnectionId);
            MqttTempSensor sensor = new MqttTempSensor(settings.Id, settings.Topic);
            sensor.FriendlyName = settings.FriendlyName;
            
            // FIXME: CC7
            client.MessageStream.Subscribe(sensor);

            return sensor;
        }

        public async Task SubscribeTopics(IMqttClient client, MqttSensorSetting settings)
        {
            // FIXME: CC6
            await client.SubscribeAsync(settings.Topic, settings.QosLevel);
        }

        Repositories.ConnectionRepo m_connections;
    }
}

/*****************************************************************************/
