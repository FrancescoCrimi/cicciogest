using Castle.Core.Logging;
using CiccioGest.Infrastructure.Conf;
using MySql.Data.MySqlClient;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using System.Data.SQLite;
using System.Globalization;
using System.IO;

namespace CiccioGest.Infrastructure.Persistence.Nhb
{
    internal class UnitOfWorkFactory : IUnitOfWorkFactory
    {
        private readonly CiccioGestConf conf;
        private readonly ILogger logger;
        private static ISessionFactory sessionFactory;

        public UnitOfWorkFactory(CiccioGestConf conf, ILogger logger)
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
                sessionFactory = GetNhbConfiguration().BuildSessionFactory();
            }
            logger.Debug("HashCode: " + GetHashCode().ToString(CultureInfo.InvariantCulture) + " Created");
        }


        #region Metodi Privati

        private Configuration GetNhbConfiguration()
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
                    configuration.SetProperty(NHibernate.Cfg.Environment.Dialect, "NHibernate.Dialect.SQLiteDialect");
                    configuration.SetProperty(NHibernate.Cfg.Environment.ConnectionString, conf.CS);
                    break;
                case Databases.SSEE:
                    configuration.SetProperty(NHibernate.Cfg.Environment.ConnectionDriver, "NHibernate.Driver.Sql2008ClientDriver");
                    configuration.SetProperty(NHibernate.Cfg.Environment.Dialect, "NHibernate.Dialect.MsSql2012Dialect");
                    configuration.SetProperty(NHibernate.Cfg.Environment.ConnectionString, conf.CS);
                    break;
            }
            //switch (conf.UserInterface)
            //{
            //    case UI.Form:
            //        configuration.SetProperty(NHibernate.Cfg.Environment.CollectionTypeFactoryClass, "CiccioUtils.NhbListCore.DomainCollectionTypeFactory, NhbListCore");
            //        //configuration.SetProperty(NHibernate.Cfg.Environment.CollectionTypeFactoryClass, "CiccioUtils.NhbListePlus.DomainCollectionTypeFactory, CiccioUtils.NhbListePlus");
            //        break;
            //    case UI.WPF:
            //        configuration.SetProperty(NHibernate.Cfg.Environment.CollectionTypeFactoryClass, "CiccioUtils.NhbListCore.DomainCollectionTypeFactory, NhbListCore");
            //        //configuration.SetProperty(NHibernate.Cfg.Environment.CollectionTypeFactoryClass, "CiccioUtils.NhbListePlus.DomainCollectionTypeFactory, CiccioUtils.NhbListePlus");
            //        break;
            //    case UI.WCF:
            //        break;
            //}
            //configuration.SetProperty(NHibernate.Cfg.Environment.CollectionTypeFactoryClass, "CiccioUtils.NhbListCore.DomainCollectionTypeFactory, NhbListCore");
            configuration.SetProperty(NHibernate.Cfg.Environment.CollectionTypeFactoryClass, "CiccioSoft.NhbCollections.CollectionCiccioTypeFactory, CiccioSoft.NhbCollections");
            configuration.SetProperty(NHibernate.Cfg.Environment.FormatSql, "true");
            configuration.SetProperty(NHibernate.Cfg.Environment.ShowSql, "true");
            configuration.AddAssembly("Persistence.Nhb");
            return configuration;
        }

        private MySqlConnection conn;
        private MySqlCommand cmd;
        private bool InitMySql()
        {
            try
            {
                conn = new MySqlConnection(conf.CS);
                conn.Open();
                cmd = conn.CreateCommand();
                cmd.CommandText = "create database if not exists CiccioGestNhb";
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (MySqlException ex)
            {
                //return false;
                throw ex;
            }
            finally
            {
                cmd.Dispose();
                conn.Close();
                conn.Dispose();
            }
        }

        private bool InitSQLite()
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
                    InitMySql();
                    break;
                case Databases.SQLite:
                    InitSQLite();
                    break;
                case Databases.SSEE:
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

        public void Dispose()
        {
            logger.Debug("HashCode: " + GetHashCode().ToString(CultureInfo.InvariantCulture) + " Disposed");
        }
    }
}
