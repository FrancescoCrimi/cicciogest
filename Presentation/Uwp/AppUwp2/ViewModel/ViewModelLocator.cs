using Castle.Facilities.Logging;
using Castle.MicroKernel.Registration;
using Castle.Services.Logging.NLogIntegration;
using Castle.Windsor;
using CiccioGest.Application;
using CiccioGest.Infrastructure;
using CiccioGest.Infrastructure.Conf;
using CiccioGest.Presentation.AppUwp2.View;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Views;

namespace CiccioGest.Presentation.AppUwp2.ViewModel
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
                windsor.Register(Component.For<IFatturaService>().ImplementedBy<Design.DesignFatturaService>());
            }
            else
            {
                IConf conf = ConfMgr.ReadConfiguration();
                switch (conf.DataAccess)
                {
                    case Storage.NHibernate:
                        windsor.Register(
                            Component.For<IConf>().Instance(conf),
                            Component.For<ISetLifeStyle>().ImplementedBy<SetLifeStyle>());
                        windsor.Install(new CiccioGest.Application.Impl.Installer());
                        break;
                    case Storage.EF:
                        break;
                    case Storage.Db4o:
                        break;
                    case Storage.WCF:
                        windsor.Register(
                            Component.For<IFatturaService>().ImplementedBy<Wcf.FatturaService>());
                        break;
                    default:
                        break;
                }
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
