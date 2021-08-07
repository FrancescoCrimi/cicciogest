using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CiccioGest.Presentation.UwpApp.ViewModel
{
    public sealed class ClientiViewModel : ObservableObject
    {
        public ClientiViewModel()
        {
        }

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
