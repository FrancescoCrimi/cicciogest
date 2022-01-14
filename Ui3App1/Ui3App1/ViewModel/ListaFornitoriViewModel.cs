using CiccioGest.Application;
using CiccioGest.Presentation.Ui3App1.Services;
using Microsoft.Extensions.Logging;
using Microsoft.Toolkit.Mvvm.Messaging;

namespace CiccioGest.Presentation.Ui3App1.ViewModel
{
    public class ListaFornitoriViewModel : FornitoriViewModel
    {
        public ListaFornitoriViewModel(ILogger<FornitoriViewModel> logger,
                                       INavigationService navigationService,
                                       IClientiFornitoriService clientiFornitoriService)
            : base(logger,
                   navigationService,
                   clientiFornitoriService)
        {
        }

        protected override void ApriFornitore()
        {
            if (FornitoreSelezionato != null)
            {
                Messenger.Send(new FornitoreIdMessage(FornitoreSelezionato.Id));
                navigationService.GoBack();
            }
        }
    }
}
