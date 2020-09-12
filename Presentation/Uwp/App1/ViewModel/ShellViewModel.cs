using Castle.Core.Logging;
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
    public sealed class ShellViewModel : ViewModelBase, IDisposable, ICazzo
    {
        private readonly ILogger logger;
        private readonly NavigationService navigationService;
        private RelayCommand loadedCommand;

        public ShellViewModel(ILogger logger, NavigationService navigationService)
        {
            this.logger = logger;
            this.navigationService = navigationService;
            logger.Debug("HashCode: " + GetHashCode().ToString(CultureInfo.InvariantCulture) + " Created");
        }

        public ICommand FattureCommand => new RelayCommand(() => navigationService.NavigateTo("Fattura"));

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
