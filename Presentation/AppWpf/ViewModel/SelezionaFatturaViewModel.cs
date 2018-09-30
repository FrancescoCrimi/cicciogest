using Castle.Core.Logging;
using Castle.MicroKernel;
using CiccioGest.Application;
using CiccioGest.Domain.Documenti;
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
    public class SelezionaFatturaViewModel : ViewModelBase
    {
        private ILogger logger;
        private IKernel kernel;
        private IFatturaService service;

        /// <summary>
        /// Initializes a new instance of the SelezionaFatturaViewModel class.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SelezionaFatturaViewModel(ILogger logger, IKernel kernel, IFatturaService service)
        {
            this.logger = logger;
            this.kernel = kernel;
            this.service = service;
            Fatture = new ObservableCollection<FatturaReadOnly>();
            ApriFattura = new RelayCommand<Window>(apriFattura);
            Messenger.Default.Register<AggiornaSelezionaFattureView>(this, aggiorna);
            aggiorna();
        }

        #region Proprietà pubbliche

        public ObservableCollection<FatturaReadOnly> Fatture { get; private set; }
        public FatturaReadOnly FatturaSelezionata { private get; set; }
        public ICommand ApriFattura { get; private set; }

        #endregion


        #region Metodi Privati

        private void aggiorna(object aa = null)
        {
            Fatture.Clear();
            foreach (FatturaReadOnly fatt in service.GetFatture())
            {
                Fatture.Add(fatt);
            }
            RaisePropertyChanged("Fatture");
        }

        private void apriFattura(Window wnd)
        {
            if (FatturaSelezionata != null)
            {
                Messenger.Default.Send(new CaricaFattura
                {
                    IdFattura = FatturaSelezionata.Id,
                    What = LoadType.Carica
                });
                wnd.Close();
            }
        }

        #endregion

    }
}