using CiccioGest.Infrastructure.Conf;
using CiccioGest.Presentation.Wpf.App1.View;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CiccioGest.Presentation.Wpf.App1.Service
{
    public class ApplicationHostService : IApplicationHostService
    {
        private readonly INavigationService navigationService;
        private readonly ShellView shellView;
        private readonly IConfigurationManager configurationManager;

        public ApplicationHostService(INavigationService navigationService,
                                      ShellView shellView,
                                      IConfigurationManager configurationManager)
        {
            this.navigationService = navigationService;
            this.shellView = shellView;
            this.configurationManager = configurationManager;
            navigationService.Initialize(shellView.GetNavigationFrame());
        }

        public async Task StartAsync()
        {
            throw new NotImplementedException();
        }

        public async Task StopAsync()
        {
            throw new NotImplementedException();
        }
    }
}
