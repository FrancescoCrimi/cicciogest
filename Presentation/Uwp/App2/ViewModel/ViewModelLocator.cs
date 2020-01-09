using Castle.Facilities.Logging;
using Castle.MicroKernel.Registration;
using Castle.Services.Logging.NLogIntegration;
using Castle.Windsor;
using CiccioGest.Application;
using CiccioGest.Application.FakeImpl;
using CiccioGest.Infrastructure;
using CiccioGest.Infrastructure.Conf;
using CiccioGest.Presentation.Uwp.App2.View;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Views;

namespace CiccioGest.Presentation.Uwp.App2.ViewModel
{
    public class ViewModelLocator
    {
        private readonly IWindsorContainer windsor;
        public static bool UseDesignTimeData => false;
        public ViewModelLocator()
        {
            var nav = new NavigationService();
            nav.Configure("FatturaPage", typeof(FatturaPage));
            nav.Configure("ListaFatturePage", typeof(ListaFatturePage));

            windsor = new WindsorContainer();
            windsor.AddFacility<LoggingFacility>(f => f.LogUsing<NLogFactory>().WithConfig("NLog.config"));
            windsor.Register(
                Component.For<NavigationService>().Instance(nav),
                Component.For<IDialogService>().ImplementedBy<DialogService>());

            if (ViewModelBase.IsInDesignModeStatic || UseDesignTimeData)
            {
                windsor.Register(Component.For<IFatturaService>().ImplementedBy<DesignFatturaService>());
            }
            else
            {
                //IAppConf conf = ConfigurationManager.ReadConfiguration();
                var confmgr = new CiccioGest.Infrastructure.Conf.Json.ConfigurationManager();
                //confmgr.SampleConf();
                //confmgr.WriteConfiguration();
                confmgr.ReadConfiguration();
                IAppConf conf = confmgr.GetCurrent();
                windsor.Register(
                    Component.For<IAppConf>().Instance(conf),
                    Component.For<ISetLifeStyle>().ImplementedBy<SetLifeStyle>());
                windsor.Install(new CiccioGest.Presentation.Uwp.Client.MyInstaller()); 
            }
            windsor.Register(
                Component.For<ShellViewModel>(),
                Component.For<FatturaViewModel>(),
                Component.For<ListaFattureViewModel>());
        }

        public ShellViewModel Shell => windsor.Resolve<ShellViewModel>();
        public FatturaViewModel Fattura => windsor.Resolve<FatturaViewModel>();
        public ListaFattureViewModel ListaFatture => windsor.Resolve<ListaFattureViewModel>();
    }
}
