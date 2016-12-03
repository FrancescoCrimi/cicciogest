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
        Fattura GetFattura(int id);
        [OperationContract]
        Fattura SaveFattura(Fattura fattura);
        [OperationContract]
        void DeleteFattura(Fattura fattura);


        [OperationContract]
        IEnumerable<Prodotto> GetProdotti();
        [OperationContract]
        Prodotto GetProdotto(int id);
        [OperationContract]
        Prodotto SaveProdotto(Prodotto prodotto);
        [OperationContract]
        void DeleteProdotto(Prodotto prodotto);


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
