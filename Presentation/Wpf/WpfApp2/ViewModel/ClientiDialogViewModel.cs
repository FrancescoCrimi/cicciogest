using CiccioGest.Application;
using CiccioGest.Presentation.WpfApp.Contracts;
using Microsoft.Extensions.Logging;

namespace CiccioGest.Presentation.WpfApp.ViewModel
{
    public class ClientiDialogViewModel : ClientiViewModel
    {
        public ClientiDialogViewModel(ILogger<ClientiViewModel> logger,
                                      IClientiFornitoriService clientiFornitoriService,
                                      INavigationService navigationService)
            : base(logger, clientiFornitoriService, navigationService)
        {
        }

        protected override void ApriCliente()
        {
            base.ApriCliente();
        }
    }
}
