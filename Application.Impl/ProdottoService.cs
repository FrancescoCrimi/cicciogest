using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ciccio1.Domain;
using Castle.Core.Logging;
using Ciccio1.Infrastructure;

namespace Ciccio1.Application.Impl
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

        public void DeleteProdotto(Prodotto prodotto)
        {
            try
            {
                prodottoRepository.Delete(prodotto);
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
