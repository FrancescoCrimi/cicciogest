using CiccioGest.Application;
using CiccioGest.Domain.Documenti;
using CiccioGest.Presentation.UwpApp.Services;
using CiccioGest.Presentation.UwpApp.View;
using Microsoft.Extensions.Logging;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.Toolkit.Mvvm.Messaging;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace CiccioGest.Presentation.UwpApp.ViewModel
{
    public class FattureViewModel : ObservableRecipient, IDisposable
    {
        private readonly ILogger logger;
        private readonly IFatturaService fatturaService;
        private readonly NavigationService navigationService;
        private FatturaReadOnly fatturaSelezionata;
        private ICommand loadedCommand;
        private RelayCommand apriFatturaCommand;
        private ICommand refreshCommand;

        public FattureViewModel(ILogger<FattureViewModel> logger,
                                IFatturaService fatturaService,
                                NavigationService navigationService)
        {
            this.logger = logger;
            this.fatturaService = fatturaService;
            this.navigationService = navigationService;
            Fatture = new ObservableCollection<FatturaReadOnly>();
            logger.LogDebug("HashCode: " + GetHashCode().ToString() + " Created");
        }

        public ObservableCollection<FatturaReadOnly> Fatture { get; private set; }

        public FatturaReadOnly FatturaSelezionata
        {
            private get => fatturaSelezionata;
            set
            {
                if (value != fatturaSelezionata)
                {
                    fatturaSelezionata = value;
                    apriFatturaCommand.NotifyCanExecuteChanged();
                }
            }
        }

        public ICommand LoadedCommand => loadedCommand ?? (loadedCommand = new RelayCommand(async () =>
        {
            Fatture.Clear();
            foreach (FatturaReadOnly fatt in await fatturaService.GetFatture())
            {
                Fatture.Add(fatt);
            }
        }));

        public ICommand ApriFatturaCommand => apriFatturaCommand ?? (apriFatturaCommand = new RelayCommand(
            () =>
            {
                if (FatturaSelezionata != null)
                {
                    navigationService.Navigate(typeof(FatturaPage));
                    Messenger.Send(new FatturaIdMessage(FatturaSelezionata.Id));
                }
            },
            () => FatturaSelezionata != null));

        public ICommand RefreshCommand => refreshCommand ?? (refreshCommand = new RelayCommand(() =>
            logger.LogDebug("Refresh Button fire")));

        public void Dispose()
        {
            logger.LogDebug("HashCode: " + GetHashCode().ToString() + " Disposed");
        }
    }
}
