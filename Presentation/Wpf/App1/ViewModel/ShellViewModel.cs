﻿using Castle.Core.Logging;
using CiccioGest.Infrastructure;
using GalaSoft.MvvmLight;
using System;
using System.Globalization;

namespace CiccioGest.Presentation.Wpf.App1.ViewModel
{
    public sealed class ShellViewModel : ViewModelBase, IDisposable, ICazzo
    {
        private readonly ILogger logger;

        public ShellViewModel(ILogger logger)
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