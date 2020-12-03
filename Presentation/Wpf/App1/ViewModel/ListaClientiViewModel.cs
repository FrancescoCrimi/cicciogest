using CiccioGest.Domain.ClientiFornitori;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using CiccioGest.Application;
using System.Windows.Input;
using Castle.Core.Logging;

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
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public ObservableCollection<Cliente> Clienti { get; }

        public Cliente ClienteSelezionato { get; set; }

        public ICommand LoadCommand { get; }

        public ICommand SelezionaClienteCommand { get; }
    }
}
