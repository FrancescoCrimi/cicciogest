using CiccioGest.Application;
using CiccioGest.Domain.Documenti;
using CiccioGest.Domain.Magazino;
using CiccioGest.Infrastructure;
using System;
using System.Collections.Generic;

namespace CiccioGest.Presentation.LoadSampleData
{
    class LoadSampleData : IDisposable
    {
        public LoadSampleData(IUnitOfWorkFactory da, IFatturaService fatturaService, IMagazinoService magazinoService)
        {
            da.CreateDataAccess();

            for (int c = 1; c < 11; c++)
            {
                Categoria cat = new Categoria("Categoria " + c.ToString());
                var asdf = magazinoService.SaveCategoria(cat).Result;
                Console.WriteLine(asdf.Id.ToString());
            }

            for (int p = 1; p < 11; p++)
            {
                var listcate = new List<Categoria>(magazinoService.GetCategorie().Result);
                Articolo prod = new Articolo("Articolo " + p.ToString(), 10 + p);
                prod.Categoria = listcate[p - 1];
                magazinoService.SaveArticolo(prod).Wait();
                Console.WriteLine(prod.Id.ToString());
            }

            for (int i = 1; i < 6; i++)
            {
                Fattura fatt = new Fattura("Fattura " + i.ToString());
                for (int o = 1; o < (i + 1); o++)
                {
                    var art = magazinoService.GetArticolo(o).Result;
                    Dettaglio dett = new Dettaglio(art, o);
                    fatt.AddDettaglio(dett);
                }
                var asdsa = fatturaService.SaveFattura(fatt).Result;
                Console.WriteLine(asdsa.Id.ToString());
            }
        }

        public void Dispose()
        {
        }
    }
}
