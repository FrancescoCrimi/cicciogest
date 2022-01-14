using Microsoft.Extensions.Logging;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;

namespace CiccioGest.Presentation.WpfBackend.ViewModel
{
    public sealed class HomeViewModel : ObservableRecipient, IDisposable
    {
        private readonly ILogger logger;

        public HomeViewModel(ILogger<HomeViewModel> logger)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            logger.LogDebug("Created: " + GetHashCode().ToString());
        }

        public void Dispose()
        {
            logger.LogDebug("Disposed: " + GetHashCode().ToString());
        }
    }
}
