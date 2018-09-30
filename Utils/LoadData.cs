using Castle.MicroKernel.Lifestyle;
using Castle.Windsor;
using CiccioGest.Application;
using CiccioGest.Domain;
using CiccioGest.Domain.Documenti;
using CiccioGest.Domain.Magazino;
using CiccioGest.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CiccioGest.Utils
{
    class LoadData
    {
        public LoadData()
        {
            IWindsorContainer container =  Bootstrap.Windsor;
            container.Install(new CiccioGest.Application.Impl.Installer());

            IDisposable disposable = container.BeginScope();
            IUnitOfWorkFactory da = container.Resolve<IUnitOfWorkFactory>();
            IFatturaService fatturaService = container.Resolve<IFatturaService>();
            IMagazinoService magazinoService = container.Resolve<IMagazinoService>();
            //IProdottoService prodottoService = container.Resolve<IProdottoService>();

            da.CreateDataAccess();

            for (int c = 1; c < 6; c++)
            {
                Categoria cat = new Categoria();
                cat.Nome = "Categoria " + c.ToString();
                magazinoService.SaveCategoria(cat);
            }

            for (int p = 1; p < 6; p++)
            {
                Prodotto prod = new Prodotto();
                prod.Nome = "Prodotto " + p.ToString();
                prod.Prezzo = 10 + p;
                prod.Categoria = magazinoService.GetCategoria(p);
                magazinoService.SaveProdotto(prod);
            }

            for (int i = 1; i < 6; i++)
            {
                Fattura fatt = new Fattura();
                fatt.Nome = "Fattura " + i.ToString();
                for (int o = 1; o < (i + 1); o++)
                {
                    Dettaglio dett = new Dettaglio(fatturaService.GetProdotto(o), o);
                    fatt.AddDettaglio(dett);
                }
                fatturaService.SaveFattura(fatt);
            }

            container.Release(da);
            container.Release(fatturaService);
            //container.Release(prodottoService);
            container.Release(magazinoService);
            disposable.Dispose();
        }
    }
}
