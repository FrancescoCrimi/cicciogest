using Ciccio1.Infrastructure.DomainBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ciccio1.Domain
{
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
