﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CiccioGest.Infrastructure
{
    public enum Storage
    {
        NHibernate = 1,
        EF,
        Db4o,
        WCF,
    }

    public enum UI
    {
        Form = 1,
        WPF,
        WCF,
        SCRIPT
    }

    public enum Databases
    {
        MySql = 1,
        SQLite,
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

    public interface ICazzo
    {

    }
}
