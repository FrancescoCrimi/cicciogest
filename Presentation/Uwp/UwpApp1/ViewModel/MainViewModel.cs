using CiccioGest.Presentation.UwpApp.Services;
using CiccioGest.Presentation.UwpApp.View;
using Microsoft.Extensions.Logging;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Windows.Input;
using Windows.UI.Xaml.Controls;

namespace CiccioGest.Presentation.UwpApp.ViewModel
{
    public sealed class MainViewModel : ObservableObject, IDisposable
    {
        private readonly ILogger logger;
        private readonly NavigationService navigationService;
        private ICommand loadedCommand;
        private ICommand fattureCommand;
        private ICommand articoliCommand;
        private ICommand categorieCommand;

        public MainViewModel(ILogger<MainViewModel> logger, NavigationService navigationService)
        {
            this.logger = logger;
            this.navigationService = navigationService;
            logger.LogDebug("HashCode: " + GetHashCode().ToString() + " Created");
        }

        public ICommand LoadedCommand => loadedCommand ?? (loadedCommand = new RelayCommand(() => {
            //navigationService.Navigate<MainPage>();
        }));

        public ICommand FattureCommand => fattureCommand ?? (fattureCommand = new RelayCommand(() =>
            navigationService.Navigate<FatturaPage>()));

        public ICommand ArticoliCommand => articoliCommand ?? (articoliCommand = new RelayCommand(() =>
            navigationService.Navigate<ArticoloPage>()));

        public ICommand CategorieCommand => categorieCommand ?? (categorieCommand = new RelayCommand(() =>
            navigationService.Navigate<CategoriaPage>()));

        public void Initialization(Frame frame)
        {
            navigationService.Initialize(frame);
        }

        public void Dispose()
        {
            logger.LogDebug("HashCode: " + GetHashCode().ToString() + " Disposed");
        }
    }
}
