// Copyright (c) 2023 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Application;
using CiccioGest.Infrastructure;
using CiccioGest.Presentation.WinUiBackend.Contracts.Services;
using Microsoft.Extensions.Logging;

namespace CiccioGest.Presentation.WinUiBackend.ViewModel
{
    public partial class ListaClientiViewModel : ClientiViewModel
    {
        public ListaClientiViewModel(ILogger<ClientiViewModel> logger,
                                     IUnitOfWork unitOfWork,
                                     IClientiFornitoriService clientiFornitoriService,
                                     INavigationService navigationService)
            : base(logger,
                   unitOfWork,
                   clientiFornitoriService,
                   navigationService)
        {
        }

        protected override void ApriCliente()
        {
            base.ApriCliente();
        }
    }
}