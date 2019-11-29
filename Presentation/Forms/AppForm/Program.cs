using Castle.Facilities.Logging;
using Castle.MicroKernel.Registration;
using Castle.Services.Logging.NLogIntegration;
using Castle.Windsor;
using CiccioGest.Infrastructure;
using CiccioGest.Infrastructure.Conf;
using CiccioGest.Presentation.AppForm.Views;
using System;

namespace CiccioGest.Presentation.AppForm
{
    class Program
    {
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool SetProcessDPIAware();
        private readonly IWindsorContainer windsor;


        [STAThread]
        static void Main()
        {
            SetProcessDPIAware();
            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
            new Program();
        }

        public Program()
        {
            windsor = new WindsorContainer();
            windsor.AddFacility<LoggingFacility>(f => f.LogUsing<NLogFactory>().WithConfig("NLog.config"));
            IConf conf = ConfMgr.ReadConfiguration();
            windsor.Register(
                Component.For<IConf>().Instance(conf),
                Component.For<ISetLifeStyle>().ImplementedBy<SetLifeStyle>());
            windsor.Install(new CiccioGest.Application.Installer());
            RegisterComponent();
            System.Windows.Forms.Application.Run(windsor.Resolve<MainView>());
        }

        private void RegisterComponent()
        {
            windsor.Register(
                Component.For<ArticoloView>().LifestyleTransient(),
                Component.For<CategoriaView>().LifestyleTransient(),
                Component.For<SelectArticoloView>().LifeStyle.Transient,
                Component.For<SelectFattureView>().LifestyleTransient(),
                Component.For<FatturaView>().LifestyleTransient(),
                Component.For<MainView>().LifestyleTransient(),
                Component.For<SettingView>().LifestyleTransient());
        }
    }
}
