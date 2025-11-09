// Copyright (c) 2016 - 2025 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Domain.ClientiFornitori;
using CiccioGest.Domain.Documenti;
using CiccioGest.Domain.Magazzino;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CiccioGest.Application
{
    public interface IFatturaService : IDisposable
    {
        Task<IList<Fattura>> GetFatture();

        Task<Fattura> GetFattura(int id);

        Task<Fattura> SaveFattura(Fattura fattura);

        Task DeleteFattura(int id);

        Task<Articolo> GetArticolo(int id);

        Task<Cliente> GetCliente(int id);
    }
}
