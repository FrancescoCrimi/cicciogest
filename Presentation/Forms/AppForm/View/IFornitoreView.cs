// Copyright (c) 2016 - 2025 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Domain.ClientiFornitori;
using System;

namespace CiccioGest.Presentation.AppForm.View
{
    public interface IFornitoreView : IView
    {
        event EventHandler NuovoFornitore;
        event EventHandler SalvaFornitore;
        event EventHandler ApriFornitore;
        void MostraFornitore(Fornitore fornitore);
    }
}
