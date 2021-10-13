//using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CiccioGest.Infrastructure.Conf
{
    public static class CiccioGestConfMgr
    {
        private static readonly string localAppData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        private static readonly string configurationsFolder = @"CiccioGest\Configurations";
        private static readonly string fileName = "AppProperties.json";
        private static readonly string folderPath = Path.Combine(localAppData, configurationsFolder);
        private static readonly string filePath = Path.Combine(folderPath, fileName);
        private static CiccioGestConfs privateAppConfs = null;


        private static CiccioGestConfs AppConfs
        {
            get
            {
                if (privateAppConfs == null)
                {
                    if (File.Exists(filePath))
                        ReadConfiguration();
                    else
                        LoadSample();
                }
                return privateAppConfs;
            }
        }

        private static void ReadConfiguration()
        {
            if (File.Exists(filePath))
            {
                var json = File.ReadAllText(filePath);
                //privateAppConfs = JsonConvert.DeserializeObject<CiccioGestConfs>(json);
            }
        }


        public static void Save()
        {
            if (privateAppConfs != null)
            {
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }
                //var fileContent = JsonConvert.SerializeObject(privateAppConfs, Formatting.Indented);
                //File.WriteAllText(filePath, fileContent, Encoding.UTF8);
            }
        }

        public static void Add(CiccioGestConf conf)
        {
            AppConfs.Available.Add(conf.Name, conf);
        }

        public static void Remove(CiccioGestConf conf)
        {
            AppConfs.Available.Remove(conf.Name);
        }

        public static void SetCurrent(CiccioGestConf conf)
        {
            if (AppConfs.Available.ContainsValue(conf))
            {
                AppConfs.Current = conf.Name;
            }
        }

        public static CiccioGestConf GetCurrent()
        {
            AppConfs.Available.TryGetValue(AppConfs.Current, out CiccioGestConf value);
            return value;
        }

        public static ICollection<CiccioGestConf> GetAll()
        {
            return AppConfs.Available.Values;
        }

        public static void LoadSample()
        {
            privateAppConfs = new CiccioGestConfs();

            var mysql = new CiccioGestConf()
            {
                CS = "server=localhost;User Id=CiccioGestNhb;password=CiccioGestNhb;database=CiccioGestNhb",
                DataAccess = Storage.NHibernate,
                Database = Databases.MySql,
                UserInterface = UI.WPF,
                Name = "mysql"
            };
            privateAppConfs.Available.Add(mysql.Name, mysql);

            var pgsql = new CiccioGestConf()
            {
                CS = "User Id=cicciogestnhb;Password=CiccioGestNhb;Host=localhost;Database=cicciogestnhb",
                DataAccess = Storage.NHibernate,
                Database = Databases.PgSql,
                UserInterface = UI.WPF,
                Name = "pgsql"
            };
            privateAppConfs.Available.Add(pgsql.Name, pgsql);

            var ssee1 = new CiccioGestConf()
            {
                CS = @"Data Source=CICCIOBOOK\SQLEXPRESS;Initial Catalog=CiccioGestNhb;Integrated Security=True",
                DataAccess = Storage.NHibernate,
                Database = Databases.SSEE,
                UserInterface = UI.WPF,
                Name = "ssee1"
            };
            privateAppConfs.Available.Add(ssee1.Name, ssee1);

            var ssee2 = new CiccioGestConf()
            {
                CS = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\CiccioGestNhb.mdf;Integrated Security=True",
                DataAccess = Storage.NHibernate,
                Database = Databases.SSEE,
                UserInterface = UI.WPF,
                Name = "ssee2"
            };
            privateAppConfs.Available.Add(ssee2.Name, ssee2);

            var sqlite1 = new CiccioGestConf()
            {
                CS = "Data Source=CiccioGestNhb.db;Version=3;BinaryGuid=False",
                DataAccess = Storage.NHibernate,
                Database = Databases.SQLite,
                UserInterface = UI.WPF,
                Name = "sqlite1"
            };
            privateAppConfs.Available.Add(sqlite1.Name, sqlite1);

            var sqlite2 = new CiccioGestConf()
            {
                CS = "Data Source=CiccioGestNhb.db;Version=3;Default IsolationLevel=ReadCommitted;BinaryGuid=False",
                DataAccess = Storage.NHibernate,
                Database = Databases.SQLite,
                UserInterface = UI.WPF,
                Name = "sqlite2"
            };
            privateAppConfs.Available.Add(sqlite2.Name, sqlite2);

            var wcf1 = new CiccioGestConf()
            {
                CS = "http://localhost:8000",
                DataAccess = Storage.WCF,
                Database = Databases.MySql,
                UserInterface = UI.WPF,
                Name = "wcf1"
            };
            privateAppConfs.Available.Add(wcf1.Name, wcf1);

            var wcf2 = new CiccioGestConf()
            {
                CS = "http://localhost:8100",
                DataAccess = Storage.WCF,
                Database = Databases.MySql,
                UserInterface = UI.WPF,
                Name = "wcf2"
            };
            privateAppConfs.Available.Add(wcf2.Name, wcf2);

            var db4o = new CiccioGestConf()
            {
                CS = "CiccioGest.db4o",
                DataAccess = Storage.Db4o,
                Database = Databases.MySql,
                UserInterface = UI.WPF,
                Name = "db4o"
            };
            privateAppConfs.Available.Add(db4o.Name, db4o);
            var memory = new CiccioGestConf()
            {
                CS = "",
                DataAccess = Storage.LiteDb,
                Database = Databases.MySql,
                UserInterface = UI.WPF,
                Name = "memory"
            };
            privateAppConfs.Available.Add(memory.Name, memory);
            var litedb = new CiccioGestConf()
            {
                CS = "CiccioGest.db",
                DataAccess = Storage.LiteDb,
                Database = Databases.MySql,
                UserInterface = UI.WPF,
                Name = "litedb"
            };
            privateAppConfs.Available.Add(litedb.Name, litedb);
            privateAppConfs.Current = mysql.Name;
            Save();
        }
    }
}
