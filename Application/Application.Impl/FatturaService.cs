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
        private readonly IUnitOfWork unitOfWork;
        private readonly IFatturaRepository fatturaRepository;
        private readonly IArticoloRepository articoloRepository;
        private readonly IClienteRepository clienteRepository;

        public FatturaService(
            ILogger logger,
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
            logger.Debug("HashCode: " + this.GetHashCode().ToString(CultureInfo.InvariantCulture) + " (uow:" + unitOfWork.GetHashCode().ToString(CultureInfo.InvariantCulture) + " ) Created");
        }

        public async Task DeleteFattura(int id)
        {
            try
            {
                await fatturaRepository.Delete(id);
                unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                unitOfWork.Rollback();
                throw ex;
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
            catch (Exception ex)
            {
                unitOfWork.Rollback();
                throw ex;
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
            logger.Debug("HashCode: " + this.GetHashCode().ToString(CultureInfo.InvariantCulture) + " (uow:" + unitOfWork.GetHashCode().ToString(CultureInfo.InvariantCulture) + " ) Disposed");
        }
    }
}
