using CiccioGest.Presentation.WpfApp1.Contracts;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace CiccioGest.Presentation.WpfApp1.Hosting
{
    public class WpfAppHostedService<TWindow> : IHostedService, IDisposable where TWindow : Window
    {
        private readonly ILogger logger;
        private readonly IWindowManagerService windowManagerService;

        public WpfAppHostedService(ILogger<WpfAppHostedService<TWindow>> logger,
                                   IWindowManagerService windowManagerService)
        {
            this.logger = logger;
            this.windowManagerService = windowManagerService;
            logger.LogDebug("Created: " + GetHashCode().ToString());
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            windowManagerService.OpenWindow(typeof(TWindow));
            logger.LogDebug("StartAsync: " + GetHashCode().ToString());
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            logger.LogDebug("StopAsync: " + GetHashCode().ToString());
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            logger.LogDebug("Disposed" + GetHashCode().ToString());
        }
    }
}
