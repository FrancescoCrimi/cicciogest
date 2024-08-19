// Copyright (c) 2016 - 2024 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Infrastructure;
using CiccioGest.Presentation.Mvvm.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace CiccioGest.Presentation.Mvvm.ViewModel
{
    public sealed partial class MainViewModel : ObservableObject, IDisposable
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
            logger.LogDebug("Created: {HashCode}", GetHashCode().ToString());
        }

        [RelayCommand]
        private async Task OnApriFatture()
        {
            await _unitOfWork.BeginAsync();
            FattureViewReturnHandler fattureViewReturnHandler = FattureViewReturnMethod;
            _navigationService.Navigate(nameof(FattureViewModel), fattureViewReturnHandler, false);

            //_navigationService.Navigate(nameof(FattureViewModel), null, false);
            //int idFattura = await Messenger.Send<IdFatturaRequestMessage>();
            //_navigationService.Navigate(nameof(FatturaViewModel));
            //Messenger.Send(new IdFatturaMessage(idFattura));
        }
        private Task FattureViewReturnMethod(FattureViewReturn fattureViewReturn)
        {
            if (fattureViewReturn.Result == WizardResult.Finished)
            {
                _navigationService.Navigate(nameof(FatturaViewModel), fattureViewReturn);
            }
            return Task.CompletedTask;
        }


        [RelayCommand]
        private async Task OnApriArticoli()
        {
            await _unitOfWork.BeginAsync();

            ArticoliViewReturnHandler articoliViewReturnHandler = ArticoliViewReturnMethod;
            _navigationService.Navigate(nameof(ArticoliViewModel), articoliViewReturnHandler, false);

            //_navigationService.Navigate(nameof(ArticoliViewModel), null, false);
            //int idArticolo = await Messenger.Send<IdArticoloRequestMessage>();
            //_navigationService.Navigate(nameof(ArticoloViewModel));
            //Messenger.Send(new IdArticoloMessage(idArticolo));
        }
        private async Task ArticoliViewReturnMethod(ArticoliViewReturn articoliViewReturn)
        {
            if (articoliViewReturn.Result == WizardResult.Finished)
            {
                _navigationService.Navigate(nameof(ArticoloViewModel), articoliViewReturn);
            }
            await Task.CompletedTask;
        }


        [RelayCommand]
        private void OnApriCategorie()
            => _navigationService.Navigate(nameof(CategoriaViewModel));


        [RelayCommand]
        private async Task OnApriClienti()
        {
            await _unitOfWork.BeginAsync();
            ClientiViewReturnHandler clientiViewReturnHandler = ClientiViewReturnMethod;
            _navigationService.Navigate(nameof(ClientiViewModel), clientiViewReturnHandler, false);

            //_navigationService.Navigate(nameof(ClientiViewModel), null, false);
            //int idCliente = await Messenger.Send<IdClienteRequestMessage>();
            //_navigationService.Navigate(nameof(ClienteViewModel));
            //Messenger.Send(new IdClienteMessage(idCliente));
        }
        private Task ClientiViewReturnMethod(ClientiViewReturn clientiViewReturn)
        {
            if (clientiViewReturn.Result == WizardResult.Finished)
            {
                _navigationService.Navigate(nameof(ClienteViewModel), clientiViewReturn);
            }
            return Task.CompletedTask;
        }


        [RelayCommand]
        private async Task OnApriFornitori()
        {
            await _unitOfWork.BeginAsync();
            FornitoriViewReturnHandler fornitoriViewReturnHandler = FornitoriViewReturnMethod;
            _navigationService.Navigate(nameof(FornitoriViewModel), fornitoriViewReturnHandler, false);

            //_navigationService.Navigate(nameof(FornitoriViewModel), null, false);
            //int idFornitore = await Messenger.Send<IdFornitoreRequestMessage>();
            //_navigationService.Navigate(nameof(FornitoreViewModel));
            //Messenger.Send(new IdFornitoreMessage(idFornitore));
        }
        private Task FornitoriViewReturnMethod(FornitoriViewReturn fornitoriViewReturn)
        {
            if (fornitoriViewReturn.Result == WizardResult.Finished)
            {
                _navigationService.Navigate(nameof(FornitoreViewModel), fornitoriViewReturn);
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
