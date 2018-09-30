using CiccioGest.Presentation.AppForm.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CiccioGest.Presentation.AppForm
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
