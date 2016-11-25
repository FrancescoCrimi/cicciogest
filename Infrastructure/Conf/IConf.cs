using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ciccio1.Infrastructure.Conf
{
    public interface IConf
    {
        UI UserInterface { get; }
        Storage DataAccess { get; }
        Databases Database { get; }
        String ConnectionString { get; }
        string Name { get; }
    }
}
