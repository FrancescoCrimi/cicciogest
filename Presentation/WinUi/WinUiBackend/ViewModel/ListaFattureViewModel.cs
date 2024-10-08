﻿// Copyright (c) 2023 Francesco Crimi
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
    public partial class ListaFattureViewModel : FattureViewModel
    {
        public ListaFattureViewModel(ILogger<FattureViewModel> logger,
                                     IUnitOfWork unitOfWork,
                                     IFatturaService fatturaService,
                                     INavigationService navigationService)
            : base(logger,
                   unitOfWork,
                   fatturaService,
                   navigationService)
        {
        }

        protected override void ApriFattura()
        {
            Messenger.Send(new FatturaIdMessage(FatturaSelezionata.Id));
            _navigationService.GoBack();
        }
    }
}