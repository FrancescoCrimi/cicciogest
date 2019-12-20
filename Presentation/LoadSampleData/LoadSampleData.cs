using CiccioGest.Application;
using CiccioGest.Application.FakeImpl;
using CiccioGest.Domain.Documenti;
using CiccioGest.Domain.Magazino;
using CiccioGest.Infrastructure;

namespace CiccioGest.Presentation.LoadSampleData
{
    class LoadSampleData
    {
        public LoadSampleData(IUnitOfWorkFactory da, IFatturaService fatturaService, IMagazinoService magazinoService)
        {
            da.CreateDataAccess();

            foreach (Categoria cat in FakeSampleData.Categorie)
            {
                magazinoService.SaveCategoria(cat);
            }

            foreach (Articolo arti in FakeSampleData.Articoli)
            {
                magazinoService.SaveArticolo(arti);
            }

            foreach (Fattura fatt in FakeSampleData.Fatture)
            {
                fatturaService.SaveFattura(fatt);
            }
        }
    }
}
