using System;
using System.Collections.Generic;
using System.Text;

namespace CiccioGest.Application
{
    public interface ISettingService
    {
        void SaveConf();
        void CreateDataAccess();
        void VerifyDataAccess();
        void LoadSampleData();
    }
}
