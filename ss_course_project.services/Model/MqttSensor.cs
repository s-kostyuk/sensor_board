﻿/*****************************************************************************/

/* FIXME List:
 Consider Change:
 * CC3 - разрешить смену параметров после создания
 * СС4 - подписываться на тему в момент консруирования
 * CC5 - add Dispatcher
 * CC7 - Unsubscribe on disposal
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
    // FIXME: CC7
    public abstract class MqttSensor<T> : BasicEntity, IMqttSensor<T>
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
                m_last_updated = DateTime.UtcNow;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Value"));
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

        public string FriendlyName
        {
            get { return m_friendly_name; }
            set
            {
                m_friendly_name = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FriendlyName"));
            }
        }

        /*-------------------------------------------------------------------*/

        public MqttSensor(Guid id, string topic, string units = null)
            : base(id)
        {
            m_topic = topic;
            m_units = units;
        }
        
        /*-------------------------------------------------------------------*/

        private string m_topic;
        private T m_value;
        private DateTime m_last_updated;
        private string m_units;
        private string m_friendly_name;

        /*-------------------------------------------------------------------*/

        public event PropertyChangedEventHandler PropertyChanged;

        /*-------------------------------------------------------------------*/

        protected abstract T Decode(byte[] value);
        
        /*-------------------------------------------------------------------*/

        public void OnNext(MqttApplicationMessage value)
        {
            if (value.Topic == m_topic) // FIMXE: CC5
            {
                T new_value = Decode(value.Payload);

                Value = new_value;
            }
        }

        /*-------------------------------------------------------------------*/

        public void OnError(Exception error)
        {
            // do_nothing
        }

        /*-------------------------------------------------------------------*/

        public void OnCompleted()
        {
            // do_nothing
        }

        /*-------------------------------------------------------------------*/
    }
}

/*****************************************************************************/
