using CiccioGest.Domain;
using CiccioGest.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace CiccioGest.Application
{
    [ServiceContract(ConfigurationName = "CiccioGest.Application.ICategoriaService")]
    public interface ICategoriaService : IDisposable
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
