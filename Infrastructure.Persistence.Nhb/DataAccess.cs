﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using MySql.Data.MySqlClient;
using System.IO;
using System.Data.SqlServerCe;
using System.Data.SQLite;
using Ciccio1.Infrastructure.Conf;
using Castle.Core.Logging;

namespace Ciccio1.Infrastructure.Persistence.Nhb
{
    class DataAccess : IDataAccess
    {
        private IConf conf;
        private ILogger logger;
        private static ISessionFactory sessionFactory;

        internal ISession ISession { get; private set; }

        public DataAccess(IConf conf, ILogger logger)
        {
            this.conf = conf;
            this.logger = logger;
            if (sessionFactory == null || sessionFactory.IsClosed)
            {
                if (sessionFactory != null)
                {
                    sessionFactory.Dispose();
                    sessionFactory = null;
                }
                sessionFactory = Configuration().BuildSessionFactory();
                logger.Debug("SessionFactory Creata " + sessionFactory.GetHashCode().ToString());
            }
            logger.Debug("DataAccess Creata " + this.GetHashCode().ToString());
        }


        #region Metodi Privati

        private Configuration Configuration()
        {
            NHibernate.Cfg.Configuration _configuration = new NHibernate.Cfg.Configuration();
            _configuration.SetProperty(NHibernate.Cfg.Environment.ConnectionProvider, "NHibernate.Connection.DriverConnectionProvider");

            switch (conf.Database)
            {
                case Databases.MySql:
                    _configuration.SetProperty(NHibernate.Cfg.Environment.ConnectionDriver, "NHibernate.Driver.MySqlDataDriver");
                    _configuration.SetProperty(NHibernate.Cfg.Environment.Dialect, "NHibernate.Dialect.MySQL55Dialect");
                    _configuration.SetProperty(NHibernate.Cfg.Environment.ConnectionString, conf.ConnectionString);
                    break;
                case Databases.SQLite:
                    _configuration.SetProperty(NHibernate.Cfg.Environment.ConnectionDriver, "NHibernate.Driver.SQLite20Driver");
                    //_configuration.SetProperty(NHibernate.Cfg.Environment.Dialect, "DddTest.Infrastructure.Persistence.Nhb.ModifySQLiteDialect, Infrastructure.Persistence.Nhb");
                    _configuration.SetProperty(NHibernate.Cfg.Environment.Dialect, "NHibernate.Dialect.SQLiteDialect");
                    _configuration.SetProperty(NHibernate.Cfg.Environment.ConnectionString, conf.ConnectionString);
                    break;
                case Databases.SSCE:
                    _configuration.SetProperty(NHibernate.Cfg.Environment.ConnectionDriver, "NHibernate.Driver.SqlServerCeDriver");
                    _configuration.SetProperty(NHibernate.Cfg.Environment.Dialect, "NHibernate.Dialect.MsSqlCe40Dialect");
                    _configuration.SetProperty(NHibernate.Cfg.Environment.ConnectionString, conf.ConnectionString);
                    break;
                case Databases.SSEE:
                    _configuration.SetProperty(NHibernate.Cfg.Environment.ConnectionDriver, "NHibernate.Driver.Sql2008ClientDriver");
                    _configuration.SetProperty(NHibernate.Cfg.Environment.Dialect, "NHibernate.Dialect.MsSql2012Dialect");
                    _configuration.SetProperty(NHibernate.Cfg.Environment.ConnectionString, conf.ConnectionString);
                    break;
            }
            _configuration.SetProperty(NHibernate.Cfg.Environment.FormatSql, "true");
            _configuration.SetProperty(NHibernate.Cfg.Environment.ShowSql, "true");
            _configuration.AddAssembly("Infrastructure.Persistence.Nhb");
            return _configuration;
        }

        private bool initMySql()
        {
            MySqlConnection conn = new MySqlConnection(conf.ConnectionString);
            try
            {
                conn.Open();
            }
            catch (MySqlException)
            {
                return false;
            }
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "create database if not exists test";
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (MySqlException)
            {
                return false;
                throw;
            }
            cmd.Dispose();
            conn.Close();
            conn.Dispose();
            return true;
        }

        private bool initSSCE()
        {
            string sdfFile = conf.ConnectionString.Split(new char[] { '=' })[1].Trim();
            if (!File.Exists(sdfFile))
            {
                SqlCeEngine en = new SqlCeEngine(conf.ConnectionString);
                en.CreateDatabase();
                en.Dispose();
            }
            return true;
        }

        private bool initSQLite()
        {
            string dbFile = conf.ConnectionString.Split(new char[] { '=' })[1].Trim();
            if (!File.Exists(dbFile))
            {
                SQLiteConnection conn = new SQLiteConnection(conf.ConnectionString);
                conn.Open();
                conn.Close();
                conn.Dispose();
            }
            return true;
        }

        #endregion


        //public ISessionFactory SessionFactory()
        //{
        //    if (sessionFactory == null || sessionFactory.IsClosed)
        //    {
        //        if (sessionFactory != null)
        //        {
        //            sessionFactory.Dispose();
        //            sessionFactory = null;
        //        }
        //        sessionFactory = Configuration().BuildSessionFactory();
        //    }
        //    return sessionFactory;
        //}

        //public IUnitOfWork Sessione()
        //{
        //    logger.Debug("richiesta ISessione");
        //    ISession nhbSession = SessionFactory().OpenSession();
        //    nhbSession.FlushMode = FlushMode.Commit;
        //    IUnitOfWork sessione = new UnitOfWorkNhb(nhbSession, logger);
        //    return sessione;
        //}

        public void CreateDataAccess()
        {
            switch (conf.Database)
            {
                case Databases.MySql:
                    initMySql();
                    break;
                case Databases.SQLite:
                    initSQLite();
                    break;
                case Databases.SSCE:
                    initSSCE();
                    break;
                case Databases.SSEE:
                    break;
                default:
                    break;
            }
            SchemaExport SE = new SchemaExport(Configuration());
            SE.Drop(true, true);
            SE.Create(true, true);
        }

        public void VerifyDataAccess()
        {
            new SchemaValidator(Configuration()).Validate();
        }



        public void Dispose()
        {
            //if (sessionFactory != null)
            //{
            //    sessionFactory.Dispose();
            //}
            logger.Debug("DataAccess Dispose " + this.GetHashCode().ToString());
        }

        public IUnitOfWork CreateUnitOfWork()
        {
            ISession = sessionFactory.OpenSession();
            ISession.FlushMode = FlushMode.Commit;
            ISession.BeginTransaction();
            return new UnitOfWork(ISession);
        }
    }
}
