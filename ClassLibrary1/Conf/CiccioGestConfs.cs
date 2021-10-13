using System;
using System.Collections.Generic;
using System.Text;

namespace CiccioGest.Infrastructure.Conf
{
    public class CiccioGestConfs
    {
        public CiccioGestConfs()
        {
            Available = new Dictionary<string, CiccioGestConf>();
        }

        public Dictionary<string, CiccioGestConf> Available { get; set; }

        public string Current { get; set; }
    }
}
