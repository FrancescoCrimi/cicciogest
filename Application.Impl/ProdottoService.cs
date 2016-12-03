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
    class ProdottoService : IProdottoService
    {
        private ILogger logger;
        private IDataAccess da;

        public ProdottoService(
            ILogger logger,
            IDataAccess da)
        {
            this.logger = logger;
            this.da = da;
        }

        public void DeleteProdotto(Prodotto prodotto)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Prodotto> GetProdotti()
        {
            throw new NotImplementedException();
        }

        public Prodotto GetProdotto(int id)
        {
            throw new NotImplementedException();
        }

        public Prodotto SaveProdotto(Prodotto prodotto)
        {
            throw new NotImplementedException();
        }
    }
}
