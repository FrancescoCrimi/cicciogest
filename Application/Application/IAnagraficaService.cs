// Copyright (c) 2016 - 2025 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Domain.ClientiFornitori;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CiccioGest.Application
{
    public interface IAnagraficaService
    {
        Task<IList<Cliente>> GetClienti();
        Task<Cliente> GetCliente(int id);
        Task<Cliente> SaveCliente(Cliente cliente);
        Task DeleteCliente(int id);

        Task<IList<Fornitore>> GetFornitori();
        Task<Fornitore> GetFornitore(int id);
        Task<Fornitore> SaveFornitore(Fornitore fornitore);
        Task DeleteFornitore(int id);
    }
}
