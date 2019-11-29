using CiccioGest.Domain.Documenti;
using CiccioGest.Domain.Magazino;
using System.Collections.Generic;
using System.Globalization;

namespace CiccioGest.Application.FakeImpl
{
    public static class FakeSampleData
    {
        public static readonly List<Categoria> Categorie = new List<Categoria>();
        public static readonly List<Articolo> Articoli = new List<Articolo>();
        public static readonly List<ArticoloReadOnly> ProdottiRO = new List<ArticoloReadOnly>();
        public static readonly List<Fattura> Fatture = new List<Fattura>();
        public static readonly List<FatturaReadOnly> FattureRO = new List<FatturaReadOnly>();

        static FakeSampleData()
        {
            CreaCategorie();
            CreaArticoli();
            CreaFatture();
        }

        private static void CreaCategorie()
        {
            for (int c = 1; c < 8; c++)
            {
                Categoria cat = new Categoria(c, "Categoria " + c.ToString(CultureInfo.InvariantCulture));
                Categorie.Add(cat);
            }
        }

        private static void CreaArticoli()
        {
            for (int p = 1; p < 6; p++)
            {
                Articolo prod = new Articolo(p, "Prodotto " + p.ToString(CultureInfo.InvariantCulture), 10 + p);
                prod.Categoria = Categorie[p - 1];
                Articoli.Add(prod);
                ArticoloReadOnly pro = new ArticoloReadOnly(prod.Id, prod.Nome, prod.Prezzo, prod.NomeCategoria);
                ProdottiRO.Add(pro);
            }
        }

        private static void CreaFatture()
        {
            for (int i = 1; i < 6; i++)
            {
                Fattura fatt = new Fattura(i, "Fattura " + i.ToString(CultureInfo.InvariantCulture));
                //fatt.Nome = "Fattura " + i.ToString();
                for (int o = 1; o < (i + 1); o++)
                {
                    Dettaglio dett = new Dettaglio(Articoli[o - 1], o);
                    fatt.AddDettaglio(dett);
                }
                Fatture.Add(fatt);
                FatturaReadOnly a = new FatturaReadOnly(i, fatt.Nome, fatt.Totale);
                FattureRO.Add(a);
            }
        }
    }
}
