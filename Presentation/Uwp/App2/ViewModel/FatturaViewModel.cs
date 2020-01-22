using Castle.Core.Logging;
using CiccioGest.Application;
using CiccioGest.Domain.Documenti;
using CiccioGest.Infrastructure;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Windows.Input;

namespace CiccioGest.Presentation.Uwp.App2.ViewModel
{
    public class FatturaViewModel : ViewModelBase, ICazzo
    {
        private readonly ILogger logger;
        private readonly IFatturaService service;
        private ICommand nuovaFatturaCommand;
        private ICommand loadedCommand;

        public FatturaViewModel(ILogger logger, IFatturaService service)
        {
            this.logger = logger;
            this.service = service;
            if (IsInDesignModeStatic)
            {
                MostraFattura(service.GetFattura(4).Result);
                Dettaglio = Fattura.Dettagli[3];
            }
            else
            {
                logger.Debug("HashCode: " + GetHashCode().ToString() + " Created");
            }
        }

        public Fattura Fattura { get; private set; }
        public Dettaglio Dettaglio { get; private set; }
        public Dettaglio DettaglioSelezionato { private get; set; }
        public ICommand NuovaFatturaCommand => nuovaFatturaCommand ??
            (nuovaFatturaCommand = new RelayCommand(() => MostraFattura(new Fattura())));

        public ICommand LoadedCommand => loadedCommand ?? (loadedCommand = new RelayCommand(async () =>
        {
            //mostra(new Fattura());
            MostraFattura(await service.GetFattura(4));
        }));

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
        //public ICommand SalvaFatturaCommand => new RelayCommand(SalvaFattura);
        //public ICommand RimuoviFatturaCommand => new RelayCommand(RimuoviFattura);
        //public ICommand ApriFatturaCommand => new RelayCommand(() => ns.Navigate(new SelezionaFatturaView()));
        //public ICommand NuovoDettaglioCommand => new RelayCommand(() => ns.Navigate(new SelezionaProdottoView()));
        //public ICommand AggiungiDettaglioCommand => new RelayCommand(AggiungiDettagglio);
        //public ICommand RimuoviDettaglioCommand => new RelayCommand(RimuoviDettaglio);
        //public ICommand SelezionaDettaglioCommand => new RelayCommand(SelezionaDettaglio);
    }
}
