using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Ciccio1.Infrastructure;
using Ciccio1.Presentation.WinForm.Views;
using Castle.Core.Logging;
using Ciccio1.Presentation.WinForm.Presenters;
using Ciccio1.Application;

namespace Ciccio1.Presentation.WinForm
{
    class Program
    {
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool SetProcessDPIAware();

        internal static Container Container { get; private set; }

        [STAThread]
        static void Main()
        {
            SetProcessDPIAware();
            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
            var aa = new Program();
        }

        private Program()
        {
            startup();
            //dummyload();
            //System.Windows.Forms.Application.Run(new ConfigDataAccessView());
        }

        private void startup()
        {
            Container = new Container();
            Container.Install(new Installer());
            //FatturaPresenter presenter = Container.Resolve<FatturaPresenter>();
            //System.Windows.Forms.Application.Run(presenter.View);
            FatturaView fv = Container.Resolve<FatturaView>();
            System.Windows.Forms.Application.Run(fv);
            //FattureForm fatt = container.Resolve<FattureForm>();
            //System.Windows.Forms.Application.Run(fatt);
        }

        private void dummyload()
        {
            Container container = new Container();
            container.Install(new Installer());
            ICiccioService service = container.Resolve<ICiccioService>();
            new LoadData(service);
        }

        //public Program()
        //{
        //    try
        //    {
        //    }
        //    catch (DataAccessException daex)
        //    {
        //        MessageBox.Show("Errore Di Accesso ai Dati; " + daex.Message);
        //        System.Windows.Forms.Application.Run(new ConfigDataAccessView());
        //    }
        //    catch (Castle.MicroKernel.ComponentActivator.ComponentActivatorException caex)
        //    {
        //        if (caex.InnerException is System.Reflection.TargetInvocationException)
        //        {
        //            if (caex.InnerException.InnerException is DataAccessException)
        //            {
        //                MessageBox.Show("Errore Di Accesso ai Dati: " + caex.InnerException.InnerException.Message);
        //                System.Windows.Forms.Application.Run(new ConfigDataAccessView());
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Errore: " + ex.Message);
        //    }
        //}

        //Form runApp()
        //{
        //    container = new Container();
        //    logger = container.Resolve<ILoggerFactory>().Create(this.GetType());
        //    container.Install(new Installer());
        //    FatturaPresenter presenter = container.Resolve<FatturaPresenter>();
        //    return presenter.View;
        //}

        //Form runConfig()
        //{
        //    return new ConfigDataAccessView();
        //}
    }
}
