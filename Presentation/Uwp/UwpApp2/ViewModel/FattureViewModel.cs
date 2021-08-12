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
using System.Threading.Tasks;
using System.Windows.Input;

namespace CiccioGest.Presentation.UwpApp.ViewModel
{
    public class FattureViewModel : ObservableRecipient, IDisposable
    {
        private readonly ILogger logger;
        private readonly IFatturaService fatturaService;
        private readonly NavigationService navigationService;
        private FatturaReadOnly fatturaSelezionata;
        private AsyncRelayCommand loadedCommand;
        private RelayCommand apriFatturaCommand;
        private AsyncRelayCommand aggiornaFattureCommand;
        private RelayCommand cancellaFatturaCommand;

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

        public ICommand LoadedCommand => loadedCommand ??
            (loadedCommand = new AsyncRelayCommand(AggiornaFatture));

        public ICommand ApriFatturaCommand => apriFatturaCommand ??
            (apriFatturaCommand = new RelayCommand(ApriFattura, EnableApriFattura));

        public ICommand CancellaFatturaCommand => cancellaFatturaCommand ??
            (cancellaFatturaCommand = new RelayCommand(CancellaFattura, EnableCancellaFattura));

        public ICommand AggiornaFattureCommand => aggiornaFattureCommand ??
            (aggiornaFattureCommand = new AsyncRelayCommand(AggiornaFatture));

        private async Task AggiornaFatture()
        {
            Fatture.Clear();
            foreach (FatturaReadOnly fatt in await fatturaService.GetFatture())
            {
                Fatture.Add(fatt);
            }
        }

        private void ApriFattura()
        {
            if (FatturaSelezionata != null)
            {
                navigationService.Navigate(typeof(FatturaPage));
                Messenger.Send(new FatturaIdMessage(FatturaSelezionata.Id));
            }
        }

        private bool EnableApriFattura() => FatturaSelezionata != null;

        private void CancellaFattura()
        {
        }

        private bool EnableCancellaFattura() => FatturaSelezionata != null;

        public void Dispose()
        {
            logger.LogDebug("HashCode: " + GetHashCode().ToString() + " Disposed");
        }
    }
}
