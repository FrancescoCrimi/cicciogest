// Copyright (c) 2016 - 2025 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Domain.Magazzino;
using System;
using System.Collections.Generic;

namespace CiccioGest.Presentation.AppForm.Views
{
    public interface ICategorieView : IView
    {
        void CaricaCategorie(IList<Categoria> categorie);
        event EventHandler<int> CategoriaSelezionataRequested;
    }
}
