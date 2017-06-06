using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Reactive;

namespace ss_course_project.services.Model
{
    public interface ISensor<T, S> : IBasicEntity, INotifyPropertyChanged, IObserver<S>
    {
        T Value { get; }
        DateTime LastUpdated { get; }
        string Units { get; set; }
    }
}
