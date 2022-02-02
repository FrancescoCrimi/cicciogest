using CiccioGest.Application;
using CiccioGest.Presentation.WinUiApp1.Services;
using Microsoft.Extensions.Logging;

namespace CiccioGest.Presentation.WinUiApp1.ViewModel
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