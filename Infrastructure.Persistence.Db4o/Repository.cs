using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Db4objects.Db4o;
using Db4objects.Db4o.Query;
using Ciccio1.Domain;
using Ciccio1.Infrastructure.DomainBase;
using Castle.Core.Logging;

namespace Ciccio1.Infrastructure.Persistence.Db4o
{
    abstract class EntityRepository<T>
        : IEntityRepository<T> where T : Entity<T>
    {
        protected DataAccess da;

        protected EntityRepository(DataAccess da)
        {
            this.da = da;
        }

        public IList<T> GetAll()
        {
            return da.ObjectContainer.Query<T>();
        }

        public T Get(int id)
        {
            IQuery query = da.ObjectContainer.Query();
            query.Constrain(typeof(T));
            query.Descend("id").Constrain(id);
            IObjectSet rst = query.Execute();
            if (rst.Count == 0)
                return null;
            else
                return (T)rst.Next();
        }

        public T Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public int Save(T entity)
        {
            da.ObjectContainer.Store(entity);
            return 0;
        }

        public void Delete(T entity)
        {
            da.ObjectContainer.Delete(entity);
        }

        public void Update(T entity)
        {
            da.ObjectContainer.Store(entity);
        }
    }



    class FatturaRepository : EntityRepository<Fattura>, IFatturaRepository
    {
        public FatturaRepository(IDataAccess da)
            : base((DataAccess)da) { }
    }

    class ProdottoRepository : EntityRepository<Prodotto>, IProdottoRepository
    {
        public ProdottoRepository(IDataAccess da)
            : base((DataAccess)da) { }
    }

    class CategoriaRepository : EntityRepository<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository(IDataAccess da)
            : base((DataAccess)da) { }
    }
}
