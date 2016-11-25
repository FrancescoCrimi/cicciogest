using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ciccio1.Domain
{
    public static class Factory
    {
        public static Fattura NewTransientFattura()
        {
            return new Fattura(Guid.Empty);
        }
        public static Fattura FatturaToPersist(Fattura f)
        {
            var newFatt = new Fattura(Guid.NewGuid());
            newFatt.Nome = f.Nome;
            newFatt.ReplaceDettagli(f.Dettagli);
            return newFatt;
        }


        public static Prodotto NewTransientProdotto()
        {
            return new Prodotto(Guid.Empty);
        }
        public static Prodotto ProdottoToPersist(Prodotto p)
        {
            Prodotto np = new Prodotto(Guid.NewGuid());
            np.Nome = p.Nome;
            np.Prezzo = p.Prezzo;
            np.Categoria = p.Categoria;
            return np;
        }


        public static Categoria NewTransientCategoria()
        {
            return new Categoria(Guid.Empty);
        }
        public static Categoria CategoriaToPersist(Categoria c)
        {
            Categoria nc = new Categoria(Guid.NewGuid());
            nc.Nome = c.Nome;
            return nc;
        }


        public static Dettaglio NuovoDettaglio(Prodotto prodotto, int quantità)
        {
            return new Dettaglio(prodotto, quantità);
        }
    }
}
