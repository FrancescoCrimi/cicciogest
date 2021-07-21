﻿//using Castle.Core.Logging;
using CiccioGest.Presentation.WpfApp1.Contracts;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.Extensions.Logging;
using System;
using System.Globalization;
using System.Windows.Input;

namespace CiccioGest.Presentation.WpfApp1.ViewModel
{
    public sealed class MainViewModel : ViewModelBase, IDisposable
    {
        private readonly ILogger logger;
        private readonly IWindowManagerService windowManagerService;
        private ICommand apriFattureCommand;
        private ICommand apriProdottiCommand;
        private ICommand apriCategorieCommand;
        private ICommand loadedCommand;

        public MainViewModel(ILogger<MainViewModel> logger, IWindowManagerService windowManagerService)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.windowManagerService = windowManagerService;
            logger.LogDebug("HashCode: " + GetHashCode().ToString(CultureInfo.InvariantCulture) + " Created");
        }

        public ICommand ApriFattureCommand => apriFattureCommand ??= new RelayCommand(() =>
            windowManagerService.OpenInNewWindow(WindowKey.Fattura));

        public ICommand ApriArticoliCommand => apriProdottiCommand ??= new RelayCommand(() =>
            windowManagerService.OpenInNewWindow(WindowKey.Articolo));

        public ICommand ApriCategorieCommand => apriCategorieCommand ??= new RelayCommand(() =>
            windowManagerService.OpenInNewWindow(WindowKey.Categoria));

        public ICommand LoadedCommand => loadedCommand ??= new RelayCommand(() => { });

        public void Dispose()
        {
            Cleanup();
            logger.LogDebug("HashCode: " + GetHashCode().ToString(CultureInfo.InvariantCulture) + " Disposed");
        }
    }
}
