using GalaSoft.MvvmLight.Messaging;
using System.ComponentModel;
using System.Windows;

namespace CiccioGest.Presentation.Wpf.App2.View
{
    public partial class ArticoloView : Window
    {
        public ArticoloView()
        {
            InitializeComponent();
            Closing += ProdottoView_Closing;
        }

        private void ProdottoView_Closing(object sender, CancelEventArgs e)
        {
            Messenger.Default.Unregister(this);
            App.Windsor.Release(DataContext);
        }
    }
}
