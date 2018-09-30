using CiccioGest.Domain.ClientiFornitori;
using CiccioGest.Domain.Magazino;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace CiccioGest.Application
{
    [ServiceContract(ConfigurationName = "CiccioGest.Application.IMagazinoService")]
    public interface IMagazinoService
    {
        [OperationContract]
        IEnumerable<ProdottoReadOnly> GetProdotti();
        [OperationContract]
        Prodotto GetProdotto(int id);
        [OperationContract]
        Prodotto SaveProdotto(Prodotto prodotto);
        [OperationContract]
        void DeleteProdotto(int id);

        [OperationContract]
        IEnumerable<Categoria> GetCategorie();
        [OperationContract]
        Categoria GetCategoria(int id);
        [OperationContract]
        Categoria SaveCategoria(Categoria categoria);
        [OperationContract]
        void DeleteCategoria(int id);

        [OperationContract]
        Fornitore GetFornitore(int id);
    }
}
