using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

using ss_course_project.services.Model;

/*****************************************************************************/

namespace ss_course_project.gui.Updaters
{
    public class PanelSensorUpdater : IDisposable
    {

        /*-------------------------------------------------------------------*/

        public PanelSensorUpdater(MqttDoubleSensor source_sensor, Panel target_panel)
        {
            CheckPanel(target_panel);

            this.m_panel = target_panel;
            this.m_sensor = source_sensor;

            this.m_sensor.PropertyChanged += M_sensor_PropertyChanged;
        }

        /*-------------------------------------------------------------------*/

        public void Dispose()
        {
            this.m_sensor.PropertyChanged -= M_sensor_PropertyChanged;
        }

        /*-------------------------------------------------------------------*/

        private void M_sensor_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            Debug.Assert(ReferenceEquals(sender, this.m_sensor));

            Action action = null;

            switch (e.PropertyName)
            {
                case "Value":
                    action = ForceUpdateValue;
                    break;

                case "FriendlyName":
                    action = ForceUpdateName;
                    break;

                case "Units":
                    action = ForceUpdateUnits;
                    break;

                default:
                    // If we a here - it's may be bad. FIXME: Add diagnostics/logging/etc.
                    break;
            }

            if (action != null)
            {
                if (m_panel.InvokeRequired)
                {
                    m_panel.Invoke(action);
                }
                else
                {
                    MessageBox.Show("Invoke not required", "M_sensor_PropertyChanged()");
                    action();
                }
            }
        }

        /*-------------------------------------------------------------------*/

        private static void CheckPanel(Panel panel)
        {
            if (! panel.Controls.ContainsKey("labelValue"))
            {
                throw new ArgumentException("Panel must contain a labelValue control");
            }

            if (! panel.Controls.ContainsKey("labelCardName"))
            {
                throw new ArgumentException("Panel must contain a labelCardName control");
            }

            if (! (panel.Controls["labelValue"] is Label))
            {
                throw new ArgumentException("labelValue must be a Label");
            }

            if (!(panel.Controls["labelCardName"] is Label))
            {
                throw new ArgumentException("labelCardName must be a Label");
            }
        }

        /*-------------------------------------------------------------------*/

        private void SetValue(string new_value)
        {
            m_panel.Controls["labelValue"].Text = new_value;
        }

        /*-------------------------------------------------------------------*/

        private void SetName(string new_name)
        {
            m_panel.Controls["labelCardName"].Text = new_name;
        }

        /*-------------------------------------------------------------------*/

        public void ForceUpdateValue()
        {
            SetValue(string.Format("{0:N1}{1}", m_sensor.Value, m_sensor.Units));
        }

        /*-------------------------------------------------------------------*/

        public void ForceUpdateUnits()
        {
            ForceUpdateValue();
        }

        /*-------------------------------------------------------------------*/

        public void ForceUpdateName()
        {
            SetName(m_sensor.FriendlyName);
        }

        /*-------------------------------------------------------------------*/

        public void ForceUpdateAll()
        {
            ForceUpdateName();
            ForceUpdateValue();
        }

        /*-------------------------------------------------------------------*/

        private Panel m_panel;
        private MqttDoubleSensor m_sensor;

        /*-------------------------------------------------------------------*/
    }
}

/*****************************************************************************/
