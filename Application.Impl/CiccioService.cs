﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ciccio1.Infrastructure;
using Ciccio1.Domain;
using Castle.Core.Logging;
using Ciccio1.Infrastructure.DomainBase;
using Ciccio1.Application;
using Castle.MicroKernel;

namespace Ciccio1.Application.Impl
{
    class CiccioService : ICiccioService
    {
        private IKernel kernel;
        private ILogger logger;
        private IDataAccess da;
        private IFatturaRepository fatturaRepository;
        private IProdottoRepository prodottoRepository;
        private ICategoriaRepository categoriaRepository;

        public CiccioService(
            IKernel kernel,
            ILogger logger,
            IDataAccess da,
            IFatturaRepository fatturaRepository,
            IProdottoRepository prodottoRepository,
            ICategoriaRepository categoriaRepository
            )
        {
            this.kernel = kernel;
            this.logger = logger;
            this.da = da;
            this.fatturaRepository = fatturaRepository;
            this.prodottoRepository = prodottoRepository;
            this.categoriaRepository = categoriaRepository;
            logger.Debug("CiccioService Creata " + this.GetHashCode().ToString());
        }

        #region ICiccioService

        public IEnumerable<Fattura> GetFatture()
        {
            return fatturaRepository.GetAll();
        }

        public Fattura GetFattura(int id)
        {
            return fatturaRepository.Get(id);
        }

        public Fattura SaveFattura(Fattura fattura)
        {
            try
            {
                if (fattura.Id == 0)
                {
                    fatturaRepository.Save(fattura);
                }
                else
                {
                    fatturaRepository.Update(fattura);
                }
                da.Commit();
            }
            catch (Exception ex)
            {
                da.Rollback();
                throw ex;
            }
            return fattura;
        }

        public void DeleteFattura(Fattura fattura)
        {
            try
            {
                fatturaRepository.Delete(fattura);
                da.Commit();
            }
            catch (Exception ex)
            {
                da.Rollback();
                throw ex;
            }
        }


        public IEnumerable<Prodotto> GetProdotti()
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

        public void DeleteProdotto(Prodotto prodotto)
        {
            try
            {
                prodottoRepository.Delete(prodotto);
                da.Commit();
            }
            catch (Exception)
            {
                da.Rollback();
                throw;
            }
        }


        public IEnumerable<Categoria> GetCategorie()
        {
            return categoriaRepository.GetAll();
        }

        public Categoria GetCategoria(int id)
        {
            return categoriaRepository.Get(id);
        }

        public Categoria SaveCategoria(Categoria categoria)
        {
            try
            {
                if (categoria.Id == 0)
                {
                    categoriaRepository.Save(categoria);
                }
                else
                {
                    categoriaRepository.Update(categoria);
                }
                da.Commit();
            }
            catch (Exception ex)
            {
                da.Rollback();
                throw ex;
            }
            return categoria;
        }

        public void DeleteCategoria(Categoria categoria)
        {
            try
            {
                categoriaRepository.Delete(categoria);
                da.Commit();
            }
            catch (Exception)
            {
                da.Rollback();
                throw;
            }
        }

        public void Dispose()
        {
            //kernel.ReleaseComponent(da);
            kernel.ReleaseComponent(fatturaRepository);
            kernel.ReleaseComponent(prodottoRepository);
            kernel.ReleaseComponent(categoriaRepository);
            logger.Debug("CiccioService Dispose " + this.GetHashCode().ToString());
        }

        #endregion
    }
}
