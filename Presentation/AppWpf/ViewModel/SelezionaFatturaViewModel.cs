using Castle.Core.Logging;
using CiccioGest.Application;
using CiccioGest.Domain.Documenti;
using CiccioGest.Infrastructure;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows.Input;

namespace CiccioGest.Presentation.AppWpf.ViewModel
{
    public sealed class SelezionaFatturaViewModel : ViewModelBase, IDisposable, ICazzo
    {
        private readonly ILogger logger;
        private readonly IFatturaService fatturaService;
        private readonly INavigationService ns;
        private ICommand loadedCommand;
        private ICommand apriFatturaCommand;

        public SelezionaFatturaViewModel(ILogger logger, IFatturaService fatturaService, INavigationService ns)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.fatturaService = fatturaService;
            this.ns = ns ?? throw new ArgumentNullException(nameof(ns));
            if (fatturaService == null) throw new ArgumentNullException(nameof(fatturaService));
            Fatture = new ObservableCollection<FatturaReadOnly>();

            logger.Debug("HashCode: " + GetHashCode().ToString(CultureInfo.InvariantCulture) + " Created");
        }

        public string Title { get => "Suca Forte"; }
        public ObservableCollection<FatturaReadOnly> Fatture { get; private set; }
        public FatturaReadOnly FatturaSelezionata { private get; set; }

        public ICommand LoadedCommand => loadedCommand ?? (loadedCommand = new RelayCommand(async () =>
        {
            foreach (FatturaReadOnly fatt in await fatturaService.GetFatture())
            {
                Fatture.Add(fatt);
            }
        }));

        public ICommand ApriFatturaCommand => apriFatturaCommand ?? (apriFatturaCommand = new RelayCommand(ApriFattura));

        private void ApriFattura()
        {
            if (FatturaSelezionata != null)
            {
                ns.GoBack();
                MessengerInstance.Send(new NotificationMessage<int>(FatturaSelezionata.Id, "IdFattura"));
            }
        }

        public void Dispose()
        {
            Cleanup();
            logger.Debug("HashCode: " + GetHashCode().ToString(CultureInfo.InvariantCulture) + " Disposed");
        }
    }
}
