// Copyright (c) 2016 - 2025 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Domain.ClientiFornitori;
using CiccioGest.Domain.Documenti;
using CiccioGest.Domain.Magazzino;
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
        public static readonly IList<Fattura> Fatture = new List<Fattura>();

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
                    Telefono = "091123456" + i.ToString(),
                    Mobile = "338123456" + i.ToString(),
                    Indirizzo = "Casa sua n° " + i + 1,
                };
                cli.IndirizzoNew.Via = "via Casa sua";
                cli.IndirizzoNew.Civico = (i + 1).ToString();
                cli.IndirizzoNew.Citta = "Palermo";
                cli.IndirizzoNew.CAP = "90100";
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
                    Mobile = "123456789" + i.ToString(),
                    Indirizzo = "Casa sua n° " + i + 1
                };
                forn.IndirizzoNew.Via = "via Casa sua";
                forn.IndirizzoNew.Civico = (i + 1).ToString();
                forn.IndirizzoNew.Citta = "Palermo";
                forn.IndirizzoNew.CAP = "90100";
                Fornitori.Add(forn);
            }
        }

        private static void CreaArticoli()
        {
            for (int p = 1; p < 11; p++)
            {
                
                Articolo articolo = new Articolo("Articolo " + p.ToString(), 10 + p);
                //articolo.AddCategoria(Categorie[p - 1]);
                articolo.Descrizione = "Articolo " + p.ToString() + " Bla bla bla";
                Articoli.Add(articolo);
            }
        }

        private static void CreaFatture()
        {
            for (int i = 1; i < 6; i++)
            {
                Fattura fatt = new Fattura(i, Clienti[i -1]);
                for (int o = 1; o < (i + 1); o++)
                {
                    Dettaglio dett = new Dettaglio(Articoli[o - 1], o);
                    //Dettaglio dett = new Dettaglio(0, Articoli[o - 1], o);
                    fatt.AddDettaglio(dett);
                }
                Fatture.Add(fatt);
            }
        }
    }
}
