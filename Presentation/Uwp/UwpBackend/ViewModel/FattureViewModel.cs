using CiccioGest.Application;
using CiccioGest.Domain.Documenti;
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
    public class FattureViewModel : ObservableRecipient, IDisposable
    {
        private readonly ILogger logger;
        private readonly IFatturaService fatturaService;
        private readonly INavigationService navigationService;
        private FatturaReadOnly fatturaSelezionata;
        private AsyncRelayCommand loadedCommand;
        private AsyncRelayCommand aggiornaFattureCommand;
        private RelayCommand apriFatturaCommand;
        private RelayCommand cancellaFatturaCommand;

        public FattureViewModel(ILogger<FattureViewModel> logger,
                                IFatturaService fatturaService,
                                INavigationService navigationService)
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
            get => fatturaSelezionata;
            set
            {
                if (value != fatturaSelezionata)
                {
                    fatturaSelezionata = value;
                    apriFatturaCommand.NotifyCanExecuteChanged();
                }
            }
        }



        public IAsyncRelayCommand LoadedCommand => loadedCommand
            ?? (loadedCommand = new AsyncRelayCommand(AggiornaFatture));

        public IAsyncRelayCommand AggiornaFattureCommand => aggiornaFattureCommand
            ?? (aggiornaFattureCommand = new AsyncRelayCommand(AggiornaFatture));

        public ICommand ApriFatturaCommand => apriFatturaCommand
            ?? (apriFatturaCommand = new RelayCommand(ApriFattura, EnableApriFattura));

        public ICommand CancellaFatturaCommand => cancellaFatturaCommand
            ?? (cancellaFatturaCommand = new RelayCommand(CancellaFattura, EnableCancellaFattura));



        private async Task AggiornaFatture()
        {
            Fatture.Clear();
            foreach (FatturaReadOnly fatt in await fatturaService.GetFatture())
            {
                Fatture.Add(fatt);
            }
        }

        protected virtual void ApriFattura()
        {
            if (FatturaSelezionata != null)
            {
                navigationService.Navigate("FatturaViewModel");
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
