﻿using CiccioGest.Application;
using CiccioGest.Domain.Magazino;
using CiccioGest.Presentation.UwpBackend.Services;
using Microsoft.Extensions.Logging;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.Toolkit.Mvvm.Messaging;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CiccioGest.Presentation.UwpBackend.ViewModel
{
    public class ArticoliViewModel : ObservableRecipient, IDisposable
    {
        private readonly ILogger logger;
        private readonly IMagazinoService magazinoService;
        private readonly INavigationService navigationService;
        private ArticoloReadOnly articoloSelezionato;
        private AsyncRelayCommand loadedCommand;
        private AsyncRelayCommand aggiornaArticoliCommand;
        private RelayCommand apriArticoloCommand;
        private RelayCommand cancellaArticoloCommand;

        public ArticoliViewModel(ILogger<ArticoliViewModel> logger,
                                 IMagazinoService magazinoService,
                                 INavigationService navigationService)
        {
            this.logger = logger;
            this.magazinoService = magazinoService;
            this.navigationService = navigationService;
            Articoli = new ObservableCollection<ArticoloReadOnly>();
            logger.LogDebug("HashCode: " + GetHashCode().ToString() + " Created");
        }

        public ObservableCollection<ArticoloReadOnly> Articoli { get; private set; }

        public ArticoloReadOnly ArticoloSelezionato
        {
            get => articoloSelezionato;
            set
            {
                if (articoloSelezionato != value)
                {
                    articoloSelezionato = value;
                    apriArticoloCommand.NotifyCanExecuteChanged();
                    cancellaArticoloCommand.NotifyCanExecuteChanged();
                }
            }
        }

        public IAsyncRelayCommand LoadedCommand => loadedCommand
            ?? (loadedCommand = new AsyncRelayCommand(AggiornaArticoli));

        public IAsyncRelayCommand AggiornaArticoliCommand => aggiornaArticoliCommand
            ?? (aggiornaArticoliCommand = new AsyncRelayCommand(AggiornaArticoli));

        public ICommand ApriArticoloCommand => apriArticoloCommand
            ?? (apriArticoloCommand = new RelayCommand(ApriArticolo, EnableApriArticolo));

        public ICommand CancellaArticoloCommand => cancellaArticoloCommand
            ?? (cancellaArticoloCommand = new RelayCommand(CancellaArticolo, EnableCancellaArticolo));

        private async Task AggiornaArticoli()
        {
            Articoli.Clear();
            foreach (ArticoloReadOnly pr in await magazinoService.GetArticoli())
            {
                Articoli.Add(pr);
            }
        }

        protected virtual void ApriArticolo()
        {
            if (ArticoloSelezionato != null)
            {
                Messenger.Send(new ArticoloIdMessage(ArticoloSelezionato.Id));
                navigationService.GoBack();
            }
        }

        private bool EnableApriArticolo() => ArticoloSelezionato != null;

        private void CancellaArticolo()
        {
        }

        private bool EnableCancellaArticolo() => ArticoloSelezionato != null;

        public void Dispose()
        {
            logger.LogDebug("HashCode: " + GetHashCode().ToString() + " Disposed");
        }
    }
}