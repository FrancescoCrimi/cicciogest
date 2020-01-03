﻿using Castle.Core.Logging;
using CiccioGest.Domain.ClientiFornitori;
using CiccioGest.Domain.Documenti;
using CiccioGest.Domain.Magazino;
using CiccioGest.Infrastructure;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;

namespace CiccioGest.Application.Impl
{
    class FatturaService : IFatturaService
    {
        private readonly ILogger logger;
        private readonly IUnitOfWork uow;
        private readonly IFatturaRepository fatturaRepository;
        private readonly IArticoloRepository articoloRepository;

        public FatturaService(
            ILogger logger,
            IUnitOfWork uow,
            IFatturaRepository fatturaRepository,
            IArticoloRepository articoloRepository)
        {
            this.logger = logger;
            this.uow = uow;
            this.fatturaRepository = fatturaRepository;
            this.articoloRepository = articoloRepository;
            logger.Debug("HashCode: " + this.GetHashCode().ToString(CultureInfo.InvariantCulture) + " (uow:" + uow.GetHashCode().ToString(CultureInfo.InvariantCulture) + " ) Created");
        }

        public Task DeleteFattura(int id)
        {
            return Task.Run(async () =>
            {
                try
                {
                    await fatturaRepository.Delete(id);
                    uow.Commit();
                }
                catch (Exception)
                {
                    uow.Rollback();
                    throw;
                }
            });
        }

        public Task<Fattura> GetFattura(int id)
        {
            return fatturaRepository.GetById(id);
        }

        public Task<IList<FatturaReadOnly>> GetFatture()
        {
            return fatturaRepository.GetAll();
        }

        public Task<Fattura> SaveFattura(Fattura fattura)
        {
            return Task.Run(async () =>
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
                    uow.Commit();
                }
                catch (Exception ex)
                {
                    uow.Rollback();
                    throw;
                }
                return fattura;
            });
        }

        public Task<Articolo> GetArticolo(int id)
        {
            return articoloRepository.GetById(id);
        }

        public Task<Cliente> GetCliente(int idCliente)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            logger.Debug("HashCode: " + this.GetHashCode().ToString(CultureInfo.InvariantCulture) + " (uow:" + uow.GetHashCode().ToString(CultureInfo.InvariantCulture) + " ) Disposed");
        }
    }
}
