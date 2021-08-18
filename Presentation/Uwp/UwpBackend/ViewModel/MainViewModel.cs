using CiccioGest.Presentation.UwpBackend.Services;
using Microsoft.Extensions.Logging;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Windows.Input;

namespace CiccioGest.Presentation.UwpBackend.ViewModel
{
    public sealed class MainViewModel : ObservableObject, IDisposable
    {
        private readonly ILogger logger;
        private readonly INavigationService navigationService;
        private ICommand loadedCommand;
        private ICommand fattureCommand;
        private ICommand articoliCommand;
        private ICommand categorieCommand;
        private RelayCommand clientiCommand;

        public MainViewModel(ILogger<MainViewModel> logger, INavigationService navigationService)
        {
            this.logger = logger;
            this.navigationService = navigationService;
            logger.LogDebug("HashCode: " + GetHashCode().ToString() + " Created");
        }

        public ICommand LoadedCommand => loadedCommand ?? (loadedCommand = new RelayCommand(() =>
        {
            //navigationService.Navigate<MainPage>();
        }));

        public ICommand FattureCommand => fattureCommand ?? (fattureCommand = new RelayCommand(() =>
        {
            navigationService.Navigate("FattureViewModel");
        }));

        public ICommand ArticoliCommand => articoliCommand ?? (articoliCommand = new RelayCommand(() =>
            navigationService.Navigate("ArticoliViewModel")));

        public ICommand CategorieCommand => categorieCommand ?? (categorieCommand = new RelayCommand(() =>
            navigationService.Navigate("CategoriaViewModel")));

        public ICommand ClientiCommand => clientiCommand ?? (clientiCommand = new RelayCommand(() =>
        {
            navigationService.Navigate("ClientiViewModel");
        }));

        public void Dispose()
        {
            logger.LogDebug("HashCode: " + GetHashCode().ToString() + " Disposed");
        }


        private RelayCommand<Type> itemInvokedCommand;

        public ICommand ItemInvokedCommand => itemInvokedCommand ??
            (itemInvokedCommand = new RelayCommand<Type>(ItemInvoked));

        private void ItemInvoked(Type type)
        {
            navigationService.Navigate(type);
        }
    }
}
