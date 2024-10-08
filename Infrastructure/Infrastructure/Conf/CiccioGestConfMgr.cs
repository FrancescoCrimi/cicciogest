﻿// Copyright (c) 2016 - 2024 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using Newtonsoft.Json;
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
                privateAppConfs = JsonConvert.DeserializeObject<CiccioGestConfs>(json);
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
                var fileContent = JsonConvert.SerializeObject(privateAppConfs, Formatting.Indented);
                File.WriteAllText(filePath, fileContent, Encoding.UTF8);
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
            AppConfs.Available.TryGetValue(AppConfs.Current, out CiccioGestConf? value);
            return value!;
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
                CS = "server=localhost;User Id=CiccioGestNhb;password=CiccioGestNhb;database=CiccioGestNhb;SslMode=none",
                DataAccess = Storage.NHibernate,
                Database = Databases.MySql,
                Name = "mysql"
            };
            privateAppConfs.Available.Add(mysql.Name, mysql);

            var pgsql = new CiccioGestConf()
            {
                CS = "User Id=cicciogestnhb;Password=CiccioGestNhb;Host=localhost;Database=cicciogestnhb",
                DataAccess = Storage.NHibernate,
                Database = Databases.PgSql,
                Name = "pgsql"
            };
            privateAppConfs.Available.Add(pgsql.Name, pgsql);

            var mssql1 = new CiccioGestConf()
            {
                CS = @"Data Source=CICCIOBOOK\SQLEXPRESS;Initial Catalog=CiccioGestNhb;Integrated Security=True",
                DataAccess = Storage.NHibernate,
                Database = Databases.MsSql,
                Name = "mssql1"
            };
            privateAppConfs.Available.Add(mssql1.Name, mssql1);

            var mssql2 = new CiccioGestConf()
            {
                CS = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\CiccioGestNhb.mdf;Integrated Security=True",
                DataAccess = Storage.NHibernate,
                Database = Databases.MsSql,
                Name = "mssql2"
            };
            privateAppConfs.Available.Add(mssql2.Name, mssql2);

            var sqlite1 = new CiccioGestConf()
            {
                CS = "Data Source=CiccioGestNhb.db;Version=3;BinaryGuid=False",
                DataAccess = Storage.NHibernate,
                Database = Databases.SQLite,
                Name = "sqlite1"
            };
            privateAppConfs.Available.Add(sqlite1.Name, sqlite1);

            var sqlite2 = new CiccioGestConf()
            {
                CS = "Data Source=CiccioGestNhb.db;Version=3;Default IsolationLevel=ReadCommitted;BinaryGuid=False",
                DataAccess = Storage.NHibernate,
                Database = Databases.SQLite,
                Name = "sqlite2"
            };
            privateAppConfs.Available.Add(sqlite2.Name, sqlite2);

            var memory = new CiccioGestConf()
            {
                CS = "",
                DataAccess = Storage.LiteDb,
                Database = Databases.MySql,
                Name = "memory"
            };
            privateAppConfs.Available.Add(memory.Name, memory);

            var litedb = new CiccioGestConf()
            {
                CS = "CiccioGest.db",
                DataAccess = Storage.LiteDb,
                Database = Databases.MySql,
                Name = "litedb"
            };
            privateAppConfs.Available.Add(litedb.Name, litedb);

            privateAppConfs.Current = mysql.Name;
            Save();
        }
    }
}
