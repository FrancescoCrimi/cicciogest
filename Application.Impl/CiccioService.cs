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
            //Func<IDataAccess, IFatturaRepository> fatturaRepositoryFactory,
            //Func<IDataAccess, IProdottoRepository> prodottoRepositoryFactory,
            //Func<IDataAccess, ICategoriaRepository> categoriaRepositoryFactory
            IFatturaRepository fatturaRepository,
            IProdottoRepository prodottoRepository,
            ICategoriaRepository categoriaRepository
            )
        {
            this.kernel = kernel;
            this.logger = logger;
            this.da = da;
            //fatturaRepository = fatturaRepositoryFactory(da);
            //prodottoRepository = prodottoRepositoryFactory(da);
            //categoriaRepository = categoriaRepositoryFactory(da);
            this.fatturaRepository = fatturaRepository;
            this.prodottoRepository = prodottoRepository;
            this.categoriaRepository = categoriaRepository;
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

        public Fattura SaveFattura(Fattura fattura)
        {
            Fattura newFat = null;
            int id = fattura.Id;
            using (IUnitOfWork uow = da.CreateUnitOfWork())
            {
                try
                {
                    if (fattura.IsTransient())
                    {
                        fattura = Factory.FatturaToPersist(fattura);
                        id = fatturaRepository.Save(fattura);
                    }
                    else
                    {
                        fatturaRepository.Update(fattura);
                    }
                    uow.Commit();
                    newFat = fatturaRepository.Get(id);
                }
                catch (Exception ex)
                {
                    uow.Rollback();
                    throw ex;
                }
            }
            return newFat;
        }

        public void DeleteFattura(Fattura fattura)
        {
            using (IUnitOfWork uow = da.CreateUnitOfWork())
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

        public Prodotto SaveProdotto(Prodotto prodotto)
        {
            Prodotto newPro = null;
            using (IUnitOfWork uow = da.CreateUnitOfWork())
            {
                int id = prodotto.Id;
                try
                {
                    if (prodotto.IsTransient())
                    {
                        prodotto = Factory.ProdottoToPersist(prodotto);
                        id = prodottoRepository.Save(prodotto);
                    }
                    else
                    {
                        prodottoRepository.Update(prodotto);
                    }
                    uow.Commit();
                    newPro = prodottoRepository.Get(id);
                }
                catch (Exception)
                {
                    uow.Rollback();
                    throw;
                }
            }
            return newPro;
        }

        public void DeleteProdotto(Prodotto prodotto)
        {
            using (IUnitOfWork uow = da.CreateUnitOfWork())
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

        public Categoria GetCategoria(Guid id)
        {
            using (IUnitOfWork uow = da.CreateUnitOfWork())
            {
                return categoriaRepository.Get(id);
            }
        }

        public Categoria SaveCategoria(Categoria categoria)
        {
            Categoria newCat = null;
            int id = categoria.Id;
            using (IUnitOfWork uow = da.CreateUnitOfWork())
            {
                try
                {
                    if (categoria.IsTransient())
                    {
                        categoria = Factory.CategoriaToPersist(categoria);
                        id = categoriaRepository.Save(categoria);
                    }
                    else
                    {
                        categoriaRepository.Update(categoria);
                    }
                    uow.Commit();
                    newCat = categoriaRepository.Get(id);
                }
                catch (Exception ex)
                {
                    uow.Rollback();
                    throw ex;
                }
            }
            return newCat;
        }

        public void DeleteCategoria(Categoria categoria)
        {
            using (IUnitOfWork uow = da.CreateUnitOfWork())
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
            kernel.ReleaseComponent(fatturaRepository);
            kernel.ReleaseComponent(prodottoRepository);
            kernel.ReleaseComponent(categoriaRepository);
            logger.Debug("CiccioService Dispose " + this.GetHashCode().ToString());
        }

        #endregion
    }
}
