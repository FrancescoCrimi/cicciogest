using Castle.Core.Logging;
using Ciccio1.Application;
using Ciccio1.Domain;
using Ciccio1.Presentation.Wpf.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Ciccio1.Presentation.Wpf.ViewModel
{
    public class FattureViewModel : ObservableObject
    {
        private ICiccioService service;
        private ILogger logger;

        public FattureViewModel(ICiccioService service, ILogger logger)
        {
            this.service = service;
            this.logger = logger;
            Fatture = new ObservableCollection<Fattura>();
            registraMessaggi();
            aggiorna();
        }


        #region Proprietà Pubbliche

        public ObservableCollection<Fattura> Fatture { get; private set; }

        public Fattura FatturaSelezionata { private get; set; }

        public ICommand NuovaFatturaCommand
        {
            get
            {
                return new RelayCommand(() =>
                App.Messenger.NotifyColleagues("ApriFatturaView", 0));
            }
        }

        public ICommand ApriFattura
        {
            get
            {
                return new RelayCommand(() =>
                App.Messenger.NotifyColleagues("ApriFatturaView", FatturaSelezionata.Id));
            }
        }

        public ICommand ApriCategorieCommand
        {
            get
            {
                return new RelayCommand(() =>
                App.Messenger.NotifyColleagues("ApriCategorieView"));
            }
        }

        public ICommand ApriProdottiCommand
        {
            get
            {
                return new RelayCommand(() =>
                App.Messenger.NotifyColleagues("ApriProdottiView"));
            }
        }

        #endregion


        #region Metodi Privati

        private void aggiorna()
        {
            IEnumerable<Fattura> fatture = service.GetFatture();
            Fatture.Clear();
            foreach (Fattura fatt in fatture)
            {
                Fatture.Add(fatt);
            }
        }

        private void registraMessaggi()
        {
            App.Messenger.Register("AggiornaFattureView", () => aggiorna());
        }

        #endregion
    }
}