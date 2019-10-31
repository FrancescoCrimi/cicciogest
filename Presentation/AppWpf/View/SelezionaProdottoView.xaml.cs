using GalaSoft.MvvmLight.Messaging;
using System.Windows.Controls;

namespace CiccioGest.Presentation.AppWpf.View
{
    public partial class SelezionaProdottoView : Page
    {
        public SelezionaProdottoView()
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
