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
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CiccioGest.Presentation.WinUiBackend.ViewModel
{
    public partial class FornitoriViewModel : ObservableRecipient, IDisposable
    {
        private readonly ILogger<FornitoriViewModel> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IClientiFornitoriService _clientiFornitoriService;
        protected readonly INavigationService _navigationService;
        private Fornitore _fornitoreSelezionato;
        private AsyncRelayCommand loadedCommand;
        private RelayCommand nuovoFornitoreCommand;
        private RelayCommand apriFornitoreCommand;
        private AsyncRelayCommand aggiornaFornitoriCommand;

        public FornitoriViewModel(ILogger<FornitoriViewModel> logger,
                                  IUnitOfWork unitOfWork,
                                  INavigationService navigationService,
                                  IClientiFornitoriService clientiFornitoriService)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _navigationService = navigationService;
            _clientiFornitoriService = clientiFornitoriService;
            Fornitori = new ObservableCollection<Fornitore>();
            _logger.LogDebug("Created: " + GetHashCode().ToString());
        }

        public ObservableCollection<Fornitore> Fornitori { get; private set; }

        public Fornitore FornitoreSelezionato
        {
            get => _fornitoreSelezionato;
            set
            {
                if (value != _fornitoreSelezionato)
                {
                    _fornitoreSelezionato = value;
                    apriFornitoreCommand.NotifyCanExecuteChanged();
                }
            }
        }



        public ICommand LoadedCommand => loadedCommand ??= new AsyncRelayCommand(AggiornaFornitori);

        public ICommand NuovoFornitoreCommand => nuovoFornitoreCommand ??= new RelayCommand(() =>
        {
        });

        public ICommand ApriFornitoreCommand => apriFornitoreCommand ??= new RelayCommand(ApriFornitore, () => FornitoreSelezionato != null);

        public ICommand AggiornaFornitoriCommand => aggiornaFornitoriCommand ??= new AsyncRelayCommand(AggiornaFornitori);



        private async Task AggiornaFornitori()
        {
            Fornitori.Clear();
            await _unitOfWork.BeginAsync();
            foreach (var item in await _clientiFornitoriService.GetFornitori())
            {
                Fornitori.Add(item);
            }
            OnPropertyChanged(nameof(Fornitori));
        }

        protected virtual void ApriFornitore()
        {
            if (FornitoreSelezionato != null)
            {
                _navigationService.Navigate(ViewEnum.Fornitore);
                Messenger.Send(new FornitoreIdMessage(FornitoreSelezionato.Id));
            }
        }


        public void Dispose()
        {
            _logger.LogDebug("Disposed: " + GetHashCode().ToString());
        }
    }
}
