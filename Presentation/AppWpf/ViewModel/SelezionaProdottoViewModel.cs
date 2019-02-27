using Castle.Core.Logging;
using Castle.MicroKernel;
using CiccioGest.Application;
using CiccioGest.Domain.Magazino;
using CiccioGest.Infrastructure;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace CiccioGest.Presentation.AppWpf.ViewModel
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public sealed class SelezionaProdottoViewModel : ViewModelBase, IDisposable, ICazzo
    {
        public ObservableCollection<ProdottoReadOnly> Prodotti { get; private set; }
        public ProdottoReadOnly ProdottoSelezionato { private get; set; }
        public ICommand SelezionaProdottoCommand { get; private set; }
        private ILogger logger;

        /// <summary>
        /// Initializes a new instance of the SelezionaProdottoViewModel class.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SelezionaProdottoViewModel(ILogger logger, IKernel kernel, IMagazinoService service)
        {
            this.logger = logger;
            SelezionaProdottoCommand = new RelayCommand<Window>(apriProdotto);
            Prodotti = new ObservableCollection<ProdottoReadOnly>();
            foreach (ProdottoReadOnly pr in service.GetProdotti())
            {
                Prodotti.Add(pr);
            }
            logger.Debug(GetType().Name + ":" + GetHashCode().ToString() + " Created");
        }

        private void apriProdotto(Window wnd)
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
            logger.Debug(GetType().Name + ":" + GetHashCode().ToString() + " Disposed");
        }
    }
}