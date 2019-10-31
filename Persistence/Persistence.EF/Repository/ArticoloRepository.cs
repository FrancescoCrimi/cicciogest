using CiccioGest.Domain.Magazino;
using System;
using System.Collections.Generic;

namespace CiccioGest.Infrastructure.Persistence.EF.Repository
{
    class ArticoloRepository : DomainRepository<Articolo>, IArticoloRepository
    {
        IEnumerable<ArticoloReadOnly> IArticoloRepository.GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
