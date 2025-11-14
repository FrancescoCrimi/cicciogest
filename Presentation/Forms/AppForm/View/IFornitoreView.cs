// Copyright (c) 2016 - 2025 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Domain.Anagrafica;
using System;

namespace CiccioGest.Presentation.AppForm.View
{
    public interface IFornitoreView : IView
    {
        event EventHandler NuovoRequested;
        event EventHandler SalvaRequested;
        event EventHandler ApriRequested;
        event EventHandler? EliminaRequested;
        void MostraFornitore(Fornitore fornitore);
    }
}
