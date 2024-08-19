// Copyright (c) 2016 - 2024 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Infrastructure.Conf;
using Microsoft.Extensions.Logging;
using MySqlConnector;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using System;
using System.Data.SQLite;
using System.IO;

namespace CiccioGest.Infrastructure.Persistence.Nhb
{
    internal class UnitOfWorkFactory : IUnitOfWorkFactory
    {
        private readonly ILogger _logger;
        private readonly CiccioGestConf _conf;
        private readonly ISessionFactory _sessionFactory;

        public UnitOfWorkFactory(ILogger<UnitOfWorkFactory> logger,
                                 CiccioGestConf conf)
        {
            _conf = conf;
            _logger = logger;
            if (_sessionFactory == null || _sessionFactory.IsClosed)
            {
                if (_sessionFactory != null)
                {
                    _sessionFactory.Dispose();
                    _sessionFactory = null!;
                }
                _sessionFactory = GetNhbConfiguration().BuildSessionFactory();
            }
            _logger.LogDebug("Created: {HashCode}", GetHashCode().ToString());
        }


        #region Private Method

        private Configuration GetNhbConfiguration()
        {
            NHibernate.Cfg.Configuration configuration = new NHibernate.Cfg.Configuration();
            configuration.SetProperty(NHibernate.Cfg.Environment.ConnectionProvider, "NHibernate.Connection.DriverConnectionProvider");

            switch (_conf.Database)
            {
                //case Databases.MySql:
                //    configuration.SetProperty(NHibernate.Cfg.Environment.ConnectionDriver, "NHibernate.Driver.MySqlDataDriver");
                //    configuration.SetProperty(NHibernate.Cfg.Environment.Dialect, "NHibernate.Dialect.MySQL57Dialect");
                //    configuration.SetProperty(NHibernate.Cfg.Environment.ConnectionString, conf.CS);
                //    break;
                case Databases.MySql:
                    configuration.SetProperty(NHibernate.Cfg.Environment.ConnectionDriver, "NHibernate.Driver.MySqlConnector.MySqlConnectorDriver, NHibernate.Driver.MySqlConnector");
                    configuration.SetProperty(NHibernate.Cfg.Environment.Dialect, "NHibernate.Dialect.MySQL57Dialect");
                    configuration.SetProperty(NHibernate.Cfg.Environment.ConnectionString, _conf.CS);
                    break;
                case Databases.PgSql:
                    configuration.SetProperty(NHibernate.Cfg.Environment.ConnectionDriver, "NHibernate.Driver.NpgsqlDriver");
                    configuration.SetProperty(NHibernate.Cfg.Environment.Dialect, "NHibernate.Dialect.PostgreSQL83Dialect");
                    configuration.SetProperty(NHibernate.Cfg.Environment.ConnectionString, _conf.CS);
                    break;
                case Databases.SQLite:
                    configuration.SetProperty(NHibernate.Cfg.Environment.ConnectionDriver, "NHibernate.Driver.SQLite20Driver");
                    configuration.SetProperty(NHibernate.Cfg.Environment.Dialect, "NHibernate.Dialect.SQLiteDialect");
                    configuration.SetProperty(NHibernate.Cfg.Environment.ConnectionString, _conf.CS);
                    break;
                //case Databases.SqlSrv:
                //    configuration.SetProperty(NHibernate.Cfg.Environment.ConnectionDriver, "NHibernate.Driver.Sql2008ClientDriver");
                //    configuration.SetProperty(NHibernate.Cfg.Environment.Dialect, "NHibernate.Dialect.MsSql2012Dialect");
                //    configuration.SetProperty(NHibernate.Cfg.Environment.ConnectionString, conf.CS);
                //    break;
                case Databases.MsSql:
                    configuration.SetProperty(NHibernate.Cfg.Environment.ConnectionDriver, "NHibernate.Driver.MicrosoftDataSqlClientDriver");
                    configuration.SetProperty(NHibernate.Cfg.Environment.Dialect, "NHibernate.Dialect.MsSql2012Dialect");
                    configuration.SetProperty(NHibernate.Cfg.Environment.ConnectionString, _conf.CS);
                    break;
            }


            configuration.SetProperty(NHibernate.Cfg.Environment.CollectionTypeFactoryClass, "CiccioSoft.NhbCollections.CollectionObservableTypeFactory, CiccioSoft.NhbCollections");
            //configuration.SetProperty(NHibernate.Cfg.Environment.CollectionTypeFactoryClass, "CiccioSoft.NhbCollections.CollectionCiccioTypeFactory, CiccioSoft.NhbCollections");
            configuration.SetProperty(NHibernate.Cfg.Environment.FormatSql, "true");
            configuration.SetProperty(NHibernate.Cfg.Environment.ShowSql, "true");
            configuration.AddAssembly("Persistence.Nhb");
            return configuration;
        }

        private bool InitMySql()
        {
            MySqlConnection conn = new MySqlConnection(_conf.CS);
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "drop database CiccioGestNhb";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "create database if not exists CiccioGestNhb";
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            conn.Close();
            conn.Dispose();
            return true;
        }

        private bool InitSQLite()
        {
            string dbFile = _conf.CS.Split(new char[] { '=' })[1].Trim();
            if (!File.Exists(dbFile))
            {
                SQLiteConnection conn = new SQLiteConnection(_conf.CS);
                conn.Open();
                conn.Close();
                conn.Dispose();
            }
            return true;
        }

        #endregion


        #region Public Method

        public void CreateDataAccess()
        {
            switch (_conf.Database)
            {
                case Databases.MySql:
                    InitMySql();
                    break;
                case Databases.SQLite:
                    InitSQLite();
                    break;
                case Databases.MsSql:
                    break;
                default:
                    break;
            }
            SchemaExport SE = new SchemaExport(GetNhbConfiguration());
            SE.Drop(true, true);
            SE.Create(true, true);
        }

        public void VerifyDataAccess()
        {
            new SchemaValidator(GetNhbConfiguration()).Validate();
        }

        #endregion


        internal ISession CreateSession()
        {
            var session = _sessionFactory.OpenSession();
            return session;
        }

        public void Dispose()
        {
            _logger.LogDebug("Disposed: {HashCode}", GetHashCode().ToString());
        }
    }
}
