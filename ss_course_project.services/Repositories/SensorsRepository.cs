﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ss_course_project.services.Model;

/*****************************************************************************/

namespace ss_course_project.services.Repositories
{
    public class SensorsRepository : IDisposable
    {
        /*-------------------------------------------------------------------*/

        public HashSet<MqttDoubleSensor> Sensors { get; private set; }

        /*-------------------------------------------------------------------*/

        public SensorsRepository()
        {
            Sensors = new HashSet<MqttDoubleSensor>();
        }

        /*-------------------------------------------------------------------*/

        public void Dispose()
        {
            Sensors.Clear();
        }

        /*-------------------------------------------------------------------*/
    }
}

/*****************************************************************************/
