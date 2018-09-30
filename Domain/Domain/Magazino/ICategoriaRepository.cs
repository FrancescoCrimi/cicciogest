using CiccioGest.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CiccioGest.Domain.Magazino
{
    public interface ICategoriaRepository : IDomainRepository<Categoria>
    {
        IEnumerable<Categoria> GetAll();
    }
}
