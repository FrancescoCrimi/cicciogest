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

        public FatturaService(
            ILogger logger,
            IDataAccess da
            )
        {

        }

        public void DeleteFattura(Fattura fattura)
        {
            throw new NotImplementedException();
        }

        public Fattura GetFattura(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Fattura> GetFatture()
        {
            throw new NotImplementedException();
        }

        public Fattura SaveFattura(Fattura fattura)
        {
            throw new NotImplementedException();
        }
    }
}
