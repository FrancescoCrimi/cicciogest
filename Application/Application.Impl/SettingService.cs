using CiccioGest.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace CiccioGest.Application.Impl
{
    internal class SettingService : ISettingService
    {
        private readonly IUnitOfWorkFactory unitOfWorkFactory;

        public SettingService(IUnitOfWorkFactory unitOfWorkFactory)
        {
            this.unitOfWorkFactory = unitOfWorkFactory;
        }

        public void CreateDataAccess()
        {
            unitOfWorkFactory.CreateDataAccess();
        }

        public void LoadSampleData()
        {
            throw new NotImplementedException();
        }

        public void SaveConf()
        {
            throw new NotImplementedException();
        }

        public void VerifyDataAccess()
        {
            unitOfWorkFactory.VerifyDataAccess();
        }
    }
}
