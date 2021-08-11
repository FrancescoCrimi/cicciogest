using CiccioGest.Application;
using CiccioGest.Domain.Magazino;
using CiccioGest.Presentation.WpfApp.Contracts;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows.Input;

namespace CiccioGest.Presentation.WpfApp.ViewModel
{
    public class ArticoliViewModel : ObservableRecipient, IDisposable
    {
        private readonly ILogger logger;
        private readonly IMagazinoService magazinoService;
        private readonly INavigationService navigationService;
        private RelayCommand loadedCommand;
        private RelayCommand apriArticoloCommand;
        private ArticoloReadOnly articoloSelezionato;

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
            private get => articoloSelezionato;
            set
            {
                if(articoloSelezionato != value)
                {
                    articoloSelezionato = value;
                    apriArticoloCommand.NotifyCanExecuteChanged();
                }
            }
        }

        public ICommand LoadedCommand => loadedCommand ??= new RelayCommand(async () =>
        {
            Articoli.Clear();
            foreach (ArticoloReadOnly pr in await magazinoService.GetArticoli())
            {
                Articoli.Add(pr);
            }
        });

        public ICommand ApriArticoloCommand => apriArticoloCommand ??=
            new RelayCommand(ApriArticolo, EnableApriArticolo);

        protected virtual void ApriArticolo()
        {
            if (ArticoloSelezionato != null)
            {
                Messenger.Send(new ArticoloIdMessage(ArticoloSelezionato.Id));
                navigationService.GoBack();
            }
        }

        private bool EnableApriArticolo() => ArticoloSelezionato != null;

        public void Dispose()
        {
            logger.LogDebug("HashCode: " + GetHashCode().ToString(CultureInfo.InvariantCulture) + " Disposed");
        }
    }
}
