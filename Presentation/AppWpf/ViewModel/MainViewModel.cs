using Castle.Core.Logging;
using CiccioGest.Infrastructure;
using GalaSoft.MvvmLight;
using System;
using System.Globalization;

namespace CiccioGest.Presentation.AppWpf.ViewModel
{
    public sealed class MainViewModel : ViewModelBase, IDisposable, ICazzo
    {
        private readonly ILogger logger;

        public MainViewModel(ILogger logger)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            logger.Debug("HashCode: " + GetHashCode().ToString(CultureInfo.InvariantCulture) + " Created");
        }

        public void Dispose()
        {
            Cleanup();
            logger.Debug("HashCode: " + GetHashCode().ToString(CultureInfo.InvariantCulture) + " Disposed");
        }
    }
}
