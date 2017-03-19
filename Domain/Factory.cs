using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CiccioGest.Domain
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
    }
}
