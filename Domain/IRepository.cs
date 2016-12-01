using Ciccio1.Infrastructure.DomainBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ciccio1.Domain
{
    public interface IFatturaRepository : IEntityRepository<Fattura, int>
    {
    }
    public interface IProdottoRepository : IEntityRepository<Prodotto, int>
    {
    }
    public interface ICategoriaRepository : IEntityRepository<Categoria, int>
    {
    }
}
