using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

/*****************************************************************************/

using ss_course_project.services;
using ss_course_project.gui.Forms;

/*****************************************************************************/

namespace ss_course_project.gui
{
    static class Program
    {
        /*-------------------------------------------------------------------*/

        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            form = new MainForm(controller);

            start_task.Start();

            form.Show();

            form.FormClosed += m_mainForm_FormClosed;

            Application.Run();
        }

        /*-------------------------------------------------------------------*/

        static void CleanupAndExit(bool isForced = false)
        {
            var result = MessageBox.Show(
                "Save settings?"
                , "Exit dialog"
                , MessageBoxButtons.YesNo
                , MessageBoxIcon.Exclamation
                , isForced ? MessageBoxDefaultButton.Button2 : MessageBoxDefaultButton.Button1
                );

            if (result == DialogResult.Yes)
            {
                controller.SaveSettings();
            }

            form.FormClosed -= m_mainForm_FormClosed;

            controller.Dispose();
            Application.Exit();
        }

        /*-------------------------------------------------------------------*/

        static void m_mainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            CleanupAndExit();
        }

        /*-------------------------------------------------------------------*/

        static async void Start()
        {
            RestoreSettingsOrExit();
            await ControllerInitOrExit();

            if (form.InvokeRequired)
            {
                form.Invoke(new Action(form.FillByController));
            }
            else
            {
                form.FillByController();
            }
        }

        /*-------------------------------------------------------------------*/

        static void RestoreSettingsOrExit()
        {
            try
            {
                controller.RestoreSettings();
            }
            catch (Exception e)
            {
                MessageBox.Show(
                    string.Format(
                        "{0}\n\nPlease, fix or remove config file at {1}\n\nApplication will be closed"
                        , e.Message
                        , (string)e.Data["ConfigPath"]
                    )
                    , "Failed to restore settings"
                    , MessageBoxButtons.OK
                    , MessageBoxIcon.Error
                    );

                CleanupAndExit();
            }
        }

        /*-------------------------------------------------------------------*/

        static async Task ControllerInitOrExit()
        {
            while (true)
            {
                try
                {
                    await controller.Init();
                    break;
                }
                catch (Exception e)
                {
                    DialogResult result = MessageBox.Show(
                    string.Format(
                        "{0}\n\nPlease, check your settings and broker availability"
                        , e.Message
                    )
                    , "Failed to restore connection"
                    , MessageBoxButtons.RetryCancel
                    , MessageBoxIcon.Error
                    );

                    if (result == DialogResult.Retry)
                    {
                        controller.RemoveConnections();
                        continue;
                    }
                    else
                    {
                        CleanupAndExit();
                    }
                }
            }
        }

        /*-------------------------------------------------------------------*/

        static MainForm form;
        static Controller controller = new Controller();
        static Task start_task = new Task(Start);

        /*-------------------------------------------------------------------*/
    }
}
