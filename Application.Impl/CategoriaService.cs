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
    class CategoriaService : ICategoriaService
    {
        private ILogger logger;
        private IDataAccess da;

        public CategoriaService(
            ILogger logger,
            IDataAccess da
            )
        {

        }

        public void DeleteCategoria(Categoria categoria)
        {
            throw new NotImplementedException();
        }

        public Categoria GetCategoria(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Categoria> GetCategorie()
        {
            throw new NotImplementedException();
        }

        public Categoria SaveCategoria(Categoria categoria)
        {
            throw new NotImplementedException();
        }
    }
}
