using CiccioGest.Infrastructure;
using GalaSoft.MvvmLight.Messaging;
using System.Windows;

namespace CiccioGest.Presentation.AppWpf.View
{
    public partial class SelezionaProdottoView : Window
    {
        public SelezionaProdottoView()
        {
            InitializeComponent();
            Closing += SelezionaProdottoView_Closing;
        }

        private void SelezionaProdottoView_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Messenger.Default.Unregister(this);
            Bootstrap.Windsor.Release(DataContext);
        }
    }
}