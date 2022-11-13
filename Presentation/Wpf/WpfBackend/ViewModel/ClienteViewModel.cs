using CiccioGest.Application;
using CiccioGest.Domain.ClientiFornitori;
using CiccioGest.Presentation.WpfBackend.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Extensions.Logging;
using System;
using System.Windows.Input;

namespace CiccioGest.Presentation.WpfBackend.ViewModel
{
    public class ClienteViewModel : ObservableRecipient, IDisposable
    {
        private readonly ILogger<ClienteViewModel> logger;
        private readonly INavigationService navigationService;
        private readonly IMessageBoxService messageBoxService;
        private readonly IClientiFornitoriService clientiFornitoriService;
        private RelayCommand loadedCommand;
        private RelayCommand nuovoClienteCommand;
        private RelayCommand salvaClienteCommand;
        private RelayCommand rimuoviClienteCommand;
        private RelayCommand apriClienteCommand;

        public ClienteViewModel(ILogger<ClienteViewModel> logger,
                                INavigationService navigationService,
                                IMessageBoxService messageBoxService,
                                IClientiFornitoriService clientiFornitoriService)
        {
            this.logger = logger;
            this.navigationService = navigationService;
            this.messageBoxService = messageBoxService;
            this.clientiFornitoriService = clientiFornitoriService;
            RegistraMessaggi();
            logger.LogDebug("Created: " + GetHashCode().ToString());
        }

        public Cliente Cliente { get; private set; }

        public Indirizzo Indirizzo { get; private set; }

        public ICommand LoadedCommand
            => loadedCommand ??= new RelayCommand(() => { });

        public ICommand NuovoClienteCommand
            => nuovoClienteCommand ??= new RelayCommand(NuovoCliente);

        public ICommand SalvaClienteCommand => salvaClienteCommand ??= new RelayCommand(() =>
        {
            try
            {
                clientiFornitoriService.SaveCliente(Cliente);
            }
            catch (Exception ex)
            {
                messageBoxService.Show("Errore: " + ex.Message);
            }
        });

        public ICommand RimuoviClienteCommand
            => rimuoviClienteCommand ??= new RelayCommand(() =>
            {
                try
                {
                    clientiFornitoriService.DeleteCliente(Cliente.Id);
                }
                catch (Exception ex)
                {
                    messageBoxService.Show("Errore: " + ex.Message);
                }
            });

        public ICommand ApriClienteCommand
            => apriClienteCommand ??= new RelayCommand(()
                => navigationService.NavigateTo(nameof(ListaClientiViewModel)));




        private void NuovoCliente()
        {
            MostraCliente(new Cliente());
        }

        private void RegistraMessaggi()
        {
            Messenger.Register<ClienteIdMessage>(this, async (r, m) =>
            {
                if (m.Value != 0)
                {
                    Cliente cliente = await clientiFornitoriService.GetCliente(m.Value);
                    MostraCliente(cliente);
                }
            });
        }

        private void MostraCliente(Cliente cliente)
        {
            Cliente = cliente;
            OnPropertyChanged(nameof(Cliente));
            Indirizzo = cliente.IndirizzoNew;
            OnPropertyChanged(nameof(Indirizzo));
        }



        public void Dispose()
        {
            logger.LogDebug("Disposed: " + GetHashCode().ToString());
        }
    }
}
