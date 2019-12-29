using CiccioGest.Domain.ClientiFornitori;
using CiccioGest.Domain.Magazino;
using System.Collections.Generic;
using System.ServiceModel;
using System.Threading.Tasks;

namespace CiccioGest.Application
{
    [ServiceContract(ConfigurationName = "CiccioGest.Application.IMagazinoService")]
    public interface IMagazinoService
    {
        [OperationContract]
        Task<IList<ArticoloReadOnly>> GetArticoli();
        [OperationContract]
        Task<Articolo> GetArticolo(int id);
        [OperationContract]
        Task<Articolo> SaveArticolo(Articolo prodotto);
        [OperationContract]
        Task DeleteArticolo(int id);

        [OperationContract]
        Task<IList<Categoria>> GetCategorie();
        [OperationContract]
        Task<Categoria> GetCategoria(int id);
        [OperationContract]
        Task<Categoria> SaveCategoria(Categoria categoria);
        [OperationContract]
        Task DeleteCategoria(int id);

        [OperationContract]
        Task<Fornitore> GetFornitore(int id);
    }
}
