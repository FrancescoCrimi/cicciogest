using CiccioGest.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CiccioGest.Domain.Magazino;
using CiccioGest.Domain.ClientiFornitori;

namespace CiccioGest.Presentation.AppWpf.Design
{
    class DesignMagazinoService : IMagazinoService
    {
        private List<Categoria> categorie = new List<Categoria>();
        private List<Prodotto> prodott = new List<Prodotto>();
        private List<ProdottoReadOnly> prodotti = new List<ProdottoReadOnly>();

        public DesignMagazinoService()
        {
            loadData();
        }

        public void DeleteCategoria(int id)
        {
            throw new NotImplementedException();
        }

        public void DeleteProdotto(int id)
        {
            throw new NotImplementedException();
        }

        public Categoria GetCategoria(int id)
        {
            return categorie.First(c => c.Id == id);
        }

        public IEnumerable<Categoria> GetCategorie()
        {
            return categorie;
        }

        public Fornitore GetFornitore(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProdottoReadOnly> GetProdotti()
        {
            return prodotti;
        }

        public Prodotto GetProdotto(int id)
        {
            return prodott.First(p => p.Id == id);
        }

        public Categoria SaveCategoria(Categoria categoria)
        {
            throw new NotImplementedException();
        }

        public Prodotto SaveProdotto(Prodotto prodotto)
        {
            throw new NotImplementedException();
        }

        private void loadData()
        {
            for (int c = 1; c < 6; c++)
            {
                Categoria cat = new Categoria(c, "Categoria " + c.ToString());
                categorie.Add(cat);
            }

            for (int p = 1; p < 6; p++)
            {
                Prodotto prod = new Prodotto(p, "Prodotto " + p.ToString(), 10 + p);
                prod.Categoria = categorie[p - 1];
                prodott.Add(prod);
                ProdottoReadOnly pro = new ProdottoReadOnly(prod.Id, prod.Nome, prod.Prezzo, prod.NomeCategoria);
                prodotti.Add(pro);
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
