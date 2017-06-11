using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

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

            
            Task st = new Task(Start);
            st.Start();

            form.Show();
            
            form.FormClosed += m_mainForm_FormClosed;

            //System.Threading.Thread.Sleep(10000);

            Application.Run();
        }

        static void m_mainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            MessageBox.Show(System.Threading.Thread.CurrentThread.ManagedThreadId.ToString(), "Form closed");
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
            //System.Threading.Thread.Sleep(10000);
            //t.Info("Start() thread id: {0}", System.Threading.Thread.CurrentThread.ManagedThreadId);
            //int id = await controller.Init().ConfigureAwait(false);
            //t.Info("Init controller() thread id: {0}", id);

            //MessageBox.Show(System.Threading.Thread.CurrentThread.ManagedThreadId.ToString(), "Start()");
            int id = await controller.Init();
            //MessageBox.Show(id.ToString(), "Init controller()");

            if (!Application.MessageLoop)
            {
                //MessageBox.Show("No message loop existing", "Start()");
            }
            //else
            //{
                if (form.InvokeRequired)
                {
                //MessageBox.Show("Invoke is required", "Start()");
                form.Invoke(new Action(form.FillByController));
                }
                else
                {
                    //MessageBox.Show("Invoke not required", "Start()");
                    form.FillByController();
                }
            //}
            //form.FillByController();
        }

        static MainForm form;
        static ITracer t = Tracer.Get("Program");
        static Controller controller = new Controller();
    }
}
