using Castle.MicroKernel.Registration;
using CiccioGest.Presentation.AppWpf.ViewModel;
using GalaSoft.MvvmLight.Messaging;
using System.Windows;
using System.Windows.Controls;

namespace CiccioGest.Presentation.AppWpf.View
{
    public partial class MainWindow : Window
    {        
        public MainWindow()
        {
            InitializeComponent();
            App.Windsor.Register(Component.For<Frame>().Instance(pippo));
            Closing += MainWindow_Closing;
        }

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            App.Windsor.Release(DataContext);
            Messenger.Default.Unregister(this);
            ViewModelLocator.Cleanup();
        }
    }
}
