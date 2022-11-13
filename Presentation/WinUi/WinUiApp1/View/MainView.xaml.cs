using CiccioGest.Presentation.WinUiApp1.Services;
using CiccioGest.Presentation.WinUiApp1.ViewModel;
using CommunityToolkit.Mvvm.DependencyInjection;
using Microsoft.UI.Xaml.Controls;

namespace CiccioGest.Presentation.WinUiApp1.View
{
    public sealed partial class MainView : Page
    {
        public MainView()
        {
            InitializeComponent();
            var nav = Ioc.Default.GetService<NavigationService>();
            nav.Initialize(shellFrame);
            DataContext = Ioc.Default.GetService<MainViewModel>();
        }
    }
}
