using CiccioGest.Application;
using CiccioGest.Domain.Documenti;
using CiccioGest.Presentation.WpfApp2.Contracts;
using CiccioGest.Presentation.WpfApp2.Helpers;
using CiccioGest.Presentation.WpfApp2.View;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.Logging;
using System;
using System.Globalization;
using System.Windows;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Messaging;

namespace CiccioGest.Presentation.WpfApp2.ViewModel
{
    public sealed class FatturaViewModel : ObservableRecipient, IDisposable
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

        public FatturaViewModel(ILogger<FatturaViewModel> logger,
                                IFatturaService fatturaService,
                                INavigationService navigationService)
        {
            this.logger = logger;
            this.fatturaService = fatturaService;
            this.navigationService = navigationService;
            RegistraMessaggi();
            logger.LogDebug("HashCode: " + GetHashCode().ToString() + " Created");
        }

        public Fattura Fattura { get; private set; }
        public Dettaglio Dettaglio { get; private set; }
        public Dettaglio DettaglioSelezionato { private get; set; }

        public ICommand NuovaFatturaCommand => nuovaFatturaCommand ??= new RelayCommand(() =>
            navigationService.NavigateTo(typeof(ListaClientiView)));

        public ICommand SalvaFatturaCommand => salvaFatturaCommand ??= new RelayCommand(async () =>
        {
            try
            {
                await fatturaService.SaveFattura(Fattura);
            }
            catch (Exception e)
            {
                MessageBox.Show("Errore: " + e.Message);
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
                MessageBox.Show("Errore: " + e.Message);
            }
        });

        public ICommand ApriFatturaCommand => apriFatturaCommand ??= new RelayCommand(() 
            => navigationService.NavigateTo(typeof(ListaFattureView)));

        public ICommand NuovoDettaglioCommand => nuovoDettaglioCommand ??= new RelayCommand(() 
            => navigationService.NavigateTo(typeof(ListaArticoliView)));

        public ICommand AggiungiDettaglioCommand => aggiungiDettaglioCommand ??= new RelayCommand(() =>
        {
            if (Dettaglio.Quantita != 0)
            {
                Fattura.AddDettaglio(Dettaglio);
                OnPropertyChanged(nameof(Fattura));
                NuovoDettaglio();
            }
        });

        public ICommand RimuoviDettaglioCommand => rimuoviDettaglioCommand ??= new RelayCommand(() =>
        {
            Fattura.RemoveDettaglio(Dettaglio);
            OnPropertyChanged(nameof(Fattura));
            NuovoDettaglio();
        });

        public ICommand SelezionaDettaglioCommand => selezionaDettaglioCommand ??= new RelayCommand(() =>
        {
            if (DettaglioSelezionato != null)
                Dettaglio = DettaglioSelezionato;
            OnPropertyChanged(nameof(Dettaglio));
        });

        public ICommand LoadedCommand => loadedCommand ??= new RelayCommand(() => { });


        private void RegistraMessaggi()
        {
            Messenger.Register<FatturaViewModel, NotificationMessage<int>>(this, async (r, ns) =>
            {
                if (ns.Notification == "IdFattura")
                {
                    MostraFattura(await fatturaService.GetFattura(ns.Content));
                }

                else if (ns.Notification == "IdProdotto")
                {
                    Dettaglio = new Dettaglio(await fatturaService.GetArticolo(ns.Content), 1);
                    OnPropertyChanged(nameof(Dettaglio));
                }
                else if (ns.Notification == "IdCliente")
                {
                    if (ns.Content != 0)
                        MostraFattura(new Fattura(await fatturaService.GetCliente(ns.Content)));
                }
            });
        }

        private void MostraFattura(Fattura fattura)
        {
            logger.LogDebug("MostraFattura " + fattura.Id + " HashCode: " + GetHashCode().ToString());
            Fattura = fattura;
            OnPropertyChanged(nameof(Fattura));
            NuovoDettaglio();
        }

        private void NuovoDettaglio()
        {
            Dettaglio = new Dettaglio(null, 1);
            OnPropertyChanged(nameof(Dettaglio));
        }

        public void Dispose()
        {
            logger.LogDebug("HashCode: " + GetHashCode().ToString(CultureInfo.InvariantCulture) + " Disposed");
        }
    }
}
