using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System.Threading.Tasks;

namespace CiccioGest.Presentation.Ui3App1.ViewModel
{
    public sealed class CategoriaViewModel : ObservableObject
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
    }
}
