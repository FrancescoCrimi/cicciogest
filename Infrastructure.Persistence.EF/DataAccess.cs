﻿using Castle.Core.Logging;
using CiccioGest.Infrastructure.Conf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CiccioGest.Infrastructure.Persistence.EF
{
    class DataAccess : IDataAccess
    {
        private ILogger logger;
        private IConf conf;
        private ModelContext context;

        public DataAccess(IConf conf, ILogger logger)
        {
            this.conf = conf;
            this.logger = logger;
        }

        internal ModelContext Model
        {
            get
            {
                return context;
            }
        }

        public void Begin()
        {
            throw new NotImplementedException();
        }

        public void Commit()
        {
            throw new NotImplementedException();
        }

        public void Rollback()
        {
            throw new NotImplementedException();
        }

        public void CreateDataAccess()
        {
            throw new NotImplementedException();
        }

        public void VerifyDataAccess()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
