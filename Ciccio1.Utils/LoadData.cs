using Ciccio1.Application;
using Ciccio1.Domain;
using Ciccio1.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ciccio1.Utils
{
    class LoadData
    {
        public LoadData()
        {
            Container container = new Container();
            container.Install(new Ciccio1.Application.Impl.Installer());
            ICiccioService service = container.Resolve<ICiccioService>();
            for (int c = 1; c < 4; c++)
            {
                Categoria cat = Factory.NewCategoria();
                cat.Nome = "Categoria " + c.ToString();
                service.SaveCategoria(cat);
            }
            for (int p = 1; p < 4; p++)
            {
                Prodotto prod = Factory.NewProdotto();
                prod.Nome = "Prodotto " + p.ToString();
                prod.Prezzo = 10 + p;
                prod.Categoria = service.GetCategoria(p);
                service.SaveProdotto(prod);
            }
            for (int i = 1; i < 4; i++)
            {
                Fattura fatt = Factory.NewFattura();
                fatt.Nome = "Fattura " + i.ToString();
                for (int o = 1; o < 4; o++)
                {
                    Dettaglio dett = new Dettaglio(service.GetProdotto(o), o + i);
                    fatt.AddDettaglio(dett);
                }
                service.SaveFattura(fatt);
            }
        }
    }
}
