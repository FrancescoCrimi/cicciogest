using CiccioGest.Application;
using CiccioGest.Domain.Magazino;
using CiccioGest.Presentation.WpfApp.Contracts;
using CiccioGest.Presentation.WpfApp.View;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CiccioGest.Presentation.WpfApp.ViewModel
{
    public class ArticoliViewModel : ViewModelBase, IDisposable
    {
        private readonly ILogger logger;
        private readonly IMagazinoService service;
        private readonly IWindowManagerService windowManagerService;
        private ArticoloReadOnly articoloSelezionato;
        private AsyncRelayCommand loadedCommand;
        private RelayCommand apriArticoloCommand;
        private RelayCommand cancellaArticoloCommand;
        private AsyncRelayCommand aggiornaArticoliCommand;

        public ArticoliViewModel(ILogger<ArticoliViewModel> logger,
                                 IMagazinoService service,
                                 IWindowManagerService windowManagerService)
        {
            this.logger = logger;
            this.service = service;
            this.windowManagerService = windowManagerService;
            Articoli = new ObservableCollection<ArticoloReadOnly>();
            logger.LogDebug("HashCode: " + GetHashCode().ToString() + " Created");
        }

        public ObservableCollection<ArticoloReadOnly> Articoli { get; private set; }

        public ArticoloReadOnly ArticoloSelezionato
        {
            protected get => articoloSelezionato;
            set
            {
                if (articoloSelezionato != value)
                {
                    articoloSelezionato = value;
                    apriArticoloCommand?.NotifyCanExecuteChanged();
                    cancellaArticoloCommand?.NotifyCanExecuteChanged();
                }
            }
        }

        public ICommand LoadedCommand => loadedCommand ??=
            new AsyncRelayCommand(AggiornaArticoli);

        public ICommand ApriArticoloCommand => apriArticoloCommand ??=
            new RelayCommand(ApriArticolo, EnableApriArticolo);

        public ICommand CancellaArticoloCommand => cancellaArticoloCommand ??=
            new RelayCommand(CancellaArticolo, EnableCancellaArticolo);

        public ICommand AggiornaArticoliCommand => aggiornaArticoliCommand ??=
            new AsyncRelayCommand(AggiornaArticoli);

        private async Task AggiornaArticoli()
        {
            Articoli.Clear();
            foreach (ArticoloReadOnly pr in await service.GetArticoli())
            {
                Articoli.Add(pr);
            }
        }

        protected virtual void ApriArticolo()
        {
            if (ArticoloSelezionato != null)
            {
                windowManagerService.OpenWindow(typeof(ArticoloView));
                Messenger.Send(new ArticoloIdMessage(ArticoloSelezionato.Id));
                CloseWindow();
            }
        }

        private bool EnableApriArticolo() => ArticoloSelezionato != null;

        private void CancellaArticolo()
        {
        }

        protected virtual bool EnableCancellaArticolo() => ArticoloSelezionato != null;

        public void Dispose()
        {
            logger.LogDebug("HashCode: " + GetHashCode().ToString() + " Disposed");
        }
    }
}
