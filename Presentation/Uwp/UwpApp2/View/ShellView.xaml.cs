using CiccioGest.Presentation.UwpApp.Services;
using CiccioGest.Presentation.UwpBackend.ViewModel;
using CommunityToolkit.Mvvm.DependencyInjection;
using Windows.UI.Xaml.Controls;

namespace CiccioGest.Presentation.UwpApp.View
{
    public sealed partial class ShellView : Page
    {
        private readonly NavigationService navigationService;
        public ShellView()
        {
            InitializeComponent();
            navigationService = Ioc.Default.GetService<NavigationService>();
            navigationService.Initialize(ContentFrame);
            DataContext = Ioc.Default.GetService<ShellViewModel>();
        }
    }
}
