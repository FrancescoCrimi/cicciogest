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
    public sealed class ClientiViewModel : ObservableRecipient
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

        private RelayCommand aggiornaClientiCommand;

        public ICommand AggiornaClientiCommand
        {
            get
            {
                if (aggiornaClientiCommand == null)
                {
                    aggiornaClientiCommand = new RelayCommand(AggiornaClienti);
                }

                return aggiornaClientiCommand;
            }
        }

        private void AggiornaClienti()
        {
        }

        private RelayCommand apriClienteCommand;

        public ICommand ApriClienteCommand
        {
            get
            {
                if (apriClienteCommand == null)
                {
                    apriClienteCommand = new RelayCommand(ApriCliente);
                }

                return apriClienteCommand;
            }
        }

        private void ApriCliente()
        {
        }

        private RelayCommand cancellaClienteCommand;

        public ICommand CancellaClienteCommand
        {
            get
            {
                if (cancellaClienteCommand == null)
                {
                    cancellaClienteCommand = new RelayCommand(CancellaCliente);
                }

                return cancellaClienteCommand;
            }
        }

        private void CancellaCliente()
        {
        }
    }
}
