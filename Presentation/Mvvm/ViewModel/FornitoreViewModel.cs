// Copyright (c) 2016 - 2025 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Application;
using CiccioGest.Domain.ClientiFornitori;
using CiccioGest.Infrastructure;
using CiccioGest.Presentation.Mvvm.Contracts;
using CiccioGest.Presentation.Mvvm.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace CiccioGest.Presentation.Mvvm.ViewModel
{
    public sealed partial class FornitoreViewModel : ObservableObject, IViewModel, IDisposable
    {
        private readonly ILogger<FornitoreViewModel> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly INavigationService _navigationService;
        private readonly IMessageBoxService _messageBoxService;
        private readonly IClientiFornitoriService _clientiFornitoriService;

        [ObservableProperty]
        private Fornitore? _fornitore;

        [ObservableProperty]
        private Indirizzo? _indirizzo;

        public FornitoreViewModel(ILogger<FornitoreViewModel> logger,
                                  IUnitOfWork unitOfWork,
                                  INavigationService navigationService,
                                  IMessageBoxService messageBoxService,
                                  IClientiFornitoriService clientiFornitoriService)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _navigationService = navigationService;
            _messageBoxService = messageBoxService;
            _clientiFornitoriService = clientiFornitoriService;
            _logger.LogDebug("Created: {HashCode}", GetHashCode().ToString());
        }

        public void Initialize(object? parameter)
        {
            if (parameter is FornitoriViewReturn fornitoriViewReturn)
            {
                //_navigationService.GoBack();
                //Task.Run(async () => await ApriFornitore(fornitoriViewReturn.IdFornitore));
                ApriFornitore(fornitoriViewReturn.IdFornitore).ConfigureAwait(false);
            }
        }


        [RelayCommand]
        private void OnLoaded() { }


        [RelayCommand]
        private void OnUnloaded() { }


        [RelayCommand]
        private async Task OnNuovoFornitore()
        {
            await _unitOfWork.BeginAsync();
            var fornitore = new Fornitore();
            Fornitore = null;
            Indirizzo = null;
            Fornitore = fornitore;
            Indirizzo = fornitore.IndirizzoNew;
        }


        [RelayCommand]
        private async Task OnSalvaFornitore()
        {
            if (Fornitore != null)
            {
                try
                {
                    await _clientiFornitoriService.SaveFornitore(Fornitore);
                    await _unitOfWork.CommitAsync();
                }
                catch (Exception ex)
                {
                    await _unitOfWork.RollbackAsync();
                    _messageBoxService.Show("Errore: " + ex.Message);
                    throw;
                }
            }
        }


        [RelayCommand]
        private async Task OnRimuoviFornitore()
        {
            if (Fornitore != null)
            {
                try
                {
                    await _clientiFornitoriService.DeleteFornitore(Fornitore.Id);
                    await _unitOfWork.CommitAsync();
                    await OnNuovoFornitore();
                }
                catch (Exception ex)
                {
                    await _unitOfWork.RollbackAsync();
                    _messageBoxService.Show("Errore: " + ex.Message);
                    throw;
                }
            }
        }


        [RelayCommand]
        private async Task OnApriFornitore()
        {
            await _unitOfWork.BeginAsync();
            FornitoriViewReturnHandler fornitoriViewReturnHandler = FornitoriViewReturnMethod;
            _navigationService.Navigate(ViewEnum.Fornitori, fornitoriViewReturnHandler, false);
        }
        private async Task FornitoriViewReturnMethod(FornitoriViewReturn fornitoriViewReturn)
        {
            if (fornitoriViewReturn.Result == WizardResult.Finished)
            {
                _navigationService.GoBack(true);
                await ApriFornitore(fornitoriViewReturn.IdFornitore);
            }
        }


        private async Task ApriFornitore(int idFornitore)
        {
            if (idFornitore != 0)
            {
                await _unitOfWork.BeginAsync();
                Fornitore fornitore = await _clientiFornitoriService.GetFornitore(idFornitore);
                Fornitore = null;
                Indirizzo = null;
                Fornitore = fornitore;
                Indirizzo = fornitore.IndirizzoNew;
            }
        }


        public void Dispose()
        {
            _logger.LogDebug("Disposed: {HashCode}", GetHashCode().ToString());
        }
    }
}
