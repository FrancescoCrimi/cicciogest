﻿// Copyright (c) 2016 - 2024 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using System;

namespace CiccioGest.Infrastructure
{
    public enum Storage
    {
        NHibernate = 1,
        EF,
        LiteDb,
        Memory,
    }

    public enum Databases
    {
        MySql = 1,  // Mysql Connector
        SQLite,     // Sqlite
        MsSql,      // Microsoft.Data.Sqlclient
        PgSql       // PostgreSql
    }

    [Serializable]
    public class DataAccessException : Exception
    {
        public DataAccessException() { }
        public DataAccessException(string message) : base(message) { }
        public DataAccessException(string message, Exception inner) : base(message, inner) { }
        protected DataAccessException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }

    public class CiccioGestConfigurationException : Exception
    {
        public CiccioGestConfigurationException() { }
        public CiccioGestConfigurationException(string message) : base(message) { }
        public CiccioGestConfigurationException(string message, Exception inner) : base(message, inner) { }
    }
}
