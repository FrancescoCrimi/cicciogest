// Copyright (c) 2016 - 2024 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Presentation.AppForm.Presenter;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Windows.Forms;

namespace CiccioGest.Presentation.AppForm.Services
{
    public class DialogService : IDisposable
    {
        private readonly ILogger _logger;
        private readonly IServiceProvider _serviceProvider;

        public DialogService(ILogger<DialogService> logger,
                             IServiceProvider serviceProvider)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
            _logger.LogDebug("Created: " + GetHashCode().ToString());
        }

        public TPresenter? OpenDialog<TPresenter>(IWin32Window owner) where TPresenter : PresenterBase
        {
            var presenter = _serviceProvider.GetService<TPresenter>();
            presenter?.ShowDialog(owner);
            return presenter;
        }

        public void Dispose()
        {
            _logger.LogDebug("Disposed: " + GetHashCode().ToString());
        }
    }
}
