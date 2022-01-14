using CiccioGest.Application;
using CiccioGest.Presentation.WpfBackend.Services;
using Microsoft.Extensions.Logging;
using Microsoft.Toolkit.Mvvm.Messaging;

namespace CiccioGest.Presentation.WpfBackend.ViewModel
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
