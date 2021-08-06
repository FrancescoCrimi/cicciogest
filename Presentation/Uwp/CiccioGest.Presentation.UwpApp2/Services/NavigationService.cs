using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

namespace CiccioGest.Presentation.UwpApp.Services
{
    public class NavigationService : IDisposable
    {
        private readonly ILogger<NavigationService> logger;
        private readonly IServiceScopeFactory serviceScopeFactory;
        private Frame frame;
        private IServiceScope scope;
        private IServiceScope oldScope;
        private static object _lastParamUsed;

        public NavigationService(ILogger<NavigationService> logger,
                                 IServiceScopeFactory serviceScopeFactory)
        {
            this.logger = logger;
            this.serviceScopeFactory = serviceScopeFactory;
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
                              NavigationTransitionInfo infoOverride = null,
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

                var navigationResult = frame.Navigate(pageType, parameter, infoOverride);
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

        public bool Navigate<T>(object parameter = null,
                                       NavigationTransitionInfo infoOverride = null,
                                       bool clearNavigation = false)
            where T : Page
            => Navigate(typeof(T), parameter, infoOverride, clearNavigation);

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
        }
    }
}
