// Copyright (c) 2016 - 2025 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Presentation.Mvvm.Contracts;
using CiccioGest.Presentation.Mvvm.Services;
using CiccioGest.Presentation.Mvvm.ViewModels;
using CiccioGest.Presentation.WinUiMenu.Helpers;
using Microsoft.Extensions.Logging;
using Microsoft.UI.Xaml.Controls;
using System;

namespace CiccioGest.Presentation.WinUiMenu.Services
{
    public sealed class NavigationService : INavigationService, IDisposable
    {
        public event EventHandler? Navigated;

        private readonly ILogger _logger;
        private readonly PageService _pageService;
        private Frame? _frame;
        private static object? _lastParamUsed;

        public NavigationService(ILogger<NavigationService> logger,
                                 PageService pageService)
        {
            _logger = logger;
            _pageService = pageService;
            _logger.LogDebug("Created: {HashCode}", GetHashCode().ToString());
        }

        public void Initialize(Frame shellFrame)
        {
            if (_frame == null)
            {
                _frame = shellFrame;
                _frame.Navigated += OnNavigated;
            }
        }

        public bool FrameContentIsNull => _frame.Content == null;

        public bool CanGoBack => _frame.CanGoBack;

        public bool CanGoForward => _frame.CanGoForward;

        public void GoBack(bool emptyForwardStack = false) => _frame.GoBack();

        public void GoForward(bool emptyForwardStack = false) => _frame.GoForward();

        public void Navigate(Type pageType,
                             object? parameter = null,
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
                    //_oldScope = _scope;
                    //_scope = _serviceScopeFactory.CreateScope();
                }
                _frame.Tag = clearNavigation;

                var navigationResult = _frame.Navigate(pageType, parameter);
                if (navigationResult)
                {
                    _lastParamUsed = parameter;
                }
            }
        }

        public void Navigate(ViewEnum key,
                             object? parameter = null,
                             bool clearNavigation = false)
        {
            var pageType = _pageService.GetPageType(key);
             Navigate(pageType, parameter, clearNavigation);
        }

        private void OnNavigated(object sender, Microsoft.UI.Xaml.Navigation.NavigationEventArgs e)
        {
            if (sender is Frame frame)
            {
                bool clearNavigation = (bool)frame.Tag;
                if (clearNavigation)
                {
                    frame.BackStack.Clear();
                }

                if (frame.GetDataContext() is IViewModel viewModel)
                {
                    viewModel.Initialize(e.Parameter);
                }

                Navigated?.Invoke(this, new EventArgs());
            }
        }

        public void Dispose()
        {
            if (_frame != null)
            {
                _frame.Navigated -= OnNavigated;
            }
            _logger.LogDebug("Disposed: {HashCode}", GetHashCode().ToString());
        }
    }
}
