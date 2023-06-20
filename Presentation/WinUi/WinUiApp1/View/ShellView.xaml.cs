using CiccioGest.Presentation.WinUiApp1.Services;
using CiccioGest.Presentation.WinUiApp1.ViewModel;
using Microsoft.UI.Xaml.Controls;

namespace CiccioGest.Presentation.WinUiApp1.View
{
    public sealed partial class ShellView : Page
    {
        public ShellView(NavigationService navigationService,
                         ShellViewModel mainViewModel)
        {
            InitializeComponent();
            navigationService.Initialize(shellFrame);
            DataContext = mainViewModel;
        }
    }
}
