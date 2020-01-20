using CiccioGest.Presentation.Wpf.App1.Contracts;
using System.Windows;

namespace CiccioGest.Presentation.Wpf.App1.View
{
    public partial class ShellView : Window
    {
        public ShellView(INavigationService navigationService)
        {
            InitializeComponent();
            navigationService.Initialize(shellFrame);
        }
    }
}
