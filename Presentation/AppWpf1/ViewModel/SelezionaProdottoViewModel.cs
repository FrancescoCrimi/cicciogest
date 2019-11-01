using Castle.Core.Logging;
using CiccioGest.Application;
using CiccioGest.Domain.Magazino;
using CiccioGest.Infrastructure;
using CiccioGest.Presentation.AppWpf1.Service;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows.Input;

namespace CiccioGest.Presentation.AppWpf1.ViewModel
{
    public sealed class SelezionaProdottoViewModel : ViewModelBase, IDisposable, ICazzo
    {
        private readonly ILogger logger;
        private readonly IMagazinoService service;
        private readonly INavigationService ns;
        private ICommand loadedCommand;
        private ICommand selezionaProdottoCommand;

        public SelezionaProdottoViewModel(ILogger logger, IMagazinoService service, INavigationService ns)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.service = service;
            this.ns = ns ?? throw new ArgumentNullException(nameof(ns));

            Prodotti = new ObservableCollection<ArticoloReadOnly>();
            logger.Debug("HashCode: " + GetHashCode().ToString(CultureInfo.InvariantCulture) + " Created");
        }

        public ObservableCollection<ArticoloReadOnly> Prodotti { get; private set; }
        public ArticoloReadOnly ProdottoSelezionato { private get; set; }
        public ICommand SelezionaProdottoCommand => selezionaProdottoCommand ??(selezionaProdottoCommand = new RelayCommand(ApriProdotto));
        public ICommand LoadedCommand => loadedCommand ?? (loadedCommand = new RelayCommand(async () =>
        {
            foreach (ArticoloReadOnly pr in await service.GetArticoli())
            {
                Prodotti.Add(pr);
            }
        }));

        private void ApriProdotto()
        {
            if (ProdottoSelezionato != null)
            {
                MessengerInstance.Send(new NotificationMessage<int>(ProdottoSelezionato.Id, "IdProdotto"));
                ns.GoBack();
            }
        }

        public void Dispose()
        {
            Cleanup();
            logger.Debug("HashCode: " + GetHashCode().ToString(CultureInfo.InvariantCulture) + " Disposed");
        }
    }
}
