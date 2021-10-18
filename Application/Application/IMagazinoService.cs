using CiccioGest.Domain.ClientiFornitori;
using CiccioGest.Domain.Magazino;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CiccioGest.Application
{
    public interface IMagazinoService
    {
        Task<IList<ArticoloReadOnly>> GetArticoli();
        Task<Articolo> GetArticolo(int id);
        Task<Articolo> SaveArticolo(Articolo prodotto);
        Task DeleteArticolo(int id);

        Task<IList<Categoria>> GetCategorie();
        Task<Categoria> GetCategoria(int id);
        Task<Categoria> SaveCategoria(Categoria categoria);
        Task DeleteCategoria(int id);

        Task<Fornitore> GetFornitore(int id);
    }
}
