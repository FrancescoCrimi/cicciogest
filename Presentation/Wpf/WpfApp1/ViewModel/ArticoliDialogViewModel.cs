using CiccioGest.Application;
using CiccioGest.Presentation.WpfApp.Contracts;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Extensions.Logging;

namespace CiccioGest.Presentation.WpfApp.ViewModel
{
    public class ArticoliDialogViewModel : ArticoliViewModel
    {
        public ArticoliDialogViewModel(ILogger<ArticoliViewModel> logger,
                                       IMagazinoService service,
                                       IWindowManagerService windowManagerService)
            : base(logger, service, windowManagerService)
        {
        }

        protected override void ApriArticolo()
        {
            if (ArticoloSelezionato != null)
            {
                Messenger.Send(new ArticoloIdMessage(ArticoloSelezionato.Id));
                CloseWindow();
            }
        }

        protected override bool EnableCancellaArticolo() => false;
    }
}
