using CiccioGest.Application;
using CiccioGest.Presentation.UwpBackend.Services;
using Microsoft.Extensions.Logging;
using Microsoft.Toolkit.Mvvm.ComponentModel;

namespace CiccioGest.Presentation.UwpBackend.ViewModel
{
    public class ClientiListViewModel : ClientiViewModel
    {
        public ClientiListViewModel(ILogger<ClientiViewModel> logger,
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