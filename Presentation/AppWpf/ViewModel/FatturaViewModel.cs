using Castle.Core.Logging;
using CiccioGest.Application;
using CiccioGest.Domain.Documenti;
using CiccioGest.Infrastructure;
using CiccioGest.Presentation.AppWpf.View;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Globalization;
using System.Windows;
using System.Windows.Input;
using System.Windows.Navigation;

namespace CiccioGest.Presentation.AppWpf.ViewModel
{
    public sealed class FatturaViewModel : ViewModelBase, IDisposable, ICazzo
    {
        private readonly ILogger logger;
        private readonly IFatturaService service;
        private readonly INavigationService ns;
        private ICommand nuovaFatturaCommand;
        private ICommand salvaFatturaCommand;
        private ICommand rimuoviFatturaCommand;
        private ICommand apriFatturaCommand;
        private ICommand nuovoDettaglioCommand;
        private ICommand aggiungiDettaglioCommand;
        private ICommand rimuoviDettaglioCommand;
        private ICommand selezionaDettaglioCommand;
        private ICommand loadedCommand;

        public FatturaViewModel(ILogger logger, IFatturaService service, INavigationService ns)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.service = service ?? throw new ArgumentNullException(nameof(service));
            this.ns = ns ?? throw new ArgumentNullException(nameof(ns));

            if (App.InDesignMode())
            {
                MostraFattura(service.GetFattura(4).Result);
                Dettaglio = Fattura.Dettagli[3];
            }
            else
            {
                RegistraMessaggi();
                MostraFattura(new Fattura());
            }
            logger.Debug("HashCode: " + GetHashCode().ToString(CultureInfo.InvariantCulture) + " Created");
        }

        public Fattura Fattura { get; private set; }
        public Dettaglio Dettaglio { get; private set; }
        public Dettaglio DettaglioSelezionato { private get; set; }

        public ICommand NuovaFatturaCommand => nuovaFatturaCommand ??
            (nuovaFatturaCommand = new RelayCommand(() => MostraFattura(new Fattura())));
        public ICommand SalvaFatturaCommand => salvaFatturaCommand ??
            (salvaFatturaCommand = new RelayCommand(SalvaFattura));
        public ICommand RimuoviFatturaCommand => rimuoviFatturaCommand ??
            (rimuoviFatturaCommand = new RelayCommand(RimuoviFattura));
        public ICommand ApriFatturaCommand => apriFatturaCommand ??
            (apriFatturaCommand = new RelayCommand(() => ns.Navigate(new SelezionaFatturaView())));
        public ICommand NuovoDettaglioCommand => nuovoDettaglioCommand ??
            (nuovoDettaglioCommand = new RelayCommand(() => ns.Navigate(new SelezionaProdottoView())));
        public ICommand AggiungiDettaglioCommand => aggiungiDettaglioCommand ??
            (aggiungiDettaglioCommand = new RelayCommand(AggiungiDettagglio));
        public ICommand RimuoviDettaglioCommand => rimuoviDettaglioCommand ??
            (rimuoviDettaglioCommand = new RelayCommand(RimuoviDettaglio));
        public ICommand SelezionaDettaglioCommand => selezionaDettaglioCommand ??
            (selezionaDettaglioCommand = new RelayCommand(SelezionaDettaglio));
        public ICommand LoadedCommand => loadedCommand ?? (loadedCommand = new RelayCommand(() => { }));

        private void RegistraMessaggi()
        {
            MessengerInstance.Register<NotificationMessage<int>>(this, async ns =>
            {
                if (ns.Notification == "IdFattura")
                {
                    MostraFattura(await service.GetFattura(ns.Content));
                }

                else if (ns.Notification == "IdProdotto")
                {
                    Dettaglio = new Dettaglio(await service.GetArticolo(ns.Content), 1);
                    RaisePropertyChanged(nameof(Dettaglio));
                }
            });
        }

        private void MostraFattura(Fattura fattura)
        {
            Fattura = fattura;
            RaisePropertyChanged(nameof(Fattura));
            NuovoDettaglio();
        }

        private void NuovoDettaglio()
        {
            Dettaglio = new Dettaglio(null, 1);
            RaisePropertyChanged(nameof(Dettaglio));
        }

        private void SalvaFattura()
        {
            try
            {
                service.SaveFattura(Fattura);
            }
            catch (Exception e)
            {
                MessageBox.Show("Errore: " + e.Message);
            }
        }

        private void RimuoviFattura()
        {
            try
            {
                service.DeleteFattura(Fattura.Id);
            }
            catch (Exception e)
            {
                MessageBox.Show("Errore: " + e.Message);
            }
        }

        private void AggiungiDettagglio()
        {
            if (Dettaglio.Quantita != 0)
            {
                Fattura.AddDettaglio(Dettaglio);
                RaisePropertyChanged(nameof(Fattura));
                NuovoDettaglio();
            }
        }

        private void RimuoviDettaglio()
        {
            Fattura.RemoveDettaglio(Dettaglio);
            RaisePropertyChanged(nameof(Fattura));
            NuovoDettaglio();
        }

        private void SelezionaDettaglio()
        {
            if (DettaglioSelezionato != null)
                Dettaglio = DettaglioSelezionato;
            RaisePropertyChanged(nameof(Dettaglio));
        }

        public void Dispose()
        {
            Cleanup();
            logger.Debug("HashCode: " + GetHashCode().ToString(CultureInfo.InvariantCulture) + " Disposed");
        }
    }
}
