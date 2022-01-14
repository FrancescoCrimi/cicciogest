using CiccioGest.Application;
using CiccioGest.Presentation.WpfBackend.Services;
using Microsoft.Extensions.Logging;
using Microsoft.Toolkit.Mvvm.Messaging;

namespace CiccioGest.Presentation.WpfBackend.ViewModel
{
    public class ListaFattureViewModel : FattureViewModel
    {
        public ListaFattureViewModel(ILogger<ListaFattureViewModel> logger,
                                     IFatturaService fatturaService,
                                     INavigationService navigationService)
            : base(logger,
                   fatturaService,
                   navigationService)
        {
        }

        protected override void ApriFattura()
        {
            if(FatturaSelezionata != null)
            {
                Messenger.Send(new FatturaIdMessage(FatturaSelezionata.Id));
                navigationService.GoBack();
            }
        }
    }
}
