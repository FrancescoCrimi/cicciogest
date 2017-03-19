using Castle.Core.Logging;
using CiccioGest.Infrastructure;
using CiccioGest.Infrastructure.Conf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CiccioGest.Infrastructure.Persistence.EFC
{
    class DataAccess : IDataAccess
    {
        private IConf conf;
        private ILogger logger;
        private ModelContext dbCtx;

        public DataAccess(IConf conf, ILogger logger)
        {
            this.conf = conf;
            this.logger = logger;
        }

        #region Metodi Pubblici

        public void Begin()
        {
            throw new NotImplementedException();
        }

        public void Commit()
        {
            dbCtx.SaveChanges();
            disposeCtx();
        }

        public void Rollback()
        {
            disposeCtx();
        }

        public void CreateDataAccess()
        {
            ModelContext.Database.EnsureCreated();
        }

        public void VerifyDataAccess()
        {
            //throw new NotImplementedException();
        }

        public void Dispose()
        {
            disposeCtx();
        }

        #endregion



        #region Metodi Internal

        internal ModelContext ModelContext
        {
            get
            {
                if(dbCtx == null)
                {
                    createCtx();
                }
                return dbCtx;
            }
        }

        #endregion



        #region Metodi Privati

        private void createCtx()
        {
            dbCtx = new ModelContext();
        }

        private void disposeCtx()
        {
            dbCtx.Dispose();
            dbCtx = null;
        }

        #endregion
    }
}
