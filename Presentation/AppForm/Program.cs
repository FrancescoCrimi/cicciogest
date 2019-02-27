using Castle.MicroKernel.Registration;
using CiccioGest.Infrastructure;
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
            new Program();
            System.Windows.Forms.Application.Run(new MainView());
            //System.Windows.Forms.Application.Run(new ConfigDataAccessView());
        }

        public Program()
        {
            Bootstrap.Windsor.Install(new CiccioGest.Presentation.Client.Installer());
            Bootstrap.Windsor.Register(
                Component.For<ProdottoView>().LifestyleTransient(),
                Component.For<CategoriaView>().LifestyleTransient(),
                Component.For<SelectProdottoView>().LifeStyle.Transient,
                Component.For<SelectFattureView>().LifestyleTransient(),
                Component.For<FatturaView>().LifestyleTransient(),
                Component.For<MainView>().LifestyleTransient());
        }
    }
}
