/*****************************************************************************/

/* FIXME List:
 Consider Change:
 * CC1 - Заменить MqttClientSetting на стандартные MqttConfiguration и 
         MqttClientCredentials
 * 
 */

/*****************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ss_course_project.services.Model;

/*****************************************************************************/

namespace ss_course_project.services.Settings
{
    // FIXME: CC1
    public struct MqttClientSetting
    {
        public string Host     { get; set; }
        public int    Port     { get; set; }
        public Guid   ClientId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}

/*****************************************************************************/
