// Copyright (c) 2016 - 2024 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CiccioGest.Application
{
    public interface ISettingService
    {
        void SaveConf();
        void CreateDataAccess();
        void VerifyDataAccess();
        Task LoadSampleData();
    }
}
