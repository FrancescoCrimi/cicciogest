using CiccioGest.Presentation.Ui3App1.Services;
using CiccioGest.Presentation.Ui3App1.ViewModel;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using Microsoft.UI.Xaml.Controls;

namespace CiccioGest.Presentation.Ui3App1.View
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
