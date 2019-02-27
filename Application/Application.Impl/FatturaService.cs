using Castle.Core.Logging;
using CiccioGest.Domain;
using CiccioGest.Domain.Documenti;
using CiccioGest.Domain.Magazino;
using CiccioGest.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CiccioGest.Domain.ClientiFornitori;

namespace CiccioGest.Application.Impl
{
    class FatturaService : IFatturaService
    {
        private ILogger logger;
        private IUnitOfWork uow;
        private IFatturaRepository fatturaRepository;
        private IProdottoRepository prodottoRepository;

        public FatturaService(
            ILogger logger,
            IUnitOfWork uow,
            IFatturaRepository fatturaRepository,
            IProdottoRepository prodottoRepository)
        {
            this.logger = logger;
            this.uow = uow;
            this.fatturaRepository = fatturaRepository;
            this.prodottoRepository = prodottoRepository;
            logger.Debug(this.GetType().Name + ":" + this.GetHashCode().ToString()+ " (uow:" + uow.GetHashCode().ToString() + " ) Created");
        }

        public void DeleteFattura(int id)
        {
            try
            {
                fatturaRepository.Delete(id);
                uow.Commit();
            }
            catch (Exception ex)
            {
                uow.Rollback();
                throw ex;
            }
        }

        public Fattura GetFattura(int id)
        {
            return fatturaRepository.Get(id);
        }

        public IEnumerable<FatturaReadOnly> GetFatture()
        {
            return fatturaRepository.GetAll();
        }

        public Fattura SaveFattura(Fattura fattura)
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
            catch (Exception ex)
            {
                uow.Rollback();
                throw ex;
            }
            return fattura;
        }

        public Prodotto GetProdotto(int id)
        {
            return prodottoRepository.Get(id);
        }

        public void Dispose()
        {
            logger.Debug(this.GetType().Name + ":" + this.GetHashCode().ToString() + " (uow:" + uow.GetHashCode().ToString() + " ) Disposed");
        }

        public Cliente GetCliente(int idCliente)
        {
            throw new NotImplementedException();
        }
    }
}
