using CiccioGest.Presentation.UwpNav.Services;
using CiccioGest.Presentation.UwpBackend.ViewModel;
using Windows.UI.Xaml.Controls;

namespace CiccioGest.Presentation.UwpNav.View
{
    public sealed partial class ShellView : Page
    {
        public ShellView(NavigationService navigationService,
                         ShellViewModel shellViewModel)
        {
            InitializeComponent();
            navigationService.Initialize(ContentFrame);
            DataContext = shellViewModel;
        }
    }
}
