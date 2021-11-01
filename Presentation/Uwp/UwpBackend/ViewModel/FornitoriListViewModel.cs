using CiccioGest.Application;
using CiccioGest.Presentation.UwpBackend.Services;
//using CiccioGest.Presentation.WpfBackend.Services;
//using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Extensions.Logging;
using Microsoft.Toolkit.Mvvm.Messaging;

namespace CiccioGest.Presentation.UwpBackend.ViewModel
{
    public class FornitoriListViewModel : FornitoriViewModel
    {
        private readonly INavigationService navigationService;

        public FornitoriListViewModel(ILogger<FornitoriViewModel> logger,
                                      INavigationService navigationService,
                                      IClientiFornitoriService clientiFornitoriService)
            : base(logger,
                   navigationService,
                   clientiFornitoriService)
        {
            this.navigationService = navigationService;
            logger.LogDebug("HashCode: " + GetHashCode().ToString() + " Created");
        }

        protected override void ApriFornitore()
        {
            if(FornitoreSelezionato != null)
            {
                Messenger.Send(new FornitoreIdMessage(FornitoreSelezionato.Id));
                navigationService.GoBack();
            }
        }
    }
}
