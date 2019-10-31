using Castle.Core.Logging;
using CiccioGest.Domain.Magazino;
using CiccioGest.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CiccioGest.Domain.ClientiFornitori;
using System.Globalization;

namespace CiccioGest.Application.Impl
{
    internal class MagazinoService : IMagazinoService
    {
        private readonly ILogger logger;
        private readonly IUnitOfWork da;
        private readonly IArticoloRepository prodottoRepository;
        private readonly ICategoriaRepository categoriaRepository;

        public MagazinoService(
            ILogger logger,
            IUnitOfWork da,
            IArticoloRepository prodottoRepository,                     
            ICategoriaRepository categoriaRepository)
        {
            this.logger = logger;
            this.da = da;
            this.prodottoRepository = prodottoRepository;
            this.categoriaRepository = categoriaRepository;
            logger.Debug("HashCode: " + GetHashCode().ToString(CultureInfo.InvariantCulture) + " Created");
        }

        public void DeleteArticolo(int id)
        {
            try
            {
                prodottoRepository.Delete(id);
                da.Commit();
            }
            catch (Exception)
            {
                da.Rollback();
                throw;
            }
        }

        public IEnumerable<ArticoloReadOnly> GetArticoli()
        {
            return prodottoRepository.GetAll();
        }

        public Articolo GetArticolo(int id)
        {
            return prodottoRepository.GetById(id);
        }

        public Articolo SaveArticolo(Articolo prodotto)
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
            catch (Exception)
            {
                da.Rollback();
                throw;
            }
            return prodotto;
        }

        public Categoria GetCategoria(int id)
        {
            return categoriaRepository.GetById(id);
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
            catch (Exception)
            {
                da.Rollback();
                throw;
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
            logger.Debug("HashCode: " + GetHashCode().ToString(CultureInfo.InvariantCulture) + " Disposed");
        }
    }
}
