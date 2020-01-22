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

        public ICommand FattureCommand => new RelayCommand(ApriFattura);
        public ICommand ArticoliCommand => new RelayCommand(ApriArticolo);
        public ICommand CategorieCommand => new RelayCommand(ApriCategoria);
        public ICommand LoadedCommand => loadedCommand ??
            (loadedCommand = new RelayCommand(() => navigationService.NavigateTo("Main")));

        public void Initialization(Frame frame)
        {
            navigationService.CurrentFrame = frame;
        }

        private void ApriFattura()
        {
            navigationService.NavigateTo("Fattura");
        }

        private void ApriCategoria()
        {
            navigationService.NavigateTo("Categoria");
        }

        private void ApriArticolo()
        {
            navigationService.NavigateTo("Articolo");
        }

        public void Dispose()
        {
            Cleanup();
            logger.Debug("HashCode: " + GetHashCode().ToString(CultureInfo.InvariantCulture) + " Disposed");
        }
    }
}
