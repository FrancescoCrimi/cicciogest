using Castle.Core.Logging;
using Castle.MicroKernel;
using CiccioGest.Application;
using CiccioGest.Domain.Documenti;
using CiccioGest.Infrastructure;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace CiccioGest.Presentation.AppWpf.ViewModel
{
    public sealed class SelezionaFatturaViewModel : ViewModelBase, IDisposable, ICazzo
    {
        public ObservableCollection<FatturaReadOnly> Fatture { get; private set; }
        public FatturaReadOnly FatturaSelezionata { private get; set; }
        public ICommand ApriFattura { get; private set; }
        private readonly ILogger logger;

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SelezionaFatturaViewModel(ILogger logger, IKernel kernel, IFatturaService service)
        {
            this.logger = logger;
            ApriFattura = new RelayCommand<Window>(apriFattura);
            Fatture = new ObservableCollection<FatturaReadOnly>();
            foreach (FatturaReadOnly fatt in service.GetFatture())
            {
                Fatture.Add(fatt);
            }
            logger.Debug(GetType().Name + ":" + GetHashCode().ToString() + " Created");
        }

        private void apriFattura(Window wnd)
        {
            if (FatturaSelezionata != null)
            {
                MessengerInstance.Send(new NotificationMessage<int>(FatturaSelezionata.Id, "IdFattura"));
                wnd.Close();
            }
        }

        public void Dispose()
        {
            Cleanup();
            logger.Debug(GetType().Name + ":" + GetHashCode().ToString() + " Disposed");
        }
    }
}