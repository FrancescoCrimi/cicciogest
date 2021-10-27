using CiccioGest.Application;
using CiccioGest.Presentation.WpfBackend.Services;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Extensions.Logging;

namespace CiccioGest.Presentation.WpfBackend.ViewModel
{
    public class ClientiListViewModel : ClientiViewModel
    {
        private readonly INavigationService navigationService;

        public ClientiListViewModel(ILogger<ClientiViewModel> logger,
                                    IClientiFornitoriService clientiFornitoriService,
                                    INavigationService navigationService)
            : base(logger,
                   clientiFornitoriService,
                   navigationService)
        {
            this.navigationService = navigationService;
            logger.LogDebug("HashCode: " + GetHashCode().ToString() + " Created");
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
