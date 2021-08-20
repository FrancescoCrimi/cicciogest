using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CiccioGest.Presentation.WpfApp.Hosting
{
    public class WpfAppLifetime : IHostLifetime, IDisposable
    {
        private readonly ILogger<WpfAppLifetime> logger;
        private readonly IHostApplicationLifetime hostApplicationLifetime;

        public WpfAppLifetime(ILogger<WpfAppLifetime> logger,
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
            logger.LogDebug("WaitForStartAsync: " + GetHashCode().ToString());
            App.Current.Exit += ApplicationExit;
            return Task.CompletedTask;
        }

        private void ApplicationExit(object sender, System.Windows.ExitEventArgs e)
        {
            App.Current.Exit -= ApplicationExit;
            hostApplicationLifetime.StopApplication();
        }

        public void Dispose()
        {
            logger.LogDebug("Disposed: " + GetHashCode().ToString());
        }
    }
}
