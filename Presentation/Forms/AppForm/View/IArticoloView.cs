// Copyright (c) 2023 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Domain.Magazino;
using System;
using System.Collections.Generic;

namespace CiccioGest.Presentation.AppForm.View
{
    public interface IArticoloView : IView
    {
        event EventHandler NuovoArticoloEvent;
        event EventHandler SalvaArticoloEvent;
        event EventHandler<int> EliminaArticoloEvent;
        event EventHandler ApriArticoloEvent;
        event EventHandler AggiungiCategoriaEvent;
        event EventHandler<Categoria> RimuoviCategoriaEvent;
        event EventHandler SelezionaFornitore;
        void SetArticolo(Articolo articolo);
        void SetCategorie(ICollection<Categoria> list);
    }
}
