// Copyright (c) 2023 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Domain.Documenti;
using System;

namespace CiccioGest.Presentation.AppForm.View
{
    public interface IFatturaView : IView
    {
        event EventHandler NuovaFatturaEvent;
        event EventHandler SalvaFatturaEvent;
        event EventHandler ApriFatturaEvent;
        event EventHandler NuovoDettaglioEvent;
        event EventHandler<Dettaglio> AggiungiDettaglioEvent;
        event EventHandler<Dettaglio> RimuoviDettaglioEvent;
        void SetDettaglio(Dettaglio dettaglio);
        void SetFattura(Fattura fattura);
    }
}
