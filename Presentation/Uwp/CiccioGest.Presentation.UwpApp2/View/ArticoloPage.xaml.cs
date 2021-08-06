using CiccioGest.Presentation.UwpApp.ViewModel;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using Windows.UI.Xaml.Controls;

namespace CiccioGest.Presentation.UwpApp.View
{
    public sealed partial class ArticoloPage : Page
    {
        public ArticoloPage()
        {
            InitializeComponent();
            DataContext = Ioc.Default.GetService<ArticoloViewModel>();
        }
    }
}
