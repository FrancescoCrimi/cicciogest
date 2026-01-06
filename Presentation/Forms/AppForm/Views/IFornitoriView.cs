// Copyright (c) 2016 - 2026 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Domain.Anagrafica;
using System;
using System.Collections.Generic;

namespace CiccioGest.Presentation.AppForm.Views
{
    public interface IFornitoriView : IView
    {
        event EventHandler<int>? FornitoreSelezionatoRequested;

        void CaricaFornitori(IList<Fornitore> fornitori);
    }
}
