using System.Collections.Generic;

namespace CiccioGest.Infrastructure.Conf
{
    public interface IConfigurationManager
    {
        void Add(AppConf conf);
        ICollection<AppConf> GetAll();
        AppConf GetCurrent();
        void LoadSample();
        void Remove(AppConf conf);
        void Save();
        void SetCurrent(AppConf conf);
    }
}