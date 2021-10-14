using System;

namespace CiccioGest.Infrastructure
{
    public enum Storage
    {
        NHibernate = 1,
        EF,
        LiteDb,
        WCF,
        Memory,
    }

    public enum Databases
    {
        MySql = 1,
        SQLite,
        SqlSrv,
        PgSql
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
