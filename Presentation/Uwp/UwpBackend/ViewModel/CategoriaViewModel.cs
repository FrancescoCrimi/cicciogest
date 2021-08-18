using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CiccioGest.Presentation.UwpBackend.ViewModel
{
    public sealed class CategoriaViewModel : ObservableObject
    {
        public CategoriaViewModel()
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
