// Copyright (c) 2023 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

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
        private readonly ILogger<NavigationService> _logger;
        private readonly IServiceScopeFactory _serviceScopeFactory;
        private readonly PageService _pageService;
        private Frame _frame;
        private IServiceScope _scope;
        private IServiceScope _oldScope;
        private static object _lastParamUsed;

        public NavigationService(ILogger<NavigationService> logger,
                                 IServiceScopeFactory serviceScopeFactory,
                                 PageService pageService)
        {
            _logger = logger;
            _serviceScopeFactory = serviceScopeFactory;
            _pageService = pageService;
            logger.LogDebug("Created: " + GetHashCode().ToString());
        }

        public void Initialize(Frame shellFrame)
        {
            if (_frame == null)
            {
                _frame = shellFrame;
                _frame.Navigated += OnNavigated;
                _frame.NavigationFailed += OnNavigationFailed;
            }
        }

        public bool CanGoBack => _frame.CanGoBack;

        public bool CanGoForward => _frame.CanGoForward;

        public void GoBack() => _frame.GoBack();

        public void GoForward() => _frame.GoForward();

        public bool Navigate(Type pageType,
                             object parameter = null,
                             bool clearNavigation = false)
        {
            if (pageType == null || !pageType.IsSubclassOf(typeof(Page)))
            {
                throw new ArgumentException($"Invalid pageType '{pageType}', please provide a valid pageType.", nameof(pageType));
            }

            // Don't open the same page multiple times
            if (_frame.Content?.GetType() != pageType || (parameter != null && !parameter.Equals(_lastParamUsed)))
            {
                if (clearNavigation)
                {
                    _oldScope = _scope;
                    _scope = _serviceScopeFactory.CreateScope();
                }
                _frame.Tag = clearNavigation;
                if (_scope == null)
                {
                    _scope = _serviceScopeFactory.CreateScope();
                }

                var navigationResult = _frame.Navigate(pageType, parameter);
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

        public bool Navigate(Views key,
                             object parameter = null,
                             bool clearNavigation = false)
        {
            var pageType = _pageService.GetPageType(key);
            return Navigate(pageType, parameter, clearNavigation);
        }

        public bool FrameContentIsNull => _frame.Content == null;


        private void OnNavigated(object sender, NavigationEventArgs e)
        {
            if (sender is Frame frame)
            {
                bool clearNavigation = (bool)frame.Tag;
                if (clearNavigation)
                {
                    frame.BackStack.Clear();
                }
                if (_oldScope != null)
                {
                    _oldScope.Dispose();
                    _oldScope = null;
                }
            }
        }

        private void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
        }

        public void Dispose()
        {
            _frame.Navigated -= OnNavigated;
            _frame.NavigationFailed -= OnNavigationFailed;
            _logger.LogDebug("Disposed " + GetHashCode().ToString());
        }
    }
}
