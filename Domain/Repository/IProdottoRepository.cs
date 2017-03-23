using CiccioGest.Domain.Model;
using CiccioGest.Domain.ReadOnlyModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CiccioGest.Domain.Repository
{
    public interface IProdottoRepository : IDomainRepository<Prodotto>
    {
        IEnumerable<ProdottoReadOnly> GetAll();
    }
}
