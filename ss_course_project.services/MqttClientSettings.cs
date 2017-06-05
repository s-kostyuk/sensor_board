using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ss_course_project.services
{
    /// <summary>
    /// ОЧЕНЬ базовые настройки MQTT-клиента
    /// </summary>
    public struct MqttClientSettings
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public string Id { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
    }
}
