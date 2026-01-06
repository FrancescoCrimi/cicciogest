// Copyright (c) 2016 - 2026 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Domain.Anagrafica;
using CiccioGest.Domain.Fatturazione;
using CiccioGest.Domain.Magazzino;
using CiccioGest.Infrastructure.Conf;
using CiccioGest.Infrastructure.Persistence.Nhb.Repository;
using Microsoft.Extensions.DependencyInjection;
using NHibernate.Cfg;

namespace CiccioGest.Infrastructure.Persistence.Nhb
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection ConfigurePersistenceNhb(this IServiceCollection serviceCollection,
                                                                 CiccioGestConf conf)
        {
            // Add NHibernate persistence services here

            // 1. Configurazione NHibernate
            var configuration = new Configuration()
                .DataBaseIntegration(db =>
                {
                    switch (conf.Database)
                    {
                        case Databases.MySql:
                            db.ConnectionString = conf.CS;
                            db.Dialect<NHibernate.Dialect.MySQL57Dialect>();
                            db.Driver<NHibernate.Driver.MySqlConnector.MySqlConnectorDriver>();
                            break;
                        case Databases.SQLite:
                            db.ConnectionString = conf.CS;
                            db.Dialect<NHibernate.Dialect.SQLiteDialect>();
                            db.Driver<NHibernate.Driver.SQLite20Driver>();
                            break;
                        case Databases.MsSql:
                            db.ConnectionString = conf.CS;
                            db.Dialect<NHibernate.Dialect.MsSql2012Dialect>();
                            db.Driver<NHibernate.Driver.Sql2008ClientDriver>();
                            //db.Driver<NHibernate.Driver.MicrosoftDataSqlClientDriver>();
                            break;
                        case Databases.PgSql:
                            db.ConnectionString = conf.CS;
                            db.Dialect<NHibernate.Dialect.PostgreSQL83Dialect>();
                            db.Driver<NHibernate.Driver.NpgsqlDriver>();
                            break;
                    }
                    db.LogFormattedSql = true;
                    db.LogFormattedSql = false;
                })
                .SetProperty(NHibernate.Cfg.Environment.CollectionTypeFactoryClass, "CiccioSoft.NhbCollections.CollectionObservableTypeFactory, CiccioSoft.NhbCollections")
                // Aggiunta automatica dei file .hbm.xml dall'assembly del Dominio        
                .AddAssembly("Persistence.Nhb");


            // 2. Registrazione ISessionFactory (SINGLETON)
            var sessionFactory = configuration.BuildSessionFactory();
            serviceCollection
                .AddSingleton(sessionFactory)
                .AddSingleton(configuration);


            // 3. Registrazione ISession (SCOPED)
            serviceCollection
                //.AddScoped(_ => sessionFactory.OpenSession())
                .AddTransient(_ => sessionFactory.OpenSession());

            //serviceCollection
            //    .AddSingleton<UnitOfWorkFactory>()
            //    .AddSingleton<IUnitOfWorkFactory>(sp => sp.GetService<UnitOfWorkFactory>()!);


            // 4. Registrazione Unit of Work
            serviceCollection
                //.AddScoped<UnitOfWork>()
                //.AddScoped<IUnitOfWork>(sp => sp.GetService<UnitOfWork>())
                .AddSingleton<UnitOfWork>()
                .AddSingleton<IUnitOfWork>(sp => sp.GetService<UnitOfWork>()!)

                .AddSingleton<IPersistenceInitializer, PersistenceInitializer>()

                .AddTransient<IFatturaRepository, FatturaRepository>()
                .AddTransient<IArticoloRepository, ArticoloRepository>()
                .AddTransient<IClienteRepository, ClienteRepository>()
                .AddTransient<IFornitoreRepository, FornitoreRepository>()
                .AddTransient<ICategoriaRepository, CategoriaRepository>();

            return serviceCollection;
        }
    }
}
