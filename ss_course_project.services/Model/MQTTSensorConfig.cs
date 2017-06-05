using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*****************************************************************************/

namespace ss_course_project.services.Model
{
    public struct MQTTSensorConfig
    {
        string Broker   { get; set; }
        int    Port     { get; set; }
        string Topic    { get; set; }
        string Login    { get; set; }
        string Password { get; set; }
    }
}

/*****************************************************************************/
