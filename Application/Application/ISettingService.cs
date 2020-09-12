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
