using CiccioGest.Domain;
using CiccioGest.Domain.Magazino;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CiccioGest.Infrastructure.Persistence.EF.Repository
{
    class ProdottoRepository : DomainRepository<Prodotto>, IProdottoRepository
    {
        IEnumerable<ProdottoReadOnly> IProdottoRepository.GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
