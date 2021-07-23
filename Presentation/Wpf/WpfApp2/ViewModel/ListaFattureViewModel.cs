﻿//using Castle.Core.Logging;
using CiccioGest.Application;
using CiccioGest.Domain.Documenti;
using CiccioGest.Infrastructure;
using CiccioGest.Presentation.WpfApp2.Contracts;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace CiccioGest.Presentation.WpfApp2.ViewModel
{
    public sealed class ListaFattureViewModel : ViewModelBase, IDisposable
    {
        private readonly ILogger logger;
        private readonly IFatturaService fatturaService;
        private readonly INavigationService navigationService;
        private ICommand loadedCommand;
        private ICommand apriFatturaCommand;

        public ListaFattureViewModel(ILogger<ListaFattureViewModel> logger,
                                     IFatturaService fatturaService,
                                     INavigationService navigationService)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.fatturaService = fatturaService;
            this.navigationService = navigationService;
            if (fatturaService == null) throw new ArgumentNullException(nameof(fatturaService));
            Fatture = new ObservableCollection<FatturaReadOnly>();
            if (IsInDesignMode)
            {
                foreach (FatturaReadOnly fatt in fatturaService.GetFatture().Result)
                {
                    Fatture.Add(fatt);
                }
            }
            logger.LogDebug("HashCode: " + GetHashCode().ToString() + " Created");
        }

        public string Title { get => "Suca Forte"; }
        public ObservableCollection<FatturaReadOnly> Fatture { get; private set; }
        public FatturaReadOnly FatturaSelezionata { private get; set; }

        public ICommand LoadedCommand => loadedCommand ??= new RelayCommand(async () =>
        {
            foreach (FatturaReadOnly fatt in await fatturaService.GetFatture())
            {
                Fatture.Add(fatt);
            }
        });

        public ICommand ApriFatturaCommand => apriFatturaCommand ??= new RelayCommand(() =>
        {
            if (FatturaSelezionata != null)
            {
                if (navigationService.CanGoBack)
                    navigationService.GoBack();
                MessengerInstance.Send(new NotificationMessage<int>(FatturaSelezionata.Id, "IdFattura"));
            }
        });

        public void Dispose()
        {
            Cleanup();
            logger.LogDebug("HashCode: " + GetHashCode().ToString() + " Disposed");
        }
    }
}