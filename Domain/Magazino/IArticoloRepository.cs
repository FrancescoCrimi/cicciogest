using CiccioGest.Domain.Common;
using System.Collections.Generic;

namespace CiccioGest.Domain.Magazino
{
    public interface IArticoloRepository : IDomainRepository<Articolo>
    {
        IEnumerable<ArticoloReadOnly> GetAll();
    }
}
