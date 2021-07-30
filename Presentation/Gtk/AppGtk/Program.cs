using CiccioGest.Infrastructure.Conf;
using CiccioGest.Presentation.AppGtk.Hosting;
using CiccioGest.Presentation.AppGtk.View;
using CiccioGest.Presentation.Mvp;
using CiccioGest.Presentation.Mvp.Presenter;
using CiccioGest.Presentation.Mvp.View;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NLog.Extensions.Logging;
using System;
using ui = Gtk;

namespace CiccioGest.Presentation.AppGtk
{
    class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            //ui.Application.Init();
            //var app = new ui.Application("org.GtkSharp3Try.GtkSharp3Try", GLib.ApplicationFlags.None);
            //app.Register(GLib.Cancellable.Current);
            ////var win = (ui.Window)windsor.Resolve<MainPresenter>().View;
            ////app.AddWindow(win);
            ////win.Show();
            //ui.Application.Run();
            CreateHostBuilder(args).Build().Run();
        }

        private static IHostBuilder CreateHostBuilder(string[] args)
        {
            var host = Host.CreateDefaultBuilder(args);
            host.ConfigureLogging((hostBuilderContext, loggingBuilder) =>
                    loggingBuilder.AddNLog(hostBuilderContext.Configuration));
            host.ConfigureServices(ConfigureServices);
            host.ConfigureGtk<MainPresenter>();
            return host;
        }

        private static void ConfigureServices(HostBuilderContext hostBuilderContext,
                                              IServiceCollection serviceCollection)
        {
            CiccioGestConf conf = CiccioGestConfMgr.GetCurrent();
            serviceCollection
                .AddSingleton(conf)
                .ConfigureMvp()
                .AddTransient<IMainView, MainView>()
                .AddTransient<IFatturaView, FatturaView>()
                .AddTransient<IListaArticoliView, ListaArticoliView>()
                .AddTransient<IListaFattureView, ListaFattureView>();
        }
    }
}
