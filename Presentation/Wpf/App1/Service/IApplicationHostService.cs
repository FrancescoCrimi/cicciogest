using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CiccioGest.Presentation.Wpf.App1.Service
{
    public interface IApplicationHostService
    {
        Task StartAsync();

        Task StopAsync();
    }
}
