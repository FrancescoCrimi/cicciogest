using CiccioGest.Presentation.WpfApp2.Contracts;
using CiccioGest.Presentation.WpfApp2.ViewModel;
using System.Windows;

namespace CiccioGest.Presentation.WpfApp2.View
{
    public partial class ShellView : Window
    {
        public ShellView(ShellViewModel shellViewModel, INavigationService navigationService)
        {
            InitializeComponent();
            DataContext = shellViewModel;
            navigationService.Initialize(shellFrame);
        }
    }
}
