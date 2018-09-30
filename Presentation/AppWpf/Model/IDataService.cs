using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CiccioGest.Presentation.AppWpf.Model
{
    public interface IDataService
    {
        void GetData(Action<DataItem, Exception> callback);
    }
}
