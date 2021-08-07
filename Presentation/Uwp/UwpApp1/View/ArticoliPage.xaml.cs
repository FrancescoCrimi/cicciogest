using CiccioGest.Presentation.UwpApp.ViewModel;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using Windows.UI.Xaml.Controls;

namespace CiccioGest.Presentation.UwpApp.View
{
    public sealed partial class ArticoliPage : Page
    {
        public ArticoliPage()
        {
            InitializeComponent();
            DataContext = Ioc.Default.GetService<ArticoliViewModel>();
        }
    }
}
