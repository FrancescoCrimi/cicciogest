using CiccioGest.Application;
using CiccioGest.Domain.ClientiFornitori;
using CiccioGest.Domain.Magazino;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CiccioGest.Presentation.AppWpf.Design
{
    class DesignMagazinoService : IMagazinoService
    {
        public void DeleteCategoria(int id)
        {
            throw new NotImplementedException();
        }

        public void DeleteArticolo(int id)
        {
            throw new NotImplementedException();
        }

        public Categoria GetCategoria(int id)
        {
            return DesignData.Categorie.First(c => c.Id == id);
        }

        public IEnumerable<Categoria> GetCategorie()
        {
            return DesignData.Categorie;
        }

        public Fornitore GetFornitore(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ArticoloReadOnly> GetArticoli()
        {
            return DesignData.ProdottiRO;
        }

        public Articolo GetArticolo(int id)
        {
            return DesignData.Prodotti.First(p => p.Id == id);
        }

        public Categoria SaveCategoria(Categoria categoria)
        {
            throw new NotImplementedException();
        }

        public Articolo SaveArticolo(Articolo prodotto)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            //throw new NotImplementedException();
        }
    }
}
