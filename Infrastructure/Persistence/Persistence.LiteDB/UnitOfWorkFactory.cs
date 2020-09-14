﻿using Castle.Core.Logging;
using CiccioGest.Domain.ClientiFornitori;
using CiccioGest.Domain.Documenti;
using CiccioGest.Domain.Magazino;
using CiccioGest.Infrastructure.Conf;
using LiteDB;
using System;

namespace CiccioGest.Infrastructure.Persistence.LiteDB
{
    internal class UnitOfWorkFactory : IUnitOfWorkFactory
    {
        private readonly IAppConf conf;
        private readonly ILogger logger;
        //private LiteDatabase db;

        public UnitOfWorkFactory(IAppConf conf, ILogger logger)
        {
            this.conf = conf;
            this.logger = logger;
            ConfigureLiteDb();
            logger.Debug("HashCode: " + GetHashCode().ToString() + " Created");
        }

        private void ConfigureLiteDb()
        {
            var mapper = BsonMapper.Global;
            mapper.Entity<Categoria>()
                .Id(cat => cat.Id);
            mapper.Entity<Cliente>()
                .Id(cli => cli.Id);
            mapper.Entity<Fornitore>()
                .Id(forn => forn.Id);
            mapper.Entity<Articolo>()
                .Id(art => art.Id)
                .DbRef(x => x.Fornitore, "Fornitore")
                .DbRef(x => x.Categoria, "Categoria");
            mapper.Entity<Dettaglio>()
                .Id(det => det.Id)
                .DbRef(x => x.Articolo, "Articolo");
            mapper.Entity<Fattura>()
                .Id(fat => fat.Id)
                .DbRef(x => x.Cliente, "Cliente");
            //db = new LiteDatabase(@"CiccioGest.db");
            LiteDB = new LiteDatabase(@conf.CS);
        }


        internal LiteDatabase LiteDB { get; private set; }


        public void CreateDataAccess()
        {
            logger.Debug("HashCode: " + GetHashCode().ToString() + " CreateDataAccess");
        }

        public void Dispose()
        {
            logger.Debug("HashCode: " + GetHashCode().ToString() + " Disposed");
            //db.Dispose();
        }

        public void VerifyDataAccess()
        {
            logger.Debug("HashCode: " + GetHashCode().ToString() + " VerifyDataAccess");
        }
    }
}
