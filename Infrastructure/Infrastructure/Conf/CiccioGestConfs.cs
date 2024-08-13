// Copyright (c) 2016 - 2024 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

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
