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
        private readonly IUnitOfWork unitOfWork;
        private readonly IArticoloRepository prodottoRepository;
        private readonly ICategoriaRepository categoriaRepository;
        private readonly IFornitoreRepository fornitoreRepository;

        public MagazinoService(
            ILogger logger,
            IUnitOfWork unitOfWork,
            IArticoloRepository prodottoRepository,
            ICategoriaRepository categoriaRepository,
            IFornitoreRepository fornitoreRepository)
        {
            this.logger = logger;
            this.unitOfWork = unitOfWork;
            this.prodottoRepository = prodottoRepository;
            this.categoriaRepository = categoriaRepository;
            this.fornitoreRepository = fornitoreRepository;
            logger.Debug("HashCode: " + GetHashCode().ToString(CultureInfo.InvariantCulture) + " Created");
        }


        public async Task DeleteArticolo(int id)
        {
            try
            {
                await prodottoRepository.Delete(id);
                unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                unitOfWork.Rollback();
                throw ex;
            }
        }

        public async Task<IList<ArticoloReadOnly>> GetArticoli()
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
                    await prodottoRepository.Save(prodotto);
                else
                    await prodottoRepository.Update(prodotto);
                unitOfWork.Commit();
                return prodotto;
            }
            catch (Exception ex)
            {
                unitOfWork.Rollback();
                throw ex;
            }
        }

        public async Task<Categoria> GetCategoria(int id)
        {
            return await categoriaRepository.GetById(id);
        }

        public async Task<IList<Categoria>> GetCategorie()
        {
            return await categoriaRepository.GetAll();
        }

        public async Task<Categoria> SaveCategoria(Categoria categoria)
        {
            try
            {
                if (categoria.Id == 0)
                    await categoriaRepository.Save(categoria);
                else
                    await categoriaRepository.Update(categoria);
                unitOfWork.Commit();
                return categoria;
            }
            catch (Exception ex)
            {
                unitOfWork.Rollback();
                throw ex;
            }
        }

        public async Task DeleteCategoria(int id)
        {
            try
            {
                await categoriaRepository.Delete(id);
                unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                unitOfWork.Rollback();
                throw ex;
            }
        }

        public async Task<Fornitore> GetFornitore(int id)
        {
            return await fornitoreRepository.GetById(id);
        }

        public void Dispose()
        {
            logger.Debug("HashCode: " + GetHashCode().ToString(CultureInfo.InvariantCulture) + " Disposed");
        }
    }
}
