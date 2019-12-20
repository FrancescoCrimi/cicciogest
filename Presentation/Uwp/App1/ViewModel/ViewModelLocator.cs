using Castle.Facilities.Logging;
using Castle.MicroKernel.Registration;
using Castle.Services.Logging.NLogIntegration;
using Castle.Windsor;
using CiccioGest.Application;
using CiccioGest.Application.FakeImpl;
using CiccioGest.Infrastructure;
using CiccioGest.Infrastructure.Conf;
using CiccioGest.Presentation.Uwp.App1.View;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Views;

namespace CiccioGest.Presentation.Uwp.App1.ViewModel
{
    public class ViewModelLocator
    {
        private readonly IWindsorContainer windsor;
        public static bool UseDesignTimeData => true;

        public ViewModelLocator()
        {
            var nav = new NavigationService();
            nav.Configure("MainPage", typeof(View.MainPage));
            nav.Configure("FatturaPage", typeof(FatturaPage));
            nav.Configure("ListaFatturePage", typeof(ListaFatturePage));
            nav.Configure("ListaArticoliPage", typeof(ListaArticoliPage));

            windsor = new WindsorContainer();
            windsor.AddFacility<LoggingFacility>(f => f.LogUsing<NLogFactory>().WithConfig("NLog.config"));

            windsor.Register(
                Component.For<NavigationService>().Instance(nav),
                Component.For<IDialogService>().ImplementedBy<DialogService>());

            //if (ViewModelBase.IsInDesignModeStatic || UseDesignTimeData)                
            if (ViewModelBase.IsInDesignModeStatic)
            {
                windsor.Register(
                    Component.For<IMagazinoService>().ImplementedBy<DesignMagazinoService>(),
                    Component.For<IFatturaService>().ImplementedBy<DesignFatturaService>());
            }
            else
            {
                //logger = Windsor.Resolve<ILoggerFactory>().Create("AppUwp.ViewModel.ViewModelLocator");
                IConf conf = ConfMgr.ReadConfiguration();
                windsor.Register(
                    Component.For<IConf>().Instance(conf),
                    Component.For<ISetLifeStyle>().ImplementedBy<SetLifeStyle>());
                windsor.Install(new CiccioGest.Presentation.Uwp.Client.MyInstaller());
            }

            windsor.Register(
                Component.For<ShellViewModel>(),
                Component.For<MainViewModel>(),
                Component.For<FatturaViewModel>(),
                Component.For<ListaFattureViewModel>(),
                Component.For<ListaArticoliViewModel>());
        }

        public ShellViewModel Shell => windsor.Resolve<ShellViewModel>();
        public MainViewModel Main => windsor.Resolve<MainViewModel>();
        public FatturaViewModel Fattura => windsor.Resolve<FatturaViewModel>();
        public ListaFattureViewModel ListaFatture => windsor.Resolve<ListaFattureViewModel>();
        public ListaArticoliViewModel ListaArticoli => windsor.Resolve<ListaArticoliViewModel>();
    }
}
