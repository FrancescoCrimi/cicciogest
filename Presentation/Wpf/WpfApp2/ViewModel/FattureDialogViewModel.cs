using CiccioGest.Application;
using CiccioGest.Presentation.WpfApp.Contracts;
using Microsoft.Extensions.Logging;

namespace CiccioGest.Presentation.WpfApp.ViewModel
{
    public class FattureDialogViewModel : FattureViewModel
    {
        public FattureDialogViewModel(ILogger<FattureViewModel> logger,
                                      IFatturaService fatturaService,
                                      INavigationService navigationService)
            : base(logger, fatturaService, navigationService)
        {
        }

        protected override void ApriFattura()
        {
            base.ApriFattura();
        }
    }
}
