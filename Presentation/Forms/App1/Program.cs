//using Castle.Facilities.Logging;
//using Castle.MicroKernel.Registration;
//using Castle.Services.Logging.NLogIntegration;
//using Castle.Windsor;
using CiccioGest.Infrastructure.Conf;
using CiccioGest.Presentation.AppForm.View;
using CiccioGest.Presentation.Mvp.Presenter;
using CiccioGest.Presentation.Mvp.View;
using System;

namespace CiccioGest.Presentation.AppForm
{
    class Program
    {
        //private static IWindsorContainer windsor;

        [STAThread]
        static void Main()
        {
            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
            Init();
            //System.Windows.Forms.Application.Run((System.Windows.Forms.Form)windsor.Resolve<MainPresenter>().View);
        }

        private static void Init()
        {
            //windsor = new WindsorContainer();
            //windsor.AddFacility<LoggingFacility>(f => f.LogUsing<NLogFactory>().WithConfig("NLog.config"));

            var conf = CiccioGestConfMgr.GetCurrent();
            //windsor.Register(Component.For<CiccioGestConf>().Instance(conf));

            //windsor.Install(new CiccioGest.Presentation.Mvp.Installer());
            //windsor.Register(
            //    Component.For<IMainView>().ImplementedBy<MainView>().LifestyleTransient(),
            //    Component.For<IListaFattureView>().ImplementedBy<ListaFattureView>().LifestyleTransient(),
            //    Component.For<IFatturaView>().ImplementedBy<FatturaView>().LifestyleTransient(),
            //    Component.For<IListaClientiView>().ImplementedBy<ListaClientiView>().LifestyleTransient(),
            //    Component.For<ICategoriaView>().ImplementedBy<CategoriaView>().LifestyleTransient(),
            //    Component.For<IArticoloView>().ImplementedBy<ArticoloView>().LifestyleTransient(),
            //    Component.For<IListaFornitoriView>().ImplementedBy<ListaFornitoriView>().LifestyleTransient(),
            //    Component.For<IListaArticoliView>().ImplementedBy<ListaArticoliView>().LifeStyle.Transient,
            //    Component.For<ISelectClienteView>().ImplementedBy<SelectClienteView>().LifestyleTransient(),
            //    Component.For<SettingView>().LifestyleTransient());
        }
    }
}
