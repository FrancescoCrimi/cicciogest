using CiccioGest.Application;
using CiccioGest.Presentation.WpfBackend.Services;
using Microsoft.Extensions.Logging;
using Microsoft.Toolkit.Mvvm.Messaging;

namespace CiccioGest.Presentation.WpfBackend.ViewModel
{
    public class ListaClientiViewModel : ClientiViewModel
    {
        public ListaClientiViewModel(ILogger<ClientiViewModel> logger,
                                     IClientiFornitoriService clientiFornitoriService,
                                     INavigationService navigationService)
            : base(logger,
                   clientiFornitoriService,
                   navigationService)
        {
        }

        protected override void ApriCliente()
        {
            if (ClienteSelezionato != null)
            {
                Messenger.Send(new ClienteIdMessage(ClienteSelezionato.Id));
                navigationService.GoBack();
            }
        }
    }
}
