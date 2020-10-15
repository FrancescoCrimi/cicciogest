using Castle.Facilities.Logging;
using Castle.MicroKernel.Registration;
using Castle.Services.Logging.NLogIntegration;
using Castle.Windsor;
using CiccioGest.Infrastructure.Conf;
using CiccioGest.Presentation.AppForm.Views;
using CiccioGest.Presentation.Forms.App1.Views;
using System;

namespace CiccioGest.Presentation.Forms.App1
{
    class Program
    {
        private static IWindsorContainer windsor;

        [STAThread]
        static void Main()
        {
            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
            Init();
            System.Windows.Forms.Application.Run(windsor.Resolve<MainView>());
        }

        private static void Init()
        {
            windsor = new WindsorContainer();
            windsor.AddFacility<LoggingFacility>(f => f.LogUsing<NLogFactory>().WithConfig("NLog.config"));

            var conf = CiccioGestConfMgr.GetCurrent();
            windsor.Register(Component.For<CiccioGestConf>().Instance(conf));

            windsor.Install(new CiccioGest.Presentation.Client.MyInstaller());
            windsor.Register(
                Component.For<MainView>().LifestyleTransient(),
                Component.For<ArticoloView>().LifestyleTransient(),
                Component.For<CategoriaView>().LifestyleTransient(),
                Component.For<FatturaView>().LifestyleTransient(),
                Component.For<ListaClientiView>().LifestyleTransient(),
                Component.For<ListaFornitoriView>().LifestyleTransient(),
                Component.For<ListaArticoliView>().LifeStyle.Transient,
                Component.For<ListaFattureView>().LifestyleTransient(),
                Component.For<ClientiDialog>().LifestyleTransient(),
                Component.For<SettingView>().LifestyleTransient());
        }
    }
}
