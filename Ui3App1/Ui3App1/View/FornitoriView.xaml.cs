using CiccioGest.Presentation.Ui3App1.ViewModel;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using Microsoft.UI.Xaml.Controls;

namespace CiccioGest.Presentation.Ui3App1.View
{
    public sealed partial class FornitoriView : Page
    {
        public FornitoriView()
        {
            InitializeComponent();
            DataContext = Ioc.Default.GetService<FornitoriViewModel>();
        }
    }
}
