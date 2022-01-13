using CiccioGest.Presentation.Ui3App1.ViewModel;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using Microsoft.UI.Xaml.Controls;

namespace CiccioGest.Presentation.Ui3App1.View
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
