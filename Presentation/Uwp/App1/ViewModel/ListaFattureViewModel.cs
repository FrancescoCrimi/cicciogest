using Castle.Core.Logging;
using CiccioGest.Application;
using CiccioGest.Domain.Documenti;
using CiccioGest.Infrastructure;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows.Input;

namespace CiccioGest.Presentation.Uwp.App1.ViewModel
{
    public sealed class ListaFattureViewModel : ViewModelBase, IDisposable
    {
        private readonly ILogger logger;
        private readonly IFatturaService service;
        private readonly NavigationService navigationService;
        private RelayCommand apriFatturaCommand;
        private ICommand loadedCommand;
        private ICommand refreshCommand;
        private FatturaReadOnly fatturaSelezionata;

        public ListaFattureViewModel(ILogger logger, IFatturaService service, NavigationService navigationService)
        {
            this.logger = logger;
            this.service = service;
            this.navigationService = navigationService;
            Fatture = new ObservableCollection<FatturaReadOnly>();
            if (IsInDesignModeStatic)
            {
                foreach (FatturaReadOnly fatt in service.GetFatture().Result)
                {
                    Fatture.Add(fatt);
                }
            }

            logger.Debug("HashCode: " + GetHashCode().ToString(CultureInfo.InvariantCulture) + " Created");
        }

        public ICommand LoadedCommand => loadedCommand ??= new RelayCommand(async () =>
        {
            Fatture.Clear();
            foreach (FatturaReadOnly fatt in await service.GetFatture())
            {
                Fatture.Add(fatt);
            }
        });

        public ICommand RefreshCommand => refreshCommand ??= new RelayCommand(() =>
            logger.Debug("Refresh Button fire"));

        public ObservableCollection<FatturaReadOnly> Fatture { get; private set; }

        public FatturaReadOnly FatturaSelezionata
        {
            private get => fatturaSelezionata;
            set
            {
                if (value != fatturaSelezionata)
                {
                    fatturaSelezionata = value;
                    apriFatturaCommand.RaiseCanExecuteChanged();
                }
            }
        }

        public ICommand ApriFatturaCommand => apriFatturaCommand ??= new RelayCommand(() =>
        {
            if (FatturaSelezionata != null)
            {
                navigationService.GoBack();
                MessengerInstance.Send(new NotificationMessage<int>(FatturaSelezionata.Id, "IdFattura"));
            }
        }, () => FatturaSelezionata != null);

        public void Dispose()
        {
            Cleanup();
            logger.Debug("HashCode: " + GetHashCode().ToString(CultureInfo.InvariantCulture) + " Disposed");
        }
    }
}
