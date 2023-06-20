// Copyright (c) 2023 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using System;

namespace CiccioGest.Presentation.AppForm.View
{
    public interface IMainView : IView
    {
        event EventHandler FattureEvent;
        event EventHandler ClientiEvent;
        event EventHandler FornitoriEvent;
        event EventHandler ArticoliEvent;
        event EventHandler CategorieEvent;
        event EventHandler OpzioniEvent;
    }
}
