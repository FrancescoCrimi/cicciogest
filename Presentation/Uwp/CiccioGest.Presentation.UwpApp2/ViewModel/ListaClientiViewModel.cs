using CiccioGest.Application;
using CiccioGest.Domain.ClientiFornitori;
using Microsoft.Extensions.Logging;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace CiccioGest.Presentation.UwpApp.ViewModel
{
    public class ListaClientiViewModel : ObservableObject, IDisposable
    {
        private readonly ILogger logger;
        private readonly IClientiFornitoriService service;
        private ICommand loadCommand;
        private ICommand selezionaClienteCommand;

        public ListaClientiViewModel(ILogger<ListaClientiViewModel> logger,
                                     IClientiFornitoriService clientiFornitoriService)
        {
            this.logger = logger;
            service = clientiFornitoriService;
            Clienti = new ObservableCollection<Cliente>();
            logger.LogDebug("HashCode: " + GetHashCode().ToString() + " Created");
        }

        public ObservableCollection<Cliente> Clienti { get; }

        public Cliente ClienteSelezionato { get; set; }

        public ICommand LoadedCommand => loadCommand ?? (loadCommand = new RelayCommand(async () =>
        {
            Clienti.Clear();
            foreach (var item in await service.GetClienti())
            {
                Clienti.Add(item);
            }
        }));

        public ICommand SelezionaClienteCommand => selezionaClienteCommand ?? ( selezionaClienteCommand = new RelayCommand(() => 
        {
            if (ClienteSelezionato != null)
            {

            }
        }));

        public void Dispose()
        {
            logger.LogDebug("HashCode: " + GetHashCode().ToString() + " Disposed");
        }
    }
}
