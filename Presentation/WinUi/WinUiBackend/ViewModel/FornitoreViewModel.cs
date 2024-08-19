// Copyright (c) 2023 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Application;
using CiccioGest.Domain.ClientiFornitori;
using CiccioGest.Infrastructure;
using CiccioGest.Presentation.WinUiBackend.Contracts;
using CiccioGest.Presentation.WinUiBackend.Contracts.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Extensions.Logging;
using System;
using System.Windows.Input;


namespace CiccioGest.Presentation.WinUiBackend.ViewModel
{
    public partial class FornitoreViewModel : ObservableRecipient, IDisposable
    {
        private readonly ILogger<FornitoreViewModel> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly INavigationService _navigationService;
        //private readonly IMessageBoxService messageBoxService;
        private readonly IClientiFornitoriService _clientiFornitoriService;
        private RelayCommand loadedCommand;
        private RelayCommand nuovoFornitoreCommand;
        private AsyncRelayCommand salvaFornitoreCommand;
        private RelayCommand apriFornitoreCommand;
        private AsyncRelayCommand eliminaFornitoreCommand;

        public FornitoreViewModel(ILogger<FornitoreViewModel> logger,
                                  IUnitOfWork unitOfWork,
                                  INavigationService navigationService,
                                  //IMessageBoxService messageBoxService,
                                  IClientiFornitoriService clientiFornitoriService)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _navigationService = navigationService;
            //this.messageBoxService = messageBoxService;
            _clientiFornitoriService = clientiFornitoriService;
            RegistraMessaggi();
            _logger.LogDebug("Created: " + GetHashCode().ToString());
        }

        public Fornitore Fornitore { get; private set; }

        public Indirizzo Indirizzo { get; private set; }



        public ICommand LoadedCommand => loadedCommand ??= new RelayCommand(() => { });

        public ICommand NuovoFornitoreCommand => nuovoFornitoreCommand ??= new RelayCommand(()
            => MostraFornitore(new Fornitore()));

        public IAsyncRelayCommand SalvaFornitoreCommand => salvaFornitoreCommand ??= new AsyncRelayCommand(async () =>
        {
            try
            {
                await _clientiFornitoriService.SaveFornitore(Fornitore);
                await _unitOfWork.CommitAsync();
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackAsync();
                throw;
            }
            finally
            {
                await _unitOfWork.BeginAsync();
            }
        });

        public IAsyncRelayCommand EliminaFornitoreCommand => eliminaFornitoreCommand ??= new AsyncRelayCommand(async () =>
        {
            try
            {
                await _clientiFornitoriService.DeleteFornitore(Fornitore.Id);
                await _unitOfWork.CommitAsync();
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackAsync();
                throw;
            }
            finally
            {
                await _unitOfWork.BeginAsync();
            }
        });

        public ICommand ApriFornitoreCommand => apriFornitoreCommand ??= new RelayCommand(()
            => _navigationService.Navigate(ViewEnum.ListaFornitori));



        private void RegistraMessaggi()
        {
            Messenger.Register<FornitoreIdMessage>(this, async (r, m) =>
            {
                if (m.Value != 0)
                {
                    await _unitOfWork.BeginAsync();
                    Fornitore fornitore = await _clientiFornitoriService.GetFornitore(m.Value);
                    MostraFornitore(fornitore);
                }
            });
        }

        private void MostraFornitore(Fornitore fornitore)
        {
            Fornitore = fornitore;
            OnPropertyChanged(nameof(Fornitore));
            Indirizzo = fornitore.IndirizzoNew;
            OnPropertyChanged(nameof(Indirizzo));
        }

        public void Dispose()
        {
            _logger.LogDebug("Disposed: " + GetHashCode().ToString());
        }
    }
}
