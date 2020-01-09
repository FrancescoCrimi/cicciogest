using System;
using System.Collections.Generic;
using System.Text;

namespace CiccioGest.Infrastructure.Conf
{
    public class AppConfs
    {
        public AppConfs()
        {
            Available = new Dictionary<string, AppConf>();
        }

        public Dictionary<string, AppConf> Available { get; set; }

        public string Current { get; set; }
    }
}
