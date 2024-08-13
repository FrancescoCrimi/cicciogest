// Copyright (c) 2016 - 2024 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Domain.ClientiFornitori;
using CiccioGest.Domain.Documenti;
using CiccioGest.Domain.Magazzino;
using CiccioGest.Infrastructure.Conf;
using LiteDB;
using Microsoft.Extensions.Logging;
using System;

namespace CiccioGest.Infrastructure.Persistence.LiteDB
{
    internal class UnitOfWorkFactory : IUnitOfWorkFactory
    {
        private readonly ILogger _logger;
        private readonly CiccioGestConf _ciccioGestConf;
        //private LiteDatabase db;

        public UnitOfWorkFactory(ILogger<UnitOfWorkFactory> logger,
                                 CiccioGestConf ciccioGestConf)
        {
            _ciccioGestConf = ciccioGestConf;
            _logger = logger;
            ConfigureLiteDb();
            logger.LogDebug("HashCode: " + GetHashCode().ToString() + " Created");
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
                .DbRef(x => x.Fornitore, "Fornitore");
                //.DbRef(x => x.Categoria, "Categoria")
            mapper.Entity<Dettaglio>()
                .Id(det => det.Id)
                .DbRef(x => x.Articolo, "Articolo");
            mapper.Entity<Fattura>()
                .Id(fat => fat.Id)
                .DbRef(x => x.Cliente, "Cliente");
            //db = new LiteDatabase(@"CiccioGest.db");
            LiteDB = new LiteDatabase(_ciccioGestConf.CS);
        }


        internal LiteDatabase LiteDB { get; private set; }


        public void CreateDataAccess()
        {
            _logger.LogDebug("HashCode: " + GetHashCode().ToString() + " CreateDataAccess");
        }

        public void Dispose()
        {
            _logger.LogDebug("HashCode: " + GetHashCode().ToString() + " Disposed");
            //db.Dispose();
        }

        public void VerifyDataAccess()
        {
            _logger.LogDebug("HashCode: " + GetHashCode().ToString() + " VerifyDataAccess");
        }

        public IUnitOfWork Create()
        {
            throw new NotImplementedException();
        }
    }
}
