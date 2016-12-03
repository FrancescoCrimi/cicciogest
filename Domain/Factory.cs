using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ciccio1.Domain
{
    public static class Factory
    {
        public static Fattura NewFattura()
        {
            return new Fattura();
        }

        public static Prodotto NewProdotto()
        {
            return new Prodotto();
        }

        public static Categoria NewCategoria()
        {
            return new Categoria();
        }

        public static Dettaglio NuovoDettaglio(Prodotto prodotto, int quantità)
        {
            return new Dettaglio(prodotto, quantità);
        }
    }
}
