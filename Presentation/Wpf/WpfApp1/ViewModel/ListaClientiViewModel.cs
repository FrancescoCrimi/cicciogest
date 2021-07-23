﻿using CiccioGest.Application;
using CiccioGest.Domain.ClientiFornitori;
using CiccioGest.Presentation.WpfApp1.Helpers;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows;
using System.Windows.Input;

namespace CiccioGest.Presentation.WpfApp1.ViewModel
{
    public class ListaClientiViewModel : ObservableRecipient, IDisposable
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
            logger.LogDebug("HashCode: " + GetHashCode().ToString(CultureInfo.InvariantCulture) + " Created");
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
                Messenger.Send(new NotificationMessage<int>(ClienteSelezionato.Id, "IdCliente"));
                wnd.Close();
            }
        });

        public void Dispose()
        {
            logger.LogDebug("HashCode: " + GetHashCode().ToString(CultureInfo.InvariantCulture) + " Disposed");
        }
    }
}