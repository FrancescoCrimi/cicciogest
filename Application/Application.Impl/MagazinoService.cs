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


        public Task DeleteArticolo(int id)
        {
            return Task.Run(() =>
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
            });
        }

        public Task<IList<ArticoloReadOnly>> GetArticoli()
        {
            return prodottoRepository.GetAll();
        }

        public Task<Articolo> GetArticolo(int id)
        {
            return prodottoRepository.GetById(id);
        }

        public async Task<Articolo> SaveArticolo(Articolo prodotto)
        {
            try
            {
                if (prodotto.Id == 0)
                {
                    await prodottoRepository.Save(prodotto);
                }
                else
                {
                    await prodottoRepository.Update(prodotto);
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

        public Task<Categoria> GetCategoria(int id)
        {
            return categoriaRepository.GetById(id);
        }

        public Task<IList<Categoria>> GetCategorie()
        {
            return categoriaRepository.GetAll();
        }

        public async Task<Categoria> SaveCategoria(Categoria categoria)
        {
            try
            {
                if (categoria.Id == 0)
                {
                    await categoriaRepository.Save(categoria);
                }
                else
                {
                    await categoriaRepository.Update(categoria);
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

        public Task DeleteCategoria(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Fornitore> GetFornitore(int id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            logger.Debug("HashCode: " + GetHashCode().ToString(CultureInfo.InvariantCulture) + " Disposed");
        }
    }
}
