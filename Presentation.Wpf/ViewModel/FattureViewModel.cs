using Castle.Core.Logging;
using CiccioGest.Application;
using CiccioGest.Domain;
using CiccioGest.Domain.Model;
using CiccioGest.Domain.ReadOnlyModel;
using CiccioGest.Presentation.Wpf.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CiccioGest.Presentation.Wpf.ViewModel
{
    public class FattureViewModel : ObservableObject
    {
        private IFatturaService service;
        private ILogger logger;

        public FattureViewModel(IFatturaService service, ILogger logger)
        {
            this.service = service;
            this.logger = logger;
            Fatture = new ObservableCollection<FatturaReadOnly>();
            registraMessaggi();
            aggiorna();
        }


        #region Proprietà Pubbliche

        public ObservableCollection<FatturaReadOnly> Fatture { get; private set; }

        public Fattura FatturaSelezionata { private get; set; }

        public ICommand NuovaFatturaCommand
        {
            get
            {
                return new RelayCommand(() =>
                ViewModelLocator.Messenger.NotifyColleagues("ApriFatturaView", 0));
            }
        }

        public ICommand ApriFattura
        {
            get
            {
                return new RelayCommand(() =>
                ViewModelLocator.Messenger.NotifyColleagues("ApriFatturaView", FatturaSelezionata.Id));
            }
        }

        public ICommand ApriCategorieCommand
        {
            get
            {
                return new RelayCommand(() =>
                ViewModelLocator.Messenger.NotifyColleagues("ApriCategorieView"));
            }
        }

        public ICommand ApriProdottiCommand
        {
            get
            {
                return new RelayCommand(() =>
                ViewModelLocator.Messenger.NotifyColleagues("ApriProdottiView"));
            }
        }

        #endregion


        #region Metodi Privati

        private void aggiorna()
        {
            IEnumerable<FatturaReadOnly> fatture = service.GetFatture();
            Fatture.Clear();
            foreach (FatturaReadOnly fatt in fatture)
            {
                Fatture.Add(fatt);
            }
        }

        private void registraMessaggi()
        {
            ViewModelLocator.Messenger.Register("AggiornaFattureView", () => aggiorna());
        }

        #endregion
    }
}