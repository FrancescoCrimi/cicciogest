using CiccioGest.Presentation.Ui3App1.ViewModel;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using Microsoft.UI.Xaml.Controls;

namespace CiccioGest.Presentation.Ui3App1.View
{
    public sealed partial class FatturaView : Page
    {
        public FatturaView()
        {
            InitializeComponent();
            DataContext = Ioc.Default.GetService<FatturaViewModel>();
        }
    }
}
