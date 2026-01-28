// Copyright (c) 2016 - 2026 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Domain.Magazzino;
using System;
using System.Collections.Generic;

namespace CiccioGest.Presentation.FormsApp.Views
{
    public interface ICategorieView : IView
    {
        event EventHandler<int>? CategoriaSelezionataRequested;

        void CaricaCategorie(IList<Categoria> categorie);
    }
}
