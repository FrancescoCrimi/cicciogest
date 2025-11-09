// Copyright (c) 2016 - 2025 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Domain.ClientiFornitori;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CiccioGest.Application.Impl
{
    internal class ClientiFornitoriService : IClientiFornitoriService
    {
        private readonly ILogger _logger;
        private readonly IClienteRepository _clienteRepository;
        private readonly IFornitoreRepository _fornitoreRepository;

        public ClientiFornitoriService(ILogger<ClientiFornitoriService> logger,
                                       IClienteRepository clienteRepository,
                                       IFornitoreRepository fornitoreRepository)
        {
            _logger = logger;
            _clienteRepository = clienteRepository;
            _fornitoreRepository = fornitoreRepository;
            _logger.LogDebug("Created: {HashCode}", GetHashCode().ToString());
        }

        public Task DeleteCliente(int id)
        {
            return _clienteRepository.Delete(id);
        }

        public Task DeleteFornitore(int id)
        {
            return _fornitoreRepository.Delete(id);
        }

        public Task<Cliente> GetCliente(int id)
        {
            return _clienteRepository.GetById(id);
        }

        public Task<IList<Cliente>> GetClienti()
        {
            return _clienteRepository.GetAll();
        }

        public Task<Fornitore> GetFornitore(int id)
        {
            return _fornitoreRepository.GetById(id);
        }

        public Task<IList<Fornitore>> GetFornitori()
        {
            return _fornitoreRepository.GetAll();
        }

        public async Task<Cliente> SaveCliente(Cliente cliente)
        {
            if (cliente.Id == 0)
                await _clienteRepository.Save(cliente);
            else
                await _clienteRepository.Update(cliente);
            return cliente;
        }

        public async Task<Fornitore> SaveFornitore(Fornitore fornitore)
        {
            if (fornitore.Id == 0)
                await _fornitoreRepository.Save(fornitore);
            else
                await _fornitoreRepository.Update(fornitore);
            return fornitore;
        }

        public void Dispose()
        {
            _logger.LogDebug("Disposed: " + GetHashCode().ToString());
        }
    }
}
