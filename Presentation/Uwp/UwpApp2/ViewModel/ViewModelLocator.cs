using CiccioGest.Application;
using CiccioGest.Application.FakeImpl;
using CiccioGest.Infrastructure;
using CiccioGest.Infrastructure.Conf;
using System.Linq;

namespace CiccioGest.Presentation.Uwp.App2.ViewModel
{
    public class ViewModelLocator
    {
        //private readonly IWindsorContainer windsor;
        public static bool UseDesignTimeData => false;
        public ViewModelLocator()
        {
            //var nav = new NavigationService();
            //nav.Configure("Fattura", typeof(FatturaPage));
            //nav.Configure("Articolo", typeof(ArticoloPage));
            //nav.Configure("Categoria", typeof(CategoriaPage));
            //nav.Configure("ListaFatture", typeof(ListaFatturePage));
            //nav.Configure("ListaArticoli", typeof(ListaArticoliPage));
            //nav.Configure("ListaClienti", typeof(ListaClientiPage));

            //windsor = new WindsorContainer();
            //windsor.AddFacility<LoggingFacility>(f => f.LogUsing<NLogFactory>().WithConfig("NLog.config"));
            //windsor.Register(
            //    Component.For<NavigationService>().Instance(nav),
            //    Component.For<IDialogService>().ImplementedBy<DialogService>());

            //    CiccioGestConf conf = CiccioGestConfMgr.GetCurrent();
            //    windsor.Register(Component.For<CiccioGestConf>().Instance(conf));
            //    windsor.Install(new CiccioGest.Presentation.Uwp.Client.MyInstaller());

            //windsor.Register(
            //    Component.For<ShellViewModel>(),
            //    Component.For<FatturaViewModel>().LifestyleTransient(),
            //    Component.For<ArticoloViewModel>().LifestyleTransient(),
            //    Component.For<CategoriaViewModel>().LifestyleTransient(),
            //    Component.For<ListaFattureViewModel>().LifestyleTransient(),
            //    Component.For<ListaClientiViewModel>().LifestyleTransient(),
            //    Component.For<ListaArticoliViewModel>().LifestyleTransient()
            //    );
        }

        //public ShellViewModel Shell => windsor.Resolve<ShellViewModel>();
        //public FatturaViewModel Fattura
        //{
        //    get
        //    {
        //        try
        //        {
        //            var aaa = windsor.Resolve<FatturaViewModel>();
        //            return aaa;
        //        }
        //        catch (System.Exception e)
        //        {
                    
        //            throw;
        //        }
        //    }
        //}

        //public ArticoloViewModel Articolo => windsor.Resolve<ArticoloViewModel>();
        //public CategoriaViewModel Categoria => windsor.Resolve<CategoriaViewModel>();
        //public ListaFattureViewModel ListaFatture => windsor.Resolve<ListaFattureViewModel>();
        //public ListaArticoliViewModel ListaArticoli => windsor.Resolve<ListaArticoliViewModel>();
        //public ListaClientiViewModel ListaClienti => windsor.Resolve<ListaClientiViewModel>();

    }
}
