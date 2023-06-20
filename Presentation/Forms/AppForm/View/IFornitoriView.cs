﻿// Copyright (c) 2023 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Domain.ClientiFornitori;
using System;
using System.Collections.Generic;

namespace CiccioGest.Presentation.AppForm.View
{
    public interface IFornitoriView : IView
    {
        void CaricaFornitori(IList<Fornitore> fornitori);
        event EventHandler<int> FornitoreSelezionatoEvent;
        event EventHandler NuovoFornitoreEvent;
    }
}
