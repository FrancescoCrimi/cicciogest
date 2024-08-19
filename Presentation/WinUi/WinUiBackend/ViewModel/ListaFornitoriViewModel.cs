// Copyright (c) 2023 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Application;
using CiccioGest.Infrastructure;
using CiccioGest.Presentation.WinUiBackend.Contracts.Services;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Extensions.Logging;

namespace CiccioGest.Presentation.WinUiBackend.ViewModel
{
    public partial class ListaFornitoriViewModel : FornitoriViewModel
    {
        public ListaFornitoriViewModel(ILogger<FornitoriViewModel> logger,
                                       IUnitOfWork unitOfWork,
                                       INavigationService navigationService,
                                       IClientiFornitoriService clientiFornitoriService)
            : base(logger,
                   unitOfWork,
                   navigationService,
                   clientiFornitoriService)
        {
        }

        protected override void ApriFornitore()
        {
            if (FornitoreSelezionato != null)
            {
                Messenger.Send(new FornitoreIdMessage(FornitoreSelezionato.Id));
                _navigationService.GoBack();
            }
        }
    }
}
