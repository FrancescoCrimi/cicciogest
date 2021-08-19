using CiccioGest.Presentation.WpfApp.Services;
using CiccioGest.Presentation.WpfBackend.ViewModel;
using System.Windows;

namespace CiccioGest.Presentation.WpfApp.View
{
    public partial class ShellView : Window
    {
        public ShellView(ShellViewModel shellViewModel, NavigationService navigationService)
        {
            InitializeComponent();
            DataContext = shellViewModel;
            navigationService.Initialize(shellFrame);
        }
    }
}
