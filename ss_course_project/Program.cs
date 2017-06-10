using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

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

            Start();

            form.Show();

            form.FormClosed += m_mainForm_FormClosed;

            Application.Run();
        }

        static void m_mainForm_FormClosed(object sender, FormClosedEventArgs e)
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
        
        static async void Start()
        {
            await controller.Init();
            form.FillByController();   
        }

        static MainForm form;
        static Controller controller = new Controller();
    }
}
