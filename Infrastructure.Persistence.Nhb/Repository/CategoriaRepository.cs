using Ciccio1.Domain;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ciccio1.Infrastructure.Persistence.Nhb.Repository
{
    class CategoriaRepository : EntityRepository<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository(IDataAccess da)
            : base((DataAccess)da) { }

        public override Categoria Get(Guid id)
        {
            return da.ISession.CreateCriteria<Categoria>().Add(Expression.Eq("IdCategoria", id)).UniqueResult<Categoria>();
        }
    }
}
