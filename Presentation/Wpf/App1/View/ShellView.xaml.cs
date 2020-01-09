using Castle.MicroKernel.Registration;
using CiccioGest.Presentation.Wpf.App1.ViewModel;
using GalaSoft.MvvmLight.Messaging;
using System.Windows;
using System.Windows.Controls;

namespace CiccioGest.Presentation.Wpf.App1.View
{
    public partial class ShellView : Window
    {
        public ShellView()
        {
            InitializeComponent();
            App.Windsor.Register(Component.For<Frame>().Instance(shellFrame));
            Closing += MainWindow_Closing;
        }

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            App.Windsor.Release(DataContext);
            Messenger.Default.Unregister(this);
            ViewModelLocator.Cleanup();
        }

        public Frame GetNavigationFrame()
        {
            return shellFrame;
        }

        public bool Suca()
        {
            return System.ComponentModel.DesignerProperties.GetIsInDesignMode(this);
        }
    }
}
