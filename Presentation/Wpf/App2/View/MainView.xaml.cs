using CiccioGest.Presentation.Wpf.App2.Contracts;
using CiccioGest.Presentation.Wpf.App2.ViewModel;
using GalaSoft.MvvmLight.Messaging;
using System.ComponentModel;
using System.Windows;

namespace CiccioGest.Presentation.Wpf.App2.View
{
    public partial class MainView : Window, IView
    {
        public MainView()
        {
            InitializeComponent();
            Closing += MainWindow_Closing;
        }

        public WindowKey WindowKey => WindowKey.Main;

        private void MainWindow_Closing(object sender, CancelEventArgs e)
        {
            App.Windsor.Release(DataContext);
            Messenger.Default.Unregister(this);
            ViewModelLocator.Cleanup();
        }
    }
}
