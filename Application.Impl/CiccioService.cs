using System;
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
        private IKernel kernel = null;
        private ILogger logger = null;
        private IDataAccess da = null;
        private IFatturaRepository fatturaRepository;
        private IProdottoRepository prodottoRepository;
        private ICategoriaRepository categoriaRepository;

        public CiccioService(
            IKernel kernel,
            ILogger logger,
            IDataAccess da,
            Func<IDataAccess, IFatturaRepository> fatturaRepositoryFactory,
            Func<IDataAccess, IProdottoRepository> prodottoRepositoryFactory,
            Func<IDataAccess, ICategoriaRepository> categoriaRepositoryFactory)
        {
            this.kernel = kernel;
            this.logger = logger;
            this.da = da;
            fatturaRepository = fatturaRepositoryFactory(da);
            prodottoRepository = prodottoRepositoryFactory(da);
            categoriaRepository = categoriaRepositoryFactory(da);
            logger.Debug("CiccioService Creata " + this.GetHashCode().ToString());
        }

        #region ICiccioService

        public IEnumerable<Fattura> GetFatture()
        {
            using (IUnitOfWork uow = da.CreateUnitOfWork())
            {
                return fatturaRepository.GetAll();
            }
        }

        public Fattura GetFattura(Guid id)
        {
            using (IUnitOfWork uow = da.CreateUnitOfWork())
            {
                return fatturaRepository.Get(id);
            }
        }

        public void SaveFattura(Fattura fattura)
        {
            using (IUnitOfWorkTrans uow = da.CreateUnitOfWorkTrans())
            {
                try
                {
                    if (fattura.IsTransient())
                    {
                        fattura = Factory.FatturaToPersist(fattura);
                    }
                    fatturaRepository.Save(fattura);
                    uow.Commit();
                }
                catch (Exception ex)
                {
                    uow.Rollback();
                    throw ex;
                }
            }
        }

        public void DeleteFattura(Fattura fattura)
        {
            using (IUnitOfWorkTrans uow = da.CreateUnitOfWorkTrans())
            {
                try
                {
                    fatturaRepository.Delete(fattura);
                    uow.Commit();
                }
                catch (Exception ex)
                {
                    uow.Rollback();
                    throw ex;
                }
            }
        }

        public IEnumerable<Prodotto> GetProdotti()
        {
            using (IUnitOfWork uow = da.CreateUnitOfWork())
            {
                return prodottoRepository.GetAll();
            }
        }

        public Prodotto GetProdotto(Guid id)
        {
            using (IUnitOfWork uow = da.CreateUnitOfWork())
            {
                return prodottoRepository.Get(id);
            }
        }

        public void SaveProdotto(Prodotto prodotto)
        {
            using (IUnitOfWorkTrans uow = da.CreateUnitOfWorkTrans())
            {
                try
                {
                    if (prodotto.IsTransient())
                    {
                        prodotto = Factory.ProdottoToPersist(prodotto);
                    }
                    prodottoRepository.Save(prodotto);
                    uow.Commit();
                }
                catch (Exception)
                {
                    uow.Rollback();
                    throw;
                }
            }
        }

        public void DeleteProdotto(Prodotto prodotto)
        {
            using (IUnitOfWorkTrans uow = da.CreateUnitOfWorkTrans())
            {
                try
                {
                    prodottoRepository.Delete(prodotto);
                    uow.Commit();
                }
                catch (Exception)
                {
                    uow.Rollback();
                    throw;
                }
            }
        }

        public IEnumerable<Categoria> GetCategorie()
        {
            using (IUnitOfWork uow = da.CreateUnitOfWork())
            {
                return categoriaRepository.GetAll();
            }
        }

        public void SaveCategoria(Categoria categoria)
        {
            using (IUnitOfWorkTrans uow = da.CreateUnitOfWorkTrans())
            {
                try
                {
                    if (categoria.IsTransient())
                    {
                        categoria = Factory.CategoriaToPersist(categoria);
                    }
                    categoriaRepository.Save(categoria);
                    uow.Commit();
                }
                catch (Exception ex)
                {
                    uow.Rollback();
                    throw ex;
                }
            }
        }

        public void DeleteCategoria(Categoria categoria)
        {
            using (IUnitOfWorkTrans uow = da.CreateUnitOfWorkTrans())
            {
                try
                {
                    categoriaRepository.Delete(categoria);
                    uow.Commit();
                }
                catch (Exception)
                {
                    uow.Rollback();
                    throw;
                }
            }
        }

        public void Dispose()
        {
            //kernel.ReleaseComponent(da);
            //kernel.ReleaseComponent(fatturaRepository);
            //kernel.ReleaseComponent(prodottoRepository);
            //kernel.ReleaseComponent(categoriaRepository);
            logger.Debug("CiccioService Dispose " + this.GetHashCode().ToString());
        }

        #endregion
    }
}
