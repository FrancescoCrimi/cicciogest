using CiccioGest.Application;
using CiccioGest.Presentation.WpfApp.Contracts;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Extensions.Logging;

namespace CiccioGest.Presentation.WpfApp.ViewModel
{
    public class ClientiDialogViewModel : ClientiViewModel
    {
        public ClientiDialogViewModel(ILogger<ClientiViewModel> logger,
                                      IClientiFornitoriService clientiFornitoriService,
                                      IWindowManagerService windowManagerService)
            : base(logger, clientiFornitoriService, windowManagerService)
        {
        }

        protected override void ApriCliente()
        {
            if (ClienteSelezionato != null)
            {
                Messenger.Send(new ClienteIdMessage(ClienteSelezionato.Id));
                CloseWindow();
            }
        }

        protected override bool EnableCancellaCliente() => false;
    }
}
