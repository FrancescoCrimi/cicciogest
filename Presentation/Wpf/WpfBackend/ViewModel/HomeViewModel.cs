// Copyright (c) 2023 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Extensions.Logging;
using System;

namespace CiccioGest.Presentation.WpfBackend.ViewModel
{
    public sealed class HomeViewModel : ObservableRecipient, IDisposable
    {
        private readonly ILogger logger;

        public HomeViewModel(ILogger<HomeViewModel> logger)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            logger.LogDebug("Created: " + GetHashCode().ToString());
        }

        public void Dispose()
        {
            logger.LogDebug("Disposed: " + GetHashCode().ToString());
        }
    }
}
