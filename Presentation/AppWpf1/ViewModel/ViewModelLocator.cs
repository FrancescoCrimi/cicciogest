using Castle.Facilities.Logging;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using CiccioGest.Application;
using CiccioGest.Infrastructure;
using CiccioGest.Infrastructure.Conf;
using CiccioGest.Presentation.AppWpf1.Design;
using CiccioGest.Presentation.AppWpf1.Service;
using GalaSoft.MvvmLight;
using System;

namespace CiccioGest.Presentation.AppWpf1.ViewModel
{
    public class ViewModelLocator : ViewModelBase, IDisposable
    {
        private readonly IWindsorContainer windsor;

        public ViewModelLocator()
        {
            //if (App.InDesignMode())
            if (IsInDesignModeStatic)
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
                Component.For<MainViewModel>().ImplementedBy<MainViewModel>(),
                Component.For<HomeViewModel>(),
                Component.For<SelezionaFatturaViewModel>().LifestyleTransient(),
                Component.For<SelezionaProdottoViewModel>().LifestyleTransient(),
                Component.For<CategoriaViewModel>().LifestyleTransient(),
                Component.For<FatturaViewModel>().LifestyleTransient(),
                Component.For<MenuControlViewModel>().LifestyleTransient(),
                Component.For<ProdottoViewModel>().LifestyleTransient());
        }

        public MainViewModel Main => windsor.Resolve<MainViewModel>();
        public SelezionaFatturaViewModel SelezionaFattura => windsor.Resolve<SelezionaFatturaViewModel>();
        public SelezionaProdottoViewModel SelezionaProdotto => windsor.Resolve<SelezionaProdottoViewModel>();
        public CategoriaViewModel Categoria => windsor.Resolve<CategoriaViewModel>();
        public FatturaViewModel Fattura => windsor.Resolve<FatturaViewModel>();
        public ProdottoViewModel Prodotto => windsor.Resolve<ProdottoViewModel>();
        public HomeViewModel Home => windsor.Resolve<HomeViewModel>();
        public MenuControlViewModel MenuControl => windsor.Resolve<MenuControlViewModel>();

        public static void Cleanup()
        {
        }

        public void Dispose()
        {
        }
    }
}
