//using Castle.Core.Logging;
using CiccioGest.Infrastructure;
using GalaSoft.MvvmLight;
using Microsoft.Extensions.Logging;
using System;
using System.Globalization;

namespace CiccioGest.Presentation.WpfApp2.ViewModel
{
    public sealed class HomeViewModel : ViewModelBase, IDisposable
    {
        private readonly ILogger logger;

        public HomeViewModel(ILogger<HomeViewModel> logger)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            logger.LogDebug("HashCode: " + GetHashCode().ToString() + " Created");
        }

        public void Dispose()
        {
            Cleanup();
            logger.LogDebug("HashCode: " + GetHashCode().ToString() + " Disposed");
        }
    }
}
