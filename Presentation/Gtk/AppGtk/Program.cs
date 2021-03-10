//using Castle.Facilities.Logging;
//using Castle.MicroKernel.Registration;
//using Castle.Services.Logging.NLogIntegration;
//using Castle.Windsor;
using CiccioGest.Infrastructure.Conf;
using CiccioGest.Presentation.Gtk.AppGtk.View;
using CiccioGest.Presentation.Mvp.Presenter;
using CiccioGest.Presentation.Mvp.View;
using System;
using ui = Gtk;

namespace CiccioGest.Presentation.Gtk.AppGtk
{
    class Program
    {
        //private static IWindsorContainer windsor;

        [STAThread]
        public static void Main(string[] args)
        {
            ui.Application.Init();

            var app = new ui.Application("org.GtkSharp3Try.GtkSharp3Try", GLib.ApplicationFlags.None);
            app.Register(GLib.Cancellable.Current);

            //Init();

            //var win = (ui.Window)windsor.Resolve<MainPresenter>().View;
            //app.AddWindow(win);

            //win.Show();
            ui.Application.Run();
        }

        //private static void Init()
        //{
        //    windsor = new WindsorContainer();
        //    windsor.AddFacility<LoggingFacility>(f => f.LogUsing<NLogFactory>().WithConfig("NLog.config"));

        //    CiccioGestConf conf = CiccioGestConfMgr.GetCurrent();
        //    windsor.Register(Component.For<CiccioGestConf>().Instance(conf));

        //    windsor.Install(new CiccioGest.Presentation.Mvp.Installer());
        //    windsor.Register(
        //        Component.For<IMainView, MainView>().ImplementedBy<MainView>().LifestyleTransient(),
        //        Component.For<IFatturaView, FatturaView>().ImplementedBy<FatturaView>().LifestyleTransient(),
        //        Component.For<IListaArticoliView, ListaArticoliView>().ImplementedBy<ListaArticoliView>().LifestyleTransient(),
        //        Component.For<IListaFattureView, ListaFattureView>().ImplementedBy<ListaFattureView>().LifestyleTransient());
        //}
    }
}
