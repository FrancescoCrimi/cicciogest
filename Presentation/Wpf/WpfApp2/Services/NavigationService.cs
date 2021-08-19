﻿using CiccioGest.Presentation.WpfBackend.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace CiccioGest.Presentation.WpfApp.Services
{
    public class NavigationService : INavigationService
    {
        private readonly ILogger logger;
        private readonly IServiceScopeFactory serviceScopeFactory;
        private readonly PageService pageService;
        private Frame frame;
        private bool clearNavigation;
        private IServiceScope scope;
        private IServiceScope oldScope;

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
            }
        }

        public bool CanGoBack => frame.CanGoBack;
        public void GoBack() => frame.GoBack();

        public void NavigateTo(Type pageType,
                               object parameter = null,
                               bool clearNavigation = false)
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

        public void NavigateTo(string key,
                               object parameter = null,
                               bool clearNavigation = false)
        {
            var pageType = pageService.GetPageType(key);
            NavigateTo(pageType, parameter, clearNavigation);
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