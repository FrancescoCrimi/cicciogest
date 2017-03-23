using CiccioGest.Domain;
using CiccioGest.Domain.Model;
using CiccioGest.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CiccioGest.Domain.ReadOnlyModel;

namespace CiccioGest.Infrastructure.Persistence.EF.Repository
{
    class ProdottoRepository : EntityRepository<Prodotto, int>, IProdottoRepository
    {
        IEnumerable<ProdottoReadOnly> IProdottoRepository.GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
