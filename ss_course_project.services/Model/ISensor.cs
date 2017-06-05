using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*****************************************************************************/

namespace ss_course_project.services.Model
{
    public interface ISensor<T> : INotifyPropertyChanged
        where T: IComparable
    {
        string Name { get; set; }
        T Value { get; }
        DateTime LastUpdate { get; }
        string Unit { get; }

        T MinThreshold { get; set; }
        T MaxThreshold { get; set; }
        bool ThresholdEnabled { get; set; }
        bool ThresholdIsSchmidt { get; set; }
    }
}

/*****************************************************************************/
