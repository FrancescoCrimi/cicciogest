// Copyright (c) 2016 - 2026 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CiccioGest.Presentation.Mvvm.ViewModels
{
    public sealed partial class DashboardViewModel : ViewModelBase, INavigationAwareAsync
    {
        private bool _disposedValue;
        private readonly ILogger _logger;

        [ObservableProperty]
        private string _title;

        public DashboardViewModel(ILogger<DashboardViewModel> logger)
        {
            _logger = logger;
            Title = "Dashboard";
            _logger.LogDebug("Created: {HashCode}", GetHashCode().ToString());
        }

        public Task OnNavigatedToAsync(object? parameter, CancellationToken cancellationToken = default)
        {
            return Task.CompletedTask;
        }

        public Task OnNavigatedFromAsync(CancellationToken cancellationToken = default)
        {
            return Task.CompletedTask;
        }

        public Task<bool> OnNavigatingFromAsync(CancellationToken cancellationToken = default)
        {
            return Task.FromResult(true);
        }


        [RelayCommand]
        private void OnLoaded() { }


        [RelayCommand]
        private void OnUnloaded() { }


        protected override void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    // Libera le risorse specifiche della classe figlia
                    _logger.LogDebug("Disposed: {HashCode}", GetHashCode().ToString());
                }

                // Chiama sempre la base alla fine
                base.Dispose(disposing);
                _disposedValue = true;
            }
        }
    }
}
