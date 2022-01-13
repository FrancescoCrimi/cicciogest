using CiccioGest.Presentation.Ui3App1.ViewModel;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using Microsoft.UI.Xaml.Controls;

namespace CiccioGest.Presentation.Ui3App1.View
{
    public sealed partial class CategoriaView : Page
    {
        public CategoriaView()
        {
            InitializeComponent();
            DataContext = Ioc.Default.GetService<CategoriaViewModel>();
        }
    }
}
