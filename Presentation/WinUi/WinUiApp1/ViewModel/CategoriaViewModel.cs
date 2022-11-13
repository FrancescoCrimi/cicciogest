using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Threading.Tasks;

namespace CiccioGest.Presentation.WinUiApp1.ViewModel
{
    public sealed class CategoriaViewModel : ObservableObject, IDisposable
    {
        public CategoriaViewModel()
        {
        }

        private AsyncRelayCommand loadedCommand;

        public IAsyncRelayCommand LoadedCommand => loadedCommand
            ?? (loadedCommand = new AsyncRelayCommand(Loaded));

        private async Task Loaded()
        {
            await Task.CompletedTask;
        }

        public void Dispose()
        {
            //logger.LogDebug("Disposed: " + GetHashCode().ToString());
        }
    }
}
