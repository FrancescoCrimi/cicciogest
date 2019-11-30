using CiccioGest.Infrastructure;
using GalaSoft.MvvmLight.Messaging;
using System.Windows;

namespace CiccioGest.Presentation.Wpf.App2.View
{
    public partial class CategoriaView : Window
    {
        public CategoriaView()
        {
            InitializeComponent();
            Closing += CategoriaView_Closing;
        }

        private void CategoriaView_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Messenger.Default.Unregister(this);
            App.Windsor.Release(DataContext);
        }
    }
}
