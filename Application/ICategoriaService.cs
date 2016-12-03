using Ciccio1.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Ciccio1.Application
{
    [ServiceContract(ConfigurationName = "Ciccio1.Application.ICategoriaService")]
    public interface ICategoriaService
    {
        [OperationContract]
        IEnumerable<Categoria> GetCategorie();
        [OperationContract]
        Categoria GetCategoria(int id);
        [OperationContract]
        Categoria SaveCategoria(Categoria categoria);
        [OperationContract]
        void DeleteCategoria(Categoria categoria);
    }
}
