using Castle.Facilities.Logging;
using Castle.MicroKernel.Registration;
using Castle.Services.Logging.NLogIntegration;
using Castle.Windsor;
using CiccioGest.Infrastructure;
using CiccioGest.Infrastructure.Conf;
using CiccioGest.Presentation.Forms.App1.Views;
using System;
using System.Reflection;

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
            IAppConf conf = ConfigurationManager.ReadConfiguration();
            //var confmgr = new CiccioGest.Infrastructure.Conf.Json.ConfigurationManager();
            ////confmgr.SampleConf();
            ////confmgr.WriteConfiguration();
            //confmgr.ReadConfiguration();
            //IAppConf conf = confmgr.GetCurrent();
            windsor.Register(
                Component.For<IAppConf>().Instance(conf),
                Component.For<ISetLifeStyle>().ImplementedBy<SetLifeStyle>());
            windsor.Install(new CiccioGest.Presentation.Client.MyInstaller());
            windsor.Register(
                Component.For<ArticoloView>().LifestyleTransient(),
                Component.For<CategoriaView>().LifestyleTransient(),
                Component.For<ListaArticoliView>().LifeStyle.Transient,
                Component.For<ListaFattureView>().LifestyleTransient(),
                Component.For<FatturaView>().LifestyleTransient(),
                Component.For<MainView>().LifestyleTransient(),
                Component.For<SettingView>().LifestyleTransient());
        }
    }
}
