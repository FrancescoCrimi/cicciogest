using CiccioGest.Application;
using CiccioGest.Presentation.WpfApp.Contracts;
using Microsoft.Extensions.Logging;
using System;

namespace CiccioGest.Presentation.WpfApp.ViewModel
{
    public class ClienteViewModel : ViewModelBase, IDisposable
    {
        private readonly ILogger<ClienteViewModel> logger;
        private readonly IClientiFornitoriService clientiFornitoriService;
        private readonly IWindowManagerService windowManagerService;

        public ClienteViewModel(ILogger<ClienteViewModel> logger,
                                IClientiFornitoriService clientiFornitoriService,
                                IWindowManagerService windowManagerService)
        {
            this.logger = logger;
            this.clientiFornitoriService = clientiFornitoriService;
            this.windowManagerService = windowManagerService;
            logger.LogDebug("HashCode: " + GetHashCode().ToString() + " Created");
        }

        public void Dispose()
        {
            logger.LogDebug("HashCode: " + GetHashCode().ToString() + " Disposed");
        }
    }
}
