using CiccioGest.Application;
using CiccioGest.Presentation.WinUiApp1.Services;
using Microsoft.Extensions.Logging;
using Microsoft.Toolkit.Mvvm.Messaging;

namespace CiccioGest.Presentation.WinUiApp1.ViewModel
{
    public class ListaFattureViewModel : FattureViewModel
    {
        public ListaFattureViewModel(ILogger<FattureViewModel> logger,
                                     IFatturaService fatturaService,
                                     INavigationService navigationService)
            : base(logger,
                   fatturaService,
                   navigationService)
        {
        }

        protected override void ApriFattura()
        {
            Messenger.Send(new FatturaIdMessage(FatturaSelezionata.Id));
            navigationService.GoBack();
        }
    }
}