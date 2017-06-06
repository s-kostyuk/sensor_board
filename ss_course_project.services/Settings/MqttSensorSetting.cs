/*****************************************************************************/

using System;
using System.Net.Mqtt;

/*****************************************************************************/

namespace ss_course_project.services.Settings
{
    public struct MqttSensorSetting
    {
        public Guid Id { get; set; }
        public Guid ConnectionId { get; set; }
        public string Topic { get; set; }
        public MqttQualityOfService QosLevel { get; set; }
    }
}

/*****************************************************************************/
