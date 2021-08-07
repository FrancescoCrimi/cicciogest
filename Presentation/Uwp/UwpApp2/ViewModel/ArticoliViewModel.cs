using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System.Windows.Input;

namespace CiccioGest.Presentation.UwpApp.ViewModel
{
    public class ArticoliViewModel : ObservableObject
    {

        private RelayCommand loadedCommand;

        public ICommand LoadedCommand
        {
            get
            {
                if (loadedCommand == null)
                {
                    loadedCommand = new RelayCommand(Loaded);
                }

                return loadedCommand;
            }
        }

        private void Loaded()
        {
        }
    }
}
