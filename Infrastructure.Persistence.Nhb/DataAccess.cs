using System;
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
        private ISession session;


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
                sessionFactory = getConfiguration().BuildSessionFactory();
                logger.Debug("SessionFactory Creata " + sessionFactory.GetHashCode().ToString());
            }
            logger.Debug("DataAccess Creata " + this.GetHashCode().ToString());
        }


        #region Metodi Publici

        public void CreateDataAccess()
        {
            //switch (conf.Database)
            //{
            //    case Databases.MySql:
            //        initMySql();
            //        break;
            //    case Databases.SQLite:
            //        initSQLite();
            //        break;
            //    case Databases.SSCE:
            //        initSSCE();
            //        break;
            //    case Databases.SSEE:
            //        break;
            //    default:
            //        break;
            //}
            SchemaExport SE = new SchemaExport(getConfiguration());
            SE.Drop(true, true);
            SE.Create(true, true);
        }

        public void VerifyDataAccess()
        {
            new SchemaValidator(getConfiguration()).Validate();
        }

        public void Begin()
        {
            disposeSession();
            session = sessionFactory.OpenSession();
            session.FlushMode = FlushMode.Commit;
            session.BeginTransaction();
        }

        public void Commit()
        {
            session.Transaction.Commit();
            disposeSession();
        }

        public void Rollback()
        {
            session.Transaction.Rollback();
        }

        public void Dispose()
        {
            disposeSession();
            logger.Debug("DataAccess Dispose " + this.GetHashCode().ToString());
        }

        #endregion

        #region Metodi Internal

        internal ISession ISession
        {
            get
            {
                if (session != null)
                    return session;
                else
                {
                    Begin();
                    return session;
                }
            }
        }

        #endregion

        #region Metodi Privati

        private Configuration getConfiguration()
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
                case Databases.SSCE:
                    configuration.SetProperty(NHibernate.Cfg.Environment.ConnectionDriver, "NHibernate.Driver.SqlServerCeDriver");
                    configuration.SetProperty(NHibernate.Cfg.Environment.Dialect, "NHibernate.Dialect.MsSqlCe40Dialect");
                    configuration.SetProperty(NHibernate.Cfg.Environment.ConnectionString, conf.CS);
                    break;
                case Databases.SSEE:
                    configuration.SetProperty(NHibernate.Cfg.Environment.ConnectionDriver, "NHibernate.Driver.Sql2008ClientDriver");
                    configuration.SetProperty(NHibernate.Cfg.Environment.Dialect, "NHibernate.Dialect.MsSql2012Dialect");
                    configuration.SetProperty(NHibernate.Cfg.Environment.ConnectionString, conf.CS);
                    break;
            }
            switch (conf.UserInterface)
            {
                case UI.Form:
                    configuration.SetProperty(NHibernate.Cfg.Environment.CollectionTypeFactoryClass, "CiccioUtil.NhbListe.CazzoListe.DomainCollectionTypeFactory, CiccioUtil.NhbListe");
                    //configuration.SetProperty(NHibernate.Cfg.Environment.CollectionTypeFactoryClass, "CiccioUtil.NhbListe.MinchiaListe.DomainCollectionTypeFactory, CiccioUtil.NhbListe");
                    break;
                case UI.WPF:
                    configuration.SetProperty(NHibernate.Cfg.Environment.CollectionTypeFactoryClass, "CiccioUtil.NhbListe.CazzoListe.DomainCollectionTypeFactory, CiccioUtil.NhbListe");
                    //configuration.SetProperty(NHibernate.Cfg.Environment.CollectionTypeFactoryClass, "CiccioUtil.NhbListe.MinchiaListe.DomainCollectionTypeFactory, CiccioUtil.NhbListe");
                    break;
                case UI.WCF:
                    break;
                case UI.REST:
                    break;
            }
            configuration.SetProperty(NHibernate.Cfg.Environment.FormatSql, "true");
            configuration.SetProperty(NHibernate.Cfg.Environment.ShowSql, "true");
            configuration.AddAssembly("Infrastructure.Persistence.Nhb");
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

        private bool initSSCE()
        {
            string sdfFile = conf.CS.Split(new char[] { '=' })[1].Trim();
            if (!File.Exists(sdfFile))
            {
                SqlCeEngine en = new SqlCeEngine(conf.CS);
                en.CreateDatabase();
                en.Dispose();
            }
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

        private void disposeSession()
        {
            //logger.Debug("rollback Transaction");
            if (session != null)
            {
                try
                {
                    if (session.Transaction != null)
                    {
                        try
                        {
                            if (session.Transaction.IsActive)
                            {
                                session.Transaction.Rollback();
                            }
                            session.Transaction.Dispose();
                        }
                        catch (Exception ex)
                        {
                            throw new HibernateException("Unable to rollback transaction for orphaned session", ex);
                        }
                    }
                    session.Close();
                    session.Dispose();
                    session = null;
                }
                catch (Exception ex)
                {
                    throw new HibernateException("Unable to close orphaned session", ex);
                }
            }
        }

        #endregion
    }
}
