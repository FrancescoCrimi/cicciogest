using CiccioGest.Application;
using CiccioGest.Presentation.WinUiApp1.Services;
using Microsoft.Extensions.Logging;
using Microsoft.Toolkit.Mvvm.Messaging;

namespace CiccioGest.Presentation.WinUiApp1.ViewModel
{
    public class ListaArticoliViewModel : ArticoliViewModel
    {
        public ListaArticoliViewModel(ILogger<ArticoliViewModel> logger,
                                      IMagazinoService magazinoService,
                                      INavigationService navigationService)
            : base(logger,
                   magazinoService,
                   navigationService)
        {
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