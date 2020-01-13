using CiccioGest.Presentation.Wpf.App1.Contracts;
using CiccioGest.Presentation.Wpf.App1.ViewModel;
using System.Windows;

namespace CiccioGest.Presentation.Wpf.App1.View
{
    public partial class ShellView : Window
    {
        public ShellView(INavigationService navigationService)
        {
            InitializeComponent();
            navigationService.Initialize(shellFrame);
            Closing += MainWindow_Closing;
        }

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //App.Windsor.Release(DataContext);
            //Messenger.Default.Unregister(this);
            ViewModelLocator.Cleanup();
        }

        public bool Suca()
        {
            return System.ComponentModel.DesignerProperties.GetIsInDesignMode(this);
        }
    }
}
