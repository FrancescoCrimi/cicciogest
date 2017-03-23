﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CiccioGest.Domain;
using Castle.Core.Logging;
using CiccioGest.Infrastructure;
using CiccioGest.Domain.Repository;
using CiccioGest.Domain.Model;
using CiccioGest.Domain.ReadOnlyModel;

namespace CiccioGest.Application.Impl
{
    class FatturaService : IFatturaService
    {
        private ILogger logger;
        private IDataAccess da;
        private IFatturaRepository fatturaRepository;
        private IProdottoRepository prodottoRepository;

        public FatturaService(
            ILogger logger,
            IDataAccess da,
            IFatturaRepository fatturaRepository,
            IProdottoRepository prodottoRepository)
        {
            this.logger = logger;
            this.da = da;
            this.fatturaRepository = fatturaRepository;
            this.prodottoRepository = prodottoRepository;
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

        public Fattura GetFattura(int id)
        {
            return fatturaRepository.Get(id);
        }

        public IEnumerable<FatturaReadOnly> GetFatture()
        {
            da.Begin();
            return fatturaRepository.GetAll();
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

        public Prodotto GetProdotto(int id)
        {
            return prodottoRepository.Get(id);
        }

        public void Dispose()
        {
            //throw new NotImplementedException();
        }
    }
}
