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
using System.Linq;

namespace CiccioGest.Presentation.Uwp.App2.ViewModel
{
    public class ViewModelLocator
    {
        private readonly IWindsorContainer windsor;
        public static bool UseDesignTimeData => false;
        public ViewModelLocator()
        {
            var nav = new NavigationService();
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

            if (ViewModelBase.IsInDesignModeStatic || UseDesignTimeData)
            {
                windsor.Register(Component.For<IFatturaService>().ImplementedBy<DesignFatturaService>());
            }
            else
            {
                CiccioGestConf conf = CiccioGestConfMgr.GetCurrent();
                windsor.Register(Component.For<CiccioGestConf>().Instance(conf));
                windsor.Install(new CiccioGest.Presentation.Uwp.Client.MyInstaller());
            }
            windsor.Register(
                Component.For<ShellViewModel>(),
                Component.For<FatturaViewModel>(),
                Component.For<ListaFattureViewModel>());
        }

        public ShellViewModel Shell => windsor.Resolve<ShellViewModel>();
        public FatturaViewModel Fattura => windsor.Resolve<FatturaViewModel>();
        public ArticoloViewModel Articolo => windsor.Resolve<ArticoloViewModel>();
        public CategoriaViewModel Categoria => windsor.Resolve<CategoriaViewModel>();
        public ListaFattureViewModel ListaFatture => windsor.Resolve<ListaFattureViewModel>();
        public ListaArticoliViewModel ListaArticoli => windsor.Resolve<ListaArticoliViewModel>();
    }
}
