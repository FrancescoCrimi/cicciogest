// Copyright (c) 2016 - 2024 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Domain.ClientiFornitori;
using CiccioGest.Domain.Magazzino;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CiccioGest.Application.Impl
{
    internal class MagazzinoService : IMagazzinoService
    {
        private readonly ILogger _logger;
        private readonly IArticoloRepository _prodottoRepository;
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly IFornitoreRepository _fornitoreRepository;

        public MagazzinoService(ILogger<MagazzinoService> logger,
                                IArticoloRepository prodottoRepository,
                                ICategoriaRepository categoriaRepository,
                                IFornitoreRepository fornitoreRepository)
        {
            _logger = logger;
            _prodottoRepository = prodottoRepository;
            _categoriaRepository = categoriaRepository;
            _fornitoreRepository = fornitoreRepository;
            _logger.LogDebug("Created: {HashCode}", GetHashCode().ToString());
        }


        public Task DeleteArticolo(int id)
        {
            return _prodottoRepository.Delete(id);
        }

        public Task<IList<Articolo>> GetArticoli()
        {
            return _prodottoRepository.GetAll();
        }

        public Task<Articolo> GetArticolo(int id)
        {
            return _prodottoRepository.GetById(id);
        }

        public async Task<Articolo> SaveArticolo(Articolo articolo)
        {
            if (articolo.Id == 0)
                await _prodottoRepository.Save(articolo);
            else
                await _prodottoRepository.Update(articolo);
            return articolo;
        }

        public Task<Categoria> GetCategoria(int id)
        {
            return _categoriaRepository.GetById(id);
        }

        public Task<IList<Categoria>> GetCategorie()
        {
            return _categoriaRepository.GetAll();
        }

        public async Task<Categoria> SaveCategoria(Categoria categoria)
        {
            if (categoria.Id == 0)
                await _categoriaRepository.Save(categoria);
            else
                await _categoriaRepository.Update(categoria);
            return categoria;
        }

        public Task DeleteCategoria(int id)
        {
            return _categoriaRepository.Delete(id);
        }

        public Task<Fornitore> GetFornitore(int id)
        {
            return _fornitoreRepository.GetById(id);
        }

        public void Dispose()
        {
            _logger.LogDebug("Disposed: " + GetHashCode().ToString());
        }
    }
}
