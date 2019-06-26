using Castle.Core.Logging;
using Castle.MicroKernel;
using CiccioGest.Application;
using CiccioGest.Domain.Documenti;
using CiccioGest.Infrastructure;
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
    public sealed class FatturaViewModel : ViewModelBase, IDisposable, ICazzo
    {
        public Fattura Fattura { get; private set; }
        public Dettaglio Dettaglio { get; private set; }
        public Dettaglio DettaglioSelezionato { private get; set; }
        public ICommand NuovaFatturaCommand { get; private set; }
        public ICommand SalvaFatturaCommand { get; private set; }
        public ICommand RimuoviFatturaCommand { get; private set; }
        public ICommand ApriFatturaCommand { get; private set; }
        public ICommand NuovoDettaglioCommand { get; private set; }
        public ICommand AggiungiDettaglioCommand { get; private set; }
        public ICommand RimuoviDettaglioCommand { get; private set; }
        public ICommand SelezionaDettaglioCommand { get; private set; }
        private ILogger logger;
        private IKernel kernel;
        private IFatturaService service;

        /// <summary>
        /// Initializes a new instance of the FatturaViewModel class.
        /// </summary>
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FatturaViewModel(ILogger logger, IKernel kernel, IFatturaService service)
        {
            this.logger = logger;
            this.kernel = kernel;
            this.service = service;
            NuovaFatturaCommand = new RelayCommand(() => mostra(new Fattura()) );
            SalvaFatturaCommand = new RelayCommand(salva);
            RimuoviFatturaCommand = new RelayCommand(elimina);
            ApriFatturaCommand = new RelayCommand(() =>
            {
                MessengerInstance.Send(new NotificationMessage("SelezionaFattura"));
            });
            NuovoDettaglioCommand = new RelayCommand(() =>
            {
                MessengerInstance.Send(new NotificationMessage("SelezionaProdotto"));
            });

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
                mostra(new Fattura());
            }
            logger.Debug(this.GetType().Name + ":" + this.GetHashCode().ToString() + " Created");
        }

        private void registraMessaggi()
        {
            MessengerInstance.Register<NotificationMessage<int>>(this, ns => {
                if (ns.Notification == "IdFattura")
                {
                    if (ns.Content == 0)
                        MessengerInstance.Send(new NotificationMessage("SelezionaFattura"));
                    else
                        mostra(service.GetFattura(ns.Content));
                }
                else if (ns.Notification == "IdProdotto")
                {
                    Dettaglio = new Dettaglio(service.GetProdotto(ns.Content), 1);
                    RaisePropertyChanged("Dettaglio");
                }
            });
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

        private void salva()
        {
            try
            {
                service.SaveFattura(Fattura);
                //window.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("Errore: " + e.Message);
            }
        }

        private void elimina()
        {
            try
            {
                service.DeleteFattura(Fattura.Id);
                //window.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("Errore: " + e.Message);
            }
        }

        private void aggiungiDettagglio()
        {
            if (Dettaglio.Quantita != 0)
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

        //void apriSelezionaProdotto()
        //{
            
        //}

        public void Dispose()
        {
            Cleanup();
            logger.Debug(GetType().Name + ":" + GetHashCode().ToString() + " Disposed");
        }
    }
}