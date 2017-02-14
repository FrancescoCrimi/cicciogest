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
using Castle.Core.Logging;

namespace Ciccio1.Presentation.Wpf.ViewModel
{
    public class FatturaViewModel : ObservableObject
    {
        private ICiccioService service;
        private ILogger logger;

        public FatturaViewModel(ICiccioService service, ILogger logger)
        {
            this.service = service;
            this.logger = logger;
            registraMessaggi();
        }

        #region Proprietà Pubbliche

        public Fattura Fattura { get; private set; }

        public Dettaglio Dettaglio { get; private set; }

        public Fattura FatturaSelezionata { private get; set; }

        public Dettaglio DettaglioSelezionato { private get; set; }

        public ICommand NuovaFatturaCommand
        {
            get
            {
                return new RelayCommand(() => nuovaFattura(0));
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
                        App.Messenger.NotifyColleagues("AggiornaFattureView");
                        App.Messenger.NotifyColleagues("ChiudiFatturaView");
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
                        App.Messenger.NotifyColleagues("AggiornaFattureView");
                        App.Messenger.NotifyColleagues("ChiudiFatturaView");
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
                    if (Dettaglio.Quantità != 0)
                    {
                        Fattura.AddDettaglio(Dettaglio);
                        RaisePropertyChanged("Fattura");
                        nuovoDettaglio();
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
                    nuovoDettaglio();
                });
            }
        }

        public ICommand ApriCategorieCommand
        {
            get
            {
                return new RelayCommand(() => App.Messenger.NotifyColleagues("ApriCategorieView"));
            }
        }

        public ICommand ApriProdottiCommand
        {
            get
            {
                return new RelayCommand(() => App.Messenger.NotifyColleagues("ApriProdottiView"));
            }
        }

        public ICommand SelezionaDettaglio
        {
            get
            {
                return new RelayCommand(() =>
                {
                    if (DettaglioSelezionato != null)
                        Dettaglio = DettaglioSelezionato;
                    RaisePropertyChanged("Dettaglio");
                });
            }
        }

        public ICommand SelezionaProdotto
        {
            get
            {
                return new RelayCommand(() => App.Messenger.NotifyColleagues("ApriSelezionaProdotto"));
            }
        }

        #endregion


        #region Metodi Privati

        private void nuovaFattura(int id)
        {
            if (id == 0)
                Fattura = Factory.NewFattura();
            else
                Fattura = service.GetFattura(id);
            RaisePropertyChanged("Fattura");
            nuovoDettaglio();
        }

        private void nuovoDettaglio()
        {
            Dettaglio = new Dettaglio(null, 1);
            RaisePropertyChanged("Dettaglio");
        }

        private void registraMessaggi()
        {
            App.Messenger.Register<int>("IdProdottoSelezionato", id =>
            {
                Dettaglio = new Dettaglio(service.GetProdotto(id), 1);
                RaisePropertyChanged("Dettaglio");
                App.Messenger.NotifyColleagues("ChiudiSelezionaProdotto");
            });

            App.Messenger.Register<int>("SettaIdFatturaView", id => nuovaFattura(id));
        }

        #endregion
    }
}
