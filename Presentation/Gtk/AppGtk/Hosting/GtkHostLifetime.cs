using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;
//using System.Windows.Forms;

namespace CiccioGest.Presentation.AppGtk.Hosting
{
    public class GtkHostLifetime : IHostLifetime, IDisposable
    {
        private readonly ILogger<GtkHostLifetime> logger;
        private readonly IHostApplicationLifetime hostApplicationLifetime;

        public GtkHostLifetime(ILogger<GtkHostLifetime> logger,
                                IHostApplicationLifetime hostApplicationLifetime)
        {
            this.logger = logger;
            this.hostApplicationLifetime = hostApplicationLifetime;
            logger.LogDebug("Created: " + GetHashCode().ToString());
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            logger.LogDebug("StopAsync: " + GetHashCode().ToString());
            return Task.CompletedTask;
        }

        public Task WaitForStartAsync(CancellationToken cancellationToken)
        {
            //System.Windows.Forms.Application.SetHighDpiMode(HighDpiMode.SystemAware);
            //System.Windows.Forms.Application.EnableVisualStyles();
            //System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);

            //System.Windows.Forms.Application.ApplicationExit += Application_ApplicationExit;

            logger.LogDebug("WaitForStartAsync: " + GetHashCode().ToString());
            return Task.CompletedTask;
        }

        private void Application_ApplicationExit(object sender, EventArgs e)
        {
            //System.Windows.Forms.Application.ApplicationExit -= Application_ApplicationExit;
            hostApplicationLifetime.StopApplication();
        }

        public void Dispose()
        {
            logger.LogDebug("Disposed: " + GetHashCode().ToString());
        }
    }
}
