﻿using Castle.Core.Logging;
using CiccioGest.Domain.ClientiFornitori;
using CiccioGest.Domain.Magazino;
using CiccioGest.Infrastructure;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;

namespace CiccioGest.Application.Impl
{
    class ClientiFornitoriService : IClientiFornitoriService
    {
        private readonly ILogger logger;
        private readonly IUnitOfWork unitOfWork;
        private readonly IClienteRepository clienteRepository;
        private readonly IFornitoreRepository fornitoreRepository;

        public ClientiFornitoriService(
            ILogger logger,
            IUnitOfWork unitOfWork,
            IClienteRepository clienteRepository,
            IFornitoreRepository fornitoreRepository
            )
        {
            this.logger = logger;
            this.unitOfWork = unitOfWork;
            this.clienteRepository = clienteRepository;
            this.fornitoreRepository = fornitoreRepository;
            logger.Debug("HashCode: " + GetHashCode().ToString(CultureInfo.InvariantCulture) + " Created");
        }

        public Task DeleteCittà(int id)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteCliente(int id)
        {
            try
            {
                await clienteRepository.Delete(id);
                unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                unitOfWork.Rollback();
                throw ex;
            }
        }

        public async Task DeleteFornitore(int id)
        {
            try
            {
                await fornitoreRepository.Delete(id);
                unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                unitOfWork.Rollback();
                throw ex;
            }
        }

        public Task<IList<Citta>> GetCittà()
        {
            throw new NotImplementedException();
        }

        public Task<Citta> GetCittà(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Cliente> GetCliente(int id)
        {
            return await clienteRepository.GetById(id);
        }

        public async Task<IList<Cliente>> GetClienti()
        {
            return await clienteRepository.GetAll();
        }

        public async Task<Fornitore> GetFornitore(int id)
        {
            return await fornitoreRepository.GetById(id);
        }

        public async Task<IList<Fornitore>> GetFornitori()
        {
            return await fornitoreRepository.GetAll();
        }

        public Task<Citta> SaveCittà(Citta città)
        {
            throw new NotImplementedException();
        }

        public async Task<Cliente> SaveCliente(Cliente cliente)
        {
            try
            {
                if (cliente.Id == 0)
                    await clienteRepository.Save(cliente);
                else
                    await clienteRepository.Update(cliente);
                unitOfWork.Commit();
                return cliente;
            }
            catch (Exception ex)
            {
                unitOfWork.Rollback();
                throw ex;
            }
        }

        public async Task<Fornitore> SaveFornitore(Fornitore fornitore)
        {
            try
            {
                if (fornitore.Id == 0)
                    await fornitoreRepository.Save(fornitore);
                else
                    await fornitoreRepository.Update(fornitore);
                unitOfWork.Commit();
                return fornitore;
            }
            catch (Exception ex)
            {
                unitOfWork.Rollback();
                throw ex;
            }
        }

        public void Dispose()
        {
            logger.Debug("HashCode: " + GetHashCode().ToString(CultureInfo.InvariantCulture) + " Disposed");
        }
    }
}
