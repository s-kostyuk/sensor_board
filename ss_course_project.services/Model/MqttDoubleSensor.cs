/*****************************************************************************/

using System;
using System.Text;
using System.Globalization;

/*****************************************************************************/

using System.Net.Mqtt;

/*****************************************************************************/

namespace ss_course_project.services.Model
{
    public class MqttDoubleSensor : MqttSensor<double>
    {
        /*-------------------------------------------------------------------*/

        public MqttDoubleSensor(Guid id, string topic, string units)
            : base(id, topic, units)
        {
        }

        /*-------------------------------------------------------------------*/

        // FIXME: Consider adding TryDecode() method
        protected override double Decode(byte[] value)
        {
            string value_as_str = Encoding.UTF8.GetString(value);
            double result;
            bool is_parse_successful = double.TryParse(
                value_as_str
                , NumberStyles.Any
                , CultureInfo.InvariantCulture
                , out result
                );

            if (is_parse_successful)
            {
                return result;
            }
            else
            {
                // FIXME: Add logging here
                return 0.0;
            }
        }

        /*-------------------------------------------------------------------*/
    }
}

/*****************************************************************************/
