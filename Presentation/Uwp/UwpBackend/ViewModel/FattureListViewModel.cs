using CiccioGest.Application;
using CiccioGest.Presentation.UwpBackend.Services;
using Microsoft.Extensions.Logging;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Messaging;

namespace CiccioGest.Presentation.UwpBackend.ViewModel
{
    public class FattureListViewModel : FattureViewModel
    {
        private readonly INavigationService navigationService;

        public FattureListViewModel(ILogger<FattureViewModel> logger,
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