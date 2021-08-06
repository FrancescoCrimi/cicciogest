using CiccioGest.Presentation.UwpApp.ViewModel;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using Windows.UI.Xaml.Controls;

namespace CiccioGest.Presentation.UwpApp.View
{
    public sealed partial class ShellPage : Page
    {
        public ShellPage()
        {
            InitializeComponent();
            var viewModel = Ioc.Default.GetService<ShellViewModel>();
            viewModel.Initialize(ContentFrame);
            DataContext = viewModel;
        }
    }
}
