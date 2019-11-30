using Castle.Facilities.Logging;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using CiccioGest.Application;
using CiccioGest.Infrastructure;
using CiccioGest.Infrastructure.Conf;
using CiccioGest.Presentation.Wpf.App1.Design;
using CiccioGest.Presentation.Wpf.App1.Service;
using GalaSoft.MvvmLight;
using System;

namespace CiccioGest.Presentation.Wpf.App1.ViewModel
{
    public sealed class ViewModelLocator : ViewModelBase, IDisposable
    {
        private readonly IWindsorContainer windsor;

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
            }
            else
            {
                windsor = App.Windsor;
                IConf conf = ConfMgr.ReadConfiguration();
                windsor.Register(
                    Component.For<IConf>().Instance(conf),
                    Component.For<INavigationService>().ImplementedBy<NavigationService>(),
                    Component.For<ISetLifeStyle>().ImplementedBy<SetLifeStyle>());
                windsor.Install(new CiccioGest.Presentation.ClientCore.Installer());
            }
            windsor.Register(
                Component.For<ShellViewModel>().ImplementedBy<ShellViewModel>(),
                Component.For<HomeViewModel>(),
                Component.For<ListaFattureViewModel>().LifestyleTransient(),
                Component.For<ListaArticoliViewModel>().LifestyleTransient(),
                Component.For<CategoriaViewModel>().LifestyleTransient(),
                Component.For<FatturaViewModel>().LifestyleTransient(),
                Component.For<MenuControlViewModel>().LifestyleTransient(),
                Component.For<ArticoloViewModel>().LifestyleTransient());
        }

        public ShellViewModel Shell => windsor.Resolve<ShellViewModel>();
        public ListaFattureViewModel ListaFatture => windsor.Resolve<ListaFattureViewModel>();
        public ListaArticoliViewModel ListaArticoli => windsor.Resolve<ListaArticoliViewModel>();
        public CategoriaViewModel Categoria => windsor.Resolve<CategoriaViewModel>();
        public FatturaViewModel Fattura => windsor.Resolve<FatturaViewModel>();
        public ArticoloViewModel Articolo => windsor.Resolve<ArticoloViewModel>();
        public HomeViewModel Home => windsor.Resolve<HomeViewModel>();
        public MenuControlViewModel MenuControl => windsor.Resolve<MenuControlViewModel>();

        public static void Cleanup()
        {
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
