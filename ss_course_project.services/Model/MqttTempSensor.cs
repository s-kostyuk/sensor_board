/*****************************************************************************/

using System;
using System.Text;
using System.Globalization;

/*****************************************************************************/

using System.Net.Mqtt;

/*****************************************************************************/

namespace ss_course_project.services.Model
{
    public class MqttTempSensor : MqttSensor<double>
    {
        /*-------------------------------------------------------------------*/

        public MqttTempSensor(Guid id, string topic, string units = "°C")
            : base(id, topic, units)
        {
        }

        /*-------------------------------------------------------------------*/

        protected override double Decode(byte[] value)
        {
            string value_as_str = Encoding.UTF8.GetString(value);
            return double.Parse(value_as_str, NumberStyles.Any, CultureInfo.InvariantCulture);
        }

        /*-------------------------------------------------------------------*/
    }
}

/*****************************************************************************/
