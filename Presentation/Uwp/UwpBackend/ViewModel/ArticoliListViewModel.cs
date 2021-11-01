using CiccioGest.Application;
using CiccioGest.Presentation.UwpBackend.Services;
using Microsoft.Extensions.Logging;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Messaging;

namespace CiccioGest.Presentation.UwpBackend.ViewModel
{
    public class ArticoliListViewModel : ArticoliViewModel
    {
        private readonly INavigationService navigationService;

        public ArticoliListViewModel(ILogger<ArticoliViewModel> logger,
                                     IMagazinoService magazinoService,
                                     INavigationService navigationService)
            : base(logger,
                   magazinoService,
                   navigationService)
        {
            this.navigationService = navigationService;
        }

        protected override void ApriArticolo()
        {
            Messenger.Send(new ArticoloIdMessage(ArticoloSelezionato.Id));
            navigationService.GoBack();
        }
    }
}