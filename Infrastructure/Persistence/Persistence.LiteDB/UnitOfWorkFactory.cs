using Castle.Core.Logging;
using CiccioGest.Domain.Documenti;
using CiccioGest.Domain.Magazino;
using CiccioGest.Infrastructure.Conf;
using LiteDB;
using System;

namespace CiccioGest.Infrastructure.Persistence.LiteDB
{
    internal class UnitOfWorkFactory : IUnitOfWorkFactory
    {
        private readonly IConf conf;
        private readonly ILogger logger;
        private LiteDatabase db;

        public UnitOfWorkFactory(IConf conf, ILogger logger)
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
            mapper.Entity<Articolo>()
                .Id(art => art.Id)
                .DbRef(x => x.Categoria, "Categoria");
            mapper.Entity<Dettaglio>()
                .Id(det => det.Id)
                .DbRef(x => x.Articolo, "Articolo");
            //db.Mapper.Entity<Fattura>()
            mapper.Entity<Fattura>()
                .Id(fat => fat.Id);
            //db = new LiteDatabase(@"CiccioGest.db");
            db = new LiteDatabase(@conf.CS);
        }


        internal LiteDatabase LiteDB => db;


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
