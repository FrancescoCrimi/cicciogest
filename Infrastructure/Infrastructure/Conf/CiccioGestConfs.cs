// Copyright (c) 2016 - 2026 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using System.Collections.Generic;

namespace CiccioGest.Infrastructure.Conf
{
    public class CiccioGestConfs
    {
        public CiccioGestConfs()
        {
            Confs = [];
        }

        public Dictionary<string, CiccioGestConf> Confs { get; set; }
    }

    public class CiccioGestConf
    {
        public Databases Database { get; set; }
        public string? CS { get; set; }
    }

    public enum Databases
    {
        MySql = 1,  // Mysql Connector
        SQLite,     // Sqlite
        MsSql,      // Microsoft.Data.Sqlclient
        PgSql       // PostgreSql
    }
}
