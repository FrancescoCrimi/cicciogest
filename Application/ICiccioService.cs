using Ciccio1.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Ciccio1.Application
{
    [ServiceContract(ConfigurationName = "Ciccio1.Application.ICiccioService")]
    public interface ICiccioService : IDisposable
    {
        [OperationContract]
        IEnumerable<Fattura> GetFatture();
        [OperationContract]
        Fattura GetFattura(Guid id);
        [OperationContract]
        void SaveFattura(Fattura fattura);
        [OperationContract]
        void DeleteFattura(Fattura fattura);


        [OperationContract]
        IEnumerable<Prodotto> GetProdotti();
        [OperationContract]
        Prodotto GetProdotto(Guid id);
        [OperationContract]
        void SaveProdotto(Prodotto prodotto);
        [OperationContract]
        void DeleteProdotto(Prodotto prodotto);


        [OperationContract]
        IEnumerable<Categoria> GetCategorie();
        [OperationContract]
        void SaveCategoria(Categoria categoria);
        [OperationContract]
        void DeleteCategoria(Categoria categoria);
    }
}
