using Castle.Facilities.Logging;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using CiccioGest.Application;
using CiccioGest.Application.FakeImpl;
using CiccioGest.Infrastructure.Conf;
using CiccioGest.Presentation.WpfApp2.Contracts;
using CiccioGest.Presentation.WpfApp2.Design;
using CiccioGest.Presentation.WpfApp2.Service;
using CiccioGest.Presentation.WpfApp2.View;
using GalaSoft.MvvmLight;
using System.Windows.Controls;

namespace CiccioGest.Presentation.WpfApp2.ViewModel
{
    public sealed class ViewModelLocator : ViewModelBase
    {
        private IWindsorContainer windsor;

        public ViewModelLocator()
        {
            if (IsInDesignMode)
            {
                windsor = new WindsorContainer();
                windsor.AddFacility<LoggingFacility>();
                windsor.Register(
                    Component.For<IPageService>().ImplementedBy<DesignPageService>(),
                    Component.For<INavigationService>().ImplementedBy<DesignNavigationService>(),
                    Component.For<IFatturaService>().ImplementedBy<DesignFatturaService>(),
                    Component.For<IMagazinoService>().ImplementedBy<DesignMagazinoService>(),
                    Component.For<IClientiFornitoriService>().ImplementedBy<DesignClientiFornitoriService>()
                    );
                RegisterVM();
            }
        }

        public void Startup(IWindsorContainer windsorContainer)
        {
            windsor = windsorContainer;
            CiccioGestConf conf = CiccioGestConfMgr.GetCurrent();
            windsor.Register(
                Component.For<CiccioGestConf>().Instance(conf),
                Component.For<IPageService>().ImplementedBy<PageService>(),
                Component.For<INavigationService>().ImplementedBy<NavigationService>());
            windsor.Install(new CiccioGest.Presentation.Client.MyInstaller());
            RegisterVM();
        }

        private void RegisterVM()
        {
            windsor.Register(
                Component.For<ShellView>(),
                Component.For<ShellViewModel>());
            Register<HomeViewModel, HomeView>();
            Register<ListaFattureViewModel, ListaFattureView>();
            Register<ListaArticoliViewModel, ListaArticoliView>();
            Register<ListaClientiViewModel, ListaClientiView>();
            Register<CategoriaViewModel, CategoriaView>();
            Register<FatturaViewModel, FatturaView>();
            Register<ArticoloViewModel, ArticoloView>();
        }

        private void Register<VM, V>()
            where VM : ViewModelBase
            where V : Page
        {
            windsor.Register(
                Component.For<VM>().LifestyleTransient(),
                Component.For<V>().LifestyleTransient());
            windsor.Resolve<IPageService>().Configure<V>();
        }

        public ShellViewModel Shell => windsor.Resolve<ShellViewModel>();
        public ListaFattureViewModel ListaFatture => windsor.Resolve<ListaFattureViewModel>();
        public ListaArticoliViewModel ListaArticoli => windsor.Resolve<ListaArticoliViewModel>();
        public CategoriaViewModel Categoria => windsor.Resolve<CategoriaViewModel>();
        public FatturaViewModel Fattura => windsor.Resolve<FatturaViewModel>();
        public ArticoloViewModel Articolo => windsor.Resolve<ArticoloViewModel>();
        public HomeViewModel Home => windsor.Resolve<HomeViewModel>();
    }
}
