// Copyright (c) 2016 - 2025 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Domain.Documenti;
using System;

namespace CiccioGest.Presentation.AppForm.Views
{
    public interface IFatturaView : IView
    {
        event EventHandler NuovaRequested;
        event EventHandler SalvaRequested;
        event EventHandler ApriRequested;
        event EventHandler? EliminaRequested;
        event EventHandler NuovoDettaglioRequested;
        event EventHandler<Dettaglio> AggiungiDettaglioRequested;
        event EventHandler<Dettaglio> RimuoviDettaglioRequested;
        void SetDettaglio(Dettaglio dettaglio);
        void SetFattura(Fattura fattura);
    }
}
