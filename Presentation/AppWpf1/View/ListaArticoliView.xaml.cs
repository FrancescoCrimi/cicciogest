using GalaSoft.MvvmLight.Messaging;
using System.Windows.Controls;

namespace CiccioGest.Presentation.AppWpf1.View
{
    public partial class ListaArticoliView : Page
    {
        public ListaArticoliView()
        {
            InitializeComponent();
            //Closing += SelezionaProdottoView_Closing;
        }

        private void SelezionaProdottoView_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Messenger.Default.Unregister(this);
            App.Windsor.Release(DataContext);
        }
    }
}
