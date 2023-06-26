// Copyright (c) 2023 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Application;
using CiccioGest.Presentation.WinUiBackend.Contracts.Services;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Extensions.Logging;

namespace CiccioGest.Presentation.WinUiBackend.ViewModel
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