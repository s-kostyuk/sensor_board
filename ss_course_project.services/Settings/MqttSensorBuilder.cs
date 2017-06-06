using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net.Mqtt;

using ss_course_project.services.Model;

namespace ss_course_project.services.Settings
{
    public class MqttSensorBuilder
    {
        public MqttSensorBuilder(Repositories.ConnectionRepo connections)
        {
            m_connections = connections;
        }

        private ISensor Build(MqttSensorSetting settings)
        {
            IMqttClient client = m_connections.GetClient(settings.ConnectionId);

            return new ISensor();
        }

        Repositories.ConnectionRepo m_connections;
    }
}
