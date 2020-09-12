using Castle.Core.Logging;
using Castle.MicroKernel;
using CiccioGest.Application;
using CiccioGest.Domain.Documenti;
using CiccioGest.Infrastructure;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Views;
using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CiccioGest.Presentation.Uwp.App1.ViewModel
{
    public sealed class FatturaViewModel : ViewModelBase, IDisposable, ICazzo
    {
        private readonly ILogger logger;
        private readonly NavigationService navigationService;
        private readonly IFatturaService fatturaService;
        private ICommand nuovaFatturaCommand;
        private ICommand salvaFatturaCommand;
        private ICommand rimuoviFatturaCommand;
        private ICommand aggiungiDettaglioCommand;
        private ICommand rimuoviDettaglioCommand;
        private ICommand selezionaDettaglioCommand;
        private ICommand apriFatturaCommand;
        private ICommand nuovoDettaglioCommand;
        private ICommand loadedCommand;

        public FatturaViewModel(ILogger logger,
                                NavigationService navigationService,
                                IFatturaService fatturaService)
        {
            this.logger = logger;
            this.navigationService = navigationService;
            this.fatturaService = fatturaService;

            if (IsInDesignModeStatic)
            {
                Mostra(this.fatturaService.GetFattura(4).Result);
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

        public ICommand LoadedCommand => loadedCommand ??= new RelayCommand(async () =>
        {
                Fattura fatt = await fatturaService.GetFattura(4);
                Mostra(fatt);
        });

        public ICommand NuovaFatturaCommand => nuovaFatturaCommand ??= new RelayCommand(() => 
            logger.Debug("Nuova Fattura Button fire"));

        public ICommand SalvaFatturaCommand => salvaFatturaCommand ??= new RelayCommand(async () =>
        {
            try
            {
                await fatturaService.SaveFattura(Fattura);
            }
            catch (Exception e)
            {
                //MessageBox.Show("Errore: " + e.Message);
            }
        });

        public ICommand RimuoviFatturaCommand => rimuoviFatturaCommand ??= new RelayCommand(async () =>
        {
            try
            {
                await fatturaService.DeleteFattura(Fattura.Id);
            }
            catch (Exception e)
            {
                //MessageBox.Show("Errore: " + e.Message);
            }
        });

        public ICommand ApriCommand => apriFatturaCommand ??= new RelayCommand(() =>
            navigationService.NavigateTo("ListaFatture"));

        public ICommand NuovoDettaglioCommand => nuovoDettaglioCommand ??= new RelayCommand(() =>
            navigationService.NavigateTo("ListaArticoli"));

        public ICommand AggiungiDettaglioCommand => aggiungiDettaglioCommand ??= new RelayCommand(() =>
        {
            if (Dettaglio.Quantita != 0)
            {
                Fattura.AddDettaglio(Dettaglio);
                RaisePropertyChanged(nameof(Fattura));
                NuovoDettaglio();
            }
        });

        public ICommand RimuoviDettaglioCommand => rimuoviDettaglioCommand ??= new RelayCommand(() =>
        {
            Fattura.RemoveDettaglio(Dettaglio);
            RaisePropertyChanged(nameof(Fattura));
            NuovoDettaglio();
        });

        public ICommand SelezionaDettaglioCommand => selezionaDettaglioCommand ??= new RelayCommand(() =>
        {
            if (DettaglioSelezionato != null)
                Dettaglio = DettaglioSelezionato;
            RaisePropertyChanged(nameof(Dettaglio));
        });


        private void RegistraMessaggi()
        {
            MessengerInstance.Register<NotificationMessage<int>>(this, async ns =>
            {
                if (ns.Notification == "IdFattura")
                {
                    if (ns.Content != 0)
                        Mostra(await fatturaService.GetFattura(ns.Content));
                }
                else if (ns.Notification == "IdProdotto")
                {
                    Dettaglio = new Dettaglio(await fatturaService.GetArticolo(ns.Content), 1);
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

        public void Dispose()
        {
            Cleanup();
            //logger.Debug("HashCode: " + GetHashCode().ToString() + " Disposed");
        }
    }
}
