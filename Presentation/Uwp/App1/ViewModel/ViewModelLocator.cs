using Castle.Facilities.Logging;
using Castle.MicroKernel.Lifestyle;
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
    public sealed class ViewModelLocator
    {
        private readonly IWindsorContainer windsor;
        public static bool UseDesignTimeData => true;

        public ViewModelLocator()
        {
            var nav = new NavigationService();
            nav.Configure("Main", typeof(MainPage));
            nav.Configure("Fattura", typeof(FatturaPage));
            nav.Configure("Articolo", typeof(ArticoloPage));
            nav.Configure("Categoria", typeof(CategoriaPage));
            nav.Configure("ListaFatture", typeof(ListaFatturePage));
            nav.Configure("ListaArticoli", typeof(ListaArticoliPage));

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
                CiccioGestConf conf = CiccioGestConfMgr.GetCurrent();
                windsor.Register(Component.For<CiccioGestConf>().Instance(conf));
                windsor.Install(new CiccioGest.Presentation.Uwp.Client.MyInstaller());
            }

            windsor.Register(
                Component.For<ShellViewModel>(),
                Component.For<MainViewModel>(),
                Component.For<FatturaViewModel>(),
                Component.For<ArticoloViewModel>(),
                Component.For<CategoriaViewModel>(),
                Component.For<ListaFattureViewModel>(),
                Component.For<ListaArticoliViewModel>());
        }

        public ShellViewModel Shell => windsor.Resolve<ShellViewModel>();
        public MainViewModel Main => windsor.Resolve<MainViewModel>();
        public FatturaViewModel Fatture
        {
            get
            {
                try
                {
                    using (windsor.BeginScope())
                    {
                        var aaa = windsor.Resolve<FatturaViewModel>();
                        return aaa;
                    }
                }
                catch (System.Exception e)
                {
                    throw;
                }
            }
        }

        public ArticoloViewModel Articolo => windsor.Resolve<ArticoloViewModel>();
        public CategoriaViewModel Categoria => windsor.Resolve<CategoriaViewModel>();
        public ListaFattureViewModel ListaFatture => windsor.Resolve<ListaFattureViewModel>();
        public ListaArticoliViewModel ListaArticoli => windsor.Resolve<ListaArticoliViewModel>();
    }
}
