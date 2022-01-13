using CiccioGest.Application;
using CiccioGest.Presentation.Ui3App1.Services;
using Microsoft.Extensions.Logging;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Messaging;

namespace CiccioGest.Presentation.Ui3App1.ViewModel
{
    public class ListaFattureViewModel : FattureViewModel
    {
        private readonly INavigationService navigationService;

        public ListaFattureViewModel(ILogger<FattureViewModel> logger,
                                    IFatturaService fatturaService,
                                    INavigationService navigationService)
            : base(logger,
                   fatturaService,
                   navigationService)
        {
            this.navigationService = navigationService;
        }

        protected override void ApriFattura()
        {
            Messenger.Send(new FatturaIdMessage(FatturaSelezionata.Id));
            navigationService.GoBack();
        }
    }
}