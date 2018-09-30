using Castle.Core.Logging;
using Castle.MicroKernel;
using CiccioGest.Application;
using CiccioGest.Domain.Documenti;
using CiccioGest.Presentation.AppWpf.View;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
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
    public class FatturaViewModel : ViewModelBase
    {
        private ILogger logger;
        private IKernel kernel;
        private IFatturaService service;

        /// <summary>
        /// Initializes a new instance of the FatturaViewModel class.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FatturaViewModel(ILogger logger, IKernel kernel, IFatturaService service)
        {
            this.logger = logger;
            this.kernel = kernel;
            this.service = service;
            NuovaFatturaCommand = new RelayCommand(nuova);
            SalvaFatturaCommand = new RelayCommand<Window>(salva);
            RimuoviFatturaCommand = new RelayCommand<Window>(elimina);
            NuovoDettaglioCommand = new RelayCommand(apriSelezionaProdotto);
            AggiungiDettaglioCommand = new RelayCommand(aggiungiDettagglio);
            RimuoviDettaglioCommand = new RelayCommand(rimuoviDettaglio);
            SelezionaDettaglioCommand = new RelayCommand(selezionaDettaglio);
            if (IsInDesignModeStatic)
            {
                mostra(service.GetFattura(4));
                Dettaglio = Fattura.Dettagli[3];
            }
            else
            {
                registraMessaggi();                
            }
        }

        #region Proprietà Pubbliche

        public Fattura Fattura { get; private set; }
        public Dettaglio Dettaglio { get; private set; }
        public Dettaglio DettaglioSelezionato { private get; set; }
        public ICommand NuovaFatturaCommand { get; private set; }
        public ICommand SalvaFatturaCommand { get; private set; }
        public ICommand RimuoviFatturaCommand { get; private set; }
        public ICommand NuovoDettaglioCommand { get; private set; }
        public ICommand AggiungiDettaglioCommand { get; private set; }
        public ICommand RimuoviDettaglioCommand { get; private set; }
        public ICommand SelezionaDettaglioCommand { get; private set; }

        #endregion


        #region Metodi Privati

        private void registraMessaggi()
        {
            Messenger.Default.Register<CaricaProdotto>(this, cp =>
            {
                Dettaglio = new Dettaglio(service.GetProdotto(cp.IdProdotto), 1);
                RaisePropertyChanged("Dettaglio");
            });

            Messenger.Default.Register<CaricaFattura>(this, cf =>
            {
                switch (cf.What)
                {
                    case LoadType.Nuova:
                        nuova();
                        break;
                    case LoadType.Cerca:
                        var sfv = new SelezionaFatturaView();
                        sfv.ShowDialog();
                        break;
                    case LoadType.Carica:
                        mostra(service.GetFattura(cf.IdFattura));
                        break;
                    default:
                        break;
                }
            });
        }

        private void nuova()
        {
            mostra(new Fattura());
        }

        private void mostra(Fattura fattura)
        {
            Fattura = fattura;
            RaisePropertyChanged("Fattura");
            nuovoDettaglio();
        }

        private void nuovoDettaglio()
        {
            Dettaglio = new Dettaglio(null, 1);
            RaisePropertyChanged("Dettaglio");
        }

        private void salva(Window window)
        {
            try
            {
                service.SaveFattura(Fattura);
                //Messenger.Default.Send(new AggiornaSelezionaFattureView());
                window.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("Errore: " + e.Message);
            }
        }

        private void elimina(Window window)
        {
            try
            {
                service.DeleteFattura(Fattura.Id);
                //Messenger.Default.Send(new AggiornaSelezionaFattureView());
                window.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("Errore: " + e.Message);
            }
        }

        private void aggiungiDettagglio()
        {
            if (Dettaglio.Quantità != 0)
            {
                Fattura.AddDettaglio(Dettaglio);
                RaisePropertyChanged("Fattura");
                nuovoDettaglio();
            }
        }

        private void rimuoviDettaglio()
        {
            Fattura.RemoveDettaglio(Dettaglio);
            RaisePropertyChanged("Fattura");
            nuovoDettaglio();
        }

        private void selezionaDettaglio()
        {
            if (DettaglioSelezionato != null)
                Dettaglio = DettaglioSelezionato;
            RaisePropertyChanged("Dettaglio");
        }

        void apriSelezionaProdotto()
        {
            var spv = new SelezionaProdottoView();
            spv.ShowDialog();
            spv.Close();
        }

        #endregion
    }
}