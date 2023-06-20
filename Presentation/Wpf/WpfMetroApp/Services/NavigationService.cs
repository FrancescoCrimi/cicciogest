// Copyright (c) 2023 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Presentation.WpfBackend.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace CiccioGest.Presentation.WpfMetroApp.Services
{
    public class NavigationService : INavigationService, IDisposable
    {
        private readonly ILogger? logger;
        private readonly IServiceScopeFactory serviceScopeFactory;
        private readonly PageService pageService;
        private Frame? frame;
        private bool clearNavigation;
        private IServiceScope? scope;
        private IServiceScope? oldScope;

        public NavigationService(ILogger<NavigationService> logger,
                                 IServiceScopeFactory serviceScopeFactory,
                                 PageService pageService)
        {
            this.logger = logger;
            this.serviceScopeFactory = serviceScopeFactory;
            this.pageService = pageService;
            logger.LogDebug("HashCode: " + GetHashCode().ToString() + " Created");
        }

        public event EventHandler? Navigated;

        public void Initialize(Frame shellFrame)
        {
            if (frame == null)
            {
                frame = shellFrame;
                frame.Navigated += OnNavigated;
            }
        }

        public bool CanGoBack
        {
            get
            {
                if (frame != null)
                    return frame.CanGoBack;
                else
                    return false;
            }
        }

        public void GoBack() => frame?.GoBack();

        public void NavigateTo(Type pageType,
                               bool clearNavigation = false)
        {
            if (frame?.Content?.GetType() != pageType)
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
                frame?.Navigate(page);
            }
        }

        public void NavigateTo(string key,
                               bool clearNavigation = false)
        {
            var pageType = pageService.GetPageType(key);
            NavigateTo(pageType, clearNavigation);
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
                Navigated?.Invoke(sender, new EventArgs());
            }
        }

        public void Dispose()
        {
            if (frame != null)
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
