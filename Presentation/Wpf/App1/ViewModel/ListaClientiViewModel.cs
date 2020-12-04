using Castle.Core.Logging;
using CiccioGest.Application;
using CiccioGest.Domain.ClientiFornitori;
using GalaSoft.MvvmLight;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace CiccioGest.Presentation.Wpf.App1.ViewModel
{
    public class ListaClientiViewModel : ViewModelBase, IDisposable
    {
        private readonly ILogger logger;
        private readonly IClientiFornitoriService clientiFornitoriService;

        public ListaClientiViewModel(ILogger logger,
                                     IClientiFornitoriService clientiFornitoriService)
        {
            this.logger = logger;
            this.clientiFornitoriService = clientiFornitoriService;
            logger.Debug("HashCode: " + GetHashCode().ToString() + " Created");
        }

        public ObservableCollection<Cliente> Clienti { get; }

        public Cliente ClienteSelezionato { get; set; }

        public ICommand LoadCommand { get; }

        public ICommand SelezionaClienteCommand { get; }

        public void Dispose()
        {
            logger.Debug("HashCode: " + GetHashCode().ToString() + " Disposed");
        }
    }
}
