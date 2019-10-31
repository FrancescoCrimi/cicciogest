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

namespace CiccioGest.Presentation.AppWpfCore.ViewModel
{
    public sealed class SelezionaProdottoViewModel : ViewModelBase, IDisposable, ICazzo
    {
        private readonly ILogger logger;

        public SelezionaProdottoViewModel(ILogger logger, IMagazinoService service)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            SelezionaProdottoCommand = new RelayCommand<Window>(ApriProdotto);
            Prodotti = new ObservableCollection<ArticoloReadOnly>();
            foreach (ArticoloReadOnly pr in service.GetArticoli())
            {
                Prodotti.Add(pr);
            }
            logger.Debug("HashCode: " + GetHashCode().ToString(CultureInfo.InvariantCulture) + " Created");
        }

        public ObservableCollection<ArticoloReadOnly> Prodotti { get; private set; }
        public ArticoloReadOnly ProdottoSelezionato { private get; set; }
        public ICommand SelezionaProdottoCommand { get; private set; }

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
