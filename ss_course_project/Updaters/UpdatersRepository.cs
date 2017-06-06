using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*****************************************************************************/

namespace ss_course_project.gui.Updaters
{
    public class UpdatersRepository
    {
        /*-------------------------------------------------------------------*/

        public HashSet<PanelSensorUpdater> PanelSensorUpdaters { get; private set; }

        /*-------------------------------------------------------------------*/

        public UpdatersRepository()
        {
            PanelSensorUpdaters = new HashSet<PanelSensorUpdater>();
        }

        /*-------------------------------------------------------------------*/



        /*-------------------------------------------------------------------*/
    }
}

/*****************************************************************************/
