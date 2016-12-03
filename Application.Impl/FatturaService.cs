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
            throw new NotImplementedException();
        }

        public Fattura GetFattura(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Fattura> GetFatture()
        {
            return fatturaRepository.GetAll();
        }

        public Fattura SaveFattura(Fattura fattura)
        {
            throw new NotImplementedException();
        }
    }
}
