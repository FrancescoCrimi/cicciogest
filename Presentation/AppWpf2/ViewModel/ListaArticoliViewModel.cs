using Castle.Core.Logging;
using CiccioGest.Application;
using CiccioGest.Domain.Magazino;
using CiccioGest.Infrastructure;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows;
using System.Windows.Input;

namespace CiccioGest.Presentation.AppWpf2.ViewModel
{
    public sealed class ListaArticoliViewModel : ViewModelBase, IDisposable, ICazzo
    {
        private readonly ILogger logger;
        private readonly IMagazinoService service;
        private ICommand selezionaProdottoCommand;
        private ICommand loadedCommand;

        public ListaArticoliViewModel(ILogger logger, IMagazinoService service)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.service = service;
            Prodotti = new ObservableCollection<ArticoloReadOnly>();
            if (App.InDesignMode)
            {
                foreach (ArticoloReadOnly pr in service.GetArticoli().Result)
                {
                    Prodotti.Add(pr);
                }
            }
            logger.Debug("HashCode: " + GetHashCode().ToString(CultureInfo.InvariantCulture) + " Created");
        }

        public ObservableCollection<ArticoloReadOnly> Prodotti { get; private set; }
        public ArticoloReadOnly ProdottoSelezionato { private get; set; }

        public ICommand SelezionaProdottoCommand => selezionaProdottoCommand ?? (selezionaProdottoCommand = new RelayCommand<Window>(ApriProdotto));

        public ICommand LoadedCommand => loadedCommand ?? (loadedCommand = new RelayCommand(async () =>
        {
            foreach (ArticoloReadOnly pr in await service.GetArticoli())
            {
                Prodotti.Add(pr);
            }
        }));

        private void ApriProdotto(Window wnd)
        {
            if (ProdottoSelezionato != null)
            {
                MessengerInstance.Send(new NotificationMessage<int>(ProdottoSelezionato.Id, "IdProdotto"));
                wnd.Close();
            }
        }

        public void Dispose()
        {
            Cleanup();
            logger.Debug("HashCode: " + GetHashCode().ToString(CultureInfo.InvariantCulture) + " Disposed");
        }
    }
}
