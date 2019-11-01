using Castle.Core.Logging;
using CiccioGest.Domain.ClientiFornitori;
using CiccioGest.Domain.Magazino;
using CiccioGest.Infrastructure;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;

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


        public async Task DeleteArticolo(int id)
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

        public async Task<IEnumerable<ArticoloReadOnly>> GetArticoli()
        {
            return await prodottoRepository.GetAll();
        }

        public async Task<Articolo> GetArticolo(int id)
        {
            return await prodottoRepository.GetById(id);
        }

        public async Task<Articolo> SaveArticolo(Articolo prodotto)
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

        public async Task<Categoria> GetCategoria(int id)
        {
            return await categoriaRepository.GetById(id);
        }

        public async Task<IEnumerable<Categoria>> GetCategorie()
        {
            return await categoriaRepository.GetAll();
        }

        public async Task<Categoria> SaveCategoria(Categoria categoria)
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

        public async Task DeleteCategoria(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Fornitore> GetFornitore(int id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            logger.Debug("HashCode: " + GetHashCode().ToString(CultureInfo.InvariantCulture) + " Disposed");
        }
    }
}
