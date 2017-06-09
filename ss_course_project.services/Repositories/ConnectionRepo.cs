/*****************************************************************************/

/* FIXME List:
 Consider Change:
 * CC2 - Добавить генерацию клиентов по настройкам
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

namespace ss_course_project.services.Repositories
{
    public class ConnectionRepo : IDisposable
    {
        public ConnectionRepo()
        {

        }

        public IMqttClient GetClient(Guid clientId)
        {
            return m_clients[clientId];
        }

        public void AddClient(Guid clientId, IMqttClient client)
        {
            m_clients.Add(clientId, client);
        }

        public void Dispose()
        {
            foreach (var item in m_clients)
            {
                item.Value.Dispose();
            }

            m_clients.Clear();
        }

        // FIXME: CC2
        //public void AddClient(Guid clientId, MqttClientSetting setting);

        private Dictionary<Guid, IMqttClient> m_clients = new Dictionary<Guid, IMqttClient>();
    }
}

/*****************************************************************************/
