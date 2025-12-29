// Copyright (c) 2016 - 2025 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Infrastructure;
using CiccioGest.Presentation.Mvvm.Services;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace CiccioGest.Presentation.Mvvm.ViewModels
{
    public sealed partial class MainViewModel : ViewModelBase
    {
        private readonly ILogger _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly INavigationService _navigationService;
        private bool _disposedValue;

        public MainViewModel(ILogger<MainViewModel> logger,
                             IUnitOfWork unitOfWork,
                             INavigationService navigationService)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _navigationService = navigationService;
            _navigationService.Navigated += OnNavigated;
            _logger.LogDebug("Created: {HashCode}", GetHashCode().ToString());
        }

        [RelayCommand]
        private void OnLoaded() { }

        [RelayCommand]
        private void OnUnloaded() { }

        [RelayCommand]
        private void OnApriDashboard() { }

        [RelayCommand]
        private async Task OnApriFattura()
        {
            await _unitOfWork.BeginAsync();
            var id = await _navigationService.NavigateDialogAsync<FattureViewModel>();
            if (id != 0)
                _navigationService.Navigate<FatturaViewModel>(new FattureViewReturn(id));
        }

        [RelayCommand]
        private async Task OnNuovaFattura()
        {
            await _unitOfWork.BeginAsync();
            var id = await _navigationService.NavigateDialogAsync<ClientiViewModel>();
            if (id != 0)
                _navigationService.Navigate<FatturaViewModel>(new ClientiViewReturn(id));
        }

        [RelayCommand]
        private async Task OnApriArticoli()
        {
            await _unitOfWork.BeginAsync();
            var id = await _navigationService.NavigateDialogAsync<ArticoliViewModel>();
            if (id != 0)
                _navigationService.Navigate<ArticoloViewModel>(new ArticoliViewReturn(id));
        }

        [RelayCommand]
        private void OnApriCategorie()
            => _navigationService.Navigate<CategoriaViewModel>();

        [RelayCommand]
        private async Task OnApriClienti()
        {
            await _unitOfWork.BeginAsync();
            var id = await _navigationService.NavigateDialogAsync<ClientiViewModel>();
            if (id != 0)
                _navigationService.Navigate<ClienteViewModel>(new ClientiViewReturn(id));
        }

        [RelayCommand]
        private async Task OnApriFornitori()
        {
            await _unitOfWork.BeginAsync();
            var id = await _navigationService.NavigateDialogAsync<FornitoriViewModel>();
            if (id != 0)
                _navigationService.Navigate<FornitoreViewModel>(new FornitoriViewReturn(id));
        }

        [RelayCommand(CanExecute = nameof(CanGoBack))]
        private void OnGoBack() => _navigationService.GoBack();
        private bool CanGoBack() => _navigationService.CanGoBack;


        private void OnNavigated(object? sender, EventArgs e)
        {
            GoBackCommand?.NotifyCanExecuteChanged();
        }

        protected override void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    // Libera le risorse specifiche della classe figlia
                    _navigationService.Navigated -= OnNavigated;
                    _logger.LogDebug("Disposed: {HashCode}", GetHashCode().ToString());
                }

                // Chiama sempre la base alla fine
                base.Dispose(disposing);
                _disposedValue = true;
            }
        }
    }
}
