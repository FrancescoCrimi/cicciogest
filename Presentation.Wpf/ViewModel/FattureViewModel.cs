using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;
//using DddTest.Presentation.Wpf.View;
using Ciccio1.Domain;
using Ciccio1.Application;
using Ciccio1.Presentation.Wpf.Utils;

namespace Ciccio1.Presentation.Wpf.ViewModel
{
    public class FattureViewModel : ObservableObject
    {
        private ICiccioService service = null;
        private bool dettIsNew = false;

        public FattureViewModel(ICiccioService fatturaService)
        {
            service = fatturaService;
            Fatture = new ObservableCollection<Fattura>();
            Dettagli = new ObservableCollection<Dettaglio>();
            registraMessaggi();
            aggiorna();
        }


        #region Proprietà Pubbliche

        public ObservableCollection<Fattura> Fatture { get; private set; }
        public Fattura Fattura { get; private set; }
        public Dettaglio Dettaglio { get; private set; }
        public ObservableCollection<Dettaglio> Dettagli { get; private set; }

        public Fattura FatturaSelezionata
        {
            set
            {
                if (value != null && value != Fattura)
                {
                    setFattura(service.GetFattura(value.IdFattura));
                    dettIsNew = false;
                }
            }
        }

        public Dettaglio DettaglioSelezionato
        {
            set
            {
                if (value != null && value != Dettaglio)
                {
                    Dettaglio = value;
                    RaisePropertyChanged("Dettaglio");
                    dettIsNew = false;
                }
            }
        }

        public ICommand NuovaFatturaCommand
        {
            get
            {
                return new RelayCommand(() => nuovaFattura());
            }
        }

        public ICommand SalvaFatturaCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    try
                    {
                        service.SaveFattura(Fattura);
                        aggiorna();
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("Errore: " + e.Message);
                    }
                });
            }
        }

        public ICommand RimuoviFatturaCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    try
                    {
                        service.DeleteFattura(Fattura);
                        aggiorna();
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("Errore: " + e.Message);
                    }
                });
            }
        }

        public ICommand NuovoDettaglioCommand
        {
            get
            {
                return new RelayCommand(() => App.Messenger.NotifyColleagues("ApriSelezionaProdotto"));
            }
        }

        public ICommand AggiungiDettaglioCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    if (dettIsNew && Dettaglio.Quantità != 0)
                    {
                        Fattura.AddDettaglio(Dettaglio);
                        RaisePropertyChanged("Fattura");
                        refreshDettagli();
                        dettIsNew = false;
                    }
                });
            }
        }

        public ICommand RimuoviDettaglioCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    Fattura.RemoveDettaglio(Dettaglio);
                    RaisePropertyChanged("Fattura");
                    refreshDettagli();
                });
            }
        }

        public ICommand ApriCategorieCommand
        {
            get
            {
                return new RelayCommand(() => App.Messenger.NotifyColleagues("ApriTipiProdottiView"));
            }
        }

        public ICommand ApriProdottiCommand
        {
            get
            {
                return new RelayCommand(() => App.Messenger.NotifyColleagues("ApriProdottiView"));
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
            nuovaFattura();
        }

        private void nuovaFattura()
        {
            setFattura(Factory.NewTransientFattura());
            dettIsNew = false;
        }

        private void setFattura(Fattura fattura)
        {
            Fattura = fattura;
            RaisePropertyChanged("Fattura");
            Dettagli.Clear();
            foreach (Dettaglio dett in Fattura.Dettagli)
            {
                Dettagli.Add(dett);
            }
            Dettaglio = null;
            RaisePropertyChanged("Dettaglio");
        }

        private void registraMessaggi()
        {
            App.Messenger.Register<Guid>("IdProdottoSelezionato", id =>
            {
                Dettaglio = Factory.NuovoDettaglio(service.GetProdotto(id), 1);
                RaisePropertyChanged("Dettaglio");
                App.Messenger.NotifyColleagues("ChiudiSelezionaProdotto");
                dettIsNew = true;
            });
        }

        private void refreshDettagli()
        {
            Dettagli.Clear();
            foreach (Dettaglio dett in Fattura.Dettagli)
            {
                Dettagli.Add(dett);
            }
            Dettaglio = null;
            RaisePropertyChanged("Dettaglio");
        }

        #endregion
    }
}
