// Copyright (c) 2016 - 2024 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.Logging;
using System;

namespace CiccioGest.Presentation.Mvvm.ViewModel
{
    public sealed partial class DashboardViewModel : ObservableObject, IViewModel, IDisposable
    {
        private readonly ILogger _logger;

        public DashboardViewModel(ILogger<DashboardViewModel> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _logger.LogDebug("Created: {HashCode}", GetHashCode().ToString());
        }

        public void Initialize(object? parameter)
        {
        }


        [RelayCommand]
        private void OnLoaded() { }


        [RelayCommand]
        private void OnUnloaded() { }


        public void Dispose()
        {
            _logger.LogDebug("Disposed: {HashCode}", GetHashCode().ToString());
        }
    }
}
