﻿//using Castle.Core.Logging;
using CiccioGest.Presentation.WpfApp2.Contracts;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.Extensions.Logging;
using System;
using System.Globalization;
using System.Windows.Input;

namespace CiccioGest.Presentation.WpfApp2.ViewModel
{
    public sealed class ShellViewModel : ViewModelBase, IDisposable
    {
        private readonly ILogger logger;
        private readonly INavigationService ns;

        public ShellViewModel(ILogger<ShellViewModel> logger, INavigationService ns)
        {
            this.logger = logger;
            this.ns = ns;
            logger.LogDebug("HashCode: " + GetHashCode().ToString(CultureInfo.InvariantCulture) + " Created");
        }

        public ICommand NuovaFatturaCommand =>
            new RelayCommand(() => ns.NavigateTo("Fattura", true));

        public ICommand ApriArticoliCommand =>
            new RelayCommand(() => ns.NavigateTo("Articolo", true));

        public ICommand ApriCategorieCommand =>
            new RelayCommand(() => ns.NavigateTo("Categoria", true));

        public void Dispose()
        {
            Cleanup();
            logger.LogDebug("HashCode: " + GetHashCode().ToString() + " Disposed");
        }
    }
}