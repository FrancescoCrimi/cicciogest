using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ciccio1.Domain;
using Castle.Core.Logging;
using Ciccio1.Infrastructure;

namespace Ciccio1.Application.Impl
{
    class FatturaService : IFatturaService
    {
        private ILogger logger;
        private IDataAccess da;
        private IFatturaRepository fatturaRepository;

        public FatturaService(
            ILogger logger,
            IDataAccess da,
            IFatturaRepository fatturaRepository
            )
        {
            this.logger = logger;
            this.da = da;
            this.fatturaRepository = fatturaRepository;
        }

        public void DeleteFattura(Fattura fattura)
        {
            try
            {
                fatturaRepository.Delete(fattura);
                da.Commit();
            }
            catch (Exception ex)
            {
                da.Rollback();
                throw ex;
            }
        }

        public Fattura GetFattura(int id)
        {
            return fatturaRepository.Get(id);
        }

        public IEnumerable<Fattura> GetFatture()
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
                da.Commit();
            }
            catch (Exception ex)
            {
                da.Rollback();
                throw ex;
            }
            return fattura;
        }

        public void Dispose()
        {
            //throw new NotImplementedException();
        }
    }
}
