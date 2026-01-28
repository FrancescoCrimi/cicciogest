// Copyright (c) 2016 - 2026 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Text.Unicode;

namespace CiccioGest.Infrastructure.Conf
{
    public static class CiccioGestConfMgr
    {
        // Path of appsettings.json
        private static readonly string _appSettingsFilePath = Path.Combine(
            Path.GetDirectoryName(Assembly.GetEntryAssembly()?.Location)!,
            "appsettings.json");

        private static CiccioGestConfs _ciccioGestConfs = null!;
        private static string _currentCiccioGestConf = string.Empty;

        // Provides preconfigured JSON serialization options with indented formatting, camel case property names, enum
        // string conversion, and full Unicode character support.
        private static readonly JsonSerializerOptions options = new()
        {
            WriteIndented = true,                                   // Formatta il JSON con rientri (leggibile)
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,      // Converte Nome -> nome
            Converters = { new JsonStringEnumConverter() },         // Enum come stringhe            
            Encoder = JavaScriptEncoder.Create(UnicodeRanges.All)   // Caratteri accentati senza l'escape \uXXXX
        };

        public static CiccioGestConf GetCurrent()
        {
            if (_ciccioGestConfs == null)
                ReadAppSettings();

            _ciccioGestConfs!.Confs.TryGetValue(_currentCiccioGestConf, out CiccioGestConf? value);
            return value ?? throw new KeyNotFoundException($"Configuration '{_currentCiccioGestConf}' not found.");
        }

        private static void ReadAppSettings()
        {
            if (!File.Exists(_appSettingsFilePath))
                WriteAppSettings();
            var json = File.ReadAllText(_appSettingsFilePath);
            var rootNode = JsonNode.Parse(json);
            _currentCiccioGestConf = rootNode!["CurrentConf"]?.GetValue<string>()!;
            _ciccioGestConfs = rootNode!["CiccioTestConfs"]!.Deserialize<CiccioGestConfs>(options)!;
        }

        private static void WriteAppSettings()
        {
            string jsonContent = File.ReadAllText(_appSettingsFilePath);

            // 1. Carica l'intero JSON come albero di nodi
            var rootNode = JsonNode.Parse(jsonContent);

            // 2. Trasforma la tua classe C# in un JsonNode
            // Questo è il passaggio chiave: serializza l'oggetto direttamente in un nodo
            JsonNode? nuovoNodoDati = JsonSerializer.SerializeToNode(LoadSample(), options);

            // 3. Sostituisci o aggiungi il nodo nell'albero
            rootNode!["CiccioTestConfs"] = nuovoNodoDati;
            rootNode!["CurrentConf"] = "mysql";

            // 4. Salva su file preservando la formattazione
            //var options = new JsonSerializerOptions { WriteIndented = true };
            File.WriteAllText(_appSettingsFilePath, rootNode!.ToJsonString(options));
        }

        public static CiccioGestConfs LoadSample()
        {
            var confs = new CiccioGestConfs();

            confs.Confs.Add("mysql", new CiccioGestConf()
            {
                CS = "server=localhost;User Id=CiccioGestNhb;password=CiccioGestNhb;database=CiccioGestNhb;SslMode=none",
                Database = Databases.MySql,
            });

            confs.Confs.Add("pgsql", new CiccioGestConf()
            {
                CS = "User Id=cicciogestnhb;Password=CiccioGestNhb;Host=localhost;Database=cicciogestnhb",
                Database = Databases.PgSql,
            });

            confs.Confs.Add("mssql1", new CiccioGestConf()
            {
                CS = @"Data Source=CICCIOBOOK\SQLEXPRESS;Initial Catalog=CiccioGestNhb;Integrated Security=True",
                Database = Databases.MsSql,
            });

            confs.Confs.Add("mssql2", new CiccioGestConf()
            {
                CS = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\CiccioGestNhb.mdf;Integrated Security=True",
                Database = Databases.MsSql,
            });

            confs.Confs.Add("sqlite1", new CiccioGestConf()
            {
                CS = "Data Source=CiccioGestNhb.db;Version=3;BinaryGuid=False",
                Database = Databases.SQLite,
            });

            confs.Confs.Add("sqlite2", new CiccioGestConf()
            {
                CS = "Data Source=CiccioGestNhb.db;Version=3;Default IsolationLevel=ReadCommitted;BinaryGuid=False",
                Database = Databases.SQLite,
            });

            return confs;
        }
    }
}
