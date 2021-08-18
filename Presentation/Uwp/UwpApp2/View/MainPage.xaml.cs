using CiccioGest.Presentation.UwpApp.Services;
using CiccioGest.Presentation.UwpBackend.ViewModel;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using Windows.UI.Xaml.Controls;

namespace CiccioGest.Presentation.UwpApp.View
{
    public sealed partial class MainPage : Page
    {
        private readonly NavigationService navigationService;
        public MainPage()
        {
            InitializeComponent();
            navigationService = Ioc.Default.GetService<NavigationService>();
            navigationService.Initialize(ContentFrame);
            DataContext = Ioc.Default.GetService<MainViewModel>();
        }
    }
}
