using CiccioGest.Application;
using CiccioGest.Domain.Documenti;
using CiccioGest.Presentation.UwpApp.Services;
using Microsoft.Extensions.Logging;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows.Input;
using Microsoft.Toolkit.Mvvm.Messaging;

namespace CiccioGest.Presentation.UwpApp.ViewModel
{
    public sealed class ListaFattureViewModel : ObservableRecipient, IDisposable
    {
        private readonly ILogger logger;
        private readonly IFatturaService service;
        private readonly NavigationService navigationService;
        private RelayCommand apriFatturaCommand;
        private ICommand loadedCommand;
        private ICommand refreshCommand;
        private FatturaReadOnly fatturaSelezionata;

        public ListaFattureViewModel(ILogger<ListaFattureViewModel> logger, IFatturaService service, NavigationService navigationService)
        {
            this.logger = logger;
            this.service = service;
            this.navigationService = navigationService;
            Fatture = new ObservableCollection<FatturaReadOnly>();
            logger.LogDebug("HashCode: " + GetHashCode().ToString(CultureInfo.InvariantCulture) + " Created");
        }

        public ICommand LoadedCommand => loadedCommand ?? (loadedCommand = new RelayCommand(async () =>
        {
            Fatture.Clear();
            foreach (FatturaReadOnly fatt in await service.GetFatture())
            {
                Fatture.Add(fatt);
            }
        }));

        public ICommand RefreshCommand => refreshCommand ?? (refreshCommand = new RelayCommand(() =>
            logger.LogDebug("Refresh Button fire")));

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

        public ICommand ApriFatturaCommand => apriFatturaCommand ?? (apriFatturaCommand = new RelayCommand(
            () =>
                {
                    if (FatturaSelezionata != null)
                    {
                        navigationService.GoBack();
                        //Messenger.Send(new NotificationMessage<int>(FatturaSelezionata.Id, "IdFattura"));
                        Messenger.Send(new FatturaIdMessage(FatturaSelezionata.Id));
                    }        
                },
            () =>
                FatturaSelezionata != null));

        public void Dispose()
        {
            logger.LogDebug("HashCode: " + GetHashCode().ToString(CultureInfo.InvariantCulture) + " Disposed");
        }
    }
}
