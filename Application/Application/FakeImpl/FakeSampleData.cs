using CiccioGest.Domain.ClientiFornitori;
using CiccioGest.Domain.Documenti;
using CiccioGest.Domain.Magazino;
using System.Collections.Generic;
using System.Globalization;

namespace CiccioGest.Application.FakeImpl
{
    public static class FakeSampleData
    {
        public static readonly IList<Categoria> Categorie = new List<Categoria>();
        public static readonly IList<Cliente> Clienti = new List<Cliente>();
        public static readonly IList<Fornitore> Fornitori = new List<Fornitore>();
        public static readonly IList<Articolo> Articoli = new List<Articolo>();
        public static readonly IList<ArticoloReadOnly> ArticoliRO = new List<ArticoloReadOnly>();
        public static readonly IList<Fattura> Fatture = new List<Fattura>();
        public static readonly IList<FatturaReadOnly> FattureRO = new List<FatturaReadOnly>();

        static FakeSampleData()
        {
            CreaCategorie();
            CreaClienti();
            CreaFornitori();
            CreaArticoli();
            CreaFatture();
        }

        private static void CreaCategorie()
        {
            for (int c = 1; c < 11; c++)
            {
                Categoria cat = new Categoria("Categoria " + c.ToString(CultureInfo.InvariantCulture));
                Categorie.Add(cat);
            }
        }

        private static void CreaClienti()
        {
            for (int i = 0; i < 11; i++)
            {
                var cli = new Cliente
                {
                    Cognome = "Cognome " + i.ToString(),
                    Nome = "Nome " + i.ToString(),
                    Email = "cliente" + i.ToString() + "@pippo.com",
                    Telefono = "123456789" + i.ToString(),
                    Indirizzo = "Casa sua n° " + i + 1
                };
                Clienti.Add(cli);
            }
        }

        private static void CreaFornitori()
        {
            for (int i = 0; i < 11; i++)
            {
                var forn = new Fornitore
                {
                    Cognome = "Cognome " + i.ToString(),
                    Nome = "Nome " + i.ToString(),
                    Email = "cliente" + i.ToString() + "@pippo.com",
                    Telefono = "123456789" + i.ToString(),
                    Indirizzo = "Casa sua n° " + i + 1
                };
                Fornitori.Add(forn);
            }
        }

        private static void CreaArticoli()
        {
            for (int p = 1; p < 11; p++)
            {
                Articolo prod = new Articolo("Articolo " + p.ToString(), 10 + p);
                prod.Categoria = Categorie[p - 1];
                Articoli.Add(prod);
                ArticoloReadOnly pro = new ArticoloReadOnly(prod.Id, prod.Nome, prod.Prezzo, prod.NomeCategoria);
                ArticoliRO.Add(pro);
            }
        }

        private static void CreaFatture()
        {
            for (int i = 1; i < 6; i++)
            {
                Fattura fatt = new Fattura(Clienti[i -1]);
                for (int o = 1; o < (i + 1); o++)
                {
                    Dettaglio dett = new Dettaglio(Articoli[o - 1], o);
                    //Dettaglio dett = new Dettaglio(0, Articoli[o - 1], o);
                    fatt.AddDettaglio(dett);
                }
                Fatture.Add(fatt);
                FatturaReadOnly a = new FatturaReadOnly(i, fatt.Nome, fatt.Totale);
                FattureRO.Add(a);
            }
        }
    }
}
