using CiccioGest.Presentation.WpfApp1.Contracts;
using Microsoft.Extensions.Logging;
using System;
using System.Windows;

namespace CiccioGest.Presentation.WpfApp1.Services
{
    public class WindowDialogService : IWindowDialogService, IDisposable
    {
        private readonly ILogger<WindowDialogService> logger;
        private readonly IServiceProvider serviceProvider;

        public WindowDialogService(ILogger<WindowDialogService> logger,
                                   IServiceProvider serviceProvider)
        {
            this.logger = logger;
            this.serviceProvider = serviceProvider;
            logger.LogDebug("Created: " + GetHashCode().ToString());
        }

        public bool? OpenDialog(Type windowType, object parameter = null)
        {
            if (windowType.IsAssignableTo(typeof(Window)))
            {

                var window = (Window)serviceProvider.GetService(windowType);
                if (window?.DataContext is INavigationAware navigationAware)
                {
                    navigationAware.OnNavigatedTo(parameter);
                }
                return window.ShowDialog();
            }
            return null;
        }

        public void Dispose()
        {
            logger.LogDebug("Disposed: " + GetHashCode().ToString());
        }
    }
}
