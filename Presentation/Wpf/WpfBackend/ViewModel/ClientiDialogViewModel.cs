using CiccioGest.Application;
using CiccioGest.Presentation.WpfBackend.Services;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Extensions.Logging;

namespace CiccioGest.Presentation.WpfBackend.ViewModel
{
    public class ClientiDialogViewModel : ClientiViewModel
    {
        private readonly INavigationService navigationService;

        public ClientiDialogViewModel(ILogger<ClientiViewModel> logger,
                                      IClientiFornitoriService clientiFornitoriService,
                                      INavigationService navigationService)
            : base(logger, clientiFornitoriService, navigationService)
        {
            this.navigationService = navigationService;
        }

        protected override void ApriCliente()
        {
            Messenger.Send(new ClienteIdMessage(ClienteSelezionato.Id));
            navigationService.GoBack();
        }
    }
}
