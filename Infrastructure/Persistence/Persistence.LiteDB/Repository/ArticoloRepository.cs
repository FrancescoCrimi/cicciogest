using CiccioGest.Domain.Magazino;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CiccioGest.Infrastructure.Persistence.LiteDB.Repository
{
    internal class ArticoloRepository : DomainRepository<Articolo>, IArticoloRepository
    {
        public ArticoloRepository()
        {
        }

        public Task<IEnumerable<ArticoloReadOnly>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
