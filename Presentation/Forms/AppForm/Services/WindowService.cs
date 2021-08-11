﻿using CiccioGest.Presentation.AppForm.Presenter;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace CiccioGest.Presentation.AppForm.Services
{
    public class WindowService : IDisposable
    {
        private readonly ILogger<WindowService> logger;
        private readonly IServiceScopeFactory serviceScopeFactory;

        public WindowService(ILogger<WindowService> logger,
                             IServiceScopeFactory serviceScopeFactory)
        {
            this.logger = logger;
            this.serviceScopeFactory = serviceScopeFactory;
            logger.LogDebug("Created: " + GetHashCode().ToString());
        }

        public TPresenter OpenWindow<TPresenter>() where TPresenter : IPresenter
        {
            var scope = serviceScopeFactory.CreateScope();
            var window = scope.ServiceProvider.GetService<TPresenter>();
            //void WindowDisposed(object sender, EventArgs e)
            //{
            //    window.Disposed -= WindowDisposed;
            //    scope.Dispose();
            //}
            //window.Disposed += WindowDisposed;
            try
            {
                window.Show();
            }
            catch (Exception ex)
            {
                logger.LogDebug(ex.Message);
            }
            return window;
        }

        public void Dispose()
        {
            logger.LogDebug("Disposed: " + GetHashCode().ToString());
        }
    }
}