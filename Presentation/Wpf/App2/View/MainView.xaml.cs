using CiccioGest.Presentation.Wpf.App2.ViewModel;
using GalaSoft.MvvmLight.Messaging;
using System.ComponentModel;
using System.Windows;

namespace CiccioGest.Presentation.Wpf.App2.View
{
    public partial class MainView : Window
    {
        public MainView()
        {
            InitializeComponent();
            Closing += MainWindow_Closing;
        }

        private void MainWindow_Closing(object sender, CancelEventArgs e)
        {
            App.Windsor.Release(DataContext);
            Messenger.Default.Unregister(this);
            ViewModelLocator.Cleanup();
        }
    }
}
