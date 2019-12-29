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
        private readonly LiteDatabase db;

        public UnitOfWorkFactory(IConf conf, ILogger logger)
        {
            this.conf = conf;
            this.logger = logger;
            db = new LiteDatabase(@"CiccioGest.db");
            //var catcol = db.GetCollection<Categoria>("categoria");
            //var artcol = db.GetCollection<Articolo>("articolo");
            //var detcol = db.GetCollection<Dettaglio>("dettaglio");
            //var fatcol = db.GetCollection<Fattura>("fattura");

            var mapper = BsonMapper.Global;           
            mapper.Entity<Categoria>()
                .Id(cat => cat.Id);
            db.Mapper.Entity<Articolo>()
                .Id(art => art.Id)
                .DbRef(x => x.Categoria, "Categoria");
            db.Mapper.Entity<Dettaglio>()
                .Id(det => det.Id)
                .DbRef(x => x.Articolo, "Articolo");
            db.Mapper.Entity<Fattura>()
                .Id(fat => fat.Id);

            logger.Debug("HashCode: " + GetHashCode().ToString() + " Created");
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
