using Castle.Core.Logging;
using CiccioGest.Application;
using CiccioGest.Domain.Documenti;
using CiccioGest.Infrastructure;
using CiccioGest.Presentation.Wpf.App1.Contracts;
using CiccioGest.Presentation.Wpf.App1.Service;
using CiccioGest.Presentation.Wpf.App1.View;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Globalization;
using System.Windows;
using System.Windows.Input;

namespace CiccioGest.Presentation.Wpf.App1.ViewModel
{
    public sealed class FatturaViewModel : ViewModelBase, IDisposable, ICazzo
    {
        private readonly ILogger logger;
        private readonly IFatturaService fatturaService;
        private readonly INavigationService navigationService;
        private ICommand nuovaFatturaCommand;
        private ICommand salvaFatturaCommand;
        private ICommand rimuoviFatturaCommand;
        private ICommand apriFatturaCommand;
        private ICommand nuovoDettaglioCommand;
        private ICommand aggiungiDettaglioCommand;
        private ICommand rimuoviDettaglioCommand;
        private ICommand selezionaDettaglioCommand;
        private ICommand loadedCommand;

        public FatturaViewModel(ILogger logger,
                                IFatturaService fatturaService,
                                INavigationService navigationService)
        {
            this.logger = logger;
            this.fatturaService = fatturaService;
            this.navigationService = navigationService;
            if (App.InDesignMode)
            {
                Fattura fatt = this.fatturaService.GetFattura(4).Result;
                MostraFattura(fatt);
                Dettaglio = fatt.Dettagli[3];
            }
            else
            {
                RegistraMessaggi();
                MostraFattura(new Fattura());
            }
            logger.Debug("HashCode: " + GetHashCode().ToString() + " Created");
        }

        public Fattura Fattura { get; private set; }
        public Dettaglio Dettaglio { get; private set; }
        public Dettaglio DettaglioSelezionato { private get; set; }

        public ICommand NuovaFatturaCommand => nuovaFatturaCommand ??= new RelayCommand(() => MostraFattura(new Fattura()));
        public ICommand SalvaFatturaCommand => salvaFatturaCommand ??= new RelayCommand(SalvaFattura);
        public ICommand RimuoviFatturaCommand => rimuoviFatturaCommand ??= new RelayCommand(RimuoviFattura);
        public ICommand ApriFatturaCommand => apriFatturaCommand ??= new RelayCommand(() => navigationService.NavigateTo("ListaFatture"));
        public ICommand NuovoDettaglioCommand => nuovoDettaglioCommand ??= new RelayCommand(() => navigationService.NavigateTo("ListaArticoli"));
        public ICommand AggiungiDettaglioCommand => aggiungiDettaglioCommand ??= new RelayCommand(AggiungiDettagglio);
        public ICommand RimuoviDettaglioCommand => rimuoviDettaglioCommand ??= new RelayCommand(RimuoviDettaglio);
        public ICommand SelezionaDettaglioCommand => selezionaDettaglioCommand ??= new RelayCommand(SelezionaDettaglio);
        public ICommand LoadedCommand => loadedCommand ??= new RelayCommand(() => { });

        private void RegistraMessaggi()
        {
            MessengerInstance.Register<NotificationMessage<int>>(this, async ns =>
            {
                if (ns.Notification == "IdFattura")
                {
                    MostraFattura(await fatturaService.GetFattura(ns.Content));
                }

                else if (ns.Notification == "IdProdotto")
                {
                    Dettaglio = new Dettaglio(await fatturaService.GetArticolo(ns.Content), 1);
                    RaisePropertyChanged(nameof(Dettaglio));
                }
            });
        }

        private void MostraFattura(Fattura fattura)
        {
            logger.Debug("MostraFattura " + fattura.Id + " HashCode: " + GetHashCode().ToString());
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
                fatturaService.SaveFattura(Fattura);
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
                fatturaService.DeleteFattura(Fattura.Id);
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
