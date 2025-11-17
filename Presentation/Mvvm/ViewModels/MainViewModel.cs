// Copyright (c) 2016 - 2025 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Infrastructure;
using CiccioGest.Presentation.Mvvm.Contracts;
using CiccioGest.Presentation.Mvvm.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace CiccioGest.Presentation.Mvvm.ViewModels
{
    public sealed partial class MainViewModel : ObservableObject, IViewModel, IDisposable
    {
        private readonly ILogger _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly INavigationService _navigationService;

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

        public void Initialize(object? parameter)
        {
        }


        [RelayCommand]
        private void OnLoaded() { }


        [RelayCommand]
        private void OnUnloaded() { }


        [RelayCommand]
        private void OnApriDashboard()
        {

        }


        [RelayCommand]
        private async Task OnApriFattura()
        {
            await _unitOfWork.BeginAsync();
            _navigationService.Navigate(ViewEnum.Fatture, (FattureViewReturnHandler)FattureViewReturnMethod, false);
        }
        private Task FattureViewReturnMethod(FattureViewReturn fattureViewReturn)
        {
            if (fattureViewReturn.Result == WizardResult.Finished)
            {
                _navigationService.Navigate(ViewEnum.Fattura, fattureViewReturn);
            }
            return Task.CompletedTask;
        }


        [RelayCommand]
        private async Task OnNuovaFattura()
        {
            await _unitOfWork.BeginAsync();
            _navigationService.Navigate(ViewEnum.Fatture, (FattureViewReturnHandler)NuovaFatturaViewReturnMethod, false);
        }
        private async Task NuovaFatturaViewReturnMethod(FattureViewReturn fattureViewReturn)
        {
            await Task.CompletedTask;
        }


        [RelayCommand]
        private async Task OnApriArticoli()
        {
            await _unitOfWork.BeginAsync();
            ArticoliViewReturnHandler articoliViewReturnHandler = ArticoliViewReturnMethod;
            _navigationService.Navigate(ViewEnum.Articoli, articoliViewReturnHandler, false);
        }
        private async Task ArticoliViewReturnMethod(ArticoliViewReturn articoliViewReturn)
        {
            if (articoliViewReturn.Result == WizardResult.Finished)
            {
                _navigationService.Navigate(ViewEnum.Articolo, articoliViewReturn);
            }
            await Task.CompletedTask;
        }


        [RelayCommand]
        private void OnApriCategorie()
            => _navigationService.Navigate(ViewEnum.Categoria);


        [RelayCommand]
        private async Task OnApriClienti()
        {
            await _unitOfWork.BeginAsync();
            ClientiViewReturnHandler clientiViewReturnHandler = ClientiViewReturnMethod;
            _navigationService.Navigate(ViewEnum.Clienti, clientiViewReturnHandler, false);
        }
        private Task ClientiViewReturnMethod(ClientiViewReturn clientiViewReturn)
        {
            if (clientiViewReturn.Result == WizardResult.Finished)
            {
                _navigationService.Navigate(ViewEnum.Cliente, clientiViewReturn);
            }
            return Task.CompletedTask;
        }


        [RelayCommand]
        private async Task OnApriFornitori()
        {
            await _unitOfWork.BeginAsync();
            FornitoriViewReturnHandler fornitoriViewReturnHandler = FornitoriViewReturnMethod;
            _navigationService.Navigate(ViewEnum.Fornitori, fornitoriViewReturnHandler, false);
        }
        private Task FornitoriViewReturnMethod(FornitoriViewReturn fornitoriViewReturn)
        {
            if (fornitoriViewReturn.Result == WizardResult.Finished)
            {
                _navigationService.Navigate(ViewEnum.Fornitore, fornitoriViewReturn);
            }
            return Task.CompletedTask;
        }


        [RelayCommand]
        private void MenuItem(Type type)
        {
            if (type != null)
                _navigationService.Navigate(type);
        }


        [RelayCommand(CanExecute = nameof(CanGoBack))]
        private void OnGoBack() => _navigationService.GoBack();
        private bool CanGoBack() => _navigationService.CanGoBack;


        private void OnNavigated(object? sender, EventArgs e)
        {
            GoBackCommand?.NotifyCanExecuteChanged();
        }


        public void Dispose()
        {
            _navigationService.Navigated -= OnNavigated;
            _logger.LogDebug("Disposed: {HashCode}", GetHashCode().ToString());
        }
    }
}
