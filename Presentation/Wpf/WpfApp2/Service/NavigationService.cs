using CiccioGest.Presentation.WpfApp.Contracts;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Globalization;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace CiccioGest.Presentation.WpfApp.Service
{
    public class NavigationService : INavigationService
    {
        private readonly ILogger logger;
        private readonly IServiceScopeFactory serviceScopeFactory;
        private Frame frame;
        private bool clearNavigation;
        private IServiceScope scope;
        private IServiceScope oldScope;

        public NavigationService(ILogger<NavigationService> logger, IServiceScopeFactory serviceScopeFactory)
        {
            this.logger = logger;
            this.serviceScopeFactory = serviceScopeFactory;
            logger.LogDebug("HashCode: " + GetHashCode().ToString(CultureInfo.InvariantCulture) + " Created");
        }

        public void Initialize(Frame shellFrame)
        {
            if (frame == null)
            {
                frame = shellFrame;
                frame.Navigated += OnNavigated;
            }
        }

        public bool CanGoBack => frame.CanGoBack;
        public void GoBack() => frame.GoBack();

        public void NavigateTo(Type pageType, bool clearNavigation = false)
        {
            if (frame.Content?.GetType() != pageType)
            {
                if (clearNavigation)
                {
                    oldScope = scope;
                    scope = serviceScopeFactory.CreateScope();
                }
                this.clearNavigation = clearNavigation;

                if (scope == null)
                {
                    scope = serviceScopeFactory.CreateScope();
                }

                var page = scope.ServiceProvider.GetService(pageType);
                frame.Navigate(page);
            }
        }

        private void OnNavigated(object sender, NavigationEventArgs e)
        {
            if (sender is Frame frame)
            {
                if (clearNavigation)
                {
                    while (frame.CanGoBack)
                    {
                        frame.RemoveBackEntry();
                    }
                    if (oldScope != null)
                    {
                        oldScope.Dispose();
                        oldScope = null;
                    }
                }
            }
        }

        public void Dispose()
        {
            frame.Navigated -= OnNavigated;
            if (scope != null)
            {
                scope.Dispose();
                scope = null;
            }
            logger.LogDebug("Disposed " + GetHashCode().ToString());
        }
    }
}
