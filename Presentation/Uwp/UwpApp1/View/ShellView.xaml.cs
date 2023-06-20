using CiccioGest.Presentation.UwpApp.Services;
using CiccioGest.Presentation.UwpBackend.ViewModel;
using CommunityToolkit.Mvvm.DependencyInjection;
using Windows.UI.Xaml.Controls;

namespace CiccioGest.Presentation.UwpApp.View
{
    public sealed partial class ShellView : Page
    {
        public ShellView()
        {
            InitializeComponent();
            var nav = Ioc.Default.GetService<NavigationService>();
            nav.Initialize(shellFrame);
            DataContext = Ioc.Default.GetService<ShellViewModel>();
        }
    }
}
