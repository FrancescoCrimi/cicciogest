using CiccioGest.Application;
using CiccioGest.Domain.Documenti;
using CiccioGest.Presentation.UwpApp.Services;
using CiccioGest.Presentation.UwpApp.View;
using Microsoft.Extensions.Logging;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Windows.Input;

namespace CiccioGest.Presentation.UwpApp.ViewModel
{
    public class FatturaViewModel : ObservableObject
    {
        private readonly ILogger logger;
        private readonly IFatturaService fatturaService;
        private readonly NavigationService navigationService;
        private ICommand nuovaFatturaCommand;
        private ICommand loadedCommand;

        public FatturaViewModel(ILogger<FatturaViewModel> logger,
                                IFatturaService fatturaService,
                                NavigationService navigationService)
        {
            this.logger = logger;
            this.fatturaService = fatturaService;
            this.navigationService = navigationService;
            logger.LogDebug("HashCode: " + GetHashCode().ToString() + " Created");
        }

        public Fattura Fattura { get; private set; }

        public Dettaglio Dettaglio { get; private set; }

        public Dettaglio DettaglioSelezionato { private get; set; }

        public ICommand LoadedCommand => loadedCommand ?? (loadedCommand = new RelayCommand(() => { }));

        public ICommand NuovaFatturaCommand => nuovaFatturaCommand ?? (nuovaFatturaCommand = new RelayCommand(() => 
        {
            navigationService.Navigate<ClientiPage>();
        }));

        public ICommand SalvaFatturaCommand => new AsyncRelayCommand(async () => 
        {
            try
            {
                await fatturaService.SaveFattura(Fattura);
            }
            catch (Exception)
            {
            }
        });
        
        public ICommand RimuoviFatturaCommand => new AsyncRelayCommand(async () =>
        {
            try
            {
                await fatturaService.DeleteFattura(Fattura.Id);
            }
            catch (Exception)
            {
            }
        });

        public ICommand ApriFatturaCommand => new RelayCommand(() => navigationService.Navigate<FatturePage>());

        public ICommand NuovoDettaglioCommand => new RelayCommand(() => navigationService.Navigate<ArticoliPage>());

        //public ICommand AggiungiDettaglioCommand => new RelayCommand(AggiungiDettagglio);

        //public ICommand RimuoviDettaglioCommand => new RelayCommand(RimuoviDettaglio);

        //public ICommand SelezionaDettaglioCommand => new RelayCommand(SelezionaDettaglio);

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
    }
}
