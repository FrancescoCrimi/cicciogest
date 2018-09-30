using CiccioGest.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CiccioGest.Domain.Documenti;
using CiccioGest.Domain.Magazino;
using CiccioGest.Presentation.AppWpf.ViewModel;
using CiccioGest.Domain.ClientiFornitori;

namespace CiccioGest.Presentation.AppWpf.Design
{
    class DesignFatturaService : IFatturaService
    {

        private List<Categoria> categorie = new List<Categoria>();
        private List<Prodotto> prodotti = new List<Prodotto>();
        private List<Fattura> fatture = new List<Fattura>();
        private List<FatturaReadOnly> fattureRO = new List<FatturaReadOnly>();

        public DesignFatturaService()
        {
            loadData();
        }

        public void DeleteFattura(int id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Fattura GetFattura(int id)
        {
            return fatture.First(fa => fa.Id == id);
        }

        public IEnumerable<FatturaReadOnly> GetFatture()
        {
            return fattureRO;
        }

        public Prodotto GetProdotto(int id)
        {
            throw new NotImplementedException();
        }

        public Fattura SaveFattura(Fattura fattura)
        {
            throw new NotImplementedException();
        }

        private  void loadData()
        {
            for (int c = 1; c < 6; c++)
            {
                Categoria cat = new Categoria(c, "Categoria " + c.ToString());
                categorie.Add(cat);
            }

            for (int p = 1; p < 6; p++)
            {
                Prodotto prod = new Prodotto(p, "Prodotto " + p.ToString(), 10 + p);
                prod.Categoria = categorie[p-1];
                prodotti.Add(prod);
            }

            for (int i = 1; i < 6; i++)
            {
                Fattura fatt = new Fattura(i, "Fattura " + i.ToString());
                //fatt.Nome = "Fattura " + i.ToString();
                for (int o = 1; o < (i + 1); o++)
                {
                    Dettaglio dett = new Dettaglio(prodotti[o-1], o);
                    fatt.AddDettaglio(dett);
                }
                fatture.Add(fatt);
                FatturaReadOnly a = new FatturaReadOnly(i, fatt.Nome, fatt.Totale);
                fattureRO.Add(a);
            }
        }

        public Cliente GetCliente(int idCliente)
        {
            throw new NotImplementedException();
        }
    }
}
