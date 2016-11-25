using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using Ciccio1.Infrastructure;
using Ciccio1.Domain;
using Ciccio1.Infrastructure.DomainBase;
using NHibernate.Criterion;

namespace Ciccio1.Infrastructure.Persistence.Nhb
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
            try
            {
                ICriteria criteria = da.ISession.CreateCriteria<T>();
                return criteria.List<T>();
            }
            catch (NHibernate.Exceptions.GenericADOException ex)
            {
                throw new DataAccessException("Suca Sql", ex);
            }
        }

        public abstract T Get(Guid id);

        public T Get(int id)
        {
            return da.ISession.Get<T>(id);
        }

        public int Save(T entity)
        {
           return (int) da.ISession.Save(entity);
        }

        public void Delete(T entity)
        {
            da.ISession.Delete(entity);
        }

        public void Update(T entity)
        {
            da.ISession.Update(entity);
        }
    }



    class FatturaRepository : EntityRepository<Fattura>, IFatturaRepository
    {
        public FatturaRepository(IDataAccess da)
            : base((DataAccess)da) { }

        public override Fattura Get(Guid id)
        {
            return da.ISession.CreateCriteria<Fattura>().Add(Expression.Eq("IdFattura", id)).UniqueResult<Fattura>();
        }
    }



    class ProdottoRepository : EntityRepository<Prodotto>, IProdottoRepository
    {
        public ProdottoRepository(IDataAccess da)
            : base((DataAccess)da) { }

        public override Prodotto Get(Guid id)
        {
            return da.ISession.CreateCriteria<Prodotto>().Add(Expression.Eq("IdProdotto", id)).UniqueResult<Prodotto>();
        }
    }



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
