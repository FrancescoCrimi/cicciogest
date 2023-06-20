// Copyright (c) 2023 Francesco Crimi
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
        private readonly ILogger<DialogService> logger;
        private readonly IServiceProvider serviceProvider;

        public DialogService(ILogger<DialogService> logger,
                             IServiceProvider serviceProvider)
        {
            this.logger = logger;
            this.serviceProvider = serviceProvider;
            logger.LogDebug("Created: " + GetHashCode().ToString());
        }

        public TPresenter OpenDialog<TPresenter>(IWin32Window owner) where TPresenter : PresenterBase
        {
            TPresenter presenter = serviceProvider.GetService<TPresenter>();
            presenter.ShowDialog(owner);
            return presenter;
        }

        public void Dispose()
        {
            logger.LogDebug("Disposed: " + GetHashCode().ToString());
        }
    }
}
