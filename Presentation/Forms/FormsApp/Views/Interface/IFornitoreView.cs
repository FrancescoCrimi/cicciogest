// Copyright (c) 2016 - 2026 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Domain.Anagrafica;
using System;

namespace CiccioGest.Presentation.FormsApp.Views
{
    public interface IFornitoreView : IView
    {
        event EventHandler? NuovoRequested;
        event EventHandler? SalvaRequested;
        event EventHandler? ApriRequested;
        event EventHandler? EliminaRequested;

        void MostraFornitore(Fornitore fornitore);
    }
}
