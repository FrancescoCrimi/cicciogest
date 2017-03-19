using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CiccioGest.Infrastructure
{
    public enum Storage
    {
        NHibernate = 1,
        EF,
        EFC,
        Db4o,
        WCF,
        REST
    }

    public enum UI
    {
        Form = 1,
        WPF,
        WCF,
        REST
    }

    public enum Databases
    {
        MySql = 1,
        SQLite,
        SSCE,
        SSEE
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
}
