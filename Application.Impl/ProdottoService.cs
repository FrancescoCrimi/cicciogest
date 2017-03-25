﻿using Castle.Core.Logging;
using CiccioGest.Domain.Model;
using CiccioGest.Domain.ReadOnlyModel;
using CiccioGest.Domain.Repository;
using CiccioGest.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CiccioGest.Application.Impl
{
    class ProdottoService : IProdottoService
    {
        private ILogger logger;
        private IDataAccess da;
        private IProdottoRepository prodottoRepository;
        private ICategoriaRepository categoriaRepository;

        public ProdottoService(
            ILogger logger,
            IDataAccess da,
            IProdottoRepository prodottoRepository,                     
            ICategoriaRepository categoriaRepository)
        {
            this.logger = logger;
            this.da = da;
            this.prodottoRepository = prodottoRepository;
            this.categoriaRepository = categoriaRepository;
        }

        public void DeleteProdotto(int id)
        {
            try
            {
                prodottoRepository.Delete(id);
                da.Commit();
            }
            catch (Exception ex)
            {
                da.Rollback();
                throw ex;
            }
        }

        public IEnumerable<ProdottoReadOnly> GetProdotti()
        {
            return prodottoRepository.GetAll();
        }

        public Prodotto GetProdotto(int id)
        {
            return prodottoRepository.Get(id);
        }

        public Prodotto SaveProdotto(Prodotto prodotto)
        {
            try
            {
                if (prodotto.Id == 0)
                {
                    prodottoRepository.Save(prodotto);
                }
                else
                {
                    prodottoRepository.Update(prodotto);
                }
                da.Commit();
            }
            catch (Exception ex)
            {
                da.Rollback();
                throw ex;
            }
            return prodotto;
        }

        public void Dispose()
        {
            //throw new NotImplementedException();
        }

        public IEnumerable<Categoria> GetCategorie()
        {
            return categoriaRepository.GetAll();
        }
    }
}
