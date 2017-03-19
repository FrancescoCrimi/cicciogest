using Castle.MicroKernel.Lifestyle;
using CiccioGest.Application;
using CiccioGest.Domain;
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
            Container container = new Container(UI.Form);
            container.Install(new CiccioGest.Application.Impl.Installer());

            IDisposable disposable = container.Windsor.BeginScope();
            IDataAccess da = container.Resolve<IDataAccess>();
            IFatturaService fatturaService = container.Resolve<IFatturaService>();
            ICategoriaService categoriaService = container.Resolve<ICategoriaService>();
            IProdottoService prodottoService = container.Resolve<IProdottoService>();

            da.CreateDataAccess();

            for (int c = 1; c < 6; c++)
            {
                Categoria cat = Factory.NewCategoria();
                cat.Nome = "Categoria " + c.ToString();
                categoriaService.SaveCategoria(cat);
            }

            for (int p = 1; p < 6; p++)
            {
                Prodotto prod = Factory.NewProdotto();
                prod.Nome = "Prodotto " + p.ToString();
                prod.Prezzo = 10 + p;
                prod.Categoria = categoriaService.GetCategoria(p);
                prodottoService.SaveProdotto(prod);
            }

            for (int i = 1; i < 6; i++)
            {
                Fattura fatt = Factory.NewFattura();
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
            container.Release(prodottoService);
            container.Release(categoriaService);
            disposable.Dispose();
        }
    }
}
