using CiccioGest.Application;
using CiccioGest.Presentation.WpfApp.Contracts;
using Microsoft.Extensions.Logging;

namespace CiccioGest.Presentation.WpfApp.ViewModel
{
    public class ArticoliDialogViewModel : ArticoliViewModel
    {
        public ArticoliDialogViewModel(ILogger<ArticoliViewModel> logger,
                                       IMagazinoService magazinoService,
                                       INavigationService navigationService)
            : base(logger, magazinoService, navigationService)
        {
        }

        protected override void ApriArticolo()
        {
            base.ApriArticolo();
        }
    }
}
