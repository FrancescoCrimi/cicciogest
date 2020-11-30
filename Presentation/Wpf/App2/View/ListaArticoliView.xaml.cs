using GalaSoft.MvvmLight.Messaging;
using System.ComponentModel;
using System.Windows;

namespace CiccioGest.Presentation.Wpf.App2.View
{
    public partial class ListaArticoliView : Window
    {
        public ListaArticoliView()
        {
            InitializeComponent();
            Closing += SelezionaProdottoView_Closing;
        }

        private void SelezionaProdottoView_Closing(object sender, CancelEventArgs e)
        {
            Messenger.Default.Unregister(this);
            App.Windsor.Release(DataContext);
        }
    }
}
