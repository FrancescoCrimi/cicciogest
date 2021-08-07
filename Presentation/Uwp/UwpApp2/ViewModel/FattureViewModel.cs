using CiccioGest.Application;
using CiccioGest.Domain.Documenti;
using CiccioGest.Infrastructure;
using Microsoft.Extensions.Logging;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace CiccioGest.Presentation.UwpApp.ViewModel
{
    public class FattureViewModel : ObservableObject
    {
        private readonly ILogger logger;
        private readonly IFatturaService fatturaService;
        private ICommand apriFatturaCommand;
        private ICommand loadedCommand;

        public FattureViewModel(ILogger<FattureViewModel> logger, IFatturaService fatturaService)
        {
            this.logger = logger;
            this.fatturaService = fatturaService;
            Fatture = new ObservableCollection<FatturaReadOnly>();
        }

        public ObservableCollection<FatturaReadOnly> Fatture { get; private set; }

        public FatturaReadOnly FatturaSelezionata { private get; set; }

        public ICommand ApriFatturaCommand => apriFatturaCommand ?? (apriFatturaCommand = new RelayCommand(ApriFattura));

        public ICommand LoadedCommand => loadedCommand ?? (loadedCommand = new RelayCommand(async () =>
        {
            Fatture.Clear();
            foreach (FatturaReadOnly fatt in await fatturaService.GetFatture())
            {
                Fatture.Add(fatt);
            }
        }));

        private void ApriFattura()
        {
            throw new NotImplementedException();
        }
    }
}
