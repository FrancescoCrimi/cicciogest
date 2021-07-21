//using Castle.Facilities.Logging;
//using Castle.MicroKernel.Registration;
//using Castle.Windsor;
using CiccioGest.Application;
using CiccioGest.Application.FakeImpl;
using CiccioGest.Infrastructure.Conf;
using CiccioGest.Presentation.WpfApp1.Contracts;
using CiccioGest.Presentation.WpfApp1.Services;
using GalaSoft.MvvmLight;

namespace CiccioGest.Presentation.WpfApp1.ViewModel
{
    public sealed class ViewModelLocator : ViewModelBase
    {
        private readonly IWindsorContainer windsor;

        public ViewModelLocator()
        {
            if (IsInDesignMode)
            {
                windsor = new WindsorContainer();
                windsor.AddFacility<LoggingFacility>();
                windsor.Register(
                    Component.For<IFatturaService>().ImplementedBy<DesignFatturaService>(),
                    Component.For<IMagazinoService>().ImplementedBy<DesignMagazinoService>(),
                    Component.For<IClientiFornitoriService>().ImplementedBy<DesignClientiFornitoriService>(),
                    Component.For<IWindowManagerService>().ImplementedBy<WindowManagerService>().LifestyleSingleton());
            }
            else
            {
                windsor = App.Windsor;
                CiccioGestConf conf = CiccioGestConfMgr.GetCurrent();
                windsor.Register(
                    Component.For<CiccioGestConf>().Instance(conf),
                    Component.For<IWindowManagerService>().ImplementedBy<WindowManagerService>().LifestyleSingleton());
                windsor.Install(new CiccioGest.Presentation.Client.MyInstaller());
            }
            windsor.Register(
                Component.For<MainViewModel>(),
                Component.For<ListaFattureViewModel>().LifestyleTransient(),
                Component.For<ListaArticoliViewModel>().LifestyleTransient(),
                Component.For<ListaClientiViewModel>().LifestyleTransient(),
                Component.For<CategoriaViewModel>().LifestyleTransient(),
                Component.For<FatturaViewModel>().LifestyleTransient(),
                Component.For<ArticoloViewModel>().LifestyleTransient());
        }

        public MainViewModel Main
        {
            get
            {
                var vm = windsor.Resolve<MainViewModel>();
                return vm;
            }
        }

        public ListaFattureViewModel ListaFatture => windsor.Resolve<ListaFattureViewModel>();
        public ListaArticoliViewModel ListaArticoli => windsor.Resolve<ListaArticoliViewModel>();
        public ListaClientiViewModel ListaClienti => windsor.Resolve<ListaClientiViewModel>();
        public CategoriaViewModel Categoria => windsor.Resolve<CategoriaViewModel>();
        public FatturaViewModel Fattura => windsor.Resolve<FatturaViewModel>();
        public ArticoloViewModel Articolo => windsor.Resolve<ArticoloViewModel>();

        public static void Cleanup()
        {
        }
    }
}
