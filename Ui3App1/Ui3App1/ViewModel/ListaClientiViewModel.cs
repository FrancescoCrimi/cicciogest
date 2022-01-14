using CiccioGest.Application;
using CiccioGest.Presentation.Ui3App1.Services;
using Microsoft.Extensions.Logging;

namespace CiccioGest.Presentation.Ui3App1.ViewModel
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
            base.ApriCliente();
        }
    }
}