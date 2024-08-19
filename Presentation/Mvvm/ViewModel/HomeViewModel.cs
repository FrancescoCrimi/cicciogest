﻿// Copyright (c) 2016 - 2024 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Extensions.Logging;
using System;

namespace CiccioGest.Presentation.Mvvm.ViewModel
{
    public sealed partial class HomeViewModel : ObservableObject, IDisposable
    {
        private readonly ILogger _logger;

        public HomeViewModel(ILogger<HomeViewModel> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _logger.LogDebug("Created: {HashCode}", GetHashCode().ToString());
        }

        public void Dispose()
        {
            _logger.LogDebug("Disposed: {HashCode}", GetHashCode().ToString());
        }
    }
}
