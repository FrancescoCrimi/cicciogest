// Copyright (c) 2023 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Domain.ClientiFornitori;
using System;

namespace CiccioGest.Presentation.AppForm.View
{
    public interface IClienteView : IView
    {
        event EventHandler NuovoCliente;
        event EventHandler SalvaCliente;
        event EventHandler ApriCliente;
        void MostraCliente(Cliente cliente);
    }
}
