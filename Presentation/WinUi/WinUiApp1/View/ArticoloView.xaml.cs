using CiccioGest.Presentation.WinUiApp1.ViewModel;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using Microsoft.UI.Xaml.Controls;

namespace CiccioGest.Presentation.WinUiApp1.View
{
    public sealed partial class ArticoloView : Page
    {
        public ArticoloView()
        {
            InitializeComponent();
            DataContext = Ioc.Default.GetService<ArticoloViewModel>();
        }
    }
}
