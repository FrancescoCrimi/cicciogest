using Castle.Facilities.Logging;
using Castle.MicroKernel.Registration;
using Castle.Services.Logging.NLogIntegration;
using Castle.Windsor;
using CiccioGest.Infrastructure.Conf;
//using CiccioGest.Presentation.AppForm.Presenter;
using CiccioGest.Presentation.AppForm.Views;
using CiccioGest.Presentation.Mvp.Presenter;
using CiccioGest.Presentation.Mvp.View;
//using CiccioGest.Presentation.Forms.App1.Views;
using System;

namespace CiccioGest.Presentation.AppForm
{
    class Program
    {
        private static IWindsorContainer windsor;

        [STAThread]
        static void Main()
        {
            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
            Init();
            System.Windows.Forms.Application.Run((System.Windows.Forms.Form)windsor.Resolve<MainPresenter>().View);
        }

        private static void Init()
        {
            windsor = new WindsorContainer();
            windsor.AddFacility<LoggingFacility>(f => f.LogUsing<NLogFactory>().WithConfig("NLog.config"));

            var conf = CiccioGestConfMgr.GetCurrent();
            windsor.Register(Component.For<CiccioGestConf>().Instance(conf));

            windsor.Install(new CiccioGest.Presentation.Client.MyInstaller());
            windsor.Register(
                Component.For<IMainView>().ImplementedBy<MainView>().LifestyleTransient(),
                Component.For<MainPresenter>().LifestyleTransient(),
                Component.For<IListaFattureView>().ImplementedBy<ListaFattureView>().LifestyleTransient(),
                Component.For<ListaFatturePresenter>().LifestyleTransient(),
                Component.For<IFatturaView>().ImplementedBy<FatturaView>().LifestyleTransient(),
                Component.For<FatturaPresenter>().LifestyleTransient(),
                Component.For<IListaClientiView>().ImplementedBy<ListaClientiView>().LifestyleTransient(),
                Component.For<ListaClientiPresenter>().LifestyleTransient(),
                Component.For<ICategoriaView>().ImplementedBy<CategoriaView>().LifestyleTransient(),
                Component.For<CategoriaPresenter>().LifestyleTransient(),

                Component.For<ArticoloView>().LifestyleTransient(),
                Component.For<ListaFornitoriView>().LifestyleTransient(),
                Component.For<ListaArticoliView>().LifeStyle.Transient,
                Component.For<ClientiDialog>().LifestyleTransient(),
                Component.For<SettingView>().LifestyleTransient());
        }
    }
}
