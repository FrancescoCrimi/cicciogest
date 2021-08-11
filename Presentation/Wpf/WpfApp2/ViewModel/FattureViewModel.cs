using CiccioGest.Application;
using CiccioGest.Domain.Documenti;
using CiccioGest.Presentation.WpfApp.Contracts;
using CiccioGest.Presentation.WpfApp.View;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace CiccioGest.Presentation.WpfApp.ViewModel
{
    public class FattureViewModel : ObservableRecipient, IDisposable
    {
        private readonly ILogger logger;
        private readonly IFatturaService fatturaService;
        private readonly INavigationService navigationService;
        private FatturaReadOnly fatturaSelezionata;
        private RelayCommand loadedCommand;
        private RelayCommand apriFatturaCommand;

        public FattureViewModel(ILogger<FattureViewModel> logger,
                                IFatturaService fatturaService,
                                INavigationService navigationService)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.fatturaService = fatturaService;
            this.navigationService = navigationService;
            if (fatturaService == null) throw new ArgumentNullException(nameof(fatturaService));
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

        public ICommand LoadedCommand => loadedCommand ??= new RelayCommand(async () =>
        {
            foreach (FatturaReadOnly fatt in await fatturaService.GetFatture())
            {
                Fatture.Add(fatt);
            }
        });

        public ICommand ApriFatturaCommand => apriFatturaCommand ??=
            new RelayCommand(ApriFattura, EnableApriFattura);


        protected virtual void ApriFattura()
        {
            if (FatturaSelezionata != null)
            {
                navigationService.NavigateTo(typeof(FatturaView));
                Messenger.Send(new FatturaIdMessage(FatturaSelezionata.Id));
            }
        }

        private bool EnableApriFattura() => FatturaSelezionata != null;

        public void Dispose()
        {
            logger.LogDebug("HashCode: " + GetHashCode().ToString() + " Disposed");
        }
    }
}
