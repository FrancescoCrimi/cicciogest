using Ciccio1.Presentation.Wpf.Utils;
using Ciccio1.Presentation.Wpf.View;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Ciccio1.Presentation.Wpf
{
    public partial class App : System.Windows.Application
    {
        private static ProdottiView pv = null;
        private static SelezionaProdottoView sp = null;
        private static FatturaView fatturaView = null;
        private static CategorieView categoriaView = null;

        internal static Messenger Messenger
        {
            get { return messenger; }
        }

        readonly static Messenger messenger = new Messenger();

        static App()
        {

            messenger.Register<int>("ApriFatturaView", id =>
            {
                fatturaView = new FatturaView();
                messenger.NotifyColleagues("SettaIdFatturaView", id);
                fatturaView.ShowDialog();
            });

            messenger.Register("ChiudiFatturaView", () =>
            {
                if(fatturaView != null)
                {
                    fatturaView.Close();
                    fatturaView = null;
                }
            });

            messenger.Register("ApriSelezionaProdotto", () =>
            {
                sp = new SelezionaProdottoView();
                sp.ShowDialog();
            });

            messenger.Register("ChiudiSelezionaProdotto", () =>
            {
                if (sp != null)
                {
                    sp.Close();
                    sp = null;
                }
            });

            messenger.Register("ApriProdottiView", () =>
            {
                pv = new ProdottiView();
                pv.ShowDialog();
            });

            messenger.Register("ChiudiProdottiView", () =>
            {
                if (pv != null)
                {
                    pv.Close();
                    pv = null;
                }
            });

            messenger.Register("ApriCategorieView", () =>
            {
                CategorieView categoriaView = new CategorieView();
                categoriaView.ShowDialog();
            });

            messenger.Register("ChiudiCategoriaView", () => 
            {
                if(categoriaView != null)
                {
                    categoriaView.Close();
                    categoriaView = null;
                }
            });
        }
    }
}
