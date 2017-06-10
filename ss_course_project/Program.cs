using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Net.Mqtt;

using ss_course_project.services;
using ss_course_project.gui.Forms;

namespace ss_course_project.gui
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            form = new MainForm(controller);
            lost_form = new ConnectionLostForm();

            Start();

            form.Show();

            form.FormClosed += m_mainForm_FormClosed;

            Application.Run();
        }

        static void exit()
        {
            var result = MessageBox.Show(
                "Save settings?"
                , "Exit dialog"
                , MessageBoxButtons.YesNo
                , MessageBoxIcon.Exclamation
                );

            if (result == DialogResult.Yes)
            {
                controller.SaveSettings();
            }

            controller.Dispose();
            Application.ExitThread();
        }

        static void m_mainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            exit();
        }
        
        static async void Start()
        {
            while (true)
            {
                try
                {
                    await controller.Init();
                    await controller.ConnectAll();
                    break;
                }
                catch (MqttClientException)
                {
                    DialogResult result = lost_form.ShowDialog();

                    controller.Dispose();

                    if (result == DialogResult.Abort)
                    {
                        exit();
                    }
                    else
                    {
                        continue;
                    }
                }
            }
            
            form.FillByController();
        }

        static MainForm form;
        static Controller controller = new Controller();
        static Form lost_form;
    }
}
