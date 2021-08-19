using CiccioGest.Presentation.UwpBackend.Services;
using Microsoft.Extensions.Logging;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CiccioGest.Presentation.UwpBackend.ViewModel
{
    public sealed class MainViewModel : ObservableObject, IDisposable
    {
        private readonly ILogger logger;
        private readonly INavigationService navigationService;
        private AsyncRelayCommand loadedCommand;
        private ICommand fattureCommand;
        private ICommand articoliCommand;
        private ICommand categorieCommand;
        private RelayCommand clientiCommand;
        private RelayCommand<Type> itemInvokedCommand;

        public MainViewModel(ILogger<MainViewModel> logger, INavigationService navigationService)
        {
            this.logger = logger;
            this.navigationService = navigationService;
            logger.LogDebug("HashCode: " + GetHashCode().ToString() + " Created");
        }

        public IAsyncRelayCommand LoadedCommand => loadedCommand
            ?? (loadedCommand = new AsyncRelayCommand(async () =>
            {
                await Task.CompletedTask;
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

        public ICommand ItemInvokedCommand => itemInvokedCommand ?? (itemInvokedCommand = new RelayCommand<Type>((type) =>
        {
            navigationService.Navigate(type);
        }));

        public void Dispose()
        {
            logger.LogDebug("HashCode: " + GetHashCode().ToString() + " Disposed");
        }
    }
}
