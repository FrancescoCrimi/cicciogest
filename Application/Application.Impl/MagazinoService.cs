using Castle.Core.Logging;
using CiccioGest.Domain.Magazino;
using CiccioGest.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CiccioGest.Domain.ClientiFornitori;

namespace CiccioGest.Application.Impl
{
    class MagazinoService : IMagazinoService
    {
        private ILogger logger;
        private IUnitOfWork da;
        private IProdottoRepository prodottoRepository;
        private ICategoriaRepository categoriaRepository;

        public MagazinoService(
            ILogger logger,
            IUnitOfWork da,
            IProdottoRepository prodottoRepository,                     
            ICategoriaRepository categoriaRepository)
        {
            this.logger = logger;
            this.da = da;
            this.prodottoRepository = prodottoRepository;
            this.categoriaRepository = categoriaRepository;
            logger.Debug("HashCode: " + GetHashCode().ToString() + " Created");
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

        public Categoria GetCategoria(int id)
        {
            return categoriaRepository.Get(id);
        }

        public IEnumerable<Categoria> GetCategorie()
        {
            return categoriaRepository.GetAll();
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

        public void DeleteCategoria(int id)
        {
            throw new NotImplementedException();
        }

        public Fornitore GetFornitore(int id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            logger.Debug("HashCode: " + GetHashCode().ToString() + " Disposed");
        }
    }
}
