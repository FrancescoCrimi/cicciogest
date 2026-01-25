// Copyright (c) 2016 - 2026 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.Logging;
using System;

namespace CiccioGest.Presentation.Mvvm.ViewModels
{
    public sealed partial class SettingsViewModel : ViewModelBase
    {
        private bool _disposedValue;
        private readonly ILogger _logger;

        [ObservableProperty]
        private string _title;

        public SettingsViewModel(ILogger<SettingsViewModel> logger)
        {
            _logger = logger;
            Title = "Setting View";
            _logger.LogDebug("Created: {HashCode}", GetHashCode().ToString());
        }

        public void Initialize(object? parameter)
        {
        }

        [RelayCommand]
        private void OnLoaded()
        {
        }

        [RelayCommand]
        private void OnUnloaded()
        {
        }

        private void LoadSampleData()
        {

        }

        private void VerifyDb()
        {

        }

        private void WriteDb()
        {

        }

        private void WriteConf()
        {

        }

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
