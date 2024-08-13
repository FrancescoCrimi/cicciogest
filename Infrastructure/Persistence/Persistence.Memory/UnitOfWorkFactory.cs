// Copyright (c) 2016 - 2024 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using System;
using System.Collections.Generic;
using System.Text;

namespace CiccioGest.Infrastructure.Persistence.Memory
{
    internal class UnitOfWorkFactory : IUnitOfWorkFactory
    {
        public UnitOfWorkFactory()
        {
        }

        public IUnitOfWork Create()
        {
            throw new NotImplementedException();
        }

        public void CreateDataAccess()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void VerifyDataAccess()
        {
            throw new NotImplementedException();
        }
    }
}
