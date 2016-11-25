using Ciccio1.Infrastructure.DomainBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ciccio1.Domain
{
    public interface IFatturaRepository : IEntityRepository<Fattura>
    {
    }
    public interface IProdottoRepository : IEntityRepository<Prodotto>
    {
    }
    public interface ICategoriaRepository : IEntityRepository<Categoria>
    {
    }
}
