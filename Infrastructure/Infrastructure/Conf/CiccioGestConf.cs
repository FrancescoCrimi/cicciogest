// Copyright (c) 2016 - 2025 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

namespace CiccioGest.Infrastructure.Conf
{
    public class CiccioGestConf
    {
        public Storage DataAccess { get; set; }
        public Databases Database { get; set; }
        public string? CS { get; set; }
        public string? Name { get; set; }
    }
}
