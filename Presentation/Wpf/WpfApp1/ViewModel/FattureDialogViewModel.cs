using CiccioGest.Application;
using CiccioGest.Presentation.WpfApp.Contracts;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Extensions.Logging;

namespace CiccioGest.Presentation.WpfApp.ViewModel
{
    public class FattureDialogViewModel : FattureViewModel
    {
        public FattureDialogViewModel(ILogger<FattureViewModel> logger,
                                      IFatturaService fatturaService,
                                      IWindowManagerService windowManagerService)
            : base(logger, fatturaService, windowManagerService)
        {
        }

        protected override void ApriFattura()
        {
            if (FatturaSelezionata != null)
            {
                Messenger.Send(new FatturaIdMessage(FatturaSelezionata.Id));
                CloseWindow();
            }
        }

        protected override bool EnableCancellaFattura() => false;
    }
}
