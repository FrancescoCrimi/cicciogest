// Copyright (c) 2016 - 2026 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Domain.Anagrafica;
using System;
using System.Collections.Generic;

namespace CiccioGest.Presentation.FormsApp.Views
{
    public interface IClientiView : IView
    {
        event EventHandler<int>? ClienteSelezionatoRequested;

        void CaricaClienti(IList<Cliente> clienti);
    }
}
