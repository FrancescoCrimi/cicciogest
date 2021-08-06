using CiccioGest.Presentation.UwpApp.ViewModel;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using Windows.UI.Xaml.Controls;

namespace CiccioGest.Presentation.UwpApp.View
{
    public sealed partial class CategoriaPage : Page
    {
        public CategoriaPage()
        {
            InitializeComponent();
            DataContext = Ioc.Default.GetService<CategoriaViewModel>();
        }
    }
}
