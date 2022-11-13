using CiccioGest.Application;
using CiccioGest.Domain.Documenti;
using CiccioGest.Presentation.WinUiApp1.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CiccioGest.Presentation.WinUiApp1.ViewModel
{
    public class FattureViewModel : ObservableRecipient, IDisposable
    {
        private readonly ILogger logger;
        private readonly IFatturaService fatturaService;
        protected readonly INavigationService navigationService;
        private FatturaReadOnly fatturaSelezionata;
        private AsyncRelayCommand loadedCommand;
        private AsyncRelayCommand aggiornaFattureCommand;
        private RelayCommand apriFatturaCommand;
        private RelayCommand nuovaFatturaCommand;

        public FattureViewModel(ILogger<FattureViewModel> logger,
                                IFatturaService fatturaService,
                                INavigationService navigationService)
        {
            this.logger = logger;
            this.fatturaService = fatturaService;
            this.navigationService = navigationService;
            Fatture = new ObservableCollection<FatturaReadOnly>();
            logger.LogDebug("Created: " + GetHashCode().ToString());
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

        public ICommand NuovaFatturaCommand => nuovaFatturaCommand
            ?? (nuovaFatturaCommand = new RelayCommand(NuovaFattura));

        public IAsyncRelayCommand AggiornaFattureCommand => aggiornaFattureCommand
            ?? (aggiornaFattureCommand = new AsyncRelayCommand(AggiornaFatture));

        public ICommand ApriFatturaCommand => apriFatturaCommand
            ?? (apriFatturaCommand = new RelayCommand(ApriFattura, () => FatturaSelezionata != null));



        private void NuovaFattura()
        {
        }

        protected virtual void ApriFattura()
        {
            if (FatturaSelezionata != null)
            {
                navigationService.Navigate("FatturaViewModel");
                Messenger.Send(new FatturaIdMessage(FatturaSelezionata.Id));
            }
        }

        private async Task AggiornaFatture()
        {
            Fatture.Clear();
            foreach (FatturaReadOnly fatt in await fatturaService.GetFatture())
            {
                Fatture.Add(fatt);
            }
        }



        public void Dispose()
        {
            logger.LogDebug("HashCode: " + GetHashCode().ToString() + " Disposed");
        }
    }
}
