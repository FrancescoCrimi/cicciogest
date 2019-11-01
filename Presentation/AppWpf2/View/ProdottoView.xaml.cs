using CiccioGest.Infrastructure;
using GalaSoft.MvvmLight.Messaging;
using System.Windows;

namespace CiccioGest.Presentation.AppWpf2.View
{
    public partial class ProdottoView : Window
    {
        public ProdottoView()
        {
            InitializeComponent();
            Closing += ProdottoView_Closing;
        }

        private void ProdottoView_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Messenger.Default.Unregister(this);
            App.Windsor.Release(DataContext);
        }
    }
}
