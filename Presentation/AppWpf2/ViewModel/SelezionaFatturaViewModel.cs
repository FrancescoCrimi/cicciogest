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
using System.Windows;
using System.Windows.Input;

namespace CiccioGest.Presentation.AppWpf2.ViewModel
{
    public sealed class SelezionaFatturaViewModel : ViewModelBase, IDisposable, ICazzo
    {
        public string Title { get => "Suca Forte"; }
        private readonly ILogger logger;
        private readonly IFatturaService fatturaService;
        private ICommand loadedCommand;
        private ICommand apriFatturaCommand;

        public SelezionaFatturaViewModel(ILogger logger, IFatturaService fatturaService)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.fatturaService = fatturaService;
            Fatture = new ObservableCollection<FatturaReadOnly>();
            //foreach (FatturaReadOnly fatt in service.GetFatture())
            //{
            //    Fatture.Add(fatt);
            //}
            logger.Debug("HashCode: " + GetHashCode().ToString(CultureInfo.InvariantCulture) + " Created");
        }

        public ObservableCollection<FatturaReadOnly> Fatture { get; private set; }
        public FatturaReadOnly FatturaSelezionata { private get; set; }
        public ICommand ApriFatturaCommand => apriFatturaCommand ?? (apriFatturaCommand = new RelayCommand<Window>(ApriFattura));
        public ICommand LoadedCommand => loadedCommand ?? (loadedCommand = new RelayCommand(async () => 
        {
            Fatture.Clear();
            foreach (FatturaReadOnly fatt in await fatturaService.GetFatture())
            {
                Fatture.Add(fatt);
            }
        }));

        private void ApriFattura(Window wnd)
        {
            if (FatturaSelezionata != null)
            {
                MessengerInstance.Send(new NotificationMessage<int>(FatturaSelezionata.Id, "ApriFatturaSelezionata"));
                wnd.Close();
            }
        }

        public void Dispose()
        {
            Cleanup();
            logger.Debug("HashCode: " + GetHashCode().ToString(CultureInfo.InvariantCulture) + " Disposed");
        }
    }
}
