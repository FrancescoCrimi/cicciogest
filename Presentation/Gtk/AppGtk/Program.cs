using Castle.Facilities.Logging;
using Castle.MicroKernel.Registration;
using Castle.Services.Logging.NLogIntegration;
using Castle.Windsor;
using CiccioGest.Infrastructure;
using CiccioGest.Infrastructure.Conf;
using CiccioGest.Presentation.Gtk.AppGtk.Contracts.Presenter;
using CiccioGest.Presentation.Gtk.AppGtk.Contracts.View;
using CiccioGest.Presentation.Gtk.AppGtk.Presenter;
using CiccioGest.Presentation.Gtk.AppGtk.View;
using System;
using System.Linq;
using ui = Gtk;

namespace CiccioGest.Presentation.Gtk.AppGtk
{
    class Program
    {
        private static IWindsorContainer windsor;

        [STAThread]
        public static void Main(string[] args)
        {
            ui.Application.Init();

            var app = new ui.Application("org.GtkSharp3Try.GtkSharp3Try", GLib.ApplicationFlags.None);
            app.Register(GLib.Cancellable.Current);

            Init();

            var win = windsor.Resolve<IMainPresenter>().View();
            app.AddWindow(win);

            win.Show();
            ui.Application.Run();
        }

        private static void Init()
        {
            windsor = new WindsorContainer();
            windsor.AddFacility<LoggingFacility>(f => f.LogUsing<NLogFactory>().WithConfig("NLog.config"));
            var confmgr = new ConfigurationManager();

            //var colconf = confmgr.GetAll();
            //var mysql = colconf.First(c => c.Name == "sqlite2");
            //confmgr.SetCurrent(mysql);
            //confmgr.Save();

            IAppConf conf = confmgr.GetCurrent();
            windsor.Register(
                Component.For<IAppConf>().Instance(conf),
                Component.For<ISetLifeStyle>().ImplementedBy<SetLifeStyle>());
            windsor.Install(new CiccioGest.Presentation.Client.MyInstaller());

            windsor.Register(
                Component.For<IFatturaPresenter, FatturaPresenter>().ImplementedBy<FatturaPresenter>().LifestyleTransient(),
                Component.For<IListaArticoliPresenter, ListaArticoliPresenter>().ImplementedBy<ListaArticoliPresenter>().LifestyleTransient(),
                Component.For<IListaFatturePresenter, ListaFatturePresenter>().ImplementedBy<ListaFatturePresenter>().LifestyleTransient(),
                Component.For<IMainPresenter, MainPresenter>().ImplementedBy<MainPresenter>().LifestyleTransient(),
                Component.For<IFatturaView, FatturaView>().ImplementedBy<FatturaView>().LifestyleTransient(),
                Component.For<IListaArticoliView, ListaArticoliView>().ImplementedBy<ListaArticoliView>().LifestyleTransient(),
                Component.For<IListaFattureView, ListaFattureView>().ImplementedBy<ListaFattureView>().LifestyleTransient(),
                Component.For<IMainView, MainView>().ImplementedBy<MainView>().LifestyleTransient());
        }
    }
}
