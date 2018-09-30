using Castle.Core.Logging;
using Castle.MicroKernel;
using CiccioGest.Application;
using CiccioGest.Domain.Magazino;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
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
    public class SelezionaProdottoViewModel : ViewModelBase
    {
        private ILogger logger;
        private IKernel kernel;
        private IMagazinoService service;

        /// <summary>
        /// Initializes a new instance of the SelezionaProdottoViewModel class.
        /// </summary>
        public SelezionaProdottoViewModel(ILogger logger, IKernel kernel, IMagazinoService service)
        {
            this.logger = logger;
            this.kernel = kernel;
            this.service = service;
            Prodotti = new ObservableCollection<ProdottoReadOnly>();
            SelezionaProdottoCommand = new RelayCommand<Window>(apriProdotto);
            Messenger.Default.Register<AggiornaSelezionaProdottoView>(this, aggiorna);
            aggiorna();
        }

        #region Proprietà pubbliche

        public ObservableCollection<ProdottoReadOnly> Prodotti { get; private set; }
        public ProdottoReadOnly ProdottoSelezionato { private get; set; }
        public ICommand SelezionaProdottoCommand { get; private set; }

        #endregion



        #region Metodi Privati

        private void aggiorna(object obj = null)
        {
            foreach (ProdottoReadOnly pr in service.GetProdotti())
            {
                Prodotti.Add(pr);
            }
        }

        private void apriProdotto(Window wnd)
        {
            if (ProdottoSelezionato != null)
            {
                //var pv = new ProdottoView();
                //Messenger.Default.Send(new ApriProdottoView { IdProdotto = ProdottoSelezionato.Id });
                Messenger.Default.Send(new CaricaProdotto
                {
                    IdProdotto = ProdottoSelezionato.Id,
                    What = LoadType.Carica
                });
                //pv.ShowDialog();
                wnd.Close();
                //pv.Close();
            }
        }

        #endregion

    }
}