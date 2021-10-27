using CiccioGest.Application;
using CiccioGest.Presentation.WpfBackend.Services;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Extensions.Logging;

namespace CiccioGest.Presentation.WpfBackend.ViewModel
{
    public class FattureListViewModel : FattureViewModel
    {
        private readonly INavigationService navigationService;

        public FattureListViewModel(ILogger<FattureListViewModel> logger,
                                    IFatturaService fatturaService,
                                    INavigationService navigationService)
            : base(logger,
                   fatturaService,
                   navigationService)
        {
            this.navigationService = navigationService;
            logger.LogDebug("HashCode: " + GetHashCode().ToString() + " Created");
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
