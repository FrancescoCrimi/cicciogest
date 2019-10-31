using Castle.Core.Logging;
using CiccioGest.Application;
using CiccioGest.Domain.Documenti;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace CiccioGest.Presentation.AppUwp2.ViewModel
{
    public class SelectFatturaViewModel : ViewModelBase
    {
        private readonly ILogger logger;
        private readonly IFatturaService fatturaService;
        private ICommand apriFatturaCommand;
        private ICommand loadedCommand;

        public SelectFatturaViewModel(ILogger logger, IFatturaService fatturaService)
        {
            this.logger = logger;
            this.fatturaService = fatturaService;
            Fatture = new ObservableCollection<FatturaReadOnly>();
        }

        public ObservableCollection<FatturaReadOnly> Fatture { get; private set; }
        public FatturaReadOnly FatturaSelezionata { private get; set; }
        public ICommand ApriFatturaCommand => apriFatturaCommand ??
            (apriFatturaCommand = new RelayCommand(ApriFattura));

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
