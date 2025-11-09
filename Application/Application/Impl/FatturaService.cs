// Copyright (c) 2016 - 2025 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Domain.ClientiFornitori;
using CiccioGest.Domain.Documenti;
using CiccioGest.Domain.Magazzino;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CiccioGest.Application.Impl
{
    class FatturaService : IFatturaService
    {
        private readonly ILogger _logger;
        private readonly IFatturaRepository _fatturaRepository;
        private readonly IArticoloRepository _articoloRepository;
        private readonly IClienteRepository _clienteRepository;

        public FatturaService(ILogger<FatturaService> logger,
                              IFatturaRepository fatturaRepository,
                              IArticoloRepository articoloRepository,
                              IClienteRepository clienteRepository)
        {
            _logger = logger;
            _fatturaRepository = fatturaRepository;
            _articoloRepository = articoloRepository;
            _clienteRepository = clienteRepository;
            _logger.LogDebug("Created: {HashCode}", GetHashCode().ToString());
        }

        public Task DeleteFattura(int id)
        {
            return _fatturaRepository.Delete(id);
        }

        public Task<Fattura> GetFattura(int id)
        {
            return _fatturaRepository.GetById(id);
        }

        public Task<IList<Fattura>> GetFatture()
        {
            return _fatturaRepository.GetAll();
        }

        public async Task<Fattura> SaveFattura(Fattura fattura)
        {
            if (fattura.Id == 0)
            {
                await _fatturaRepository.Save(fattura);
            }
            else
            {
                await _fatturaRepository.Update(fattura);
            }
            return fattura;
        }

        public Task<Articolo> GetArticolo(int id)
        {
            return _articoloRepository.GetById(id);
        }

        public Task<Cliente> GetCliente(int id)
        {
            return _clienteRepository.GetById(id);
        }

        public void Dispose()
        {
            _logger.LogDebug("Disposed: " + GetHashCode().ToString());
        }
    }
}
