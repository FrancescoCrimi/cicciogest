using CiccioGest.Infrastructure.DomainBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CiccioGest.Domain
{
    [Serializable]
    [DataContract(Namespace = "http://gesttest.it")]
    public class DomainEntity<TEntity> : Entity<TEntity, int>
        where TEntity : DomainEntity<TEntity>
    { }


    public interface IDomainRepository<TEntity> : IEntityRepository<TEntity, int>
        where TEntity : DomainEntity<TEntity>
    { }

    public interface IFatturaRepository : IDomainRepository<Fattura>
    { }

    public interface IProdottoRepository : IDomainRepository<Prodotto>
    { }

    public interface ICategoriaRepository : IDomainRepository<Categoria>
    { }
}
