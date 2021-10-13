using CiccioGest.Domain.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CiccioGest.Domain.Magazino
{
    public interface IArticoloRepository : IDomainRepository<Articolo>
    {
        Task<IList<ArticoloReadOnly>> GetAll();
    }
}
