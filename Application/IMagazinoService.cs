using CiccioGest.Domain.ClientiFornitori;
using CiccioGest.Domain.Magazino;
using System.Collections.Generic;
using System.ServiceModel;

namespace CiccioGest.Application
{
    [ServiceContract(ConfigurationName = "CiccioGest.Application.IMagazinoService")]
    public interface IMagazinoService
    {
        [OperationContract]
        IEnumerable<ArticoloReadOnly> GetArticoli();
        [OperationContract]
        Articolo GetArticolo(int id);
        [OperationContract]
        Articolo SaveArticolo(Articolo prodotto);
        [OperationContract]
        void DeleteArticolo(int id);

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
