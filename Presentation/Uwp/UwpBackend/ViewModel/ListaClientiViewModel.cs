// Copyright (c) 2023 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Application;
using CiccioGest.Presentation.UwpBackend.Contracts.Services;
using Microsoft.Extensions.Logging;

namespace CiccioGest.Presentation.UwpBackend.ViewModel
{
    public class ListaClientiViewModel : ClientiViewModel
    {
        public ListaClientiViewModel(ILogger<ClientiViewModel> logger,
                                     IClientiFornitoriService clientiFornitoriService,
                                     INavigationService navigationService)
            : base(logger,
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