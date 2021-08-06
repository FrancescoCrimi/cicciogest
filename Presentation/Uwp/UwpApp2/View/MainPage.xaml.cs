using CiccioGest.Presentation.UwpApp.ViewModel;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using Windows.UI.Xaml.Controls;

namespace CiccioGest.Presentation.UwpApp.View
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
            MainViewModel viewModel = Ioc.Default.GetService<MainViewModel>();
            viewModel.Initialize(ContentFrame);
            DataContext = viewModel;
        }
    }
}
