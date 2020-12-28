﻿using Castle.Core.Logging;
using Castle.MicroKernel;
using Castle.MicroKernel.Lifestyle;
using CiccioGest.Infrastructure;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using System;
using System.Globalization;
using System.Windows.Input;
using Windows.UI.Xaml.Controls;

namespace CiccioGest.Presentation.Uwp.App1.ViewModel
{
    public sealed class ShellViewModel : ViewModelBase, IDisposable
    {
        private readonly ILogger logger;
        private readonly IKernel kernel;
        private readonly NavigationService navigationService;
        private RelayCommand loadedCommand;

        public ShellViewModel(ILogger logger, IKernel kernel, NavigationService navigationService)
        {
            this.logger = logger;
            this.kernel = kernel;
            this.navigationService = navigationService;
            logger.Debug("HashCode: " + GetHashCode().ToString(CultureInfo.InvariantCulture) + " Created");
        }

        public ICommand FattureCommand
        {
            get
            {
                //using (kernel.BeginScope())
                //{
                    return new RelayCommand(() => navigationService.NavigateTo("Fattura"));
                //}
            }
        }

        public ICommand ArticoliCommand => new RelayCommand(() => navigationService.NavigateTo("Articolo"));

        public ICommand CategorieCommand => new RelayCommand(() => navigationService.NavigateTo("Categoria"));

        public ICommand LoadedCommand => loadedCommand ??= new RelayCommand(() => navigationService.NavigateTo("Main"));

        public void Initialization(Frame frame) => navigationService.CurrentFrame = frame;

        public void Dispose()
        {
            Cleanup();
            logger.Debug("HashCode: " + GetHashCode().ToString(CultureInfo.InvariantCulture) + " Disposed");
        }
    }
}
