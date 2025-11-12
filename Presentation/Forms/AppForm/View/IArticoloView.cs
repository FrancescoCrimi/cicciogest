// Copyright (c) 2016 - 2025 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Domain.Magazzino;
using System;
using System.Collections.Generic;

namespace CiccioGest.Presentation.AppForm.View
{
    public interface IArticoloView : IView
    {
        event EventHandler NuovoArticoloRequested;
        event EventHandler SalvaArticoloRequested;
        event EventHandler<int> EliminaArticoloRequested;
        event EventHandler ApriArticoloRequested;
        event EventHandler AggiungiCategoriaRequested;
        event EventHandler<Categoria> RimuoviCategoriaRequested;
        event EventHandler SelezionaFornitoreRequested;
        void SetArticolo(Articolo articolo);
        void SetCategorie(ICollection<Categoria> list);
    }
}
