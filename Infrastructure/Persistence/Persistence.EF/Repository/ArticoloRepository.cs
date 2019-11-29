using CiccioGest.Domain.Magazino;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CiccioGest.Infrastructure.Persistence.EF.Repository
{
    class ArticoloRepository : DomainRepository<Articolo>, IArticoloRepository
    {
        public Task<IEnumerable<ArticoloReadOnly>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
