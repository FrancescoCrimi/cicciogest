using CiccioGest.Presentation.WpfApp1.Contracts;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Windows;


namespace CiccioGest.Presentation.WpfApp1.Services
{
    public class WindowManagerService : IWindowManagerService, IDisposable
    {
        private readonly ILogger<WindowManagerService> logger;
        private readonly IServiceScopeFactory serviceScopeFactory;

        public WindowManagerService(ILogger<WindowManagerService> logger,
                                    IServiceScopeFactory serviceScopeFactory)
        {
            this.logger = logger;
            this.serviceScopeFactory = serviceScopeFactory;
            logger.LogDebug("Created: " + GetHashCode().ToString());
        }

        public void OpenWindow(Type windowType, object parameter = null)
        {
            if (windowType.IsAssignableTo(typeof(System.Windows.Window)))
            {
                var scope = serviceScopeFactory.CreateScope();
                var window = (System.Windows.Window)scope.ServiceProvider.GetService(windowType);
                window.Closed += OnWindowClosed;
                void OnWindowClosed(object sender, EventArgs e)
                {
                    scope.Dispose();
                    scope = null;
                    window.Closed -= OnWindowClosed;
                }
                if (window.DataContext is INavigationAware navigationAware)
                {
                    navigationAware.OnNavigatedTo(parameter);
                }
                window.Show();
            }
        }

        public void Dispose()
        {
            logger.LogDebug("Disposed: " + GetHashCode().ToString());
        }
    }
}
