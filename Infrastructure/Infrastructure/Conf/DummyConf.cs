using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CiccioGest.Infrastructure.Conf
{
    public class DummyConf : IConf
    {
        public UI UserInterface { get; set; }
        public Storage DataAccess { get; set; }
        public Databases Database { get; set; }
        public string CS { get; set; }
        public string Name { get; set; }
    }
}
