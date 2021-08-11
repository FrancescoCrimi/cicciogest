using CiccioGest.Application;
using CiccioGest.Domain.Documenti;
using CiccioGest.Presentation.WpfApp.Contracts;
using CiccioGest.Presentation.WpfApp.View;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace CiccioGest.Presentation.WpfApp.ViewModel
{
    public class FattureViewModel : ViewModelBase, IDisposable
    {
        private readonly ILogger logger;
        private readonly IFatturaService fatturaService;
        private readonly IWindowManagerService windowManagerService;
        private FatturaReadOnly fatturaSelezionata;
        private RelayCommand loadedCommand;
        private RelayCommand apriFatturaCommand;
        private RelayCommand aggiornaFatturaCommand;
        private RelayCommand cancellaFatturaCommand;

        public FattureViewModel(ILogger<FattureViewModel> logger,
                                IFatturaService fatturaService,
                                IWindowManagerService windowManagerService)
        {
            this.logger = logger;
            this.fatturaService = fatturaService;
            this.windowManagerService = windowManagerService;
            Fatture = new ObservableCollection<FatturaReadOnly>();
            logger.LogDebug("HashCode: " + GetHashCode().ToString() + " Created");
        }

        public ObservableCollection<FatturaReadOnly> Fatture { get; private set; }

        public FatturaReadOnly FatturaSelezionata
        {
            protected get => fatturaSelezionata;
            set
            {
                if(fatturaSelezionata != value)
                {
                    fatturaSelezionata = value;
                    apriFatturaCommand.NotifyCanExecuteChanged();
                    cancellaFatturaCommand.NotifyCanExecuteChanged();
                }
            }
        }

        public ICommand LoadedCommand => loadedCommand ??= new RelayCommand(async () =>
        {
            Fatture.Clear();
            foreach (FatturaReadOnly fatt in await fatturaService.GetFatture())
            {
                Fatture.Add(fatt);
            }
        });

        public ICommand ApriFatturaCommand => apriFatturaCommand ??= new RelayCommand(ApriFattura, EnableApriFattura);

        protected virtual void ApriFattura()
        {
            if (FatturaSelezionata != null)
            {
                windowManagerService.OpenWindow(typeof(FatturaView));
                Messenger.Send(new FatturaIdMessage(FatturaSelezionata.Id));
                CloseWindow();
            }
        }

        private bool EnableApriFattura() => fatturaSelezionata != null;

        public ICommand CancellaFatturaCommand => cancellaFatturaCommand ??= new RelayCommand(CancellaFattura, EnableCancellaFattura);

        private void CancellaFattura()
        {
        }

        protected virtual bool EnableCancellaFattura() => fatturaSelezionata != null;

        public ICommand AggiornaFatturaCommand => aggiornaFatturaCommand ??= new RelayCommand(AggiornaFattura);

        private void AggiornaFattura()
        {
        }

        public void Dispose()
        {
            logger.LogDebug("HashCode: " + GetHashCode().ToString() + " Disposed");
        }
    }
}
