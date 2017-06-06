using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ss_course_project.services.Model;

/*****************************************************************************/

namespace ss_course_project.services.Repositories
{
    public class SensorsRepository
    {
        /*-------------------------------------------------------------------*/

        public HashSet<MqttTempSensor> Sensors { get; private set; }

        /*-------------------------------------------------------------------*/

        public SensorsRepository()
        {
            Sensors = new HashSet<MqttTempSensor>();
        }

        /*-------------------------------------------------------------------*/



        /*-------------------------------------------------------------------*/
    }
}

/*****************************************************************************/
