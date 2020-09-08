using Castle.Core.Logging;
using Castle.MicroKernel;
using CiccioGest.Application;
using CiccioGest.Domain.Documenti;
using CiccioGest.Infrastructure;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Globalization;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CiccioGest.Presentation.Wpf.App2.ViewModel
{
    public sealed class FatturaViewModel : ViewModelBase, IDisposable, ICazzo
    {
        private readonly ILogger logger;
        private readonly IFatturaService service;
        private ICommand nuovaFatturaCommand;
        private ICommand salvaFatturaCommand;
        private ICommand rimuoviFatturaCommand;
        private ICommand apriFatturaCommand;
        private ICommand nuovoDettaglioCommand;
        private ICommand aggiungiDettaglioCommand;
        private ICommand rimuoviDettaglioCommand;
        private ICommand selezionaDettaglioCommand;
        private ICommand loadedCommand;

        public FatturaViewModel(ILogger logger, IFatturaService service)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.service = service ?? throw new ArgumentNullException(nameof(service));
            if (App.InDesignMode)
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

        public ICommand NuovaFatturaCommand => nuovaFatturaCommand ??= new RelayCommand(() => MostraFattura(new Fattura()));
        public ICommand SalvaFatturaCommand => salvaFatturaCommand ??= new RelayCommand(async () => await SalvaFattura());
        public ICommand RimuoviFatturaCommand => rimuoviFatturaCommand ??= new RelayCommand(async () => await RimuoviFattura());
        public ICommand ApriFatturaCommand => apriFatturaCommand ??= new RelayCommand(() =>
                MessengerInstance.Send(new NotificationMessage("SelezionaFattura")));
        public ICommand NuovoDettaglioCommand => nuovoDettaglioCommand ??= new RelayCommand(() =>
                MessengerInstance.Send(new NotificationMessage("SelezionaProdotto")));
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
                    if (ns.Content == 0)
                        MessengerInstance.Send(new NotificationMessage("SelezionaFattura"));
                    else
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

        private async Task SalvaFattura()
        {
            try
            {
                await service.SaveFattura(Fattura);
            }
            catch (Exception e)
            {
                MessageBox.Show("Errore: " + e.Message);
            }
        }

        private async Task RimuoviFattura()
        {
            try
            {
                await service.DeleteFattura(Fattura.Id);
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
