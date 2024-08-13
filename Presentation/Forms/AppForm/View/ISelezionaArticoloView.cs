﻿// Copyright (c) 2023 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Domain.Magazzino;
using System;
using System.Collections.Generic;

namespace CiccioGest.Presentation.AppForm.View
{
    public interface ISelezionaArticoloView : IView
    {
        void CaricaArticoli(IList<Articolo> articoli);
        event EventHandler<int> ArticoloSelezionatoEvent;
    }
}
