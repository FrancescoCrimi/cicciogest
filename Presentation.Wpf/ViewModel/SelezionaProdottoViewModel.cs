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
using System.Windows;
using System.Windows.Input;

namespace Ciccio1.Presentation.Wpf.ViewModel
{
    public class SelezionaProdottoViewModel : ObservableObject
    {
        public SelezionaProdottoViewModel(IProdottoService prodottoService, ILogger logger)
        {
            Prodotti = new ObservableCollection<Prodotto>();
            var prodotti = prodottoService.GetProdotti();
            foreach (Prodotto pr in prodotti)
            {
                Prodotti.Add(pr);
            }
        }

        public ObservableCollection<Prodotto> Prodotti { get; private set; }
        public Prodotto ProdottoSelezionato { private get; set; }

        public ICommand SelezionaProdottoCommand
        {
            get
            {
                return new RelayCommand<Window>(window =>
                {
                    ViewModelLocator.Messenger.NotifyColleagues("IdProdottoSelezionato", ProdottoSelezionato.Id);
                    window.Close();
                });
            }
        }
    }
}
