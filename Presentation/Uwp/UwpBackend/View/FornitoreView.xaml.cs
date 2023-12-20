using CiccioGest.Presentation.UwpBackend.ViewModel;
using CommunityToolkit.Mvvm.DependencyInjection;
using Windows.UI.Xaml.Controls;

namespace CiccioGest.Presentation.UwpBackend.View
{
    public sealed partial class FornitoreView : Page
    {
        public FornitoreView()
        {
            InitializeComponent();
            DataContext = Ioc.Default.GetService<FornitoreViewModel>();
        }
    }
}
