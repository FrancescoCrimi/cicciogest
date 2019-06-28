using CiccioGest.Domain.Documenti;
using CiccioGest.Domain.Magazino;
using System;
using System.Collections.Generic;

namespace CiccioGest.Presentation.AppWpf.Design
{
    public static class DesignData 
    {
        public static List<Categoria> Categorie = new List<Categoria>();
        public static List<Prodotto> Prodotti = new List<Prodotto>();
        public static List<ProdottoReadOnly> ProdottiRO = new List<ProdottoReadOnly>();
        public static List<Fattura> Fatture = new List<Fattura>();
        public static List<FatturaReadOnly> FattureRO = new List<FatturaReadOnly>();


        static DesignData()
        {

            for (int c = 1; c < 6; c++)
            {
                Categoria cat = new Categoria(c, "Categoria " + c.ToString());
                Categorie.Add(cat);
            }

            for (int p = 1; p < 6; p++)
            {
                Prodotto prod = new Prodotto(p, "Prodotto " + p.ToString(), 10 + p);
                prod.Categoria = Categorie[p - 1];
                Prodotti.Add(prod);
                ProdottoReadOnly pro = new ProdottoReadOnly(prod.Id, prod.Nome, prod.Prezzo, prod.NomeCategoria);
                ProdottiRO.Add(pro);
            }

            for (int i = 1; i < 6; i++)
            {
                Fattura fatt = new Fattura(i, "Fattura " + i.ToString());
                //fatt.Nome = "Fattura " + i.ToString();
                for (int o = 1; o < (i + 1); o++)
                {
                    Dettaglio dett = new Dettaglio(Prodotti[o - 1], o);
                    fatt.AddDettaglio(dett);
                }
                Fatture.Add(fatt);
                FatturaReadOnly a = new FatturaReadOnly(i, fatt.Nome, fatt.Totale);
                FattureRO.Add(a);
            }
        }
    }
}