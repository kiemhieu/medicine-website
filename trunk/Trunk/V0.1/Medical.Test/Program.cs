using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Medical.Test.Windsor;

namespace Medical.Test
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MDITabbed());

            /*
            var container = new WindsorContainer();
            container.Register(Component.For(typeof(ITest)).ImplementedBy(typeof(Windsor.Test)));

            var test = container.Resolve<ITest>();
            test.Speak("Chạy đi con ơi");
             */
        }
    }
}
