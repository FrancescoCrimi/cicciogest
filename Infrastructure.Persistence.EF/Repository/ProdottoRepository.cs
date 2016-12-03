using Ciccio1.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ciccio1.Infrastructure.Persistence.EF.Repository
{
    class ProdottoRepository : EntityRepository<Prodotto, int>, IProdottoRepository
    {
    }
}
