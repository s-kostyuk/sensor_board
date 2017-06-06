/*****************************************************************************/

/* FIXME List:
 Consider Change:
 * CC3 - разрешить смену параметров после создания
 * СС4 - подписываться на тему в момент консруирования
 */

/*****************************************************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*****************************************************************************/

using System.Net.Mqtt;

/*****************************************************************************/

namespace ss_course_project.services.Model
{
    class MqttSensor<T> : BasicEntity, ISensor<T>
    {
        /*-------------------------------------------------------------------*/

        public T Value {
            get
            {
                return m_value;
            }

            private set
            {
                m_value = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Value"));
                m_last_updated = DateTime.UtcNow;
            }
        }

        /*-------------------------------------------------------------------*/

        public DateTime LastUpdated {
            get
            {
                return m_last_updated;
            }

            private set
            {
                m_last_updated = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("LastUpdated"));
            }
        }

        /*-------------------------------------------------------------------*/

        public string Units {
            get
            {
                return m_units;
            }

            set
            {
                m_units = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Units"));
            }
        }

        /*-------------------------------------------------------------------*/

        public MqttSensor(Guid id, IMqttClient client, string topic, string units = null)
            : base(id)
        {
            m_client = client;
            m_topic = topic;
            m_units = units;
        }

        /*-------------------------------------------------------------------*/

        private string m_topic;
        private IMqttClient m_client;
        private T m_value;
        private DateTime m_last_updated;
        private string m_units;

        /*-------------------------------------------------------------------*/

        public event PropertyChangedEventHandler PropertyChanged;

        /*-------------------------------------------------------------------*/
    }
}

/*****************************************************************************/
