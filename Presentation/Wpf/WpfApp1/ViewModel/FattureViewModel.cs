using CiccioGest.Application;
using CiccioGest.Domain.Documenti;
using CiccioGest.Presentation.WpfApp.Contracts;
using CiccioGest.Presentation.WpfApp.View;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CiccioGest.Presentation.WpfApp.ViewModel
{
    public class FattureViewModel : ViewModelBase, IDisposable
    {
        private readonly ILogger logger;
        private readonly IFatturaService fatturaService;
        private readonly IWindowManagerService windowManagerService;
        private FatturaReadOnly fatturaSelezionata;
        private AsyncRelayCommand loadedCommand;
        private RelayCommand apriFatturaCommand;
        private RelayCommand cancellaFatturaCommand;
        private AsyncRelayCommand aggiornaFattureCommand;

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

        public ICommand LoadedCommand => loadedCommand ??=
            new AsyncRelayCommand(AggiornaFatture);

        public ICommand ApriFatturaCommand => apriFatturaCommand ??=
            new RelayCommand(ApriFattura, EnableApriFattura);

        public ICommand CancellaFatturaCommand => cancellaFatturaCommand ??=
            new RelayCommand(CancellaFattura, EnableCancellaFattura);

        public ICommand AggiornaFattureCommand => aggiornaFattureCommand ??=
            new AsyncRelayCommand(AggiornaFatture);

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
                windowManagerService.OpenWindow(typeof(FatturaView));
                Messenger.Send(new FatturaIdMessage(FatturaSelezionata.Id));
                CloseWindow();
            }
        }

        private bool EnableApriFattura() => fatturaSelezionata != null;

        private void CancellaFattura()
        {
        }

        protected virtual bool EnableCancellaFattura() => fatturaSelezionata != null;

        public void Dispose()
        {
            logger.LogDebug("HashCode: " + GetHashCode().ToString() + " Disposed");
        }
    }
}
