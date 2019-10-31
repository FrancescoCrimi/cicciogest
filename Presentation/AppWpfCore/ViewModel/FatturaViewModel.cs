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

namespace CiccioGest.Presentation.AppWpfCore.ViewModel
{
    public sealed class FatturaViewModel : ViewModelBase, IDisposable, ICazzo
    {
        private readonly ILogger logger;
        //private readonly IKernel kernel;
        private readonly IFatturaService service;

        public FatturaViewModel(ILogger logger, IFatturaService service)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            //this.kernel = kernel;
            this.service = service ?? throw new ArgumentNullException(nameof(service));
            if (IsInDesignModeStatic)
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

        public ICommand NuovaFatturaCommand => new RelayCommand(() => MostraFattura(new Fattura()));
        public ICommand SalvaFatturaCommand => new RelayCommand(SalvaFattura);
        public ICommand RimuoviFatturaCommand => new RelayCommand(RimuoviFattura);
        public ICommand ApriFatturaCommand => new RelayCommand(() =>
                MessengerInstance.Send(new NotificationMessage("SelezionaFattura")));
        public ICommand NuovoDettaglioCommand => new RelayCommand(() =>
                MessengerInstance.Send(new NotificationMessage("SelezionaProdotto")));
        public ICommand AggiungiDettaglioCommand => new RelayCommand(AggiungiDettagglio);
        public ICommand RimuoviDettaglioCommand => new RelayCommand(RimuoviDettaglio);
        public ICommand SelezionaDettaglioCommand => new RelayCommand(SelezionaDettaglio);

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

                else if (ns.Notification == "ApriFatturaSelezionata")
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
                //window.Close();
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
                //window.Close();
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
