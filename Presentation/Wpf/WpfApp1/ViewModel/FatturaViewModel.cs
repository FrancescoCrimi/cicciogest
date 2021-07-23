using CiccioGest.Application;
using CiccioGest.Domain.Documenti;
using CiccioGest.Presentation.WpfApp1.Contracts;
using CiccioGest.Presentation.WpfApp1.Helpers;
using CiccioGest.Presentation.WpfApp1.View;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Extensions.Logging;
using System;
using System.Globalization;
using System.Windows;
using System.Windows.Input;

namespace CiccioGest.Presentation.WpfApp1.ViewModel
{
    public sealed class FatturaViewModel : ObservableRecipient, IDisposable
    {
        private readonly ILogger logger;
        private readonly IFatturaService service;
        private readonly IWindowManagerService windowManagerService;
        private readonly IWindowDialogService windowDialogService;
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
                                IFatturaService service,
                                IWindowManagerService windowManagerService,
                                IWindowDialogService windowDialogService)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.service = service ?? throw new ArgumentNullException(nameof(service));
            this.windowManagerService = windowManagerService;
            this.windowDialogService = windowDialogService;
            RegistraMessaggi();
            logger.LogDebug("HashCode: " + GetHashCode().ToString(CultureInfo.InvariantCulture) + " Created");
        }

        public Fattura Fattura { get; private set; }
        public Dettaglio Dettaglio { get; private set; }
        public Dettaglio DettaglioSelezionato { private get; set; }

        public ICommand NuovaFatturaCommand => nuovaFatturaCommand ??= new RelayCommand(() =>
        {
            windowDialogService.OpenDialog(typeof(ListaClientiView));
        });

        public ICommand SalvaFatturaCommand => salvaFatturaCommand ??= new RelayCommand(async () =>
        {
            try
            {
                await service.SaveFattura(Fattura);
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
                await service.DeleteFattura(Fattura.Id);
            }
            catch (Exception e)
            {
                MessageBox.Show("Errore: " + e.Message);
            }
        });

        public ICommand ApriFatturaCommand => apriFatturaCommand ??= new RelayCommand(() =>
                windowDialogService.OpenDialog(typeof(ListaFattureView)));

        public ICommand NuovoDettaglioCommand => nuovoDettaglioCommand ??= new RelayCommand(() =>
                windowDialogService.OpenDialog(typeof(ListaArticoliView)));

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
                    if (ns.Content != 0)
                        MostraFattura(await service.GetFattura(ns.Content));
                }
                else if (ns.Notification == "IdProdotto")
                {
                    if (ns.Content != 0)
                    {
                        Dettaglio = new Dettaglio(await service.GetArticolo(ns.Content), 1);
                        OnPropertyChanged(nameof(Dettaglio));
                    }
                }
                else if (ns.Notification == "IdCliente")
                {
                    if (ns.Content != 0)
                        MostraFattura(new Fattura(await service.GetCliente(ns.Content)));
                }
            });
        }

        private void MostraFattura(Fattura fattura)
        {
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
