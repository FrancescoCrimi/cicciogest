using Castle.Core.Logging;
using CiccioGest.Infrastructure;
using GalaSoft.MvvmLight;
using System;
using System.Globalization;

namespace CiccioGest.Presentation.WpfApp2.ViewModel
{
    public sealed class HomeViewModel : ViewModelBase, IDisposable
    {
        private readonly ILogger logger;

        public HomeViewModel(ILogger logger)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            logger.Debug("HashCode: " + GetHashCode().ToString() + " Created");
        }

        public void Dispose()
        {
            Cleanup();
            logger.Debug("HashCode: " + GetHashCode().ToString() + " Disposed");
        }
    }
}
