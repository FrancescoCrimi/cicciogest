using Castle.Facilities.Logging;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using CiccioGest.Application;
using CiccioGest.Application.FakeImpl;
using CiccioGest.Infrastructure;
using CiccioGest.Infrastructure.Conf;
using CiccioGest.Presentation.Wpf.App1.Contracts;
using CiccioGest.Presentation.Wpf.App1.Design;
using CiccioGest.Presentation.Wpf.App1.Service;
using CiccioGest.Presentation.Wpf.App1.View;
using GalaSoft.MvvmLight;
using System;
using System.Windows.Controls;

namespace CiccioGest.Presentation.Wpf.App1.ViewModel
{
    public sealed class ViewModelLocator : ViewModelBase, IDisposable
    {
        private IWindsorContainer windsor;
        private INavigationService navigationService;

        public ViewModelLocator()
        {
            if (App.InDesignMode)
            //if (IsInDesignModeStatic)
            {
                windsor = new WindsorContainer();
                windsor.AddFacility<LoggingFacility>();
                windsor.Register(
                    Component.For<IFatturaService>().ImplementedBy<DesignFatturaService>(),
                    Component.For<IMagazinoService>().ImplementedBy<DesignMagazinoService>(),
                    Component.For<IClientiFornitoriService>().ImplementedBy<DesignClientiFornitoriService>(),
                    Component.For<INavigationService>().ImplementedBy<DesignNavigationService>());
                registerVM();
            }
        }

        public void Startup(IWindsorContainer windsorContainer)
        {
            windsor = windsorContainer;
            var confmgr = new ConfigurationManager();
            confmgr.ReadConfiguration();
            IAppConf conf = confmgr.GetCurrent();
            windsor.Register(
                Component.For<IAppConf>().Instance(conf),
                Component.For<INavigationService>().ImplementedBy<NavigationService>(),
                Component.For<ISetLifeStyle>().ImplementedBy<SetLifeStyle>());
            windsor.Install(new CiccioGest.Presentation.Client.MyInstaller());
            registerVM();
        }

        private void registerVM()
        {
            windsor.Register(
                Component.For<ShellView>(),
                Component.For<ShellViewModel>()
                //Component.For<HomeViewModel>().LifestyleTransient(),
                //Component.For<ListaFattureViewModel>().LifestyleTransient(),
                //Component.For<ListaArticoliViewModel>().LifestyleTransient(),
                //Component.For<CategoriaViewModel>().LifestyleTransient(),
                //Component.For<FatturaViewModel>().LifestyleTransient(),
                //Component.For<ArticoloViewModel>().LifestyleTransient()
                );
            Register<HomeViewModel, HomeView>();
            Register<ListaFattureViewModel, ListaFattureView>();
            Register<ListaArticoliViewModel, ListaArticoliView>();
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
            windsor.Resolve<INavigationService>().Configure<V>();
            //windsor.ResolveAll()
        }


        public ShellViewModel Shell => windsor.Resolve<ShellViewModel>();
        public ListaFattureViewModel ListaFatture => windsor.Resolve<ListaFattureViewModel>();
        public ListaArticoliViewModel ListaArticoli => windsor.Resolve<ListaArticoliViewModel>();
        public CategoriaViewModel Categoria => windsor.Resolve<CategoriaViewModel>();
        public FatturaViewModel Fattura => windsor.Resolve<FatturaViewModel>();
        public ArticoloViewModel Articolo => windsor.Resolve<ArticoloViewModel>();
        public HomeViewModel Home => windsor.Resolve<HomeViewModel>();

        public static void Cleanup()
        {
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
