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
    /// <summary>
    /// Logica di interazione per App.xaml
    /// </summary>
    public partial class App : System.Windows.Application
    {
        private static ProdottiView pv = null;
        private static SelezionaProdottoView sp = null;

        internal static Messenger Messenger
        {
            get { return messenger; }
        }

        readonly static Messenger messenger = new Messenger();

        static App()
        {
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

            messenger.Register("ApriTipiProdottiView", () =>
            {
                CategorieView tv = new CategorieView();
                tv.ShowDialog();
            });
        }
    }
}
