using System.Windows;

namespace Ciccio1.Presentation.Wpf.View
{
    public partial class FattureView : Window
    {
        //private ProdottiView pv = null;
        //private SelezionaProdottoView sp = null;

        public FattureView()
        {
            InitializeComponent();

            //App.Messenger.Register("ApriSelezionaProdotto", () => 
            //{
            //    sp = new SelezionaProdottoView();
            //    sp.ShowDialog();
            //});

            //App.Messenger.Register("ChiudiSelezionaProdotto", () => 
            //{
            //    if (sp != null)
            //    {
            //        sp.Close();
            //        sp = null;
            //    }
            //});

            //App.Messenger.Register("ApriProdottiView", () => 
            //{
            //    pv = new ProdottiView();
            //    pv.ShowDialog();
            //});

            //App.Messenger.Register("ChiudiProdottiView", () => 
            //{
            //    if (pv != null)
            //    {
            //        pv.Close();
            //        pv = null;
            //    }
            //});

            //App.Messenger.Register("ApriTipiProdottiView", () => 
            //{
            //    CategorieView tv = new CategorieView();
            //    tv.ShowDialog();
            //});
        }
    }
}
