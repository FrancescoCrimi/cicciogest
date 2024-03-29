﻿using CiccioGest.Domain.ClientiFornitori;
using CiccioGest.Domain.Documenti;
using CiccioGest.Domain.Magazino;
using CiccioGest.Infrastructure;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CiccioGest.Application.Impl
{
    class FatturaService : IFatturaService
    {
        private readonly ILogger logger;
        private readonly IUnitOfWork unitOfWork;
        private readonly IFatturaRepository fatturaRepository;
        private readonly IArticoloRepository articoloRepository;
        private readonly IClienteRepository clienteRepository;

        public FatturaService(ILogger<FatturaService> logger,
                              IUnitOfWork unitOfWork,
                              IFatturaRepository fatturaRepository,
                              IArticoloRepository articoloRepository,
                              IClienteRepository clienteRepository)
        {
            this.logger = logger;
            this.unitOfWork = unitOfWork;
            this.fatturaRepository = fatturaRepository;
            this.articoloRepository = articoloRepository;
            this.clienteRepository = clienteRepository;
            logger.LogDebug("Created: " + GetHashCode().ToString() + " (uow: " + unitOfWork.GetHashCode().ToString() + ")");
        }

        public async Task DeleteFattura(int id)
        {
            try
            {
                await fatturaRepository.Delete(id);
                unitOfWork.Commit();
            }
            catch (Exception)
            {
                unitOfWork.Rollback();
                throw;
            }
        }

        public async Task<Fattura> GetFattura(int id)
        {
            return await fatturaRepository.GetById(id);
        }

        public async Task<IList<FatturaReadOnly>> GetFatture()
        {
            return await fatturaRepository.GetAll();
        }

        public async Task<Fattura> SaveFattura(Fattura fattura)
        {
            try
            {
                if (fattura.Id == 0)
                {
                    await fatturaRepository.Save(fattura);
                }
                else
                {
                    await fatturaRepository.Update(fattura);
                }
                unitOfWork.Commit();
                return fattura;
            }
            catch (Exception)
            {
                unitOfWork.Rollback();
                throw;
            }
        }

        public async Task<Articolo> GetArticolo(int id)
        {
            return await articoloRepository.GetById(id);
        }

        public async Task<Cliente> GetCliente(int id)
        {
            return await clienteRepository.GetById(id);
        }

        public void Dispose()
        {
            logger.LogDebug("Disposed: " + GetHashCode().ToString() + " (uow: " + unitOfWork.GetHashCode().ToString() + ")");
        }
    }
}
