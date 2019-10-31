using Castle.Facilities.Logging;
using Castle.MicroKernel.Registration;
using Castle.Services.Logging.NLogIntegration;
using Castle.Windsor;
using CiccioGest.Application;
using CiccioGest.Infrastructure;
using CiccioGest.Infrastructure.Conf;
using CiccioGest.Presentation.AppWpfCore.Design;
using GalaSoft.MvvmLight;

namespace CiccioGest.Presentation.AppWpfCore.ViewModel
{
    public class ViewModelLocator
    {
        private readonly IWindsorContainer windsor;

        public ViewModelLocator()
        {
            if (ViewModelBase.IsInDesignModeStatic)
            {
                windsor = new WindsorContainer();
                windsor.AddFacility<LoggingFacility>();
                windsor.Register(
                    Component.For<IFatturaService>().ImplementedBy<DesignFatturaService>(),
                    Component.For<IMagazinoService>().ImplementedBy<DesignMagazinoService>(),
                    Component.For<IClientiFornitoriService>().ImplementedBy<DesignClientiFornitoriService>());
            }
            else
            {
                windsor = App.Windsor;
                IConf conf = ConfMgr.ReadConfiguration();
                windsor.Register(
                    Component.For<IConf>().Instance(conf),
                    Component.For<ISetLifeStyle>().ImplementedBy<SetLifeStyle>());
                //windsor.Install(new CiccioGest.Application.Installer());
                windsor.Install(new CiccioGest.Presentation.ClientCore.Installer());
            }
            windsor.Register(
                Component.For<MainViewModel>(),
                Component.For<SelezionaFatturaViewModel>().LifestyleTransient(),
                Component.For<SelezionaProdottoViewModel>().LifestyleTransient(),
                Component.For<CategoriaViewModel>().LifestyleTransient(),
                Component.For<FatturaViewModel>().LifestyleTransient(),
                Component.For<ProdottoViewModel>().LifestyleTransient());
        }

        public MainViewModel Main => windsor.Resolve<MainViewModel>();
        public SelezionaFatturaViewModel SelezionaFattura => windsor.Resolve<SelezionaFatturaViewModel>();
        public SelezionaProdottoViewModel SelezionaProdotto => windsor.Resolve<SelezionaProdottoViewModel>();
        public CategoriaViewModel Categoria => windsor.Resolve<CategoriaViewModel>();
        public FatturaViewModel Fattura => windsor.Resolve<FatturaViewModel>();
        public ProdottoViewModel Prodotto => windsor.Resolve<ProdottoViewModel>();

        public static void Cleanup()
        {
        }
    }
}
