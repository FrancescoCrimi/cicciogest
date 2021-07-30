using CiccioGest.Presentation.Mvp.Presenter;
using CiccioGest.Presentation.Mvp.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CiccioGest.Presentation.AppGtk.Hosting
{
    public class GtkHostedService<TPresenter> : IHostedService, IDisposable where TPresenter : IPresenter
    {
        private readonly ILogger logger;
        private readonly WindowService windowService;
        private readonly IServiceProvider serviceProvider;

        public GtkHostedService(ILogger<GtkHostedService<TPresenter>> logger,
                                 WindowService windowService,
                                 IServiceProvider serviceProvider)
        {
            this.logger = logger;
            this.windowService = windowService;
            this.serviceProvider = serviceProvider;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested)
            {
                return Task.CompletedTask;
            }
            Gtk.Application.Init();
            var app = new Gtk.Application("org.GtkSharp3Try.GtkSharp3Try", GLib.ApplicationFlags.None);
            app.Register(GLib.Cancellable.Current);
            var win = (Gtk.Window)serviceProvider.GetService<TPresenter>().View;
            app.AddWindow(win);
            win.Show();
            Gtk.Application.Run();

            logger.LogDebug("StartAsync: " + GetHashCode().ToString());
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            logger.LogDebug("Stopping WinForms application.");
            //foreach (var form in System.Windows.Forms.Application.OpenForms.Cast<Form>().ToList())
            //{
            //    try
            //    {
            //        form.Close();
            //        form.Dispose();
            //    }
            //    catch (Exception ex)
            //    {
            //        logger.LogWarning(ex, "Couldn't cleanup a Form");
            //    }
            //}
            //System.Windows.Forms.Application.ExitThread();
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            logger.LogDebug("Disposed: " + GetHashCode().ToString());
        }
    }
}
