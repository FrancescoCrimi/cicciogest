using Castle.Core.Logging;
using CiccioGest.Application;
using CiccioGest.Domain.ClientiFornitori;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows;
using System.Windows.Input;

namespace CiccioGest.Presentation.Wpf.App2.ViewModel
{
    public class ListaClientiViewModel : ViewModelBase, IDisposable
    {
        private readonly ILogger logger;
        private readonly IClientiFornitoriService clientiFornitoriService;
        private ICommand loadCommand;
        private ICommand selezionaClienteCommand;

        public ListaClientiViewModel(ILogger logger,
                                     IClientiFornitoriService clientiFornitoriService)
        {
            this.logger = logger;
            this.clientiFornitoriService = clientiFornitoriService;
            Clienti = new ObservableCollection<Cliente>();
            if (IsInDesignMode)
            {
                foreach (var item in clientiFornitoriService.GetClienti().Result)
                {
                    Clienti.Add(item);
                }
            }
            logger.Debug("HashCode: " + GetHashCode().ToString(CultureInfo.InvariantCulture) + " Created");
        }

        public ObservableCollection<Cliente> Clienti { get; }

        public Cliente ClienteSelezionato { get; set; }

        public ICommand LoadCommand => loadCommand ??= new RelayCommand(async () => 
        {
            Clienti.Clear();
            foreach (var item in await clientiFornitoriService.GetClienti())
            {
                Clienti.Add(item);
            }
        });

        public ICommand SelezionaClienteCommand => selezionaClienteCommand ??= new RelayCommand<Window>(async (wnd) => 
        {
            if (ClienteSelezionato != null)
            {

            }
        });

        public void Dispose()
        {
            logger.Debug("HashCode: " + GetHashCode().ToString(CultureInfo.InvariantCulture) + " Disposed");
        }
    }
}
