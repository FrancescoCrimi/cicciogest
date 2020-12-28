using Castle.Core.Logging;
using CiccioGest.Application;
using CiccioGest.Domain.ClientiFornitori;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
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
        private readonly IClientiFornitoriService service;
        private ICommand loadCommand;
        private ICommand selezionaClienteCommand;

        public ListaClientiViewModel(ILogger logger,
                                     IClientiFornitoriService clientiFornitoriService)
        {
            this.logger = logger;
            service = clientiFornitoriService;
            Clienti = new ObservableCollection<Cliente>();
            if (IsInDesignMode)
            {
                foreach (var item in service.GetClienti().Result)
                {
                    Clienti.Add(item);
                }
            }
            logger.Debug("HashCode: " + GetHashCode().ToString(CultureInfo.InvariantCulture) + " Created");
        }

        public ObservableCollection<Cliente> Clienti { get; }

        public Cliente ClienteSelezionato { get; set; }

        public ICommand LoadedCommand => loadCommand ??= new RelayCommand(async () =>
        {
            Clienti.Clear();
            foreach (var item in await service.GetClienti())
            {
                Clienti.Add(item);
            }
        });

        public ICommand SelezionaClienteCommand => selezionaClienteCommand ??= new RelayCommand<Window>((wnd) =>
        {
            if (ClienteSelezionato != null)
            {
                MessengerInstance.Send(new NotificationMessage<int>(ClienteSelezionato.Id, "IdCliente"));
                wnd.Close();
            }
        });

        public void Dispose()
        {
            logger.Debug("HashCode: " + GetHashCode().ToString(CultureInfo.InvariantCulture) + " Disposed");
        }
    }
}
