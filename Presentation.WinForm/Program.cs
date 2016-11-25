using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Ciccio1.Infrastructure;
using Ciccio1.Presentation.WinForm.Views;
using Castle.Core.Logging;
using Ciccio1.Presentation.WinForm.Presenters;

namespace Ciccio1.Presentation.WinForm
{
    class Program
    {
        private static Container container = null;
        private ILogger logger = null;

        [STAThread]
        static void Main()
        {
            var aa = new Program();
            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
            System.Windows.Forms.Application.Run(aa.runApp());
            //System.Windows.Forms.Application.Run(aa.runConfig());
        }

        Form runApp()
        {
            container = new Container();
            logger = container.Resolve<ILoggerFactory>().Create(this.GetType());
            container.Install(new Installer());
            FatturaPresenter presenter = container.Resolve<FatturaPresenter>();
            return presenter.View;
        }
        Form runConfig()
        {
            return new ConfigDataAccessView();
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
    }
}
