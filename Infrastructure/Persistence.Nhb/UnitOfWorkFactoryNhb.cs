using Castle.Core.Logging;
using CiccioGest.Infrastructure.Conf;
using MySql.Data.MySqlClient;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CiccioGest.Infrastructure.Persistence.Nhb
{
    class UnitOfWorkFactoryNhb : IUnitOfWorkFactory
    {
        private IConf conf;
        private ILogger logger;
        private static ISessionFactory sessionFactory;

        public UnitOfWorkFactoryNhb(IConf conf, ILogger logger)
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
                sessionFactory = getNhbConfiguration().BuildSessionFactory();
                //logger.Debug(sessionFactory.GetType().Name + ":" + sessionFactory.GetHashCode().ToString() + " Created");
            }
            logger.Debug(this.GetType().Name + ":" + this.GetHashCode().ToString() + " Created");
        }


        #region Metodi Privati

        private Configuration getNhbConfiguration()
        {
            NHibernate.Cfg.Configuration configuration = new NHibernate.Cfg.Configuration();
            configuration.SetProperty(NHibernate.Cfg.Environment.ConnectionProvider, "NHibernate.Connection.DriverConnectionProvider");

            switch (conf.Database)
            {
                case Databases.MySql:
                    configuration.SetProperty(NHibernate.Cfg.Environment.ConnectionDriver, "NHibernate.Driver.MySqlDataDriver");
                    configuration.SetProperty(NHibernate.Cfg.Environment.Dialect, "NHibernate.Dialect.MySQL55Dialect");
                    configuration.SetProperty(NHibernate.Cfg.Environment.ConnectionString, conf.CS);
                    break;
                case Databases.SQLite:
                    configuration.SetProperty(NHibernate.Cfg.Environment.ConnectionDriver, "NHibernate.Driver.SQLite20Driver");
                    //_configuration.SetProperty(NHibernate.Cfg.Environment.Dialect, "DddTest.Infrastructure.Persistence.Nhb.ModifySQLiteDialect, Infrastructure.Persistence.Nhb");
                    configuration.SetProperty(NHibernate.Cfg.Environment.Dialect, "NHibernate.Dialect.SQLiteDialect");
                    configuration.SetProperty(NHibernate.Cfg.Environment.ConnectionString, conf.CS);
                    break;
                //case Databases.SSCE:
                //    configuration.SetProperty(NHibernate.Cfg.Environment.ConnectionDriver, "NHibernate.Driver.SqlServerCeDriver");
                //    configuration.SetProperty(NHibernate.Cfg.Environment.Dialect, "NHibernate.Dialect.MsSqlCe40Dialect");
                //    configuration.SetProperty(NHibernate.Cfg.Environment.ConnectionString, conf.CS);
                //    break;
                case Databases.SSEE:
                    configuration.SetProperty(NHibernate.Cfg.Environment.ConnectionDriver, "NHibernate.Driver.Sql2008ClientDriver");
                    configuration.SetProperty(NHibernate.Cfg.Environment.Dialect, "NHibernate.Dialect.MsSql2012Dialect");
                    configuration.SetProperty(NHibernate.Cfg.Environment.ConnectionString, conf.CS);
                    break;
            }
            switch (conf.UserInterface)
            {
                case UI.Form:
                    configuration.SetProperty(NHibernate.Cfg.Environment.CollectionTypeFactoryClass, "CiccioUtils.NhbListe.DomainCollectionTypeFactory, CiccioUtils.NhbListe");
                    //configuration.SetProperty(NHibernate.Cfg.Environment.CollectionTypeFactoryClass, "CiccioUtils.NhbListePlus.DomainCollectionTypeFactory, CiccioUtils.NhbListePlus");
                    break;
                case UI.WPF:
                    configuration.SetProperty(NHibernate.Cfg.Environment.CollectionTypeFactoryClass, "CiccioUtils.NhbListe.DomainCollectionTypeFactory, CiccioUtils.NhbListe");
                    //configuration.SetProperty(NHibernate.Cfg.Environment.CollectionTypeFactoryClass, "CiccioUtils.NhbListePlus.DomainCollectionTypeFactory, CiccioUtils.NhbListePlus");
                    break;
                case UI.WCF:
                    break;
                case UI.REST:
                    break;
            }
            configuration.SetProperty(NHibernate.Cfg.Environment.FormatSql, "true");
            configuration.SetProperty(NHibernate.Cfg.Environment.ShowSql, "true");
            configuration.AddAssembly("Persistence.Nhb");
            return configuration;
        }

        private bool initMySql()
        {
            MySqlConnection conn = new MySqlConnection(conf.CS);
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

        private bool initSQLite()
        {
            string dbFile = conf.CS.Split(new char[] { '=' })[1].Trim();
            if (!File.Exists(dbFile))
            {
                SQLiteConnection conn = new SQLiteConnection(conf.CS);
                conn.Open();
                conn.Close();
                conn.Dispose();
            }
            return true;
        }

        #endregion



        internal ISessionFactory SessionFactory()
        {
            return sessionFactory;
        }


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
                //case Databases.SSCE:
                //    initSSCE();
                //    break;
                case Databases.SSEE:
                    break;
                default:
                    break;
            }
            SchemaExport SE = new SchemaExport(getNhbConfiguration());
            SE.Drop(true, true);
            SE.Create(true, true);
        }

        public void VerifyDataAccess()
        {
            new SchemaValidator(getNhbConfiguration()).Validate();
        }

        public void Dispose()
        {
            logger.Debug(this.GetType().Name + ":" + this.GetHashCode().ToString() + " Disposed");
        }
    }
}
