using Castle.Core.Logging;
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
        private readonly IArticoloRepository prodottoRepository;

        public FatturaService(
            ILogger logger,
            IUnitOfWork uow,
            IFatturaRepository fatturaRepository,
            IArticoloRepository prodottoRepository)
        {
            this.logger = logger;
            this.uow = uow;
            this.fatturaRepository = fatturaRepository;
            this.prodottoRepository = prodottoRepository;
            logger.Debug("HashCode: " + this.GetHashCode().ToString(CultureInfo.InvariantCulture) + " (uow:" + uow.GetHashCode().ToString(CultureInfo.InvariantCulture) + " ) Created");
        }

        public Task DeleteFattura(int id)
        {
            return Task.Run(() =>
            {
                try
                {
                    fatturaRepository.Delete(id);
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
            return Task.Run(() => fatturaRepository.GetById(id));
        }

        public Task<IEnumerable<FatturaReadOnly>> GetFatture()
        {
            return Task.Run(() => fatturaRepository.GetAll());
        }

        public Task<Fattura> SaveFattura(Fattura fattura)
        {
            return Task.Run(() =>
            {
                try
                {
                    if (fattura.Id == 0)
                    {
                        fatturaRepository.Save(fattura);
                    }
                    else
                    {
                        fatturaRepository.Update(fattura);
                    }
                    uow.Commit();
                }
                catch (Exception)
                {
                    uow.Rollback();
                    throw;
                }
                return fattura;
            });
        }

        public Task<Articolo> GetArticolo(int id)
        {
            return Task.Run(() => prodottoRepository.GetById(id));
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
