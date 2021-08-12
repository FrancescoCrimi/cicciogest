﻿using CiccioGest.Application;
using CiccioGest.Domain.Magazino;
using CiccioGest.Presentation.UwpApp.Services;
using Microsoft.Extensions.Logging;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.Toolkit.Mvvm.Messaging;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CiccioGest.Presentation.UwpApp.ViewModel
{
    public class ArticoliViewModel : ObservableRecipient
    {
        private AsyncRelayCommand loadedCommand;
        private RelayCommand apriArticoloCommand;
        private RelayCommand cancellaArticoloCommand;
        private AsyncRelayCommand aggiornaArticoliCommand;
        private ArticoloReadOnly articoloSelezionato;
        private readonly ILogger<ArticoliViewModel> logger;
        private readonly IMagazinoService magazinoService;
        private readonly NavigationService navigationService;

        public ArticoliViewModel(ILogger<ArticoliViewModel> logger,
                                 IMagazinoService magazinoService,
                                 NavigationService navigationService)
        {
            this.logger = logger;
            this.magazinoService = magazinoService;
            this.navigationService = navigationService;
        }

        public ObservableCollection<ArticoloReadOnly> Articoli { get; private set; }

        public ArticoloReadOnly ArticoloSelezionato
        {
            private get => articoloSelezionato;
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

        public ICommand LoadedCommand => loadedCommand ??
            (loadedCommand = new AsyncRelayCommand(AggiornaArticoli));

        public ICommand ApriArticoloCommand => apriArticoloCommand ??
            (apriArticoloCommand = new RelayCommand(ApriArticolo, EnableApriArticolo));

        public ICommand CancellaArticoloCommand => cancellaArticoloCommand ??
            (cancellaArticoloCommand = new RelayCommand(CancellaArticolo, EnableCancellaArticolo));

        public ICommand AggiornaArticoliCommand => aggiornaArticoliCommand ??
            (aggiornaArticoliCommand = new AsyncRelayCommand(AggiornaArticoli));

        private void ApriArticolo()
        {
            Messenger.Send(new ArticoloIdMessage(ArticoloSelezionato.Id));
            navigationService.GoBack();
        }

        private bool EnableApriArticolo()
        {
            throw new NotImplementedException();
        }

        private void CancellaArticolo()
        {
        }

        private bool EnableCancellaArticolo()
        {
            throw new NotImplementedException();
        }

        private async Task AggiornaArticoli()
        {
            Articoli.Clear();
            foreach (ArticoloReadOnly pr in await magazinoService.GetArticoli())
            {
                Articoli.Add(pr);
            }
            logger.LogDebug("Ciao Ciao");
        }
    }
}
