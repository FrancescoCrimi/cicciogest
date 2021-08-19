using CiccioGest.Presentation.UwpBackend.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace CiccioGest.Presentation.UwpApp.Services
{
    public class NavigationService : INavigationService, IDisposable
    {
        private readonly ILogger<NavigationService> logger;
        private readonly IServiceScopeFactory serviceScopeFactory;
        private readonly PageService pageService;
        private Frame frame;
        private IServiceScope scope;
        private IServiceScope oldScope;
        private static object _lastParamUsed;

        public NavigationService(ILogger<NavigationService> logger,
                                 IServiceScopeFactory serviceScopeFactory,
                                 PageService pageService)
        {
            this.logger = logger;
            this.serviceScopeFactory = serviceScopeFactory;
            this.pageService = pageService;
            logger.LogDebug("HashCode: " + GetHashCode().ToString() + " Created");
        }

        public void Initialize(Frame shellFrame)
        {
            if (frame == null)
            {
                frame = shellFrame;
                frame.Navigated += OnNavigated;
                frame.NavigationFailed += OnNavigationFailed;
            }
        }

        public bool CanGoBack => frame.CanGoBack;

        public bool CanGoForward => frame.CanGoForward;

        public void GoBack() => frame.GoBack();

        public void GoForward() => frame.GoForward();

        public bool Navigate(Type pageType,
                             object parameter = null,
                             bool clearNavigation = false)
        {
            if (pageType == null || !pageType.IsSubclassOf(typeof(Page)))
            {
                throw new ArgumentException($"Invalid pageType '{pageType}', please provide a valid pageType.", nameof(pageType));
            }

            // Don't open the same page multiple times
            if (frame.Content?.GetType() != pageType || (parameter != null && !parameter.Equals(_lastParamUsed)))
            {
                if (clearNavigation)
                {
                    oldScope = scope;
                    scope = serviceScopeFactory.CreateScope();
                }
                frame.Tag = clearNavigation;
                if (scope == null)
                {
                    scope = serviceScopeFactory.CreateScope();
                }

                var navigationResult = frame.Navigate(pageType, parameter);
                if (navigationResult)
                {
                    _lastParamUsed = parameter;
                }

                return navigationResult;
            }
            else
            {
                return false;
            }
        }

        public bool Navigate(string key,
                             object parameter = null,
                             bool clearNavigation = false)
        {
            var pageType = pageService.GetPageType(key);
            return Navigate(pageType, parameter, clearNavigation);
        }

        private void OnNavigated(object sender, NavigationEventArgs e)
        {
            if (sender is Frame frame)
            {
                bool clearNavigation = (bool)frame.Tag;
                if (clearNavigation)
                {
                    frame.BackStack.Clear();
                }
                if (oldScope != null)
                {
                    oldScope.Dispose();
                    oldScope = null;
                }
            }
        }

        private void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
        }

        public void Dispose()
        {
            frame.Navigated -= OnNavigated;
            frame.NavigationFailed -= OnNavigationFailed;
            logger.LogDebug("Disposed " + GetHashCode().ToString());
        }
    }
}
