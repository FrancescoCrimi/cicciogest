using CiccioGest.Presentation.UwpApp.Services;
using CiccioGest.Presentation.UwpBackend.ViewModel;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using Windows.UI.Xaml.Controls;

namespace CiccioGest.Presentation.UwpApp.View
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
            var nav = Ioc.Default.GetService<NavigationService>();
            nav.Initialize(shellFrame);
            DataContext = Ioc.Default.GetService<MainViewModel>();
        }
    }
}
