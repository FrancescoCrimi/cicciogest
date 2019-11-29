using Castle.MicroKernel.Registration;
using CiccioGest.Presentation.AppWpf1.ViewModel;
using GalaSoft.MvvmLight.Messaging;
using System.Windows;
using System.Windows.Controls;

namespace CiccioGest.Presentation.AppWpf1.View
{
    public partial class ShellView : Window
    {
        public ShellView()
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
        public bool Suca()
        {
            return System.ComponentModel.DesignerProperties.GetIsInDesignMode(this);
        }
    }
}
