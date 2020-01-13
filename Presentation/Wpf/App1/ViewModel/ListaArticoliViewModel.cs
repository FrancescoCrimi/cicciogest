using Castle.Core.Logging;
using CiccioGest.Application;
using CiccioGest.Domain.Magazino;
using CiccioGest.Infrastructure;
using CiccioGest.Presentation.Wpf.App1.Contracts;
using CiccioGest.Presentation.Wpf.App1.Service;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows.Input;

namespace CiccioGest.Presentation.Wpf.App1.ViewModel
{
    public sealed class ListaArticoliViewModel : ViewModelBase, IDisposable, ICazzo
    {
        private readonly ILogger logger;
        private readonly IMagazinoService magazinoService;
        private readonly INavigationService navigationService;
        private ICommand loadedCommand;
        private ICommand selezionaProdottoCommand;

        public ListaArticoliViewModel(ILogger logger,
                                      IMagazinoService magazinoService,
                                      INavigationService navigationService)
        {
            this.logger = logger;
            this.magazinoService = magazinoService;
            this.navigationService = navigationService;

            Prodotti = new ObservableCollection<ArticoloReadOnly>();
            if (App.InDesignMode)
            {
                foreach (ArticoloReadOnly pr in magazinoService.GetArticoli().Result)
                {
                    Prodotti.Add(pr);
                }
            }

            logger.Debug("HashCode: " + GetHashCode().ToString(CultureInfo.InvariantCulture) + " Created");
        }

        public ObservableCollection<ArticoloReadOnly> Prodotti { get; private set; }
        public ArticoloReadOnly ProdottoSelezionato { private get; set; }
        public ICommand SelezionaProdottoCommand => selezionaProdottoCommand ?? (selezionaProdottoCommand = new RelayCommand(ApriProdotto));
        public ICommand LoadedCommand => loadedCommand ?? (loadedCommand = new RelayCommand(async () =>
        {
            foreach (ArticoloReadOnly pr in await magazinoService.GetArticoli())
            {
                Prodotti.Add(pr);
            }
        }));



        private void ApriProdotto()
        {
            if (ProdottoSelezionato != null)
            {
                MessengerInstance.Send(new NotificationMessage<int>(ProdottoSelezionato.Id, "IdProdotto"));
                navigationService.GoBack();
            }
        }

        public void Dispose()
        {
            Cleanup();
            logger.Debug("HashCode: " + GetHashCode().ToString(CultureInfo.InvariantCulture) + " Disposed");
        }
    }
}
