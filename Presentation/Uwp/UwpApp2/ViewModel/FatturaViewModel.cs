using CiccioGest.Application;
using CiccioGest.Domain.Documenti;
using CiccioGest.Infrastructure;
using Microsoft.Extensions.Logging;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System.Windows.Input;

namespace CiccioGest.Presentation.UwpApp.ViewModel
{
    public class FatturaViewModel : ObservableObject
    {
        private readonly ILogger logger;
        private readonly IFatturaService service;
        private ICommand nuovaFatturaCommand;
        private ICommand loadedCommand;

        public FatturaViewModel(ILogger<FatturaViewModel> logger, IFatturaService service)
        {
            this.logger = logger;
            this.service = service;
            logger.LogDebug("HashCode: " + GetHashCode().ToString() + " Created");
        }

        public Fattura Fattura { get; private set; }

        public Dettaglio Dettaglio { get; private set; }

        public Dettaglio DettaglioSelezionato { private get; set; }

        public ICommand NuovaFatturaCommand => nuovaFatturaCommand ?? (nuovaFatturaCommand = new RelayCommand(() => 
        {
            //MostraFattura(new Fattura());
        }));

        public ICommand LoadedCommand => loadedCommand ?? (loadedCommand = new RelayCommand(async () =>
        {
            MostraFattura(await service.GetFattura(4));
        }));

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
        //public ICommand SalvaFatturaCommand => new RelayCommand(SalvaFattura);
        //public ICommand RimuoviFatturaCommand => new RelayCommand(RimuoviFattura);
        //public ICommand ApriFatturaCommand => new RelayCommand(() => ns.Navigate(new SelezionaFatturaView()));
        //public ICommand NuovoDettaglioCommand => new RelayCommand(() => ns.Navigate(new SelezionaProdottoView()));
        //public ICommand AggiungiDettaglioCommand => new RelayCommand(AggiungiDettagglio);
        //public ICommand RimuoviDettaglioCommand => new RelayCommand(RimuoviDettaglio);
        //public ICommand SelezionaDettaglioCommand => new RelayCommand(SelezionaDettaglio);
    }
}
