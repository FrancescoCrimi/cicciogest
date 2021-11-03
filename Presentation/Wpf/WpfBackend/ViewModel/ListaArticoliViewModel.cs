using CiccioGest.Application;
using CiccioGest.Presentation.WpfBackend.Services;
using Microsoft.Extensions.Logging;
using Microsoft.Toolkit.Mvvm.Messaging;

namespace CiccioGest.Presentation.WpfBackend.ViewModel
{
    public class ListaArticoliViewModel : ArticoliViewModel
    {
        private readonly INavigationService navigationService;

        public ListaArticoliViewModel(ILogger<ArticoliViewModel> logger,
                                     IMagazinoService magazinoService,
                                     INavigationService navigationService)
            : base(logger,
                   magazinoService,
                   navigationService)
        {
            this.navigationService = navigationService;
            logger.LogDebug("HashCode: " + GetHashCode().ToString() + " Created");
        }

        protected override void ApriArticolo()
        {
            if (ArticoloSelezionato != null)
            {
                Messenger.Send(new ArticoloIdMessage(ArticoloSelezionato.Id));
                navigationService.GoBack();
            }
        }
    }
}
