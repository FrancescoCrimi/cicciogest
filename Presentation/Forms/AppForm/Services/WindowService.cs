// Copyright (c) 2016 - 2025 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Presentation.AppForm.Presenter;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CiccioGest.Presentation.AppForm.Services
{
    public class WindowService
    {
        private readonly ILogger _logger;
        private readonly IServiceProvider _serviceProvider;

        public WindowService(ILogger<WindowService> logger,
                             IServiceProvider serviceProvider)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
            _logger.LogDebug("Created: " + GetHashCode().ToString());
        }

        public Task Show<TPresenter>(object? parameter = null)
            where TPresenter : PresenterBase
        {
            return Show<TPresenter>(owner: null!, parameter);
        }

        public async Task Show<TPresenter>(IWin32Window owner, object? parameter = null)
            where TPresenter : PresenterBase
        {
            var presenter = _serviceProvider.GetRequiredService<TPresenter>();

            if (presenter is IInitializable init && parameter != null)
                await init.InitializeAsync(parameter);

            if (owner == null)
                presenter.Show();
            else
                presenter.Show(owner);
        }


        public async Task<TResult?> ShowDialog<TPresenter, TResult>(object? parameter = null)
            where TPresenter : PresenterBase, IResultProvider<TResult>
        {
            return await ShowDialog<TPresenter, TResult>(owner: null!, parameter);
        }

        public async Task<TResult?> ShowDialog<TPresenter, TResult>(IWin32Window owner, object? parameter = null)
            where TPresenter : PresenterBase, IResultProvider<TResult>
        {
            var presenter = _serviceProvider.GetRequiredService<TPresenter>();

            if (presenter is IInitializable init && parameter != null)
                await init.InitializeAsync(parameter);

            var dialogResult = owner == null ? presenter.ShowDialog() : presenter.ShowDialog(owner);
            return dialogResult == DialogResult.OK ? presenter.GetResult() : default;
        }



        //public TPresenter? OpenWindow<TPresenter>() where TPresenter : PresenterBase
        //{
        //    var scope = _serviceScopeFactory.CreateScope();
        //    var window = scope.ServiceProvider.GetService<TPresenter>();

        //    void WindowDisposed(object sender, EventArgs e)
        //    {
        //        window.Disposed -= WindowDisposed;
        //        scope.Dispose();
        //    }
        //    window.Disposed += WindowDisposed;

        //    window?.Show();
        //    return window;
        //}
    }
}
