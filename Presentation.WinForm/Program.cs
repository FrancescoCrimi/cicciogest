using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Ciccio1.Infrastructure;
using Ciccio1.Presentation.WinForm.Views;
using Castle.Core.Logging;
using Ciccio1.Application;
using Castle.Windsor;
using Castle.MicroKernel.Lifestyle;

namespace Ciccio1.Presentation.WinForm
{
    class Program
    {
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool SetProcessDPIAware();

        [STAThread]
        static void Main()
        {
            SetProcessDPIAware();
            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
            System.Windows.Forms.Application.Run(new HomeView());
            //System.Windows.Forms.Application.Run(new ConfigDataAccessView());
        }
    }
}
