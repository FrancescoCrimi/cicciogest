// Copyright (c) 2016 - 2025 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Domain.Anagrafica;
using System;
using System.Collections.Generic;

namespace CiccioGest.Presentation.AppForm.View
{
    public interface IClientiView : IView
    {
        void CaricaClienti(IList<Cliente> clienti);
        event EventHandler<int> ClienteSelezionatoRequested;
    }
}
