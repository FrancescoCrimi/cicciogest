using Castle.Core.Logging;
using Castle.MicroKernel;
using CiccioGest.Application;
using CiccioGest.Domain.Documenti;
using CiccioGest.Infrastructure;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CiccioGest.Presentation.Uwp.App1.ViewModel
{
    public sealed class FatturaViewModel : ViewModelBase, IDisposable, ICazzo
    {
        private readonly ILogger logger;
        private readonly IFatturaService service;
        private ICommand nuovaFatturaCommand;
        private ICommand salvaFatturaCommand;
        private ICommand rimuoviFatturaCommand;
        private ICommand aggiungiDettaglioCommand;
        private ICommand rimuoviDettaglioCommand;
        private ICommand selezionaDettaglioCommand;
        private ICommand apriFatturaCommand;
        private ICommand nuovoDettaglioCommand;
        private ICommand loadedCommand;

        public FatturaViewModel(ILogger logger, IFatturaService service)
        {
            this.logger = logger;
            this.service = service;

            if (IsInDesignModeStatic)
            {
                Mostra(service.GetFattura(4).Result);
                Dettaglio = Fattura.Dettagli[3];
            }
            else
            {
                RegistraMessaggi();
                logger.Debug("HashCode: " + GetHashCode().ToString() + " Created");
            }
        }

        public Fattura Fattura { get; private set; }
        public Dettaglio Dettaglio { get; private set; }
        public Dettaglio DettaglioSelezionato { private get; set; }

        public ICommand LoadedCommand => loadedCommand ??
            (loadedCommand = new RelayCommand(async () => Mostra(await service.GetFattura(5))));

        public ICommand NuovaFatturaCommand => nuovaFatturaCommand ??
            (nuovaFatturaCommand = new RelayCommand(() => logger.Debug("Nuova Fattura Button fire")));

        public ICommand SalvaFatturaCommand => salvaFatturaCommand ??
            (salvaFatturaCommand = new RelayCommand(Salva));

        public ICommand RimuoviFatturaCommand => rimuoviFatturaCommand ??
            (rimuoviFatturaCommand = new RelayCommand(Elimina));

        public ICommand ApriFatturaCommand => apriFatturaCommand ??
            (apriFatturaCommand = new RelayCommand(() =>
            MessengerInstance.Send(new NotificationMessage("SelezionaFattura"))));

        public ICommand NuovoDettaglioCommand => nuovoDettaglioCommand ??
            (nuovoDettaglioCommand = new RelayCommand(() =>
            MessengerInstance.Send(new NotificationMessage("SelezionaProdotto"))));

        public ICommand AggiungiDettaglioCommand => aggiungiDettaglioCommand ??
            (aggiungiDettaglioCommand = new RelayCommand(AggiungiDettagglio));

        public ICommand RimuoviDettaglioCommand => rimuoviDettaglioCommand ??
            (rimuoviDettaglioCommand = new RelayCommand(RimuoviDettaglio));

        public ICommand SelezionaDettaglioCommand => selezionaDettaglioCommand ??
            (selezionaDettaglioCommand = new RelayCommand(SelezionaDettaglio));

        private void RegistraMessaggi()
        {
            MessengerInstance.Register<NotificationMessage<int>>(this, async ns =>
            {
                if (ns.Notification == "IdFattura")
                {
                    if (ns.Content == 0)
                        MessengerInstance.Send(new NotificationMessage("SelezionaFattura"));
                    else
                        Mostra(await service.GetFattura(ns.Content));
                }

                else if (ns.Notification == "ApriFatturaSelezionata")
                {
                    Mostra(await service.GetFattura(ns.Content));
                }

                else if (ns.Notification == "IdProdotto")
                {
                    Dettaglio = new Dettaglio(await service.GetArticolo(ns.Content), 1);
                    RaisePropertyChanged(nameof(Dettaglio));
                }
            });
        }

        private void Mostra(Fattura fattura)
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

        private void Salva()
        {
            try
            {
                service.SaveFattura(Fattura);
                //window.Close();
            }
            catch (Exception e)
            {
                //MessageBox.Show("Errore: " + e.Message);
            }
        }

        private void Elimina()
        {
            try
            {
                service.DeleteFattura(Fattura.Id);
                //window.Close();
            }
            catch (Exception e)
            {
                //MessageBox.Show("Errore: " + e.Message);
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
            //logger.Debug("HashCode: " + GetHashCode().ToString() + " Disposed");
        }
    }
}
