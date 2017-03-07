using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ciccio1.Infrastructure;
using Ciccio1.Presentation.Wpf.ViewModel;
using Ciccio1.Presentation.Wpf.Utils;
using Ciccio1.Presentation.Wpf.View;
using Castle.MicroKernel.Lifestyle;
using System.Windows;

namespace Ciccio1.Presentation.Wpf
{
    public class ViewModelLocator
    {
        private readonly static Container ioc;
        private readonly static Messenger messenger;
        private readonly static Dictionary<int, IDisposable> dict;

        static ViewModelLocator()
        {
            ioc = new Container(UI.WPF);
            messenger = new Messenger();
            registramessaggi();
            dict = new Dictionary<int, IDisposable>();
            ioc.Install(new Installer());
        }

        public FattureViewModel FattureViewModel
        {
            get { return ioc.Resolve<FattureViewModel>(); }
        }

        public FatturaViewModel FatturaViewModel
        {
            get { return ioc.Resolve<FatturaViewModel>(); }
        }

        public ProdottiViewModel ProdottiViewModel
        {
            get { return ioc.Resolve<ProdottiViewModel>(); }
        }

        public CategorieViewModel CategorieViewModel
        {
            get { return ioc.Resolve<CategorieViewModel>(); }
        }

        public SelezionaProdottoViewModel SelezionaProdottoViewModel
        {
            get { return ioc.Resolve<SelezionaProdottoViewModel>(); }
        }



        internal static Messenger Messenger
        {
            get { return messenger; }
        }



        private static void view_Closed(object sender, EventArgs e)
        {
            IDisposable disp = null;
            if (dict.TryGetValue(sender.GetHashCode(), out disp))
            {
                Window wnd = sender as Window;
                if (wnd != null)
                {
                    dict.Remove(wnd.GetHashCode());
                    ioc.Release(wnd.DataContext);
                    disp.Dispose();
                }
            }
        }

        private static void registramessaggi()
        {
            messenger.Register("ApriFatture", () =>
            {
                IDisposable disposable = ioc.Windsor.BeginScope();
                FattureView fattureView = new FattureView();
                fattureView.Closed += view_Closed;
                dict.Add(fattureView.GetHashCode(), disposable);
                fattureView.Show();
            });

            messenger.Register<int>("ApriFatturaView", id =>
            {
                IDisposable disposable = ioc.Windsor.BeginScope();
                FatturaView fatturaView = new FatturaView();
                fatturaView.Closed += view_Closed;
                dict.Add(fatturaView.GetHashCode(), disposable);
                messenger.NotifyColleagues("SettaIdFatturaView", id);
                fatturaView.ShowDialog();
            });

            messenger.Register("ApriProdottiView", () =>
            {
                IDisposable disposable = ioc.Windsor.BeginScope();
                ProdottiView prodottiView = new ProdottiView();
                prodottiView.Closed += view_Closed;
                dict.Add(prodottiView.DataContext.GetHashCode(), disposable);
                prodottiView.ShowDialog();
            });

            messenger.Register("ApriCategorieView", () =>
            {
                IDisposable disposable = ioc.Windsor.BeginScope();
                CategorieView categoriaView = new CategorieView();
                categoriaView.Closed += view_Closed;
                dict.Add(categoriaView.DataContext.GetHashCode(), disposable);
                categoriaView.ShowDialog();
            });

            messenger.Register("ApriSelezionaProdotto", () =>
            {
                IDisposable disposable = ioc.Windsor.BeginScope();
                SelezionaProdottoView sp = new SelezionaProdottoView();
                sp.Closed += view_Closed;
                dict.Add(sp.DataContext.GetHashCode(), disposable);
                sp.ShowDialog();
            });
        }
    }
}
