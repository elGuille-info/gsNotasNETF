using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gsNotasNETF
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Usar este código SOLAMENTE si nunca se quiere que haya más de una instancia.

            // No permitir más de una instancia en ejecución. (19/oct/22 08.12)
            System.Threading.Mutex mut = new System.Threading.Mutex(false, Application.ProductName);
            bool running = !mut.WaitOne(0, false);
            if (running)
            {
                Application.ExitThread();
                return;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormNotasUC());
        }
    }
}
