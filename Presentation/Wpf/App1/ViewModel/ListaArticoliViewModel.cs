using Castle.Core.Logging;
using CiccioGest.Application;
using CiccioGest.Domain.Magazino;
using CiccioGest.Presentation.Wpf.App1.Contracts;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows.Input;

namespace CiccioGest.Presentation.Wpf.App1.ViewModel
{
    public sealed class ListaArticoliViewModel : ViewModelBase, IDisposable
    {
        private readonly ILogger logger;
        private readonly IMagazinoService magazinoService;
        private readonly INavigationService navigationService;
        private ICommand loadedCommand;
        private ICommand selezionaArticoloCommand;

        public ListaArticoliViewModel(ILogger logger,
                                      IMagazinoService magazinoService,
                                      INavigationService navigationService)
        {
            this.logger = logger;
            this.magazinoService = magazinoService;
            this.navigationService = navigationService;
            Articoli = new ObservableCollection<ArticoloReadOnly>();
            if (IsInDesignMode)
            {
                foreach (ArticoloReadOnly pr in magazinoService.GetArticoli().Result)
                {
                    Articoli.Add(pr);
                }
            }
            logger.Debug("HashCode: " + GetHashCode().ToString() + " Created");
        }

        public ObservableCollection<ArticoloReadOnly> Articoli { get; private set; }

        public ArticoloReadOnly ArticoloSelezionato { private get; set; }

        public ICommand SelezionaArticoloCommand => selezionaArticoloCommand ??= new RelayCommand(() =>
        {
            if (ArticoloSelezionato != null)
            {
                MessengerInstance.Send(new NotificationMessage<int>(ArticoloSelezionato.Id, "IdProdotto"));
                navigationService.GoBack();
            }
        });

        public ICommand LoadedCommand => loadedCommand ??= new RelayCommand(async () =>
        {
            foreach (ArticoloReadOnly pr in await magazinoService.GetArticoli())
            {
                Articoli.Add(pr);
            }
        });

        public void Dispose()
        {
            Cleanup();
            logger.Debug("HashCode: " + GetHashCode().ToString(CultureInfo.InvariantCulture) + " Disposed");
        }
    }
}
