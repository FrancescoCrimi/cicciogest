// Copyright (c) 2016 - 2025 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Domain.ClientiFornitori;
using CiccioGest.Domain.Magazzino;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CiccioGest.Application
{
    public interface IMagazzinoService
    {
        Task<IList<Articolo>> GetArticoli();
        Task<Articolo> GetArticolo(int id);
        Task<Articolo> SaveArticolo(Articolo prodotto);
        Task DeleteArticolo(int id);

        Task<IList<Categoria>> GetCategorie();
        Task<Categoria> GetCategoria(int id);
        Task<Categoria> SaveCategoria(Categoria categoria);
        Task DeleteCategoria(int id);

        Task<Fornitore> GetFornitore(int id);
    }
}
