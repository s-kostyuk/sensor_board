using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*****************************************************************************/

namespace ss_course_project.services.Model
{
    public class MQTTSensor <T> : ISensor<T>
        where T : IComparable
    {
        /*-------------------------------------------------------------------*/

        public string Name { get; set; }
        public T Value { get; private set; }
        public DateTime LastUpdate { get; private set; }
        public string Unit { get; private set; }

        /*-------------------------------------------------------------------*/

        

        /*-------------------------------------------------------------------*/

        public event PropertyChangedEventHandler PropertyChanged;

        /*-------------------------------------------------------------------*/

        public T MinThreshold { get; set; }
        public T MaxThreshold { get; set; }
        public bool MinThresholdReached { get; private set; }
        public bool MaxThresholdReached { get; private set; }
        public bool ThresholdEnabled { get; set; }
        public bool ThresholdIsSchmidt { get; set; }

        /*-------------------------------------------------------------------*/

        public MQTTSensor(MQTTSensorConfig config)
        {
            this.m_connection_config = config;
            this.Unit = "°C";
            this.LastUpdate = DateTime.Now;
        }

        /*-------------------------------------------------------------------*/


        /*-------------------------------------------------------------------*/

        private void CheckThreshold()
        {
            if (ThresholdEnabled)
            {
                MaxThresholdReached = Value.CompareTo(MaxThreshold) > 0;
                MinThresholdReached = Value.CompareTo(MinThreshold) < 0;
            }
        }

        /*-------------------------------------------------------------------*/

        // Create the OnPropertyChanged method to raise the event
        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        /*-------------------------------------------------------------------*/

        private T m_value;
        private MQTTSensorConfig m_connection_config;

        /*-------------------------------------------------------------------*/
    }
}

/*****************************************************************************/
